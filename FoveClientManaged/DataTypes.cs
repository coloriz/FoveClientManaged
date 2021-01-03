using System;
using System.Runtime.InteropServices;

namespace Fove.Managed
{
    #region FoveEnum

    public enum EFVR_AlphaMode
    {
        Auto,
        One,
        Sample
    }

    public enum EFVR_ClientCapabilities
    {
        Gaze = 1,
        Orientation = 2,
        Position = 4
    }

    public enum EFVR_ClientType
    {
        Base,
        Overlay = 0x10000,
        Diagnostic = 0x20000
    }

    public enum EFVR_ColorSpace
    {
        Auto,
        Linear,
        GammaCorrected
    }

    public enum EFVR_ErrorCode
    {
        None,
        Connection_General,
        Connect_NotConnected = 7,
        Connect_ServerUnreachable = 2,
        Connect_RegisterFailed,
        Connect_DeregisterFailed = 8,
        Connect_RuntimeVersionTooOld = 4,
        Connect_HeartbeatNoReply,
        Connect_ClientVersionTooOld,
        API_General = 100,
        API_InitNotCalled,
        API_InitAlreadyCalled,
        API_InvalidArgument,
        API_NullInPointer = 110,
        API_InvalidEnumValue,
        API_NullOutPointersOnly = 120,
        API_OverlappingOutPointers,
        Data_General = 1000,
        Data_RegisteredWrongVersion,
        Data_UnreadableNotFound,
        Data_NoUpdate,
        Data_Uncalibrated,
        Data_MissingIPCData,
        Hardware_General = 2000,
        Hardware_CoreFault,
        Hardware_CameraFault,
        Hardware_IMUFault,
        Hardware_ScreenFault,
        Hardware_SecurityFault,
        Hardware_Disconnected,
        Hardware_WrongFirmwareVersion,
        Server_General = 3000,
        Server_HardwareInterfaceInvalid,
        Server_HeartbeatNotRegistered,
        Server_DataCreationError,
        Server_ModuleError_ET,
        Code_NotImplementedYet = 4000,
        Code_FunctionDeprecated,
        Position_NoObjectsInView = 5000,
        Position_NoDlibRegressor,
        Position_NoCascadeClassifier,
        Position_NoModel,
        Position_NoImages,
        Position_InvalidFile,
        Position_NoCamParaSet,
        Position_CantUpdateOptical,
        Position_ObjectNotTracked,
        Position_NoCameraFound,
        Eye_Left_NoDlibRegressor = 6000,
        Eye_Right_NoDlibRegressor,
        Eye_CalibrationFailed,
        Eye_LoadCalibrationFailed,
        User_General = 7000,
        User_ErrorLoadingProfile,
        Compositor_UnableToCreateDeviceAndContext = 8000,
        Compositor_UnableToUseTexture,
        Compositor_DeviceMismatch,
        Compositor_IncompatibleCompositorVersion,
        Compositor_UnableToFindRuntime,
        Compositor_DisconnectedFromRuntime = 8006,
        Compositor_ErrorCreatingTexturesOnDevice = 8008,
        Compositor_NoEyeSpecifiedForSubmit,
        UnknownError = 9000
    }

    public enum EFVR_Eye
    {
        Neither,
        Left,
        Right,
        Both
    }

    public enum EFVR_GraphicsAPI
    {
        DirectX,
        OpenGL,
        Vulkan
    }

    #endregion

    #region FoveStruct

    public struct SFVR_ClientInfo
    {
        public EFVR_ClientType type;

        public EFVR_GraphicsAPI api;

        [MarshalAs(UnmanagedType.I1)]
        public bool disableTimeWarp;

        public EFVR_AlphaMode alphaMode;

        [MarshalAs(UnmanagedType.I1)]
        public bool disableFading;

        [MarshalAs(UnmanagedType.I1)]
        public bool disableDistortion;
    }

    public struct SFVR_CompositorLayer
    {
        public int layerId;

        public SFVR_Vec2i idealResolutionPerEye;
    }

    public struct SFVR_CompositorLayerCreateInfo
    {
        public EFVR_ClientType type;

        [MarshalAs(UnmanagedType.I1)]
        public bool disableTimewarp;

        public EFVR_AlphaMode alphaMode;

        [MarshalAs(UnmanagedType.I1)]
        public bool disableFading;

        [MarshalAs(UnmanagedType.I1)]
        public bool disableDistortion;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct SFVR_CompositorLayerEyeSubmitInfo
    {
        [FieldOffset(0)]
        public SFVR_CompositorTexture texInfo;

        [FieldOffset(72)]
        public SFVR_TextureBounds bounds;
    }

    public struct SFVR_CompositorLayerSubmitInfo
    {
        public int layerId;

        public SFVR_Pose pose;

        public SFVR_CompositorLayerEyeSubmitInfo left;

        public SFVR_CompositorLayerEyeSubmitInfo right;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct SFVR_CompositorTexture
    {
        [FieldOffset(0)]
        public IntPtr pTexture;

        [FieldOffset(64)]
        public EFVR_ColorSpace colorSpace;
    }

    public struct SFVR_GazeConvergenceData
    {
        public EFVR_ErrorCode error;

        public ulong id;

        public ulong timestamp;

        public SFVR_Ray ray;

        public float distance;

        public float accuracy;
    }

    public struct SFVR_GazeVector
    {
        public EFVR_ErrorCode error;

        public ulong id;

        public ulong timestamp;

        public SFVR_Vec3 vector;
    }

    public struct SFVR_Matrix34
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public float[] mat;
    }

    public struct SFVR_Matrix44
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public float[] mat;
    }

    public struct SFVR_Pose
    {
        public EFVR_ErrorCode error;

        public ulong id;

        public ulong timestamp;

        public SFVR_Quaternion orientation;

        public SFVR_Vec3 angularVelocity;

        public SFVR_Vec3 angularAcceleration;

        public SFVR_Vec3 position;

        public SFVR_Vec3 velocity;

        public SFVR_Vec3 acceleration;
    }

    public struct SFVR_ProjectionParams
    {
        public float left;

        public float right;

        public float top;

        public float bottom;
    }

    public struct SFVR_Ray
    {
        public SFVR_Vec3 origin;

        public SFVR_Vec3 direction;
    }

    public struct SFVR_TextureBounds
    {
        public float left;

        public float top;

        public float right;

        public float bottom;
    }

    public struct SFVR_Vec2
    {
        public float x;

        public float y;

        public SFVR_Vec2(float ix, float iy)
        {
            this.x = ix;
            this.y = iy;
        }
    }

    public struct SFVR_Vec2i
    {
        public int x;

        public int y;

        private SFVR_Vec2i(int ix, int iy)
        {
            this.x = ix;
            this.y = iy;
        }
    }

    public struct SFVR_Versions
    {
        public int clientMajor;

        public int clientMinor;

        public int clientBuild;

        public int clientProtocol;

        public int runtimeMajor;

        public int runtimeMinor;

        public int runtimeBuild;

        public int firmware;

        public int maxFirmware;

        public int minFirmware;

        public bool tooOldHeadsetConnected;
    }

    #endregion
}
