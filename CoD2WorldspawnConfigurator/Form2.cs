using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoD2WorldspawnConfigurator
{
    public partial class Form2 : Form
    {
        private List<MapInfo> stockWorldspawns;
        public List<MapInfo> StockWorldspawns { get { return stockWorldspawns; } set { stockWorldspawns = value; } }

        private List<string> myWorldspawns;
        public List<string> MyWorldspawns { get { return myWorldspawns; } set { myWorldspawns = value; } }

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(List<string> mapNames)
        {
            InitializeComponent();
            StockWorldspawns = GenerateStockWorldspawns();
            MyWorldspawns = mapNames;

            LoadListBoxes();
        }

        private List<MapInfo> GenerateStockWorldspawns()
        {
            List<MapInfo> maps = new List<MapInfo>();

            //maps.Add(PackMapInfo("mapName", "northyaw", "_color", "ambient", "diffuseFraction", "sunColor", "sunDiffuseColor",
            //                      "sunlight", "sunDirection", "contrastGain", "bounceFraction"));
            // TODO: hardcode map info

            return maps;
        }

        private MapInfo PackMapInfo(string mapName, string northyaw, string _color, string ambient, string diffuseFraction,
                                    string sunColor, string sunDiffuseColor, string sunlight, string sunDirection, string contrastGain, 
                                    string bounceFraction)
        {
            MapInfo mapInfo = new MapInfo();

            mapInfo.Name = mapName;
            mapInfo.FileURL = "";
            mapInfo.Worldspawn.InsertKeyVal(new WorldspawnKeyVal("classname",       "worldspawn"));
            mapInfo.Worldspawn.InsertKeyVal(new WorldspawnKeyVal("northyaw",        northyaw));
            mapInfo.Worldspawn.InsertKeyVal(new WorldspawnKeyVal("_color",          _color));
            mapInfo.Worldspawn.InsertKeyVal(new WorldspawnKeyVal("ambient",         ambient));
            mapInfo.Worldspawn.InsertKeyVal(new WorldspawnKeyVal("diffusefraction", diffuseFraction));
            mapInfo.Worldspawn.InsertKeyVal(new WorldspawnKeyVal("suncolor",        sunColor));
            mapInfo.Worldspawn.InsertKeyVal(new WorldspawnKeyVal("sundiffusecolor", sunDiffuseColor));
            mapInfo.Worldspawn.InsertKeyVal(new WorldspawnKeyVal("sunlight",        sunlight));
            mapInfo.Worldspawn.InsertKeyVal(new WorldspawnKeyVal("sundirection",    sunDirection));
            mapInfo.Worldspawn.InsertKeyVal(new WorldspawnKeyVal("contrastgain",    contrastGain));
            mapInfo.Worldspawn.InsertKeyVal(new WorldspawnKeyVal("bouncefraction",  bounceFraction));

            return mapInfo;
        }

        private void LoadListBoxes()
        {
            listbox_myworldspawns.Items.Clear();
            listbox_stockworldspawns.Items.Clear();

            foreach(MapInfo map in stockWorldspawns)
            {
                listbox_stockworldspawns.Items.Add(map.Name);
            }
            foreach(string mapName in MyWorldspawns)
            {
                listbox_myworldspawns.Items.Add(mapName);
            }
            
        }
    }
}
