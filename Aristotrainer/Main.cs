using Aristotrainer.Structs;
using Aristotrainer.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aristotrainer
{
    public partial class Main : Form
    {
        public static Main Instance;

        public Dictionary<string, HackInformation> Cheats;

        public delegate void InvokeDelegatePos(CharacterInformation CharInfo);

        public delegate void InvokeDelegate(GeneralInformation GeneralInfo,
            MapInformation MapInfo,
            CharacterInformation CharInfo);

        public readonly InvokeDelegatePos InvokeControlsPos;

        public readonly InvokeDelegate InvokeControls;

        public Main()
        {
            Instance = this;
            InitializeComponent();
            LoadCheats();
            InvokeControls = new InvokeDelegate(UpdateInformation);
            InvokeControlsPos = new InvokeDelegatePos(UpdateInformationPos);
        }

        private void Main_OnLoad(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName("MapleStory").Length != 1)
            {
                MessageBox.Show("Couldn't find MapleStory.");
                Close();
                return;
            }
            Process MapleStory = Process.GetProcessesByName("MapleStory")[0];
            new InformationCollecter(
                MapleStory.Id,
                MapleStory.Handle,
                MapleStory.MainWindowHandle);
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            fieldDamageCap.Value = int.MaxValue;
            WriteMemory((int)Address.UnlimitedAttack, new byte[1] { 0xEB });
            WriteMemory((int)Address.ShowPassword, new byte[1] { 0x75 });
            WriteMemory((int)Address.ViewSwears, new byte[2] { 0x90, 0x90 });
        }

        private void Main_OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (InformationCollecter.Instance != null)
                InformationCollecter.Instance.AbortThreads();
        }

        #region Updating

        public void UpdateInformationPos(CharacterInformation CharInfo)
        {
            if (InvokeRequired)
                Invoke(InvokeControlsPos, CharInfo);
            else
            {
                label5.Text = string.Format("Position: X: {0} Y: {1}",
                    CharInfo.Position.X, CharInfo.Position.Y);
            }
        }

        public void UpdateInformation(GeneralInformation GeneralInfo,
            MapInformation MapInfo,
            CharacterInformation CharInfo)
        {
            if (InvokeRequired)
                Invoke(InvokeControls, GeneralInfo, MapInfo, CharInfo);
            else
            {
                listView1.Items.Clear();
                foreach (string thread in InformationCollecter.Instance.Threads.Keys)
                    listView1.Items.Add(new ListViewItem(thread));
                listView2.Clear();
                foreach (string str in GeneralInfo.ToString().Split('\n'))
                    listView2.Items.Add(new ListViewItem(str));
                foreach (string str in CharInfo.ToString().Split('\n'))
                    listView2.Items.Add(new ListViewItem(str));
                foreach (string str in MapInfo.ToString().Split('\n'))
                    listView2.Items.Add(new ListViewItem(str));
            }
        }

        #endregion

        #region Cheats

        public void Teleport(Point location)
        {
            Teleport(location.X, location.Y);
        }

        public void Teleport(int x, int y)
        {
            int CharacterBase = BitConverter.ToInt32(
                MemoryTool.ReadAddress(
                InformationCollecter.Instance.ProcessHandle,
                (IntPtr)BasePointer.CharacterBase,
                4), 0);
            int teleport = CharacterBase + (int)Offset.Teleport;
            int teleportX = CharacterBase + (int)Offset.TeleportX;
            int teleportY = CharacterBase + (int)Offset.TeleportY;
            WriteMemory(teleportX, BitConverter.GetBytes(x));
            WriteMemory(teleportY, BitConverter.GetBytes(y));
            WriteMemory(teleport, BitConverter.GetBytes(true));
        }

        private void LoadCheats()
        {
            byte jne = 0x75, esi = 0x81, nop = 0x90, jmp = 0xEB;
            //90 - nop 74 - jump if 75 - jump if not 71 - equal
            Cheats = new Dictionary<string, HackInformation>();
            Cheats.Add("Swim Hack", new HackInformation((IntPtr)Address.SwimHack,
                new byte[] { 0xEB }, new byte[] { 0x74 }));
            Cheats.Add("Super Tubi", new HackInformation((IntPtr)Address.SuperTubi,
                new byte[] { nop, nop, nop, nop, nop, nop }, new byte[] { 0x89, 0x86, 0x04, 0x21, 0x00, 0x00 }));
            Cheats.Add("Instant Drop", new HackInformation((IntPtr)Address.InstantDrop,
                new byte[] { 0x25 }, new byte[] { 0x0D }));
            Cheats.Add("Instant Loot", new HackInformation((IntPtr)Address.InstantLoot,
                new byte[] { 0x81, 0xFE, 0x00, 0x00, 0x00, 0x00 }, new byte[] { 0x81, 0xFE, 0xBC, 0x02, 0x00, 0x00 }));
            //Cheats.Add("Unlimited Attack", new HackInformation((IntPtr)Address.UnlimitedAttack,
            //    new byte[] { 0xEB }, new byte[] { 0x7E }));
            Cheats.Add("Fall Through Floor", new HackInformation((IntPtr)Address.FallThroughFloor,
                new byte[] { 0 }, new byte[] { 2 }));
            Cheats.Add("No KB", new HackInformation((IntPtr)Address.NoKnockback,
                new byte[] { 0 }, new byte[] { 1 }));
            Cheats.Add("Instant Air Loot", new HackInformation((IntPtr)Address.InstantAirLoot,
                new byte[] { nop, nop }, new byte[] { 0x75, 0x68 }));
            Cheats.Add("Instant Mining1", new HackInformation((IntPtr)Address.InstantMining1,
                new byte[] { nop, nop }, new byte[] { 0x7C, 0x41 }));
            Cheats.Add("Instant Mining2", new HackInformation((IntPtr)Address.InstantMining2,
                new byte[] { 0xEB }, new byte[] { 0x7F }));
            Cheats.Add("Instant Mining3", new HackInformation((IntPtr)Address.InstantMining3,
                new byte[] { nop, nop }, new byte[] { 0x75, 0x13 }));
            Cheats.Add("Reactor DeM", new HackInformation((IntPtr)Address.ReactorDeM,
                new byte[] { nop, nop }, new byte[] { 0x74, 0x73 }));
            Cheats.Add("Key Bind1", new HackInformation((IntPtr)Address.Keybind1,
                new byte[] { nop, nop }, new byte[] { 0x74, 5 }));
            Cheats.Add("Key Bind2", new HackInformation((IntPtr)Address.Keybind2,
                new byte[] { nop, nop, nop, nop, nop, nop }, new byte[] { 0x0F, 0x84, 0x1C, 0x06, 0x00, 0x00 }));
            Cheats.Add("Key Bind3", new HackInformation((IntPtr)Address.Keybind3,
                new byte[] { 0xC2, 4, 0 }, new byte[] { 0x6A, 0xFF, 0x68 }));
            Cheats.Add("CPU Hack1", new HackInformation((IntPtr)Address.CPUHack1,
                new byte[] { nop, nop, nop, nop, nop }, new byte[] { 0xE8, 0xE0, 0xCA, 0xFF, 0xFF }));
            Cheats.Add("CPU Hack2", new HackInformation((IntPtr)Address.CPUHack2,
                new byte[] { nop, nop, nop, nop, nop }, new byte[] { 0xE8, 0x52, 0xC4, 0xFF, 0xFF }));
            Cheats.Add("CPU Hack3", new HackInformation((IntPtr)Address.CPUHack3,
                new byte[] { nop, nop, nop, nop, nop }, new byte[] { 0xE8, 0x32, 0xD9, 0xFF, 0xFF }));
            Cheats.Add("Sit Hack", new HackInformation((int)Address.SitHack,
                "75", "74"));
            Cheats.Add("Mob Teleport", new HackInformation((int)Address.MobTeleport,
                "0F 84", "0F 8C"));
            Cheats.Add("Raining Mobs", new HackInformation((int)Address.RainingMobs,
                "D9 C1", "D9 C0"));
            Cheats.Add("Slow Mobs", new HackInformation((int)Address.SlowMobs,
                "B8 00 00 00 00", "B8 E8 03 00 00"));
            Cheats.Add("Blink Godmode", new HackInformation((int)Address.BlinkGodmode,
                "EB 09", "7E 21"));
            Cheats.Add("Physical Godmode", new HackInformation((int)Address.PhysicalGodmode,
                "0F 84", "0F 85"));
            Cheats.Add("Multi Attack", new HackInformation((int)Address.MultiAttack,
                "74", "75"));
            Cheats.Add("Weird Item Drop", new HackInformation((int)Address.WeirdItemDrop,
                "75", "74"));
            Cheats.Add("Hide Login Info", new HackInformation((int)Address.HideLoginInfo,
                "EB", "74"));
            //Cheats.Add("Show Password", new HackInformation((int)Address.ShowPassword,
            //    "75", "74"));
            Cheats.Add("Generic No Delay", new HackInformation((int)Address.GenericNoDelay,
                "74", "75"));
            //Cheats.Add("View Swears", new HackInformation((int)Address.ViewSwears,
            //    "90 90", "74 27"));
            foreach (string key in Cheats.Keys)
            {
                string str = key;
                ListViewItem item = new ListViewItem();
                item.Tag = str;
                if (str.EndsWith("2") || str.EndsWith("3"))
                {
                    string realname = str.Substring(0, str.Length - 1);
                    int index = listView3.Items[realname].Index;
                    listView3.Items[index].Tag += ";" + str;
                    continue;
                }
                if (str.EndsWith("1"))
                    str = str.Substring(0, str.Length - 1);
                item.Name = str;
                item.Text = str;
                listView3.Items.Add(item);
            }
            listView3.ItemChecked += new ItemCheckedEventHandler(cheatBox_OnCheckedChanged);
        }

        private void cheatBox_OnCheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox)
            {
                cheatBox_OnCheckedChanged_Old(sender, e);
                return;
            }
            if (!(sender is ListView))
            {
                MessageBox.Show(sender.ToString());
                return;
            }
            foreach (object cb in ((ListView)sender).Items)
            {
                if (!(cb is ListViewItem))
                {
                    MessageBox.Show(sender.ToString());
                    return;
                }
                foreach (string str in ((ListViewItem)cb).Tag.ToString().Split(';'))
                {
                    if (!Cheats.ContainsKey(str))
                        continue;
                    HackInformation Cheat = Cheats[str];
                    byte[] buffer = Cheat.DisableBuffer;
                    if (((ListViewItem)cb).Checked)
                        buffer = Cheat.EnableBuffer;
                    int result = WriteMemory((int)Cheat.Address, buffer);
                    if (result != 1)
                    {
                        ((ListViewItem)cb).Checked = false;
                    }
                }
            }
        }

        private void cheatBox_OnCheckedChanged_Old(object sender, EventArgs e)
        {
            if (!(sender is CheckBox))
            {
                MessageBox.Show(sender.ToString());
                return;
            }
            foreach (string str in ((CheckBox)sender).Tag.ToString().Split(';'))
            {
                if (!Cheats.ContainsKey(str))
                    continue;
                HackInformation Cheat = Cheats[str];
                byte[] buffer = Cheat.DisableBuffer;
                if (((CheckBox)sender).Checked)
                    buffer = Cheat.EnableBuffer;
                int result = WriteMemory((int)Cheat.Address, buffer);
                if (result != 1)
                {
                    ((CheckBox)sender).Checked = false;
                }
            }
        }

        private void morphBox_OnValueChanged(object sender, EventArgs e)
        {
            IntPtr zero = IntPtr.Zero;
            IntPtr address = (IntPtr)(BitConverter.ToInt32(
                MemoryTool.ReadAddress(
                InformationCollecter.Instance.ProcessHandle,
                (IntPtr)BasePointer.CharacterBase,
                4), 0) + (int)Offset.Morph);
            if (InformationCollecter.Instance.Threads.ContainsKey("Morph"))
                InformationCollecter.Instance.Threads["Morph"].Abort();
            InformationCollecter.Instance.Threads.Remove("Morph");
            InformationCollecter.Instance.Threads.Add("Morph",
                new Thread(new ThreadStart(
                        () =>
                        {
                            while (true)
                            {
                                WriteMemory((int)address, BitConverter.GetBytes((int)numericUpDown1.Value));
                                Thread.Sleep(100);
                            }
                        })));
            InformationCollecter.Instance.Threads["Morph"].Start();
        }

        private void checkBoxNDFA_OnCheckedChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
            {
                if (checkBoxNDFA.Checked)
                    MessageBox.Show("Please select a skill.");
                checkBoxNDFA.Checked = false;
                return;
            }
            byte[] buffer = new byte[] { 0x83, 0xBE, 0x8C, 0x7B, 0x00, 0x00, 0x00, 0x0F, 0x84, 0x3E, 0x01, 0x00, 0x00, 0x2B, 0xAE, 0x94, 0x7B, 0x00, 0x00, 0x0F, 0x88, 0x32, 0x01, 0x00, 0x00 };
            byte nop = 0x90;
            if (checkBoxNDFA.Checked)
                buffer = new byte[] { 0xC7, 0x86, 0x28, 0x70, 0x00, 0x00, 0x82, 0x4F, 0x12, 0x00, nop, nop, nop, nop, nop, nop, nop, nop, nop, nop, nop, nop, nop, nop, nop };
            IntPtr zero = IntPtr.Zero;
            int result = WriteMemory((int)0x00BF612D, buffer);
            if (result != 1)
            {
                checkBoxNDFA.Checked = false;
            }
        }

        private void comboBox1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cheats.ContainsKey("NDFinalAttack"))
                Cheats.Remove("NDFinalAttack");
            byte nop = 0x90;
            int SkillID;
            int.TryParse(comboBox1.Text.Split('#')[1], out SkillID);
            if (SkillID <= 0)
                checkBoxNDFA.Enabled = false;
            byte[] Skill = BitConverter.GetBytes(SkillID);
            Cheats.Add("NDFinalAttack", new HackInformation((IntPtr)0x00BF612D,
                new byte[] { 0xC7, 0x86, 0x28, 0x70, 0x00, 0x00, Skill[0], Skill[1], Skill[2], Skill[3], nop, nop, nop, nop, nop, nop, nop, nop, nop, nop, nop, nop, nop, nop, nop }, new byte[] { 0x83, 0xBE, 0x8C, 0x7B, 0x00, 0x00, 0x00, 0x0F, 0x84, 0x3E, 0x01, 0x00, 0x00, 0x2B, 0xAE, 0x94, 0x7B, 0x00, 0x00, 0x0F, 0x88, 0x32, 0x01, 0x00, 0x00 }));
        }

        private void checkBoxTeleport_OnCheckedChanged(object sender, EventArgs e)
        {
            if (InformationCollecter.Instance.Threads.ContainsKey("ClickTeleport"))
            {
                InformationCollecter.Instance.Threads["ClickTeleport"].Abort();
                InformationCollecter.Instance.Threads.Remove("ClickTeleport");
            }
            if (checkBoxTeleport.Checked)
            {
                InformationCollecter.Instance.Threads.Add("ClickTeleport",
                    new Thread(new ThreadStart(
                        () =>
                        {
                            while (true)
                            {
                                if (InformationCollecter.Instance.CharInfo.MouseAnimation == 0xC)
                                {
                                    Teleport(InformationCollecter.Instance.CharInfo.MouseLocation.Y,
                                        InformationCollecter.Instance.CharInfo.MouseLocation.X);
                                }
                                Thread.Sleep(10);
                            }
                        })));
            }
            if (InformationCollecter.Instance.Threads.ContainsKey("ClickTeleport"))
                InformationCollecter.Instance.Threads["ClickTeleport"].Start();
        }

        private void checkBoxKami_OnCheckedChanged(object sender, EventArgs e)
        {
            if (InformationCollecter.Instance.Threads.ContainsKey("Kami"))
            {
                InformationCollecter.Instance.Threads["Kami"].Abort();
                InformationCollecter.Instance.Threads.Remove("Kami");
            }
            int delay = (int)numericUpDown4.Value;
            if (checkBoxKami.Checked)
            {
                InformationCollecter.Instance.Threads.Add("Kami",
                    new Thread(new ThreadStart(
                        () =>
                        {
                            while (true)
                            {
                                int addition = -50;
                                if ((InformationCollecter.Instance.CharInfo.BreathState & 1) != 0)
                                    addition *= -1; //flag 1 = left direction
                                Teleport(InformationCollecter.Instance.MapInfo.MobPosition.X + addition,
                                    InformationCollecter.Instance.MapInfo.MobPosition.Y);
                                Thread.Sleep(delay);
                            }
                        })));
            }
            if (InformationCollecter.Instance.Threads.ContainsKey("Kami"))
                InformationCollecter.Instance.Threads["Kami"].Start();
        }

        private void fieldDamageCap_OnValueChanged(object sender, EventArgs e)
        {
            WriteMemory((int)Address.DamageCap, BitConverter.GetBytes((double)fieldDamageCap.Value));
        }

        private int WriteMemory(int address, byte[] buffer)
        {
            IntPtr zero = IntPtr.Zero;
            return WinAPI.WriteProcessMemory(
                InformationCollecter.Instance.ProcessHandle, (IntPtr)address, buffer, (uint)buffer.Length, out zero);
        }

#endregion

        #region Keyboard

        public void PressKey(int Key, int lParam)
        {
            uint WM_KEYDOWN = 0x100;

            WinAPI.PostMessage(InformationCollecter.Instance.MainWindowHandle,
                WM_KEYDOWN, Key, lParam);
        }

        public int FindKey(string Key)
        {
            foreach (string str in Enum.GetNames(typeof(Keyboard.VKeys)))
            {
                if (Key.ToUpper().Equals(str.ToUpper()))
                    return (int)Enum.Parse(typeof(Keyboard.VKeys), Key);
            }
            return -1;
        }

        public int FindLParam(string Key)
        {
            foreach (string str in Enum.GetNames(typeof(Keyboard.VKeysScan)))
            {
                if (Key.ToUpper().Equals(str.ToUpper()))
                    return (int)Enum.Parse(typeof(Keyboard.VKeysScan), Key);
            }
            return -1;
        }

        #endregion

        #region Bot

        private void checkBoxAttack_CheckedChanged(object sender, EventArgs e)
        {
            if (InformationCollecter.Instance.Threads.ContainsKey("AutoAttack"))
            {
                InformationCollecter.Instance.Threads["AutoAttack"].Abort();
                InformationCollecter.Instance.Threads.Remove("AutoAttack");
            }
            if (checkBoxAttack.Checked)
            {
                int Key = FindKey("VK_" + comboBox2.Text.ToUpper());
                int lParam = FindLParam("VK_" + comboBox2.Text.ToUpper());
                if (comboBox2.SelectedIndex < 0 || Key < 0 || lParam < 0)
                {
                    MessageBox.Show("Please choose a valid key.");
                    checkBoxAttack.Checked = false;
                    return;
                }
                InformationCollecter.Instance.Threads.Add("AutoAttack",
                    new Thread(new ThreadStart(
                        () =>
                        {
                            while (true)
                            {
                                if (InformationCollecter.Instance.MapInfo.MobCount >= numericUpDown5.Value)
                                    WinAPI.PostMessage(InformationCollecter.Instance.MainWindowHandle,
                                        0x100, Key, lParam);
                                Thread.Sleep(100);
                            }
                        })));
            }
            if (InformationCollecter.Instance.Threads.ContainsKey("AutoAttack"))
                InformationCollecter.Instance.Threads["AutoAttack"].Start();
        }

        private void checkBoxHP_CheckedChanged(object sender, EventArgs e)
        {
            if (InformationCollecter.Instance.Threads.ContainsKey("AutoHP"))
            {
                InformationCollecter.Instance.Threads["AutoHP"].Abort();
                InformationCollecter.Instance.Threads.Remove("AutoHP");
            }
            if (checkBoxHP.Checked)
            {
                int Key = FindKey("VK_END");
                int lParam = FindLParam("VK_END");
                if (Key < 0 || lParam < 0)
                {
                    MessageBox.Show("Please choose a valid key.");
                    checkBoxHP.Checked = false;
                    return;
                }
                InformationCollecter.Instance.Threads.Add("AutoHP",
                    new Thread(new ThreadStart(
                        () =>
                        {
                            while (true)
                            {
                                if (InformationCollecter.Instance.CharInfo.AlertHP < 19)
                                    MessageBox.Show("Please change your HP Alert to maximum at System->System Options.");
                                if (InformationCollecter.Instance.CharInfo.HP < numericUpDown2.Value)
                                    WinAPI.PostMessage(InformationCollecter.Instance.MainWindowHandle,
                                        0x100, Key, lParam);
                                Thread.Sleep(100);
                            }
                        })));
            }
            if (InformationCollecter.Instance.Threads.ContainsKey("AutoHP"))
                InformationCollecter.Instance.Threads["AutoHP"].Start();
        }

        private void checkBoxMP_CheckedChanged(object sender, EventArgs e)
        {
            if (InformationCollecter.Instance.Threads.ContainsKey("AutoMP"))
            {
                InformationCollecter.Instance.Threads["AutoMP"].Abort();
                InformationCollecter.Instance.Threads.Remove("AutoMP");
            }
            if (checkBoxMP.Checked)
            {
                int Key = FindKey("VK_HOME");
                int lParam = FindLParam("VK_HOME");
                if (Key < 0 || lParam < 0)
                {
                    MessageBox.Show("Please choose a valid key.");
                    checkBoxMP.Checked = false;
                    return;
                }
                InformationCollecter.Instance.Threads.Add("AutoMP",
                    new Thread(new ThreadStart(
                        () =>
                        {
                            while (true)
                            {
                                if (InformationCollecter.Instance.CharInfo.AlertMP < 19)
                                    MessageBox.Show("Please change your MP Alert to maximum at System->System Options.");
                                if (InformationCollecter.Instance.CharInfo.MP < numericUpDown3.Value)
                                    WinAPI.PostMessage(InformationCollecter.Instance.MainWindowHandle,
                                        0x100, Key, lParam);
                                Thread.Sleep(100);
                            }
                        })));
            }
            if (InformationCollecter.Instance.Threads.ContainsKey("AutoMP"))
                InformationCollecter.Instance.Threads["AutoMP"].Start();
        }

        private void checkBoxLoot_CheckedChanged(object sender, EventArgs e)
        {
            if (InformationCollecter.Instance.Threads.ContainsKey("AutoLoot"))
            {
                InformationCollecter.Instance.Threads["AutoLoot"].Abort();
                InformationCollecter.Instance.Threads.Remove("AutoLoot");
            }
            if (checkBoxLoot.Checked)
            {
                int Key = FindKey("VK_Z");
                int lParam = FindLParam("VK_Z");
                if (Key < 0 || lParam < 0)
                {
                    MessageBox.Show("Please choose a valid key.");
                    checkBoxLoot.Checked = false;
                    return;
                }
                InformationCollecter.Instance.Threads.Add("AutoLoot",
                    new Thread(new ThreadStart(
                        () =>
                        {
                            while (true)
                            {
                                if (InformationCollecter.Instance.MapInfo.ItemCount >= numericUpDown6.Value)
                                    WinAPI.PostMessage(InformationCollecter.Instance.MainWindowHandle,
                                        0x100, Key, lParam);
                                Thread.Sleep(10);
                            }
                        })));
            }
            if (InformationCollecter.Instance.Threads.ContainsKey("AutoLoot"))
                InformationCollecter.Instance.Threads["AutoLoot"].Start();
        }

        #endregion

        #region Test

        public void TeleportThroughMap()
        {
            if (InformationCollecter.Instance.Threads.ContainsKey("MapScan"))
            {
                InformationCollecter.Instance.Threads["MapScan"].Abort();
                InformationCollecter.Instance.Threads.Remove("MapScan");
            }
            InformationCollecter.Instance.Threads.Add("MapScan",
                new Thread(new ThreadStart(
                    () =>
                    {
                        MapInformation MapInfo = InformationCollecter.Instance.MapInfo;
                        while (InformationCollecter.Instance.MapInfo.ItemCount > 0)
                        {
                            for (int y = MapInfo.TopWall; y < MapInfo.BottomWall; y++)
                                for (int x = MapInfo.LeftWall; x < MapInfo.RightWall; x++)
                                    Teleport(x, y);
                        }
                        Teleport(MapInfo.MapCenter);
                    })));
            if (InformationCollecter.Instance.Threads.ContainsKey("MapScan"))
                InformationCollecter.Instance.Threads["MapScan"].Start();
        }

        #endregion
    }
}
