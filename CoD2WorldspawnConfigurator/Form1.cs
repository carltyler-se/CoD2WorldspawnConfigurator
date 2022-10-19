using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoD2WorldspawnConfigurator
{
    public partial class Form1 : Form
    {
        string _sourceFolderURL = "";
        List<string> mapNames = new List<string>();
        MapInfo loadedMap = null;

        decimal sliderMultiplier = 100;

        public Form1()
        {
            InitializeComponent();
            AddToolTips();


            // Set where the settings file is located
            Settings.SettingsFileLocation = Directory.GetCurrentDirectory() + "\\settings.ini";

            SetSourceFolder(Settings.GetMapSourceFolderUrl());

            if(Directory.Exists(_sourceFolderURL))
            {
                LoadMapsFromURL(_sourceFolderURL);
            }
            else
            {
                mapNames = new List<string>();
            }
        }

        private void SetSourceFolder(string newURL)
        {
            _sourceFolderURL = newURL;
            Settings.SaveMapSourceLocationToFile(_sourceFolderURL);
            MapHandler.MapSourceFolder = _sourceFolderURL;
        }

        private void AddToolTips()
        {
            ToolTip toolTipClassname = new ToolTip();
            toolTipClassname.ToolTipIcon = ToolTipIcon.Info;
            toolTipClassname.IsBalloon = true;
            toolTipClassname.ShowAlways = false;
            toolTipClassname.ToolTipTitle = "Classname";
            toolTipClassname.SetToolTip(lbl_classname, WorldspawnDescription.Classname);

            ToolTip toolTipNorthyaw = new ToolTip();
            toolTipNorthyaw.ToolTipIcon = ToolTipIcon.Info;
            toolTipNorthyaw.IsBalloon = true;
            toolTipNorthyaw.ShowAlways = false;
            toolTipNorthyaw.ToolTipTitle = "Northyaw";
            toolTipNorthyaw.SetToolTip(lbl_northyaw, WorldspawnDescription.Northyaw);

            ToolTip toolTipColor = new ToolTip();
            toolTipColor.ToolTipIcon = ToolTipIcon.Info;
            toolTipColor.IsBalloon = true;
            toolTipColor.ShowAlways = false;
            toolTipColor.ToolTipTitle = "Color";
            toolTipColor.SetToolTip(lbl_color, WorldspawnDescription.Color);

            ToolTip toolTipAmbient = new ToolTip();
            toolTipAmbient.ToolTipIcon = ToolTipIcon.Info;
            toolTipAmbient.IsBalloon = true;
            toolTipAmbient.ShowAlways = false;
            toolTipAmbient.ToolTipTitle = "Ambient";
            toolTipAmbient.SetToolTip(lbl_ambient, WorldspawnDescription.Ambient);

            ToolTip toolTipDiffuseFraction = new ToolTip();
            toolTipDiffuseFraction.ToolTipIcon = ToolTipIcon.Info;
            toolTipDiffuseFraction.IsBalloon = true;
            toolTipDiffuseFraction.ShowAlways = false;
            toolTipDiffuseFraction.ToolTipTitle = "Diffuse Fraction";
            toolTipDiffuseFraction.SetToolTip(lbl_diffusefraction, WorldspawnDescription.DiffuseFraction);

            ToolTip toolTipSunColor = new ToolTip();
            toolTipSunColor.ToolTipIcon = ToolTipIcon.Info;
            toolTipSunColor.IsBalloon = true;
            toolTipSunColor.ShowAlways = false;
            toolTipSunColor.ToolTipTitle = "Sun Color";
            toolTipSunColor.SetToolTip(lbl_suncolor, WorldspawnDescription.SunColor);

            ToolTip toolTipSunDiffuseColor = new ToolTip();
            toolTipSunDiffuseColor.ToolTipIcon = ToolTipIcon.Info;
            toolTipSunDiffuseColor.IsBalloon = true;
            toolTipSunDiffuseColor.ShowAlways = false;
            toolTipSunDiffuseColor.ToolTipTitle = "Sun Diffuse Color";
            toolTipSunDiffuseColor.SetToolTip(lbl_sundiffusecolor, WorldspawnDescription.SunDiffuseColor);

            ToolTip toolTipSunlight = new ToolTip();
            toolTipSunlight.ToolTipIcon = ToolTipIcon.Info;
            toolTipSunlight.IsBalloon = true;
            toolTipSunlight.ShowAlways = false;
            toolTipSunlight.ToolTipTitle = "Sunlight";
            toolTipSunlight.SetToolTip(lbl_sunlight, WorldspawnDescription.Sunlight);

            ToolTip toolTipSunDirection = new ToolTip();
            toolTipSunDirection.ToolTipIcon = ToolTipIcon.Info;
            toolTipSunDirection.IsBalloon = true;
            toolTipSunDirection.ShowAlways = false;
            toolTipSunDirection.ToolTipTitle = "Sun Direction";
            toolTipSunDirection.SetToolTip(lbl_sundirection, WorldspawnDescription.SunDirection);

            ToolTip toolTipContrastGain = new ToolTip();
            toolTipContrastGain.ToolTipIcon = ToolTipIcon.Info;
            toolTipContrastGain.IsBalloon = true;
            toolTipContrastGain.ShowAlways = false;
            toolTipContrastGain.ToolTipTitle = "Contrast Gain";
            toolTipContrastGain.SetToolTip(lbl_contrastgain, WorldspawnDescription.ContrastGain);

            ToolTip toolTipBounceFraction = new ToolTip();
            toolTipBounceFraction.ToolTipIcon = ToolTipIcon.Info;
            toolTipBounceFraction.IsBalloon = true;
            toolTipBounceFraction.ShowAlways = false;
            toolTipBounceFraction.ToolTipTitle = "Bounce Fraction";
            toolTipBounceFraction.SetToolTip(lbl_bouncefraction, WorldspawnDescription.BounceFraction);
        }

        private void LoadMapsFromURL(string url)
        {
            loadedMap = null;
            mapNames = MapHandler.GetAllMapNamesInFolder(_sourceFolderURL).ToList();
            LoadListBox(mapNames);
            lbl_folderPath.Text = Settings.GetMapSourceFolderUrl();
            ZeroiseForm();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lbl_classname_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void slider_northyaw_Scroll(object sender, EventArgs e)
        {
            UpdateUIValues();
        }

        private void slider_ambient_Scroll(object sender, EventArgs e)
        {
            UpdateUIValues();
        }

        private void slider_diffusefraction_Scroll(object sender, EventArgs e)
        {
            UpdateUIValues();
        }

        private void slider_sunlight_Scroll(object sender, EventArgs e)
        {
            UpdateUIValues();
        }

        private void slider_contrastgain_Scroll(object sender, EventArgs e)
        {
            UpdateUIValues();
        }

        private void slider_bouncefraction_Scroll(object sender, EventArgs e)
        {
            UpdateUIValues();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            ZeroiseForm();
        }

        private void ZeroiseForm()
        {
            // remove saved map
            loadedMap = null;

            //RGB pickers
            foreach (Control c in grpbox_worldspawn.Controls)
            {
                if (c is NumericUpDown)
                {
                    NumericUpDown b = (NumericUpDown)c;
                    b.Value = 0;
                }
                if(c is TrackBar)
                {
                    TrackBar b = (TrackBar)c;
                    b.Value = 0;
                }
            }

            //sliders
            slider_northyaw.Value = 0;
            slider_ambient.Value = 0;
            slider_diffusefraction.Value = 0;
            slider_sunlight.Value = 0;
            slider_contrastgain.Value = 0;
            slider_bouncefraction.Value = 0;

            UpdateUI();
        }

        private void UpdateUI()
        {
            if (loadedMap != null)
                lbl_loadedmapname.Text = loadedMap.Name;
            else
                lbl_loadedmapname.Text = "[No Map Selected]";

            UpdateUIValues();
        }

        private void UpdateUIValues()
        {
            lbl_northyaw_value.Text = slider_northyaw.Value.ToString();
            lbl_ambient_value.Text = (slider_ambient.Value / sliderMultiplier).ToString();
            lbl_diffusefraction_value.Text = (slider_diffusefraction.Value / sliderMultiplier).ToString();
            lbl_sunlight_value.Text = (slider_sunlight.Value / sliderMultiplier).ToString();
            lbl_contrastgain_value.Text = (slider_contrastgain.Value / sliderMultiplier).ToString();
            lbl_bouncefraction_value.Text = (slider_bouncefraction.Value / sliderMultiplier).ToString();
        }

        private void SetButtonsEnabled(bool val)
        {
            btn_save.Enabled = val;
            btn_default.Enabled = val;
        }

        private void ToggleButtonsEnabled()
        {
            btn_save.Enabled = !btn_save.Enabled;
            btn_default.Enabled = !btn_default.Enabled;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if(loadedMap != null)
            {
                DialogResult result = MessageBox.Show($@"Are you sure you want to overwrite the worldspawn of {loadedMap.Name}?", "Caution", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    // Extract the values from the UI
                    loadedMap.Worldspawn = GetWorldspawnFromUI();

                    // Save the map using MapHandler
                    //MapHandler.SaveWorldspawnSettings(loadedMap.Name, loadedMap.Worldspawn.GetWorldspawnKeyVals());

                    // Save the map using MapHandler with a backup before the change
                    MapHandler.SaveWorldspawnSettingsWithBackup(loadedMap.FileURL, loadedMap.Worldspawn.GetWorldspawnKeyVals());
                }

                //Refresh the map list
                int previousSelectionIndex = listBox_MapList.SelectedIndex;
                mapNames = MapHandler.GetAllMapNamesInFolder(_sourceFolderURL).ToList();
                LoadListBox(mapNames);
                listBox_MapList.SelectedIndex = previousSelectionIndex;
                SetUIValues();
            }
        }

        private Worldspawn GetWorldspawnFromUI()
        {
            Worldspawn ws = new Worldspawn();

            ws.InsertKeyVal(new WorldspawnKeyVal("classname", "worldspawn"));
            ws.InsertKeyVal(new WorldspawnKeyVal("northyaw", $@"{slider_northyaw.Value}"));
            ws.InsertKeyVal(new WorldspawnKeyVal("_color", $@"{numeric_color_r.Value} {numeric_color_g.Value} {numeric_color_b.Value}"));
            ws.InsertKeyVal(new WorldspawnKeyVal("ambient", $@"{slider_ambient.Value / sliderMultiplier}"));
            ws.InsertKeyVal(new WorldspawnKeyVal("diffusefraction", $@"{slider_diffusefraction.Value / sliderMultiplier}"));
            ws.InsertKeyVal(new WorldspawnKeyVal("suncolor", $@"{numeric_suncolor_r.Value} {numeric_suncolor_g.Value} {numeric_suncolor_b.Value}"));
            ws.InsertKeyVal(new WorldspawnKeyVal("sundiffusecolor", $@"{numeric_sundiffusecolor_r.Value} {numeric_sundiffusecolor_g.Value} {numeric_sundiffusecolor_b.Value}"));
            ws.InsertKeyVal(new WorldspawnKeyVal("sunlight", $@"{slider_sunlight.Value / sliderMultiplier}"));
            ws.InsertKeyVal(new WorldspawnKeyVal("sundirection", $@"{numeric_sundirection_x.Value} {numeric_sundirection_y.Value} {numeric_sundirection_z.Value}"));
            ws.InsertKeyVal(new WorldspawnKeyVal("contrastgain", $@"{slider_contrastgain.Value / sliderMultiplier}"));
            ws.InsertKeyVal(new WorldspawnKeyVal("bouncefraction", $@"{slider_bouncefraction.Value / sliderMultiplier}"));

            return ws;

        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            // Open a folder browser
            FolderBrowserDialog browser = new FolderBrowserDialog();
            DialogResult result = browser.ShowDialog();

            if(result == DialogResult.OK)
            {
                _sourceFolderURL = browser.SelectedPath;
                lbl_folderPath.Text = _sourceFolderURL;
                SetSourceFolder(_sourceFolderURL);
                SetButtonsEnabled(false);

                LoadMapsFromURL(_sourceFolderURL);

                loadedMap = null;
                mapNames = MapHandler.GetAllMapNamesInFolder(_sourceFolderURL).ToList();
                LoadListBox(mapNames);
            }
            else if(result == DialogResult.Cancel)
            {

            }               
        }

        private void LoadListBox(List<string> names)
        {
            listBox_MapList.Items.Clear();
            foreach(string n in names)
            {
                if (n.EndsWith(".map"))
                {
                    string[] nameSplit = n.Split('\\');
                    listBox_MapList.Items.Add(nameSplit[nameSplit.Length - 1]);
                }
            }
        }

        private void SetUIValues()
        {
            if (loadedMap == null) return;

            Worldspawn w = loadedMap.Worldspawn;

            textBox1.Text = w.GetKeyVal("classname").Value;

            string[] colorVals = w.GetKeyVal("_color").Value.Split(' '); 
            numeric_color_r.Value = decimal.Parse(colorVals[0]);
            numeric_color_g.Value = decimal.Parse(colorVals[1]);
            numeric_color_b.Value = decimal.Parse(colorVals[2]);

            string[] sunColorVals = w.GetKeyVal("suncolor").Value.Split(' ');
            numeric_suncolor_r.Value = decimal.Parse(sunColorVals[0]);
            numeric_suncolor_g.Value = decimal.Parse(sunColorVals[1]);
            numeric_suncolor_b.Value = decimal.Parse(sunColorVals[2]);

            string[] sunDiffuseColorVals = w.GetKeyVal("sundiffusecolor").Value.Split(' ');
            numeric_sundiffusecolor_r.Value = decimal.Parse(sunDiffuseColorVals[0]);
            numeric_sundiffusecolor_g.Value = decimal.Parse(sunDiffuseColorVals[1]);
            numeric_sundiffusecolor_b.Value = decimal.Parse(sunDiffuseColorVals[2]);

            string[] sunDirectionVals = w.GetKeyVal("sundirection").Value.Split(' ');
            numeric_sundirection_x.Value = int.Parse(sunDirectionVals[0]);
            numeric_sundirection_y.Value = int.Parse(sunDirectionVals[1]);
            numeric_sundirection_z.Value = int.Parse(sunDirectionVals[2]);

            slider_ambient.Value = (int)(decimal.Parse(w.GetKeyVal("ambient").Value) * sliderMultiplier);
            slider_northyaw.Value = (int)(decimal.Parse(w.GetKeyVal("northyaw").Value));
            slider_diffusefraction.Value = (int)(decimal.Parse(w.GetKeyVal("diffusefraction").Value) * sliderMultiplier);
            slider_sunlight.Value = (int)(decimal.Parse(w.GetKeyVal("sunlight").Value) * sliderMultiplier);
            slider_contrastgain.Value = (int)(decimal.Parse(w.GetKeyVal("contrastgain").Value) * sliderMultiplier);
            slider_bouncefraction.Value = (int)(decimal.Parse(w.GetKeyVal("bouncefraction").Value) * sliderMultiplier);

            UpdateUI();
        }

        private void lbl_loadedmapname_Click(object sender, EventArgs e)
        {

        }

        private void btn_default_Click(object sender, EventArgs e)
        {
            SetUIValues();
        }

        private void listBox_MapList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string chosenMapURL;
            loadedMap = null;
            if(listBox_MapList.SelectedIndex != -1)
            {

                if (mapNames[listBox_MapList.SelectedIndex] != null)
                    chosenMapURL = mapNames[listBox_MapList.SelectedIndex];
                else 
                    chosenMapURL = "";
                
                if (chosenMapURL != "")
                {
                    loadedMap = MapHandler.GetMapInfo(chosenMapURL);
                
                    if(loadedMap != null)
                    {
                        if(loadedMap.Worldspawn != null)
                        {
                            if (loadedMap.Worldspawn.Count() == 0)
                            {
                                MessageBox.Show($@"No Worldspawn Found", "Warning");
                                listBox_MapList.SelectedIndex = -1;
                                SetButtonsEnabled(false);
                                SetUIValues();
                                ZeroiseForm();
                            }
                            else
                            {
                                SetButtonsEnabled(true);
                                SetUIValues();
                            }
                        }
                    }
                }
            }
            else { SetButtonsEnabled(false); }
        }
    }
}
