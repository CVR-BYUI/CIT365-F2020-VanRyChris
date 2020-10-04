using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk
{
    class Desk
    {
        // Constants
        public const int MINWIDTH = 24;
        public const int MAXWIDTH = 96;
        public const int MINDEPTH = 12;
        public const int MAXDEPTH = 48;

        // Object constructor
        public int Width { get; set; }
        public int Depth { get; set; }
        public int SurfaceArea { get; set; }
        public int DrawerCount { get; set; }
        public string DesktopMaterial { get; set; }

    }
}