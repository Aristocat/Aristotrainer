using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Aristotrainer.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int X;
        public int Y;
        public int Width;
        public int Height;
    }
}
