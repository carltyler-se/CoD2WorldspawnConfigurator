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
    public partial class Form1 : Form
    {
        MapInfo loadedMap = new MapInfo();

        public Form1()
        {
            InitializeComponent();
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
            lbl_loadedmapname.Text = "[No Map Selected]";
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
            MessageBox.Show("Function Not Implemented");
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            // load the map
            loadTestMap();

            // if map loaded properly, load the values into ui
            if(loadedMap != null)
            {
                LoadMapValues(loadedMap);
            }
                
        }

        private void loadTestMap()
        {
            loadedMap = new MapInfo("placeholder/directory");
            loadedMap.Name = "mp_testmap";
            loadedMap.InsertWorldspawnValue(new WorldspawnKeyVal("classname","worldspawn"));
            loadedMap.InsertWorldspawnValue(new WorldspawnKeyVal("northyaw", "90"));
            loadedMap.InsertWorldspawnValue(new WorldspawnKeyVal("_color", "50 50 50"));
            loadedMap.InsertWorldspawnValue(new WorldspawnKeyVal("ambient", "0.8"));
            loadedMap.InsertWorldspawnValue(new WorldspawnKeyVal("diffusefraction", "0.2"));
            loadedMap.InsertWorldspawnValue(new WorldspawnKeyVal("suncolor", "50 51 52"));
            loadedMap.InsertWorldspawnValue(new WorldspawnKeyVal("sundiffusecolor", "255 240 242"));
            loadedMap.InsertWorldspawnValue(new WorldspawnKeyVal("sunlight", "1.2"));
            loadedMap.InsertWorldspawnValue(new WorldspawnKeyVal("sundirection", "256 130 0"));
            loadedMap.InsertWorldspawnValue(new WorldspawnKeyVal("contrastgain", "0.4"));
            loadedMap.InsertWorldspawnValue(new WorldspawnKeyVal("bouncefraction", "0.5"));

            UpdateUI();
        }

        private void LoadMapValues(MapInfo map)
        {
            // Map name
            lbl_loadedmapname.Text = loadedMap.Name;

            // _color
            string[] color_string = map.GetWorldspawnValue("_color").Value.Split(' ');
            numeric_color_r.Value = int.Parse(color_string[0]);
            numeric_color_g.Value = int.Parse(color_string[1]);
            numeric_color_b.Value = int.Parse(color_string[2]);

            // suncolor
            string[] suncolor_string = map.GetWorldspawnValue("suncolor").Value.Split(' ');
            numeric_suncolor_r.Value = int.Parse(suncolor_string[0]);
            numeric_suncolor_g.Value = int.Parse(suncolor_string[1]);
            numeric_suncolor_b.Value = int.Parse(suncolor_string[2]);

            // sundiffusecolor
            string[] sundiffusecolor_string = map.GetWorldspawnValue("sundiffusecolor").Value.Split(' ');
            numeric_sundiffusecolor_r.Value = int.Parse(sundiffusecolor_string[0]);
            numeric_sundiffusecolor_g.Value = int.Parse(sundiffusecolor_string[1]);
            numeric_sundiffusecolor_b.Value = int.Parse(sundiffusecolor_string[2]);

            // sundirection
            string[] sundirection_string = map.GetWorldspawnValue("sundirection").Value.Split(' ');
            numeric_sundirection_x.Value = int.Parse(sundirection_string[0]);
            numeric_sundirection_y.Value = int.Parse(sundirection_string[1]);
            numeric_sundirection_z.Value = int.Parse(sundirection_string[2]);

            // Sliders
            slider_northyaw.Value = int.Parse(map.GetWorldspawnValue("northyaw").Value);
            slider_ambient.Value = (int)float.Parse(map.GetWorldspawnValue("ambient").Value) * 100;
            slider_diffusefraction.Value = (int)float.Parse(map.GetWorldspawnValue("diffusefraction").Value) * 100;
            slider_sunlight.Value = (int)float.Parse(map.GetWorldspawnValue("sunlight").Value) * 100;
            slider_contrastgain.Value = (int)float.Parse(map.GetWorldspawnValue("contrastgain").Value) * 100;
            slider_bouncefraction.Value = (int)float.Parse(map.GetWorldspawnValue("bouncefraction").Value) * 100;

            UpdateUI();
        }
    }
}
