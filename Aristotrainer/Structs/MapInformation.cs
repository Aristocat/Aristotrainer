using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aristotrainer.Structs
{
    public struct MapInformation
    {
        public int MapID { get; set; }

        public int PeopleCount { get; set; }

        public int PortalCount { get; set; }

        public int MobCount { get; set; }

        public Point MobPosition { get; set; }

        public int ItemCount { get; set; }

        public int LeftWall { get; set; }

        public int TopWall { get; set; }

        public int RightWall { get; set; }

        public int BottomWall { get; set; }

        public Point MapCenter { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Map: {0}\r\n", MapID);
            sb.AppendFormat("Character Count: {0}\r\n", PeopleCount);
            sb.AppendFormat("Portal Count: {0}\r\n", PortalCount);
            sb.AppendFormat("Monster Count: {0}\r\n", MobCount);
            sb.AppendFormat("Item Count: {0}\r\n", ItemCount);
            sb.AppendFormat("Mob Position: X: {0} Y: {1}\r\n", MobPosition.X, MobPosition.Y);

            return sb.ToString();
        }
    }
}
