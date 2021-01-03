using System;
using System.Diagnostics;
using Fove.Managed;
using OpenCvSharp;

namespace FoveOrientation
{
	class Program
	{
		static void GetCoord(SFVR_Vec3 vec, int width, int height, out int x_coord, out int y_coord)
		{
			float longitude = (float)Math.Atan2(vec.x, vec.z) * 180f / (float)Math.PI;
			float latitude = (float)Math.Asin(-vec.y) * 180f / (float)Math.PI;

			x_coord = (int)((longitude / 360f + 0.5f) * width);
			y_coord = (int)((latitude / 180f + 0.5f) * height);
		}

		static void Main(string[] args)
		{
			FVRHeadset headset = new FVRHeadset(EFVR_ClientCapabilities.Gaze | EFVR_ClientCapabilities.Orientation);

			headset.IsHardwareConnected(out bool isConnected);
			Debug.Assert(isConnected, "Hardware is not connected!");

			headset.IsHardwareReady(out bool isReady);
			Debug.Assert(isReady, "Hardware capabilities are not ready!");

			VideoCapture cap = new VideoCapture(args[1]);
			if (!cap.IsOpened())
			{
				throw new Exception("Video is not valid!");
			}

			int video_width = (int)cap.Get(CaptureProperty.FrameWidth);
			int video_height = (int)cap.Get(CaptureProperty.FrameHeight);

			Cv2.NamedWindow("coord", WindowMode.Normal);
			Cv2.ResizeWindow("coord", 1600, 900);

			Mat frame = new Mat();
			while (true)
			{
				cap.Read(frame);
				if (frame.Empty())
				{
					cap.Set(CaptureProperty.PosFrames, 0);
					continue;
				}

				headset.GetHMDPose(out SFVR_Pose pose);
				SFVR_Quaternion hmdRotation = new SFVR_Quaternion(pose.orientation.x, pose.orientation.y, pose.orientation.z, pose.orientation.w);

				SFVR_Vec3 result = hmdRotation * SFVR_Vec3.Forward;

				GetCoord(result, video_width, video_height, out int x, out int y);

				Cv2.Circle(frame, new Point(x, y), 50, new Scalar(0, 0, 255), -1);

				Cv2.ImShow("coord", frame);
				if ((Cv2.WaitKey(30) & 0xFF) == 'q')
					break;
			}

			cap.Release();
			Cv2.DestroyAllWindows();
		}
	}
}
