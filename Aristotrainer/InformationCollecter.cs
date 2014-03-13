using Aristotrainer.Structs;
using Aristotrainer.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aristotrainer
{
    class InformationCollecter
    {
        public static InformationCollecter Instance;
        public Dictionary<string, Thread> Threads;
        public int ProcessID;
        public IntPtr ProcessHandle;
        public IntPtr MainWindowHandle;
        public GeneralInformation GeneralInfo;
        public MapInformation MapInfo;
        public CharacterInformation CharInfo;

        public InformationCollecter(
            int ProcessID,
            IntPtr ProcessHandle,
            IntPtr MainWindowHandle)
        {
            Instance = this;
            this.ProcessID = ProcessID;
            this.ProcessHandle = ProcessHandle;
            this.MainWindowHandle = MainWindowHandle;
            Threads = new Dictionary<string, Thread>();
            BeginThreads();
        }

        public void BeginThreads()
        {
            Threads.Add("MapleStory", new Thread(new ThreadStart(() =>
            {
                while (true)
                {
                    try
                    {
                        Process MapleStory = Process.GetProcessById(ProcessID);
                        ProcessHandle = MapleStory.Handle;
                        MainWindowHandle = MapleStory.MainWindowHandle;
                        GeneralInfo.ProcessHandle = ProcessHandle;
                    }
                    catch { Environment.Exit(0); }
                    Thread.Sleep(100);
                }
            })));
            GeneralInfo = new GeneralInformation();
            Threads.Add("GeneralInformation", new Thread(
                new ThreadStart(UpdateGeneralInformation)));
            MapInfo = new MapInformation();
            Threads.Add("MapInformation", new Thread(
                new ThreadStart(UpdateMapInformation)));
            CharInfo = new CharacterInformation();
            Threads.Add("CharacterInformation", new Thread(
                new ThreadStart(UpdateCharacterInformation)));
            Threads.Add("Position", new Thread(new ThreadStart(() =>
                {
                    int CharacterBase = (int)BasePointer.CharacterBase;
                    int MonsterBase = (int)BasePointer.MonsterBase;
                    int Mob1 = (int)Offset.Mob1,
                        Mob2 = (int)Offset.Mob2,
                        Mob3 = (int)Offset.Mob3,
                        Mob4 = (int)Offset.Mob4;
                    int MouseBase = (int)BasePointer.MouseBase;
                    int MouseLocationBase = (int)Offset.MouseLocation;
                    while (true)
                    {
                        CharInfo.Position = new Point(
                        ReadInt32Pointer(CharacterBase, (int)Offset.CharacterX),
                        ReadInt32Pointer(CharacterBase, (int)Offset.CharacterY));
                        UpdatePosition();
                        CharInfo.MouseAnimation = ReadInt32Pointer(MouseBase, (int)Offset.MouseAnimation);
                        CharInfo.MouseLocation = new Point(
                            ReadInt32MultiPointer(MouseBase, new int[] { MouseLocationBase, (int)Offset.MouseX }),
                            ReadInt32MultiPointer(MouseBase, new int[] { MouseLocationBase, (int)Offset.MouseY }));
                        MapInfo.MobPosition = new Point(
                            ReadInt32MultiPointer(MonsterBase, new int[] { Mob1, Mob2, Mob3, Mob4, (int)Offset.MobX }),
                            ReadInt32MultiPointer(MonsterBase, new int[] { Mob1, Mob2, Mob3, Mob4, (int)Offset.MobY }));
                        Thread.Sleep(1);
                    }
                })));
            foreach (Thread thread in Threads.Values)
                thread.Start();
        }

        public void AbortThreads()
        {
            foreach (Thread thread in Threads.Values)
                thread.Abort();
        }

        public void UpdateGeneralInformation()
        {
            int ServerBase = (int)BasePointer.ServerBase;
            while (true)
            {
                GeneralInfo.DamageCap = BitConverter.ToDouble(
                    MemoryTool.ReadAddress(ProcessHandle,
                    (IntPtr)Address.DamageCap,
                    8), 0);
                GeneralInfo.WorldID = ReadInt32Pointer(ServerBase, (int)Offset.WorldID);
                GeneralInfo.Channel = ReadInt32Pointer(ServerBase, (int)Offset.ChannelID);
                UpdateInformation();
                Thread.Sleep(2000);
            }
        }

        public void UpdateMapInformation()
        {
            int MapBase = (int)BasePointer.MapBase;
            int PeopleBase = (int)BasePointer.PeopleBase;
            int PortalBase = (int)BasePointer.PortalBase;
            int MonsterBase = (int)BasePointer.MonsterBase;
            int ItemBase = (int)BasePointer.ItemBase;
            int WallBase = (int)BasePointer.WallBase;
            while (true)
            {
                MapInfo.MapID = ReadInt32Pointer(MapBase, (int)Offset.MapID);
                MapInfo.PeopleCount = ReadInt32Pointer(PeopleBase, (int)Offset.PeopleCount);
                MapInfo.PortalCount = ReadInt32Pointer(PortalBase, (int)Offset.PortalCount);
                MapInfo.MobCount = ReadInt32Pointer(MonsterBase, (int)Offset.MobCount);
                MapInfo.ItemCount = ReadInt32Pointer(ItemBase, (int)Offset.ItemCount);
                MapInfo.LeftWall = ReadInt32Pointer(WallBase, (int)Offset.LeftWall);
                MapInfo.TopWall = ReadInt32Pointer(WallBase, (int)Offset.TopWall);
                MapInfo.RightWall = ReadInt32Pointer(WallBase, (int)Offset.RightWall);
                MapInfo.BottomWall = ReadInt32Pointer(WallBase, (int)Offset.BottomWall);
                MapInfo.MapCenter = new Point(
                    (MapInfo.LeftWall + MapInfo.RightWall) / 2,
                    (MapInfo.TopWall + MapInfo.BottomWall) / 2);
                UpdateInformation();
                Thread.Sleep(500);
            }
        }

        public void UpdateCharacterInformation()
        {
            int CharacterStat = (int)BasePointer.StatBase;
            int CharacterStatAlert = (int)BasePointer.AlertBase;
            int CharacterBase = (int)BasePointer.CharacterBase;
            int MouseBase = (int)BasePointer.MouseBase;
            int MouseLocationBase = (int)Offset.MouseLocation;
            while (true)
            {
                //CharInfo.Name = "hi";
                CharInfo.HP = ReadInt32Pointer(CharacterStat, (int)Offset.HP);
                CharInfo.MP = ReadInt32Pointer(CharacterStat, (int)Offset.MP);
                CharInfo.EXPPercentage = ReadDoublePointer(CharacterStat, (int)Offset.ExpPercentage);
                CharInfo.AlertHP = ReadInt32Pointer(CharacterStatAlert, (int)Offset.AlertHP);
                CharInfo.AlertMP = ReadInt32Pointer(CharacterStatAlert, (int)Offset.AlertMP);
                CharInfo.Position = new Point(
                    ReadInt32Pointer(CharacterBase, (int)Offset.CharacterX),
                    ReadInt32Pointer(CharacterBase, (int)Offset.CharacterY));
                CharInfo.Teleport = ReadInt32Pointer(CharacterBase, (int)Offset.Teleport);
                CharInfo.TeleportPosition = new Point(
                    ReadInt32Pointer(CharacterBase, (int)Offset.TeleportX),
                    ReadInt32Pointer(CharacterBase, (int)Offset.TeleportY));
                CharInfo.WatchedItemID = ReadInt32Pointer(CharacterBase, (int)Offset.WatchedItemID);
                CharInfo.AttackCount = ReadBytePointer(CharacterBase, (int)Offset.AttackCount);
                CharInfo.BuffCount = ReadBytePointer(CharacterBase, (int)Offset.BuffCount);
                CharInfo.Morph = ReadInt32Pointer(CharacterBase, (int)Offset.Morph);
                CharInfo.BreathState = ReadInt32Pointer(CharacterBase, (int)Offset.BreathState);
                CharInfo.CharacterAnimation = ReadInt32Pointer(CharacterBase, (int)Offset.CharacterAnimation);
                CharInfo.MouseAnimation = ReadInt32Pointer(MouseBase, (int)Offset.MouseAnimation);
                CharInfo.MouseLocation = new Point(
                    ReadInt32MultiPointer(MouseBase, new int[] { MouseLocationBase, (int)Offset.MouseX }),
                    ReadInt32MultiPointer(MouseBase, new int[] { MouseLocationBase, (int)Offset.MouseY }));
                UpdateInformation();
                Thread.Sleep(1000);
            }
        }

        public void UpdateInformation()
        {
            Main.Instance.UpdateInformation(GeneralInfo, MapInfo, CharInfo);
        }

        public void UpdatePosition()
        {
            Main.Instance.UpdateInformationPos(CharInfo);
        }

        public int ReadInt32Pointer(int address, int offset)
        {
            return BitConverter.ToInt32(
                MemoryTool.ReadPointer(ProcessHandle, (IntPtr)address, offset, 4),
                0);
        }

        public int ReadInt32MultiPointer(int address, int[] offset)
        {
            return BitConverter.ToInt32(
                MemoryTool.ReadMultiPointer(ProcessHandle, (IntPtr)address, offset, 4),
                0);
        }

        public byte ReadBytePointer(int address, int offset)
        {
            return MemoryTool.ReadPointer(ProcessHandle, (IntPtr)address, offset, 1)[0];
        }

        public double ReadDoublePointer(int address, int offset)
        {
            return BitConverter.ToDouble(
                MemoryTool.ReadPointer(ProcessHandle, (IntPtr)address, offset, 8),
                0);
        }
    }
}
