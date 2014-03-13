using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aristotrainer.Structs
{
    public struct CharacterInformation
    {
        //public string Name { get; set; }

        public int HP { get; set; }

        public int MP { get; set; }

        public double EXPPercentage { get; set; }

        public int AlertHP { get; set; }

        public int AlertMP { get; set; }

        public Point Position { get; set; }

        public int Teleport { get; set; }

        public Point TeleportPosition { get; set; }

        public int WatchedItemID { get; set; }

        public byte AttackCount { get; set; }

        public int BuffCount { get; set; }

        public int Morph { get; set; }

        public int BreathState { get; set; }

        public int CharacterAnimation { get; set; }

        public int MouseAnimation { get; set; }

        public Point MouseLocation { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("HP: {0}\r\n", HP);
            sb.AppendFormat("MP: {0}\r\n", MP);
            sb.AppendFormat("EXP Percentage: {0}%\r\n", EXPPercentage.ToString("N2"));
            sb.AppendFormat("Alert HP: {0}\r\n", AlertHP);
            sb.AppendFormat("Alert MP: {0}\r\n", AlertMP);
            sb.AppendFormat("Position: X: {0} Y: {1}\r\n", Position.X, Position.Y);
            sb.AppendFormat("Teleport: {0}\r\n", Teleport);
            sb.AppendFormat("Teleport Position: X: {0} Y: {1}\r\n", TeleportPosition.X, TeleportPosition.Y);
            sb.AppendFormat("Mouse Animation: {0}\r\n", MouseAnimation);
            sb.AppendFormat("Mouse Location: X: {0} Y: {1}\r\n", MouseLocation.X, MouseLocation.Y);
            sb.AppendFormat("Watched ItemID: {0}\r\n", WatchedItemID);
            sb.AppendFormat("Attack Count: {0}\r\n", AttackCount);
            sb.AppendFormat("Buff Count: {0}\r\n", BuffCount);
            sb.AppendFormat("Morph: {0}\r\n", Morph);
            sb.AppendFormat("Breath Status: {0}\r\n", BreathState.ToString());
            sb.AppendFormat("Animation: {0}\r\n", CharacterAnimation);

            return sb.ToString();
        }
    }
}
