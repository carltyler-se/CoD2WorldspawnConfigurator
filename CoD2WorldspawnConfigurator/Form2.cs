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

        private Worldspawn selectedWorldspawn;
        public Worldspawn SelectedWorldspawn { get { return selectedWorldspawn; } set { selectedWorldspawn = value; } }

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
            maps.Add(PackMapInfo("mp_breakout", "90", "1 0.95 0.95", "0.05", "0.31", "0.9 0.95 1", "0.80 0.82 0.85",
                                  "1.5", "-137 305 0", "1", "1"));
            maps.Add(PackMapInfo("mp_brecourt", "90", "0.47 0.56 0.62", "0.00", "0.35", "1 1 1", "0.9 0.95 1",
                                  "0.8", "-40 44 0", "1", "1"));
            maps.Add(PackMapInfo("mp_burgundy", "0", "0 0.5 1", "0.02", "0.3", "1 0.95 0.85", "0.85 0.9 1",
                                  "1.5", "-45 210 0", "1", "1"));
            maps.Add(PackMapInfo("mp_carentan", "0", "0.85 0.9 1", "0", "0.56", "1 0.95 0.85", "0.85 0.9 1",
                                  "1.8", "-40 -138 0", "1", "1"));
            maps.Add(PackMapInfo("mp_dawnville", "90", "0 0 0", "0", "0.6", "0.9 0.92 0.85", "0.85 0.9 1",
                                  "1.2", "-57 169 0", "1", "1"));
            maps.Add(PackMapInfo("mp_decoy", "180", "0 0 0", "0.0", "0.4", "0.5 0.52 0.55", "0.15 0.21 0.6",
                                  "0.47", "-60 245 0", "1", "1"));
            maps.Add(PackMapInfo("mp_downtown", "0", "1 0.96 0.98", "0.0", "0.4", "1 0.96 0.98", "0.9 0.9 0.96",
                                  "1.15", "-24 -127 0", "0.4", "1"));
            maps.Add(PackMapInfo("mp_farmhouse", "0", "0.89 0.70 0.41", "0", "0.4", "0.94 0.62 0.5", "0.58 0.59 0.71",
                                  "1.3", "-19 -70 0", "1", "1"));
            maps.Add(PackMapInfo("mp_leningrad", "0", "1 0.96 1.98", "0", "0.52", "1 0.96 0.98", "0.9 0.9 0.96",
                                  "1.15", "-70 35 0", "1", "1"));
            maps.Add(PackMapInfo("mp_matmata", "0", "1.0 0.78 0.30", "0.02", "0.45", "1 0.98 0.85", "1.0 0.86 0.89",
                                  "1.45", "-20 315 0", "1", "1"));
            maps.Add(PackMapInfo("mp_railyard", "0", "1 1 1", "0.1", "0.65", "1 1 1", "1 1 1",
                                  "1.3", "-40 225 0", "1", "1"));
            maps.Add(PackMapInfo("mp_toujane", "0", "0.81 0.80 0.70", "0.02", "0.4", "0.98 0.88 0.75", "0.98 0.88 0.92",
                                  "1.3", "-45 135 0", "1", "1"));
            maps.Add(PackMapInfo("mp_trainstation", "0", "0.85 0.90 1", "0.02", "0.3", "1 0.95 0.85", "0.85 0.90 1",
                                  "1.5", "-45 210 0", "1", "1"));
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
                string[] nameSplits = mapName.Split('\\');
                listbox_myworldspawns.Items.Add(nameSplits[nameSplits.Length - 1]);
            }
            
        }

        private void PrintWorldspawn(Worldspawn wsToPrint)
        {
            textbox_worldspawndata.Clear();
            textbox_worldspawndata.Refresh();
            if (wsToPrint != null)
            {
                foreach (WorldspawnKeyVal kv in wsToPrint.GetWorldspawnKeyVals())
                {
                    textbox_worldspawndata.Text += "\"" + kv.Key + "\" \"" + kv.Value + "\"" + Environment.NewLine;
                }
            }
            else 
                textbox_worldspawndata.Text = "No Worldspawn Found";
        }

        private void listbox_stockworldspawns_SelectedIndexChanged(object sender, EventArgs e)
        {
            listbox_myworldspawns.SelectedIndex = -1;
            if (listbox_stockworldspawns.SelectedIndex == -1) 
            {
                btn_copy.Enabled = false;
                return;
            }
            
            if(listbox_stockworldspawns.SelectedIndex > -1)
            {
                btn_copy.Enabled = true;
                MapInfo info = StockWorldspawns[listbox_stockworldspawns.SelectedIndex];
                SelectedWorldspawn = info.Worldspawn;
                PrintWorldspawn(SelectedWorldspawn);
            }
        }

        private void listbox_myworldspawns_SelectedIndexChanged(object sender, EventArgs e)
        {
            listbox_stockworldspawns.SelectedIndex = -1;
            if (listbox_myworldspawns.SelectedIndex == -1)
            {
                btn_copy.Enabled = false;
                return;
            }

            btn_copy.Enabled = true;
            string mapURL = myWorldspawns[listbox_myworldspawns.SelectedIndex];
            MapInfo info = MapHandler.GetMapInfo(mapURL);
            SelectedWorldspawn = info.Worldspawn;
            PrintWorldspawn(SelectedWorldspawn);
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btn_copy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            SelectedWorldspawn = null;
            listbox_myworldspawns.SelectedIndex = -1;
            listbox_stockworldspawns.SelectedIndex = -1;
            btn_copy.Enabled = false;
            textbox_worldspawndata.Clear();
            textbox_worldspawndata.Refresh();
        }
    }
}
