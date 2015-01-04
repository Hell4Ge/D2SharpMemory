using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2SharpMemory.Structs.Offsets
{
    public static class D2Client
    {
        public static IntPtr AreaId = new IntPtr(0x1234B0);
        public static IntPtr ServerIp = new IntPtr(0xF4320);
        public static IntPtr GameName = new IntPtr(0x11B980);
    }
}
