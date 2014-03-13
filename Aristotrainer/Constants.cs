using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aristotrainer
{
    #region Addresses

    public enum Address : int
    {
        Base = 0x400000,
        DamageCap = Base + 0xB67188, //Scan 199,999/999,999/50,000,000

        InstantLoot = 0x0045B639,
        SuperTubi = 0x004D5577,
        ShowPassword = 0x0051DF6F,
        HideLoginInfo = 0x00520ADC,
        WeirdItemDrop = 0x00565A03,
        InstantDrop = 0x00565A25,
        InstantAirLoot = 0x00567E39,
        CPUHack1 = 0x006DE1BB,
        CPUHack2 = 0x006DEEE9,
        CPUHack3 = 0x006E39F9,
        RainingMobs = 0x00746296,
        SlowMobs = 0x0074674B,
        MobTeleport = 0x00747417,
        Keybind3 = 0x007D9A50,
        ViewSwears = 0x008A296B,
        NoKnockback = 0x008A51DB,
        Keybind1 = 0x00A91E02,
        Keybind2 = 0x00ABF6C6,
        BlinkGodmode = 0x00B92A17,
        UnlimitedAttack = 0x00B9A160,
        SitHack = 0x00BA1521,
        InstantMining1 = 0x00BA9B12,
        InstantMining2 = 0x00BA9B1B,
        ReactorDeM = 0x00BAE32F,
        InstantMining3 = 0x00BB9617,
        MultiAttack = 0x00BDA959,
        GenericNoDelay = 0x00BDBC11,
        PhysicalGodmode = 0x00BED49F,
        SwimHack = 0x00C5F0E9,
        FallThroughFloor = 0x00C61216,
    }

    #endregion

    #region Base Pointers

    public enum BasePointer : int
    {
        Base = 0x400000,
        ServerBase = Base + 0xCE7930, //8B ? ? ? ? ? A1 ? ? ? ? 8D ? ? ? 51 8B CD 89 44 24 ? E8 ? ? ? ? 8B 70
        CharacterBase = Base + 0xCE7934, //8B ? ? ? ? ? 85 C9 74 ? 83 B8 ? ? ? ? 00 74 ? 8B ? ? ? ? ? 85 C0 7E ? 8B
        WallBase = Base + 0xCEC0C0, //8B ? ? ? ? ? 8B ? ? 8B ? ? ? ? ? 85 C0 74 ? 8B ? ? 48 ? ? 76 ? 6A
        AlertBase = Base + 0xCEC13C, //8B 15 ? ? ? ? 8B 4A ? 8D 0C 89 85 C9 74 27 8B
        PeopleBase = Base + 0xCEC140, //8B ? ? ? ? ? 50 E8 ? ? ? ? ? ? ? ? 0F 84 ? ? ? ? 39 ? ? ? ? ? 0F 85
        MonsterBase = Base + 0xCEC144, //8B 0D ? ? ? ? E8 ? ? ? ? 8B F8 89 7C 24 1C 33 ED
        StatBase = Base + 0xCEC418, //8B 0D ? ? ? ? 52 6A ? 56 E8 ? ? ? ? 8B BF
        MouseBase = Base + 0x0CEC708, //8B 0D ? ? ? ? 74 12 83 B9 ? ? ? ? ? 74 09 6A ? 6A ? E8 (1st)
        MapBase = Base + 0xCECA28, //8B ? ? ? ? ? 53 E8 ? ? ? ? 8B 44 ? ? C7 44 24 1C FF FF FF FF 85 C0 74 ? 83 C0
        ItemBase = Base + 0xCEFBF8, //89 3D ? ? ? ? 8D 4E ? C7 06
        PortalBase = Base + 0xCEFE14, //8B 3D ? ? ? ? 8B 47 ? 85 C0
    }

    #endregion

    #region Offset

    public enum Offset : int
    {
        //ServerBase
        WorldID = 0x2098, //8B 8F ? ? ? ? 8B 00 51 50 6A ? 8B CE C7 44 24 ? ? ? ? ? E8
        ChannelID = 0x209C, //WorldID + 4

        //CharacterBase
        Morph = 0x634, //8B 81 ? ? ? ? 56 8D B1 ? ? ? ? 85 C0 74 ? 50 E8
        BreathState = 0x6AC, //83 B8 ? ? ? ? 00 7E ? 6A 00 6A 00 6A 00 6A 00
        CharacterAnimation = 0x6B0, //BreathState + 4
        WatchedItemID = 0x7B40, //89 A9 ? ? 00 00 8B 40 ? C7 44 24 ? ? ? ? ? 85 C0
        Teleport = 0x7BB8, //83 BE ? ? ? ? 00 89 44 ? ? 0F 84 ? ? ? ? 8B
        TeleportX = 0x7BC0, //8B 8E ? ? 00 00 51 6A 00 ? ? FF D2 8B ? ? ? 00 00 8D BE ? ? ? ? 8D ? ? 50 8B
        TeleportY = 0x7BC4, //TeleportX + 4
        AttackCount = 0x7DDC, //89 ? ? ? 00 00 C7 ? ? ? 00 00 ? 00 00 00 89 ? ? ? 00 00 89 ? ? ? 00 00 89 ? ? ? 00 00 C7 ? ? ? 00 00 ? 00 00 00 89 ? ? ? 00 00 8D
        BuffCount = 0x7DEC, //AttackCount + 0x10
        CharacterX = 0x8D78, //89 8E ? ? ? ? 8B 50 ? 8B 06 89 96 ? ? ? ? 8B 50
        CharacterY = 0x8D7C, //CharacterX + 4

        //WallBase
        LeftWall = 0x1C,
        TopWall = 0x20,
        RightWall = 0x24,
        BottomWall = 0x28,

        //AlertBase
        AlertHP = 0x50, //8B 48 ? 8d 0C 89 85 C9 74 27 8B 7D ? 8B
        AlertMP = 0x54, //AlertHP + 4

        //PeopleBase
        PeopleCount = 0x18, //8B ? ? ? ? 7C ? 83 ? ? 7D ? 8B ? ? ? ? ? 8B 74 ? ? ? ? 74 ? 8B ? ? 8B

        //MonsterBase
        MobCount = 0x10,
        Mob1/*1st*/ = 0x28, //89 7E ? 89 7E ? ? ? ? ? ? 89 46 ? 89 46 ? 89 7E ? 89 7E ? 89 7E ? 89 ? ? 89
        Mob2/*2nd*/ = 0x04, //89 7B 04 89 44 24 14 0F 8E D6 FE ? ? C7 44 24 28 ? ? ? ? 85 F6 74 26 83 C6 F0
        Mob3/*3rd*/ = 0x130, //89 9E C4 01 ? ? 89 9E C8 01 ? ? 89 9E E8 01 ? ?
        Mob4/*4th*/ = 0x24, //89 5C 24 24 C7 01 ? ? ? ? 89 59 04 C7 41 08
        MobX/*5th*/ = 0x58, //89 6E 58 8D 7E 5C 89 2F 8D 5E 60 89 2B 8D 4E 70
        MobY/*5th*/ = 0x5C, //MobX + 4

        //StatBase
        ExpPercentage = 0x2108, //89 86 ? ? 00 00 5E C2 ? ? CC CC CC CC 68 ? ? ? ? 83 C1 
        HP = 0x21D4, //89 8E ? ? ? ? 8B 15 ? ? ? ? 8B 4A ? 8D 0C 89
        MP = 0x21D8, //HP + 4

        //MouseBase
        MouseLocation/*1st*/ = 0x978, //8B B1 ? ? ? ? 85 F6 75 ? 68 ? ? ? ? E8 ? ? ? 00 8B 4C 24 ? 8B 06 8B 90 ? ? ? ? F7 D9
        MouseX/*2nd*/ = 0x58, //8B 88 ? ? ? ? 6A ? 57 83 C5 ? 55
        MouseY/*2nd*/ = 0x5C, //MouseX + 4
        MouseAnimation = 0x9CC, //8B 87 ? ? ? ? 8B 4C 24 ? 3B C1

        //MapBase
        MapID = 0x11C8, //8B ? ? ? ? ? 50 51 8B 0D ? ? ? ? 8D ? ? ? 52 C6 84 ? ? ? ? ? 03 E8

        //ItemBase
        ItemCount = 0x14, //8B 4C 24 ? 83 C1 F8 83 F9 50 77 ? 0F ? ? ? ? ? ? FF

        //PortalBase
        PortalCount = 0x18,
    }

    #endregion
}
