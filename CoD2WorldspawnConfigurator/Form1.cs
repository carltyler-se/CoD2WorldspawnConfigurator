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
        string sourceFolderURL = "";
        List<string> mapNames = new List<string>();
        MapInfo loadedMap = new MapInfo();

        int sliderMultiplier = 100;

        public Form1()
        {
            InitializeComponent();
            Settings.SettingsFileLocation = Directory.GetCurrentDirectory() + "\\settings.ini";
            MapHandler.SetMapSourceFolder(Settings.GetMapSourceFolderUrl());
            PreloadMapsFromURL(Settings.GetMapSourceFolderUrl());

        }

        private void PreloadMapsFromURL(string url)
        {
            loadedMap = null;
            sourceFolderURL = url;
            mapNames = MapHandler.GetAllMapNamesInFolder(sourceFolderURL).ToList();
            LoadListBoxWithNames(mapNames);
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
            // remove saved map
            loadedMap = null;

            //RGB pickers
            foreach(Control c in grpbox_worldspawn.Controls)
            {
                if(c is NumericUpDown)
                {
                    NumericUpDown b = (NumericUpDown)c;
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
            lbl_loadedmap.Text = loadedMap.Name;
            UpdateUIValues();
        }

        private void UpdateUIValues()
        {
            lbl_northyaw_value.Text = slider_northyaw.Value.ToString();
            lbl_ambient_value.Text = slider_ambient.Value.ToString();
            lbl_diffusefraction_value.Text = slider_diffusefraction.Value.ToString();
            lbl_sunlight_value.Text = slider_sunlight.Value.ToString();
            lbl_contrastgain_value.Text = slider_contrastgain.Value.ToString();
            lbl_bouncefraction_value.Text = slider_bouncefraction.Value.ToString();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if(loadedMap != null)
            {
                DialogResult result = MessageBox.Show($@"Are you sure you want to overwrite the worldspawn of {loadedMap.Name}?", "Caution", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    string worldspawnString = "";
                    foreach (WorldspawnKeyVal keyVal in loadedMap.Worldspawn.GetWorldspawnKeyVals())
                    {
                        worldspawnString += $@"{keyVal.Key}: {keyVal.Value}{System.Environment.NewLine}";
                    }
                    MessageBox.Show("Saving map " + loadedMap.Name + " with worldspawn:\n" + worldspawnString);
                    
                    // Save the map using MapHandler
                }
                else if (result == DialogResult.No)
                {
                    // Reloaded the maps current worldspawn
                }
            }
        }


        private void btn_load_Click(object sender, EventArgs e)
        {
            // Open a folder browser
            FolderBrowserDialog browser = new FolderBrowserDialog();
            DialogResult result = browser.ShowDialog();


            if(result == DialogResult.OK)
            {
                sourceFolderURL = browser.SelectedPath;
                lbl_folderPath.Text = sourceFolderURL;
                Settings.SaveMapSourceLocationToFile(sourceFolderURL);
            }

            // Get all maps from the chosen folder
            loadedMap = null;
            mapNames = MapHandler.GetAllMapNamesInFolder(sourceFolderURL).ToList();

            LoadListBoxWithNames(mapNames);
               
        }

        private void LoadListBoxWithNames(List<string> names)
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

            int maxRGB = 256;
            int minRGB = 0;

            // TODO: NORMALISE RGB VALUES FROM MAX OF 1 TO 256
            string[] colorVals = w.GetKeyVal("_color").Value.Split(' ');
            //      z      = ( x – min(x)) / (max(x) – min(x)) * 100
            // normalisedR = (256 - 0) / ()


            numeric_color_r.Value = int.Parse(colorVals[0]);
            numeric_color_g.Value = int.Parse(colorVals[1]);
            numeric_color_b.Value = int.Parse(colorVals[2]);

            string[] sunColorVals = w.GetKeyVal("suncolor").Value.Split(' ');
            numeric_suncolor_r.Value = int.Parse(sunColorVals[0]);
            numeric_suncolor_g.Value = int.Parse(sunColorVals[1]);
            numeric_suncolor_b.Value = int.Parse(sunColorVals[2]);

            string[] sunDiffuseColorVals = w.GetKeyVal("sundiffusecolor").Value.Split(' ');
            numeric_sundiffusecolor_r.Value = int.Parse(sunDiffuseColorVals[0]);
            numeric_sundiffusecolor_g.Value = int.Parse(sunDiffuseColorVals[1]);
            numeric_sundiffusecolor_b.Value = int.Parse(sunDiffuseColorVals[2]);

            string[] sunDirectionVals = w.GetKeyVal("sundirection").Value.Split(' ');
            numeric_sundirection_x.Value = int.Parse(sunDirectionVals[0]);
            numeric_sundirection_y.Value = int.Parse(sunDirectionVals[1]);
            numeric_sundirection_z.Value = int.Parse(sunDirectionVals[2]);

            slider_ambient.Value = int.Parse(w.GetKeyVal("ambient").Value) * sliderMultiplier;
            slider_northyaw.Value = int.Parse(w.GetKeyVal("northyaw").Value) * sliderMultiplier;
            slider_diffusefraction.Value = int.Parse(w.GetKeyVal("diffusefraction").Value) * sliderMultiplier;
            slider_sunlight.Value = int.Parse(w.GetKeyVal("sunlight").Value) * sliderMultiplier;
            slider_contrastgain.Value = int.Parse(w.GetKeyVal("contrastgain").Value) * sliderMultiplier;
            slider_bouncefraction.Value = int.Parse(w.GetKeyVal("bouncefraction").Value) * sliderMultiplier;

            UpdateUI();
        }

        private void lbl_loadedmapname_Click(object sender, EventArgs e)
        {

        }

        private void btn_default_Click(object sender, EventArgs e)
        {

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
                        string worldspawnString = "";
                
                        if (loadedMap.Worldspawn.Count() == 0) 
                            worldspawnString = $@"No Worldspawn Found";
                        else 
                        { 
                            foreach (WorldspawnKeyVal keyVal in loadedMap.Worldspawn.GetWorldspawnKeyVals())
                            {
                                worldspawnString += $@"{keyVal.Key}, {keyVal.Value}{System.Environment.NewLine}";
                            }        
                        }    
                        MessageBox.Show($@"Loading values for {loadedMap.Name}{System.Environment.NewLine}{worldspawnString}");

                        SetUIValues();
                
                    }
                }

            }

        }
    }
}
