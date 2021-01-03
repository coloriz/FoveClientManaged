using System;
using System.Runtime.InteropServices;

namespace Fove.Managed
{
	public class FVRCompositor
	{
		private IntPtr _compositorPtr;

		private readonly int _compositorId;

		private static int _staticIdIncrement;

		public FVRCompositor()
		{
			this._compositorId = FVRCompositor._staticIdIncrement++;
			this._compositorPtr = FVRCompositor.CGetFVRCompositor();
		}

		~FVRCompositor()
		{
			Console.WriteLine("Compositor interface being destroyed." + this._compositorId.ToString());
			if (this._compositorPtr != IntPtr.Zero)
			{
				FVRCompositor.FVR_Compositor_Shutdown(this._compositorPtr);
			}
		}

		public void DisconnectImmediately()
		{
			Console.WriteLine("Compositor disconnect requested." + this._compositorId.ToString());
			if (this._compositorPtr != IntPtr.Zero)
			{
				this._compositorPtr = IntPtr.Zero;
				FVRCompositor.FVR_Compositor_Shutdown(this._compositorPtr);
			}
		}

		public EFVR_ErrorCode CreateLayer(SFVR_CompositorLayerCreateInfo layerInfo, out SFVR_CompositorLayer layer)
		{
			layer = default(SFVR_CompositorLayer);
			if (this._compositorPtr != IntPtr.Zero)
			{
				return FVRCompositor.FVR_Compositor_CreateLayer(this._compositorPtr, ref layerInfo, ref layer);
			}
			return EFVR_ErrorCode.API_General;
		}

		public EFVR_ErrorCode Submit(ref SFVR_CompositorLayerSubmitInfo layer)
		{
			if (this._compositorPtr != IntPtr.Zero)
			{
				return FVRCompositor.FVR_Compositor_Submit(this._compositorPtr, ref layer);
			}
			return EFVR_ErrorCode.API_General;
		}

		public SFVR_Pose WaitForRenderPose()
		{
			SFVR_Pose result = default(SFVR_Pose);
			if (this._compositorPtr != IntPtr.Zero)
			{
				EFVR_ErrorCode eFVR_ErrorCode = FVRCompositor.FVR_Compositor_WaitForRenderPose(this._compositorPtr, ref result);
				if (eFVR_ErrorCode != 0)
				{
					Console.WriteLine("[FOVE] WaitForRenderPose exited with error code " + eFVR_ErrorCode);
				}
			}
			return result;
		}

		public SFVR_Pose GetLastRenderPose()
		{
			if (this._compositorPtr != IntPtr.Zero)
			{
				SFVR_Pose result = default(SFVR_Pose);
				EFVR_ErrorCode eFVR_ErrorCode = FVRCompositor.FVR_Compositor_GetLastRenderPose(this._compositorPtr, ref result);
				if (eFVR_ErrorCode == EFVR_ErrorCode.None)
				{
					return result;
				}
				Console.WriteLine("GetLastRenderPose returned error: " + eFVR_ErrorCode);
			}
			return default(SFVR_Pose);
		}

		public bool IsReady()
		{
			if (this._compositorPtr != IntPtr.Zero)
			{
				bool result = false;
				EFVR_ErrorCode eFVR_ErrorCode = FVRCompositor.FVR_Compositor_IsReady(this._compositorPtr, ref result);
				if (eFVR_ErrorCode == EFVR_ErrorCode.None)
				{
					return result;
				}
				Console.WriteLine("IsReady returned error: " + eFVR_ErrorCode);
			}
			return false;
		}

		[DllImport("FoveClient.dll")]
		private static extern IntPtr CGetFVRCompositor();

		[DllImport("FoveClient.dll")]
		private static extern EFVR_ErrorCode FVR_Compositor_CreateLayer(IntPtr compositor, ref SFVR_CompositorLayerCreateInfo layerInfo, ref SFVR_CompositorLayer outLayer);

		[DllImport("FoveClient.dll")]
		private static extern EFVR_ErrorCode FVR_Compositor_Submit(IntPtr compositor, ref SFVR_CompositorLayerSubmitInfo layer);

		[DllImport("FoveClient.dll")]
		private static extern EFVR_ErrorCode FVR_Compositor_WaitForRenderPose(IntPtr compositor, ref SFVR_Pose pose);

		[DllImport("FoveClient.dll")]
		private static extern EFVR_ErrorCode FVR_Compositor_GetLastRenderPose(IntPtr compositor, ref SFVR_Pose pose);

		[DllImport("FoveClient.dll")]
		private static extern EFVR_ErrorCode FVR_Compositor_IsReady(IntPtr compositor, ref bool b);

		[DllImport("FoveClient.dll")]
		private static extern void FVR_Compositor_Shutdown(IntPtr compositor);
	}
}
