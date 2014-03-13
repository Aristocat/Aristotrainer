using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aristotrainer.Structs
{
    public struct GeneralInformation
    {
        //ServerBase: 8B ? ? ? ? ? A1 ? ? ? ? 8D ? ? ? 51 8B CD 89 44 24 ? E8 ? ? ? ? 8B 70

        public IntPtr ProcessHandle { get; set; }

        public int WorldID { get; set; }
        //8B 8F ? ? ? ? 8B 00 51 50 6A ? 8B CE C7 44 24 ? ? ? ? ? E8

        public int Channel { get; set; }
        //WorldID + 4

        public double DamageCap { get; set; }
        //199,999/999,999/50,000,000

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Process Handle: {0}\r\n", ProcessHandle);
            sb.AppendFormat("World ID: {0}\r\n", WorldID);
            sb.AppendFormat("World Name: {0}\r\n", ((World)WorldID).ToString());
            sb.AppendFormat("Channel: {0}\r\n", (Channel + 1));
            sb.AppendFormat("Damage Cap: {0}\r\n", DamageCap);

            return sb.ToString();
        }
    }
}
