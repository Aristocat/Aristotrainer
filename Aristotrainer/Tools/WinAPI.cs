using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Aristotrainer.Structs;
using System.Drawing;

namespace Aristotrainer.Tools
{
    class WinAPI
    {
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "SetWindowText", CharSet = CharSet.Ansi)]
        public static extern bool SetWindowText(IntPtr hWnd, String strNewWindowName);

        [DllImport("user32.dll", EntryPoint = "GetWindowText", CharSet = CharSet.Ansi)]
        public static extern bool GetWindowText(IntPtr hWnd, [OutAttribute()] StringBuilder strNewWindowName, Int32 maxCharCount);

        [DllImport("kernel32.dll")]
        public static extern int ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [In, Out] byte[] buffer, uint size, out IntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        public static extern int WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [In, Out] byte[] buffer, uint size, out IntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public static extern IntPtr ShowWindow(IntPtr hWnd, int nCmdShow);

        //[DllImport("user32.dll", SetLastError = true)]
        //public static extern bool GetWindowRect(IntPtr hWnd, ref RECT Rect);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int Width, int Height, bool Repaint);

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

        public const short SWP_NOMOVE = 0X2;
        public const short SWP_NOSIZE = 1;
        public const short SWP_NOZORDER = 0X4;
        public const int SWP_SHOWWINDOW = 0x0040;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_CLOSE = 0xF060;

        [DllImport("USER32.DLL")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("USER32.DLL")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("USER32.DLL")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll")]
        public static extern IntPtr GetMenu(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern int GetMenuItemCount(IntPtr hMenu);

        [DllImport("user32.dll")]
        public static extern bool DrawMenuBar(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool RemoveMenu(IntPtr hMenu, uint uPosition, uint uFlags);

        public static uint MF_BYPOSITION = 0x400;
        public static uint MF_REMOVE = 0x1000;
        public static int GWL_STYLE = -16;
        public static int WS_OVERLAPPED = 0x00000000;
        public static int WS_MAXIMIZEBOX = 0x00010000;
        public static int WS_THICKFRAME = 0x00040000;
        public static int WS_MINIMIZEBOX = 0x20000000;
        public static int WS_CHILD = 0x40000000;
        public static int WS_BORDER = 0x00800000;
        public static int WS_DLGFRAME = 0x00400000;
        public static int WS_CAPTION = WS_BORDER | WS_DLGFRAME;
        public static int WS_SYSMENU = 0x00080000;
        public static int WS_OVERLAPPEDWINDOW = WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX;

        const UInt32 WM_CLOSE = 0x0010;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern bool PostMessage(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern uint MapVirtualKey(uint uCode, uint uMapType);

        [DllImport("user32.dll")]
        public static extern bool PtInRect([In] ref RECT lprc, Point pt);
    }
}
