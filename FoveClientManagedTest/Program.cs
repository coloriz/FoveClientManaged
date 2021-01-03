using System;
using System.Threading;
using System.Diagnostics;
using Fove.Managed;

namespace FoveClientManagedTest
{
    class Program
    {
        public static void Main(string[] args)
        {
            FVRHeadset headset = new FVRHeadset(EFVR_ClientCapabilities.Gaze | EFVR_ClientCapabilities.Orientation);
            Console.WriteLine("Headset : " + headset);

            // Check the software versions and spit out an error if the client is newer than the runtime
            EFVR_ErrorCode softwareVersionOkay = headset.CheckSoftwareVersions();
            if (softwareVersionOkay != EFVR_ErrorCode.None)
            {
                Console.WriteLine("Fove Interface failed software version check");

                if (softwareVersionOkay == EFVR_ErrorCode.Connect_ClientVersionTooOld)
                {
                    headset.GetSoftwareVersions(out SFVR_Versions versions);
                    string client = $"{ versions.clientMajor }.{ versions.clientMinor }.{ versions.clientBuild }";
                    string service = $"{ versions.runtimeMajor }.{ versions.runtimeMinor }.{ versions.runtimeBuild }";
                    Console.WriteLine($"Please update your FOVE runtime: (client - { client } | runtime - { service })");
                }
            }

            headset.IsHardwareConnected(out bool isConnected);
            Debug.Assert(isConnected, "Hardware is not connected!");

            headset.IsHardwareReady(out bool isReady);
            Debug.Assert(isReady, "Hardware capabilities are not ready!");

            while (true)
            {
                headset.GetHMDPose(out SFVR_Pose pose);
                SFVR_Quaternion hmdRotation = pose.orientation;
                SFVR_Vec3 euler = hmdRotation.EulerAngles;
                Console.WriteLine(euler);
                Thread.Sleep(100);
            }
        }
    }
}
