using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoD2WorldspawnConfigurator
{
    internal class Worldspawn
    {
        // Member Variables
        public string Classname { get { return "worldspawn"; } }
        public RGBValue Color { get; set; }
        public RGBValue SunColor { get; set; }
        public RGBValue SunDiffuseColor { get; set; }
        private int northYaw = 0;
        public int NorthYaw 
        {
            get { return northYaw; }
            set 
            {
                if (value < -360) northYaw = -360;
                else if (value > 360) northYaw = 360;
            }
        }
        private float diffuseFraction = 0f;
        public float DiffuseFraction
        {
            get { return diffuseFraction; }
            set
            {
                if (value < 0) diffuseFraction = 0f;
                else if (value > 1) diffuseFraction = 1f;
                else diffuseFraction = value;
            }
        }
        private float ambient = 0.8f;
        public float Ambient
        {
            get { return ambient; }
            set
            {
                if (value < 0) ambient = 0f;
                else if (value > 1) ambient = 1f;
                else ambient = value;
            }
        }
        private float sunlight = 1f;
        public float Sunlight 
        {
            get { return sunlight; }
            set
            {
                if (value < 0) sunlight = 0f;
                else if (value > 2) sunlight = 2f;
                else sunlight = value;
            }
        }
        public Direction SunDirection { get; set; }
        private float contrastGain = .5f;
        public float ContrastGain 
        {
            get { return contrastGain; }
            set
            {
                if (value < 0) contrastGain = 0f;
                else if (value > 1) contrastGain = 1f;
                else contrastGain = value;
            }
        }
        private float bounceFraction = 0.5f;
        public float BounceFraction { 
            get { return bounceFraction; }
            set 
            {
                if (value < 0) bounceFraction = 0f;
                else if (value > 1) bounceFraction = 1f;
                else bounceFraction = value;
            } 
        }

        // Contructors
        public Worldspawn() { }
        public Worldspawn(RGBValue color, RGBValue sunColor, RGBValue sunDiffuseColor, int northYaw, float diffuseFraction, float ambient, float sunlight, Direction sundirection, float contrastGain, float bounceFraction)
        {
            Color = color;
            SunColor = sunColor;
            SunDiffuseColor = sunDiffuseColor;
            NorthYaw = northYaw;
            DiffuseFraction = diffuseFraction;
            Ambient = ambient;
            Sunlight = sunlight;
            SunDirection = sundirection;
            ContrastGain = contrastGain;
            BounceFraction = bounceFraction;
        }
    
        // Functions
        public List<WorldspawnKeyVal> ExportWorldspawnKeyVals()
        {
            List<WorldspawnKeyVal> keyVals = new List<WorldspawnKeyVal>();

            keyVals.Add(new WorldspawnKeyVal("classname", "worldspawn"));
            keyVals.Add(new WorldspawnKeyVal("_color", Color.ToString()));
            keyVals.Add(new WorldspawnKeyVal("suncolor", SunColor.ToString()));
            keyVals.Add(new WorldspawnKeyVal("sundiffusecolor", SunDiffuseColor.ToString()));
            keyVals.Add(new WorldspawnKeyVal("northyaw", NorthYaw.ToString()));
            keyVals.Add(new WorldspawnKeyVal("diffusefraction", DiffuseFraction.ToString()));
            keyVals.Add(new WorldspawnKeyVal("ambient", Ambient.ToString()));
            keyVals.Add(new WorldspawnKeyVal("sunlight", Sunlight.ToString()));
            keyVals.Add(new WorldspawnKeyVal("sundirection", SunDirection.ToString()));
            keyVals.Add(new WorldspawnKeyVal("contrastgain", ContrastGain.ToString()));
            keyVals.Add(new WorldspawnKeyVal("bouncefraction", BounceFraction.ToString()));

            return keyVals;
        }    
    }
}
