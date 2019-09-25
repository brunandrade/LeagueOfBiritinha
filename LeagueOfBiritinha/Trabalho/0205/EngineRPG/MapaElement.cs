using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EngineRPG.MapElements;
using Windows.UI.Xaml.Controls;

namespace EngineRPG
{
    public abstract class MapaElement
    {
        public int CoordX { get; set; }
        public int CoordY { get; set; }
        public int caminhar = 0;
        public int NumItem=0;
    }
}
