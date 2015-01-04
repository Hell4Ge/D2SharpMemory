using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2SharpMemory
{
    public class SharpMemory
    {
        public static Process mainProcess;
        public SharpMemory(Process p)
        {
            mainProcess = p;
            Structs.Consts.Init();
        }
    }
}
