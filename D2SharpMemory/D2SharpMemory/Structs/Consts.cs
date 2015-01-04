using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2SharpMemory.Structs
{
    public static class Consts
    {
        public static void Init()
        {
            DllBase.D2Client        = getModuleAddr(D2SharpMemory.SharpMemory.mainProcess, "D2Client.dll");
            DllBase.Storm           = getModuleAddr(D2SharpMemory.SharpMemory.mainProcess, "Storm.dll");
            DllBase.Fog             = getModuleAddr(D2SharpMemory.SharpMemory.mainProcess, "Fog.dll");
            DllBase.D2Win           = getModuleAddr(D2SharpMemory.SharpMemory.mainProcess, "D2Win.dll");
            DllBase.D2Sound         = getModuleAddr(D2SharpMemory.SharpMemory.mainProcess, "D2Sound.dll");
            DllBase.D2Gfx           = getModuleAddr(D2SharpMemory.SharpMemory.mainProcess, "D2Gfx.dll");
            DllBase.D2CMP           = getModuleAddr(D2SharpMemory.SharpMemory.mainProcess, "D2CMP.dll");
            DllBase.D2Lang          = getModuleAddr(D2SharpMemory.SharpMemory.mainProcess, "D2Lang.dll");
            DllBase.D2MCPClient     = getModuleAddr(D2SharpMemory.SharpMemory.mainProcess, "D2MCPClient.dll");
            DllBase.D2Direct3D      = getModuleAddr(D2SharpMemory.SharpMemory.mainProcess, "D2Direct3D.dll");
            DllBase.D2Launch        = getModuleAddr(D2SharpMemory.SharpMemory.mainProcess, "D2Launch.dll");
            DllBase.D2Net           = getModuleAddr(D2SharpMemory.SharpMemory.mainProcess, "D2Net.dll");
            DllBase.Bnclient        = getModuleAddr(D2SharpMemory.SharpMemory.mainProcess, "Bnclient.dll");
            DllBase.D2Multi         = getModuleAddr(D2SharpMemory.SharpMemory.mainProcess, "D2Multi.dll");
            DllBase.D2Common        = getModuleAddr(D2SharpMemory.SharpMemory.mainProcess, "D2Common.dll");
            DllBase.D2Game          = getModuleAddr(D2SharpMemory.SharpMemory.mainProcess, "D2Game .dll");
        }
        private static IntPtr getModuleAddr(Process p, String mName)
        {
            foreach (ProcessModule pm in p.Modules)
            {

                if (pm.ModuleName.Equals(mName))
                    return pm.BaseAddress;
            }

            return IntPtr.Zero;
        }
        public struct DllBase
        {
            public static IntPtr D2Client;
            public static IntPtr Storm;
            public static IntPtr Fog;
            public static IntPtr D2Win;
            public static IntPtr D2Sound;
            public static IntPtr D2Gfx;
            public static IntPtr D2CMP;
            public static IntPtr D2Lang;
            public static IntPtr D2MCPClient;
            public static IntPtr D2Direct3D;
            public static IntPtr D2Launch;
            public static IntPtr D2Net;
            public static IntPtr Bnclient;
            public static IntPtr D2Multi;
            public static IntPtr D2Common;
            public static IntPtr D2Game;
        }

        public struct Memory
        {
            public const int PROCESS_WM_READ = 0x0010;
        }
    }
}
