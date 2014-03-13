using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aristotrainer.Tools
{
    class MemoryTool
    {
        public static byte[] ReadAddress(IntPtr pHandle, IntPtr address, byte bufferSize)
        {
            var buffer = new byte[bufferSize];
            IntPtr zero = IntPtr.Zero;
            WinAPI.ReadProcessMemory(pHandle, address, buffer, bufferSize, out zero);
            return buffer;
        }

        public static byte[] ReadPointer(IntPtr pHandle, IntPtr pointer, int offset, byte bufferSize)
        {
            var address = new byte[4];
            var buffer = new byte[bufferSize];
            IntPtr zero = IntPtr.Zero;
            WinAPI.ReadProcessMemory(pHandle, pointer, address, 4, out zero);
            pointer = (IntPtr)BitConverter.ToInt32(address, 0);
            WinAPI.ReadProcessMemory(pHandle,
                (IntPtr)((int)pointer + offset),
                buffer, bufferSize, out zero);
            return buffer;
        }

        public static byte[] ReadMultiPointer(IntPtr pHandle, IntPtr pointer, int[] offset, byte bufferSize)
        {
            var address = new byte[4];
            var buffer = new byte[bufferSize];
            IntPtr zero = IntPtr.Zero;
            WinAPI.ReadProcessMemory(pHandle, pointer, address, 4, out zero);
            pointer = (IntPtr)BitConverter.ToInt32(address, 0);
            for (int i = 0; i < offset.Length - 1; i++)
            {
                WinAPI.ReadProcessMemory(pHandle,
                    (IntPtr)((int)pointer + offset[i]),
                    address, 4, out zero);
                pointer = (IntPtr)BitConverter.ToInt32(address, 0);
            }
            WinAPI.ReadProcessMemory(pHandle,
                    (IntPtr)((int)pointer + offset[offset.Length - 1]),
                    buffer, bufferSize, out zero);
            return buffer;
        }

        public static string ReadStringPointer(IntPtr pHandle, int pointer, int offset, uint length)
        {
            var buffer = new byte[length];
            IntPtr zero = IntPtr.Zero;
            WinAPI.ReadProcessMemory(pHandle, new IntPtr(pointer), buffer, length, out zero);
            pointer = BitConverter.ToInt32(buffer, 0);
            WinAPI.ReadProcessMemory(pHandle, new IntPtr(pointer + offset), buffer, length, out zero);
            return Encoding.ASCII.GetString(HexTool.FromHex(
                BitConverter.ToString(buffer, 0).Replace("-", "")));
        }
    }
}
