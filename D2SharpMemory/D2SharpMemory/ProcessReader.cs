using D2SharpMemory.Structs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2SharpMemory
{
    public class ProcessReader
    {
        PMR.ProcessMemoryReader reader;
        public ProcessReader(Process p)
        {
            this.reader = new PMR.ProcessMemoryReader(p);
            SharpMemory.mainProcess = p;
            Structs.Consts.Init();
        }

        public String getServerIP()
        {
            byte[] IP = reader.Read(IntPtr.Add(Consts.DllBase.D2Client, (int)Structs.Offsets.D2Client.ServerIp), 15);
            return Encoding.ASCII.GetString(IP);
        }

        public String getLastChatMsg()
        {
            //IntPtr addr = IntPtr.Add(IntPtr.Add(Consts.DllBase.D2Client, (int)0x1234D0), 0x2);
            IntPtr addr = IntPtr.Add(new IntPtr(0x6FBD34D2), 0x1);
            byte[] MSG = reader.Read(addr, 256);
            return Encoding.ASCII.GetString(MSG).Split('\0')[0];
        }

        public int getAreaId()
        {
            return Convert.ToInt32(reader.Read(IntPtr.Add(Consts.DllBase.D2Client, (int)Structs.Offsets.D2Client.AreaId), 1)[0]);
        }

        public String getGameName()
        {
            byte[] bGameName = reader.Read(IntPtr.Add(ptrGameInfo(), 0x1B), 0x18);
            return Encoding.ASCII.GetString(bGameName);
        }

        public String getAccName()
        {
            byte[] szAccountName = reader.Read(IntPtr.Add(ptrGameInfo(), 0x89), 0x30);
            return Encoding.ASCII.GetString(szAccountName);
        }

        public String getCharName()
        {
            byte[] szCharName = reader.Read(IntPtr.Add(ptrGameInfo(), 0xB9), 0x18);
            return Encoding.ASCII.GetString(szCharName);
        }

        public String getRealmName()
        {

            byte[] szRealmName = reader.Read(IntPtr.Add(ptrGameInfo(), 0xD1), 0x18);
            return Encoding.ASCII.GetString(szRealmName);
        }

        private IntPtr ptrGameInfo()
        {
            // VARPTR(D2CLIENT, GameInfo, GameStructInfo*, 0x11B980);

            /*
                struct GameStructInfo {
                BYTE _1[0x1B];                    //0x00
                char szGameName[0x18];            //0x1B
                char szGameServerIp[0x56];        //0x33
                char szAccountName[0x30];        //0x89
                char szCharName[0x18];            //0xB9
                char szRealmName[0x18];            //0xD1
                BYTE _2[0x158];                    //0xE9
                char szGamePassword[0x18];        //0x241
            };
            */
            IntPtr gameInfoStructPtr = IntPtr.Add(Consts.DllBase.D2Client, 0x11B980);
            byte[] nextPtr = reader.Read(gameInfoStructPtr, 4);
            String fixAddr = (nextPtr[3].ToString("X") + nextPtr[2].ToString("X") + nextPtr[1].ToString("X") + nextPtr[0].ToString("X"));

            Int32 gameInfoPtr = Convert.ToInt32(fixAddr, 16);

            return new IntPtr(gameInfoPtr);
        }

        public bool inGame()
        {
            int aux = reader.Read(IntPtr.Add(Structs.Consts.DllBase.D2Client, 0x11BBFD), 1)[0];
            if (aux > 0)
                return true;

            return false;
        }

    }
}
