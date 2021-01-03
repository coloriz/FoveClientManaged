using System;
using System.Runtime.InteropServices;

namespace Fove.Managed
{
	public class FVRHeadset
    {
		private IntPtr _headsetPtr;

		public FVRHeadset(EFVR_ClientCapabilities capabilities = (EFVR_ClientCapabilities)7)
		{
			Console.WriteLine("Creating a Fove HMD interface.");
			this._headsetPtr = FVRHeadset.CGetFVRHeadset();
			FVRHeadset.FVR_Headset_Initialise(this._headsetPtr, capabilities);
		}

		~FVRHeadset()
		{
			Console.WriteLine("Managed FVRHeadset is actually being destructed");
			FVRHeadset.FVR_Headset_Destroy(this._headsetPtr);
			this._headsetPtr = IntPtr.Zero;
		}

		public EFVR_ErrorCode IsHardwareConnected(out bool outBool)
		{
			outBool = false;
			return FVRHeadset.FVR_Headset_IsHardwareConnected(this._headsetPtr, ref outBool);
		}

		public EFVR_ErrorCode IsHardwareReady(out bool outBool)
		{
			outBool = false;
			return FVRHeadset.FVR_Headset_IsHardwareReady(this._headsetPtr, ref outBool);
		}

		public EFVR_ErrorCode CheckSoftwareVersions()
		{
			return FVRHeadset.FVR_Headset_CheckSoftwareVersions(this._headsetPtr);
		}

		public EFVR_ErrorCode GetGazeVector(EFVR_Eye eye, out SFVR_GazeVector outGazeVector)
		{
			outGazeVector = default(SFVR_GazeVector);
			return FVRHeadset.FVR_Headset_GetGazeVector(this._headsetPtr, eye, ref outGazeVector);
		}

		public EFVR_ErrorCode GetGazeConvergence(out SFVR_GazeConvergenceData ouConvergenceData)
		{
			ouConvergenceData = default(SFVR_GazeConvergenceData);
			return FVRHeadset.FVR_Headset_GetGazeConvergence(this._headsetPtr, ref ouConvergenceData);
		}

		public EFVR_ErrorCode CheckEyesClosed(out EFVR_Eye outEye)
		{
			outEye = EFVR_Eye.Neither;
			return FVRHeadset.FVR_Headset_CheckEyesClosed(this._headsetPtr, ref outEye);
		}

		public EFVR_ErrorCode CheckEyesTracked(out EFVR_Eye outEye)
		{
			outEye = EFVR_Eye.Neither;
			return FVRHeadset.FVR_Headset_CheckEyesTracked(this._headsetPtr, ref outEye);
		}

		public EFVR_ErrorCode IsEyeTrackingEnabled(out bool outBool)
		{
			outBool = false;
			return FVRHeadset.FVR_Headset_IsEyeTrackingEnabled(this._headsetPtr, ref outBool);
		}

		public EFVR_ErrorCode IsEyeTrackingCalibrated(out bool outBool)
		{
			outBool = false;
			return FVRHeadset.FVR_Headset_IsEyeTrackingCalibrated(this._headsetPtr, ref outBool);
		}

		public EFVR_ErrorCode IsEyeTrackingCalibrating(out bool outBool)
		{
			outBool = false;
			return FVRHeadset.FVR_Headset_IsEyeTrackingCalibrating(this._headsetPtr, ref outBool);
		}

		public EFVR_ErrorCode IsEyeTrackingReady(out bool outBool)
		{
			outBool = false;
			return FVRHeadset.FVR_Headset_IsEyeTrackingReady(this._headsetPtr, ref outBool);
		}

		public EFVR_ErrorCode EnsureEyeTrackingCalibration()
		{
			return FVRHeadset.FVR_Headset_EnsureEyeTrackingCalibration(this._headsetPtr);
		}

		public EFVR_ErrorCode IsMotionReady(out bool outBool)
		{
			outBool = false;
			return FVRHeadset.FVR_Headset_IsMotionReady(this._headsetPtr, ref outBool);
		}

		public EFVR_ErrorCode TareOrientationSensor()
		{
			return FVRHeadset.FVR_Headset_TareOrientationSensor(this._headsetPtr);
		}

		public EFVR_ErrorCode IsPositionReady(out bool outBool)
		{
			outBool = false;
			return FVRHeadset.FVR_Headset_IsPositionReady(this._headsetPtr, ref outBool);
		}

		public EFVR_ErrorCode TarePositionSensors()
		{
			return FVRHeadset.FVR_Headset_TarePositionSensors(this._headsetPtr);
		}

		public EFVR_ErrorCode GetHMDPose(out SFVR_Pose outPose)
		{
			outPose = default(SFVR_Pose);
			return FVRHeadset.FVR_Headset_GetHMDPose(this._headsetPtr, ref outPose);
		}

		public EFVR_ErrorCode GetPoseByIndex(int id, out SFVR_Pose outPose)
		{
			outPose = default(SFVR_Pose);
			return FVRHeadset.FVR_Headset_GetPoseByIndex(this._headsetPtr, id, ref outPose);
		}

		public EFVR_ErrorCode GetProjectionMatricesLH(float zNear, float zFar, out SFVR_Matrix44 outLeftMx, out SFVR_Matrix44 outRightMx)
		{
			outLeftMx = default(SFVR_Matrix44);
			outRightMx = default(SFVR_Matrix44);
			return FVRHeadset.FVR_Headset_GetProjectionMatricesLH(this._headsetPtr, zNear, zFar, ref outLeftMx, ref outRightMx);
		}

		public EFVR_ErrorCode GetProjectionMatricesRH(float zNear, float zFar, out SFVR_Matrix44 outLeftMx, out SFVR_Matrix44 outRightMx)
		{
			outLeftMx = default(SFVR_Matrix44);
			outRightMx = default(SFVR_Matrix44);
			return FVRHeadset.FVR_Headset_GetProjectionMatricesRH(this._headsetPtr, zNear, zFar, ref outLeftMx, ref outRightMx);
		}

		public EFVR_ErrorCode GetRawProjectionValues(out SFVR_ProjectionParams outLeftParams, out SFVR_ProjectionParams outRightParams)
		{
			outLeftParams = default(SFVR_ProjectionParams);
			outRightParams = default(SFVR_ProjectionParams);
			return FVRHeadset.FVR_Headset_GetRawProjectionValues(this._headsetPtr, ref outLeftParams, ref outRightParams);
		}

		public EFVR_ErrorCode GetEyeToHeadMatrices(out SFVR_Matrix44 outLeftMx, out SFVR_Matrix44 outRightMx)
		{
			outLeftMx = default(SFVR_Matrix44);
			outRightMx = default(SFVR_Matrix44);
			return FVRHeadset.FVR_Headset_GetEyeToHeadMatrices(this._headsetPtr, ref outLeftMx, ref outRightMx);
		}

		public EFVR_ErrorCode ManualDriftCorrection3D(SFVR_Vec3 vec)
		{
			return FVRHeadset.FVR_Headset_ManualDriftCorrection3D(this._headsetPtr, vec);
		}

		public EFVR_ErrorCode GetSoftwareVersions(out SFVR_Versions outVersions)
		{
			outVersions = default(SFVR_Versions);
			return FVRHeadset.FVR_Headset_GetSoftwareVersions(this._headsetPtr, ref outVersions);
		}

		public EFVR_ErrorCode GetIOD(out float iod)
		{
			float num = 0.06f;
			EFVR_ErrorCode result = FVRHeadset.FVR_Headset_GetIOD(this._headsetPtr, ref num);
			iod = num;
			return result;
		}

		[DllImport("FoveClient.dll")]
		private static extern IntPtr CGetFVRHeadset();

		[DllImport("FoveClient.dll")]
		[return: MarshalAs(UnmanagedType.I4)]
		private static extern EFVR_ErrorCode FVR_Headset_Initialise(IntPtr headset, EFVR_ClientCapabilities capabilities);

		[DllImport("FoveClient.dll")]
		[return: MarshalAs(UnmanagedType.I4)]
		private static extern EFVR_ErrorCode FVR_Headset_IsHardwareConnected(IntPtr headset, ref bool result);

		[DllImport("FoveClient.dll")]
		[return: MarshalAs(UnmanagedType.I4)]
		private static extern EFVR_ErrorCode FVR_Headset_IsHardwareReady(IntPtr headset, ref bool result);

		[DllImport("FoveClient.dll")]
		private static extern EFVR_ErrorCode FVR_Headset_CheckSoftwareVersions(IntPtr headset);

		[DllImport("FoveClient.dll")]
		private static extern EFVR_ErrorCode FVR_Headset_GetSoftwareVersions(IntPtr headset, [In] [Out] ref SFVR_Versions outVersions);

		[DllImport("FoveClient.dll")]
		private static extern EFVR_ErrorCode FVR_Headset_GetGazeVector(IntPtr headset, EFVR_Eye eye, [In] [Out] ref SFVR_GazeVector outGaze);

		[DllImport("FoveClient.dll")]
		private static extern EFVR_ErrorCode FVR_Headset_GetGazeConvergence(IntPtr headset, [In] [Out] ref SFVR_GazeConvergenceData outData);

		[DllImport("FoveClient.dll")]
		private static extern EFVR_ErrorCode FVR_Headset_CheckEyesClosed(IntPtr headset, ref EFVR_Eye eyes);

		[DllImport("FoveClient.dll")]
		private static extern EFVR_ErrorCode FVR_Headset_CheckEyesTracked(IntPtr headset, ref EFVR_Eye eyes);

		[DllImport("FoveClient.dll")]
		[return: MarshalAs(UnmanagedType.I4)]
		private static extern EFVR_ErrorCode FVR_Headset_IsEyeTrackingEnabled(IntPtr headset, ref bool result);

		[DllImport("FoveClient.dll")]
		[return: MarshalAs(UnmanagedType.I4)]
		private static extern EFVR_ErrorCode FVR_Headset_IsEyeTrackingCalibrated(IntPtr headset, ref bool result);

		[DllImport("FoveClient.dll")]
		[return: MarshalAs(UnmanagedType.I4)]
		private static extern EFVR_ErrorCode FVR_Headset_IsEyeTrackingCalibrating(IntPtr headset, ref bool result);

		[DllImport("FoveClient.dll")]
		[return: MarshalAs(UnmanagedType.I4)]
		private static extern EFVR_ErrorCode FVR_Headset_IsEyeTrackingReady(IntPtr headset, ref bool result);

		[DllImport("FoveClient.dll")]
		private static extern EFVR_ErrorCode FVR_Headset_EnsureEyeTrackingCalibration(IntPtr headset);

		[DllImport("FoveClient.dll")]
		[return: MarshalAs(UnmanagedType.I4)]
		private static extern EFVR_ErrorCode FVR_Headset_IsMotionReady(IntPtr headset, ref bool result);

		[DllImport("FoveClient.dll")]
		[return: MarshalAs(UnmanagedType.I4)]
		private static extern EFVR_ErrorCode FVR_Headset_TareOrientationSensor(IntPtr headset);

		[DllImport("FoveClient.dll")]
		[return: MarshalAs(UnmanagedType.I4)]
		private static extern EFVR_ErrorCode FVR_Headset_IsPositionReady(IntPtr headset, ref bool result);

		[DllImport("FoveClient.dll")]
		[return: MarshalAs(UnmanagedType.I4)]
		private static extern EFVR_ErrorCode FVR_Headset_TarePositionSensors(IntPtr headset);

		[DllImport("FoveClient.dll")]
		private static extern EFVR_ErrorCode FVR_Headset_GetHMDPose(IntPtr headset, ref SFVR_Pose pose);

		[DllImport("FoveClient.dll")]
		private static extern EFVR_ErrorCode FVR_Headset_GetPoseByIndex(IntPtr headset, int id, [In] [Out] ref SFVR_Pose pose);

		[DllImport("FoveClient.dll")]
		private static extern EFVR_ErrorCode FVR_Headset_GetProjectionMatricesLH(IntPtr headset, float zNear, float zFar, [In] [Out] ref SFVR_Matrix44 lmat, [In] [Out] ref SFVR_Matrix44 rmat);

		[DllImport("FoveClient.dll")]
		private static extern EFVR_ErrorCode FVR_Headset_GetProjectionMatricesRH(IntPtr headset, float zNear, float zFar, [In] [Out] ref SFVR_Matrix44 lmat, [In] [Out] ref SFVR_Matrix44 rmat);

		[DllImport("FoveClient.dll")]
		private static extern EFVR_ErrorCode FVR_Headset_GetRawProjectionValues(IntPtr headset, [In] [Out] ref SFVR_ProjectionParams outLeft, [In] [Out] ref SFVR_ProjectionParams outRight);

		[DllImport("FoveClient.dll")]
		private static extern EFVR_ErrorCode FVR_Headset_GetEyeToHeadMatrices(IntPtr headset, [In] [Out] ref SFVR_Matrix44 outLeftMx, [In] [Out] ref SFVR_Matrix44 outRightMx);

		[DllImport("FoveClient.dll")]
		private static extern void FVR_Headset_Destroy(IntPtr headset);

		[DllImport("FoveClient.dll")]
		private static extern EFVR_ErrorCode FVR_Headset_TriggerOnePointCalibration(IntPtr headset);

		[DllImport("FoveClient.dll")]
		private static extern EFVR_ErrorCode FVR_Headset_ManualDriftCorrection3D(IntPtr headset, SFVR_Vec3 vec);

		[DllImport("FoveClient.dll")]
		private static extern EFVR_ErrorCode FVR_Headset_GetIOD(IntPtr headset, ref float outIOD);
	}
}
