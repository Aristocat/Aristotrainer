﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aristotrainer.Tools
{
    public class Keyboard
    {
        private const uint WM_KEYDOWN = (uint)0x100;
        private const uint WM_CHAR = (uint)0x102;
        private const uint WM_KEYUP = (uint)0x101;
        private const uint WM_GETTEXT = (uint)0x000D;

        public enum KeyEvents : int
        {
            KEYEVENTF_KEYUP = 0x0002,
        };

        public enum VKeysScan : int
        {
            VK_BACK = 0x000E0001,   //BACKSPACE key
            VK_TAB = 0x000F0001,   //TAB key
            //VK_CLEAR = 0x00000001,   //CLEAR key
            VK_RETURN = 0x001C0001,   //ENTER key
            VK_SHIFT = 0x002A0001,   //SHIFT key
            VK_CONTROL = 0x001D0001,   //CTRL key
            VK_MENU = 0x00380001,   //ALT key
            //VK_PAUSE = 0x00000001,   //PAUSE key
            VK_CAPITAL = 0x003A0001,   //CAPS LOCK key
            VK_ESCAPE = 0x00010001,   //ESC key
            VK_SPACE = 0x00390001,   //SPACEBAR
            VK_PRIOR = 0x00490001,   //PAGE UP key
            VK_NEXT = 0x00510001,   //PAGE DOWN key
            VK_END = 0x004F0001,   //END key
            VK_HOME = 0x00470001,   //HOME key
            VK_LEFT = 0x004B0001,   //LEFT ARROW key
            VK_UP = 0x00480001,   //UP ARROW key
            VK_RIGHT = 0x004D0001,   //RIGHT ARROW key
            VK_DOWN = 0x00500001,   //DOWN ARROW key
            //VK_SELECT = 0x000001,   //SELECT key
            //VK_PRINT = 0x000001,   //PRINT key
            //VK_EXECUTE = 0x000001,   //EXECUTE key
            VK_SNAPSHOT = 0x00370001,   //PRINT SCREEN key
            VK_INSERT = 0x00520001,   //INS key
            VK_DELETE = 0x00530001,   //DEL key
            //VK_HELP = 0x000001,   //HELP key
            VK_0 = 0x000B0001,   //0 key
            VK_1 = 0x00020001,   //1 key
            VK_2 = 0x00030001,   //2 key
            VK_3 = 0x00040001,   //3 key
            VK_4 = 0x00050001,   //4 key
            VK_5 = 0x00060001,   //5 key
            VK_6 = 0x00070001,    //6 key
            VK_7 = 0x00080001,    //7 key
            VK_8 = 0x00090001,   //8 key
            VK_9 = 0x000A0001,    //9 key
            VK_A = 0x001E0001,   //A key
            VK_B = 0x00300001,   //B key
            VK_C = 0x002E0001,   //C key
            VK_D = 0x00200001,   //D key
            VK_E = 0x00120001,   //E key
            VK_F = 0x00210001,   //F key
            VK_G = 0x00220001,   //G key
            VK_H = 0x00230001,   //H key
            VK_I = 0x00170001,    //I key
            VK_J = 0x00240001,   //J key
            VK_K = 0x00250001,   //K key
            VK_L = 0x00260001,   //L key
            VK_M = 0x00320001,   //M key
            VK_N = 0x00310001,    //N key
            VK_O = 0x00180001,   //O key
            VK_P = 0x00190001,    //P key
            VK_Q = 0x00100001,   //Q key
            VK_R = 0x00130001,   //R key
            VK_S = 0x001F0001,   //S key
            VK_T = 0x00140001,   //T key
            VK_U = 0x00160001,   //U key
            VK_V = 0x002F0001,   //V key
            VK_W = 0x00110001,   //W key
            VK_X = 0x002D0001,   //X key
            VK_Y = 0x00150001,   //Y key
            VK_Z = 0x002C0001,    //Z key
            VK_NUMPAD0 = 0x00520001,   //Numeric keypad 0 key
            VK_NUMPAD1 = 0x004F0001,   //Numeric keypad 1 key
            VK_NUMPAD2 = 0x00500001,   //Numeric keypad 2 key
            VK_NUMPAD3 = 0x00510001,   //Numeric keypad 3 key
            VK_NUMPAD4 = 0x004B0001,   //Numeric keypad 4 key
            VK_NUMPAD5 = 0x004C0001,   //Numeric keypad 5 key
            VK_NUMPAD6 = 0x004D0001,   //Numeric keypad 6 key
            VK_NUMPAD7 = 0x00470001,   //Numeric keypad 7 key
            VK_NUMPAD8 = 0x00480001,   //Numeric keypad 8 key
            VK_NUMPAD9 = 0x00490001,   //Numeric keypad 9 key
            //VK_SEPARATOR = 0x000001,   //Separator key ***** WHAT KEY IS THIS SUPPOSED TO BE? *****
            VK_SUBTRACT = 0x004A0001,   //Subtract key
            VK_DECIMAL = 0x00530001,   //Decimal key
            VK_DIVIDE = 0x01350001,   //Divide key
            VK_F1 = 0x003B0001,   //F1 key
            VK_F2 = 0x003C0001,   //F2 key
            VK_F3 = 0x003D0001,   //F3 key
            VK_F4 = 0x003E0001,   //F4 key
            VK_F5 = 0x003F0001,   //F5 key
            VK_F6 = 0x00400001,   //F6 key
            VK_F7 = 0x00410001,   //F7 key
            VK_F8 = 0x00420001,   //F8 key
            VK_F9 = 0x00430001,   //F9 key
            VK_F10 = 0x00440001,   //F10 key
            VK_F11 = 0x00570001,   //F11 key ***** MIGHT NEED 0157 instead of 0057 *****
            VK_F12 = 0x00580001,   //F12 key ***** MIGHT NEED 0158 instead of 0058 *****
            VK_SCROLL = 0x00460001,   //SCROLL LOCK key
            VK_LSHIFT = 0x002A0001,   //Left SHIFT key
            VK_RSHIFT = 0x00360001,   //Right SHIFT key
            VK_LCONTROL = 0x001D0001,   //Left CONTROL key
            VK_RCONTROL = 0x001D0001,    //Right CONTROL key
            VK_LMENU = 0x00380001,      //Left MENU key
            VK_RMENU = 0x00380001,   //Right MENU key
            //VK_PLAY = 0x000001,   //Play key
            //VK_ZOOM = 0x000001, //Zoom key
        }



        //Special Keys
        public enum VKeys : int
        {
            VK_LBUTTON = 0x01,   //Left mouse button
            VK_RBUTTON = 0x02,   //Right mouse button
            VK_CANCEL = 0x03,   //Control-break processing
            VK_MBUTTON = 0x04,   //Middle mouse button (three-button mouse)
            VK_BACK = 0x08,   //BACKSPACE key
            VK_TAB = 0x09,   //TAB key
            VK_CLEAR = 0x0C,   //CLEAR key
            VK_RETURN = 0x0D,   //ENTER key
            VK_SHIFT = 0x10,   //SHIFT key
            VK_CONTROL = 0x11,   //CTRL key
            VK_MENU = 0x12,   //ALT key
            VK_PAUSE = 0x13,   //PAUSE key
            VK_CAPITAL = 0x14,   //CAPS LOCK key
            VK_ESCAPE = 0x1B,   //ESC key
            VK_SPACE = 0x20,   //SPACEBAR
            VK_PRIOR = 0x21,   //PAGE UP key
            VK_NEXT = 0x22,   //PAGE DOWN key
            VK_END = 0x23,   //END key
            VK_HOME = 0x24,   //HOME key
            VK_LEFT = 0x25,   //LEFT ARROW key
            VK_UP = 0x26,   //UP ARROW key
            VK_RIGHT = 0x27,   //RIGHT ARROW key
            VK_DOWN = 0x28,   //DOWN ARROW key
            VK_SELECT = 0x29,   //SELECT key
            VK_PRINT = 0x2A,   //PRINT key
            VK_EXECUTE = 0x2B,   //EXECUTE key
            VK_SNAPSHOT = 0x2C,   //PRINT SCREEN key
            VK_INSERT = 0x2D,   //INS key
            VK_DELETE = 0x2E,   //DEL key
            VK_HELP = 0x2F,   //HELP key
            VK_0 = 0x30,   //0 key
            VK_1 = 0x31,   //1 key
            VK_2 = 0x32,   //2 key
            VK_3 = 0x33,   //3 key
            VK_4 = 0x34,   //4 key
            VK_5 = 0x35,   //5 key
            VK_6 = 0x36,    //6 key
            VK_7 = 0x37,    //7 key
            VK_8 = 0x38,   //8 key
            VK_9 = 0x39,    //9 key
            VK_A = 0x41,   //A key
            VK_B = 0x42,   //B key
            VK_C = 0x43,   //C key
            VK_D = 0x44,   //D key
            VK_E = 0x45,   //E key
            VK_F = 0x46,   //F key
            VK_G = 0x47,   //G key
            VK_H = 0x48,   //H key
            VK_I = 0x49,    //I key
            VK_J = 0x4A,   //J key
            VK_K = 0x4B,   //K key
            VK_L = 0x4C,   //L key
            VK_M = 0x4D,   //M key
            VK_N = 0x4E,    //N key
            VK_O = 0x4F,   //O key
            VK_P = 0x50,    //P key
            VK_Q = 0x51,   //Q key
            VK_R = 0x52,   //R key
            VK_S = 0x53,   //S key
            VK_T = 0x54,   //T key
            VK_U = 0x55,   //U key
            VK_V = 0x56,   //V key
            VK_W = 0x57,   //W key
            VK_X = 0x58,   //X key
            VK_Y = 0x59,   //Y key
            VK_Z = 0x5A,    //Z key
            VK_NUMPAD0 = 0x60,   //Numeric keypad 0 key
            VK_NUMPAD1 = 0x61,   //Numeric keypad 1 key
            VK_NUMPAD2 = 0x62,   //Numeric keypad 2 key
            VK_NUMPAD3 = 0x63,   //Numeric keypad 3 key
            VK_NUMPAD4 = 0x64,   //Numeric keypad 4 key
            VK_NUMPAD5 = 0x65,   //Numeric keypad 5 key
            VK_NUMPAD6 = 0x66,   //Numeric keypad 6 key
            VK_NUMPAD7 = 0x67,   //Numeric keypad 7 key
            VK_NUMPAD8 = 0x68,   //Numeric keypad 8 key
            VK_NUMPAD9 = 0x69,   //Numeric keypad 9 key
            VK_SEPARATOR = 0x6C,   //Separator key
            VK_SUBTRACT = 0x6D,   //Subtract key
            VK_DECIMAL = 0x6E,   //Decimal key
            VK_DIVIDE = 0x6F,   //Divide key
            VK_F1 = 0x70,   //F1 key
            VK_F2 = 0x71,   //F2 key
            VK_F3 = 0x72,   //F3 key
            VK_F4 = 0x73,   //F4 key
            VK_F5 = 0x74,   //F5 key
            VK_F6 = 0x75,   //F6 key
            VK_F7 = 0x76,   //F7 key
            VK_F8 = 0x77,   //F8 key
            VK_F9 = 0x78,   //F9 key
            VK_F10 = 0x79,   //F10 key
            VK_F11 = 0x7A,   //F11 key
            VK_F12 = 0x7B,   //F12 key
            VK_SCROLL = 0x91,   //SCROLL LOCK key
            VK_LSHIFT = 0xA0,   //Left SHIFT key
            VK_RSHIFT = 0xA1,   //Right SHIFT key
            VK_LCONTROL = 0xA2,   //Left CONTROL key
            VK_RCONTROL = 0xA3,    //Right CONTROL key
            VK_LMENU = 0xA4,      //Left MENU key
            VK_RMENU = 0xA5,   //Right MENU key
            VK_PLAY = 0xFA,   //Play key
            VK_ZOOM = 0xFB, //Zoom key
        }

        //Windows API messages
        public enum WMessages : uint
        {
            WM_MOUSEMOVE = 0x200,  //Mouse Move
            WM_LBUTTONDOWN = 0x201, //Left mousebutton down
            WM_LBUTTONUP = 0x202,  //Left mousebutton up
            WM_LBUTTONDBLCLK = 0x203, //Left mousebutton doubleclick
            WM_RBUTTONDOWN = 0x204, //Right mousebutton down
            WM_RBUTTONUP = 0x205,   //Right mousebutton up
            WM_RBUTTONDBLCLK = 0x206, //Right mousebutton doubleclick
            WM_KEYDOWN = 0x100,  //Key down
            WM_KEYUP = 0x101,   //Key up
            WM_NCHITTEST = 0x84,
            WM_SETCURSOR = 0x20,
        }
    }
}
