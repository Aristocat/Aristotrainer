using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aristotrainer.Structs
{
    public class HackInformation
    {
        public IntPtr Address;

        public byte[] EnableBuffer;

        public byte[] DisableBuffer;

        public HackInformation(IntPtr Address,
            byte[] EnableBuffer, byte[] DisableBuffer)
        {
            this.Address = Address;
            this.EnableBuffer = EnableBuffer;
            this.DisableBuffer = DisableBuffer;
        }

        public HackInformation(int Address,
            string EnableBuffer, string DisableBuffer)
        {
            this.Address = (IntPtr)Address;
            this.EnableBuffer = Tools.HexTool.FromHex(
                EnableBuffer.Replace(" ", ""));
            this.DisableBuffer = Tools.HexTool.FromHex(
                DisableBuffer.Replace(" ", ""));
        }
    }
}
