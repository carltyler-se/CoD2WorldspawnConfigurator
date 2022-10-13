namespace CoD2WorldspawnConfigurator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_northyaw = new System.Windows.Forms.Label();
            this.lbl_color = new System.Windows.Forms.Label();
            this.lbl_ambient = new System.Windows.Forms.Label();
            this.lbl_classname = new System.Windows.Forms.Label();
            this.lbl_suncolor = new System.Windows.Forms.Label();
            this.lbl_sundiffusecolor = new System.Windows.Forms.Label();
            this.lbl_contrastgain = new System.Windows.Forms.Label();
            this.lbl_sundirection = new System.Windows.Forms.Label();
            this.lbl_diffusefraction = new System.Windows.Forms.Label();
            this.lbl_sunlight = new System.Windows.Forms.Label();
            this.grpbox_worldspawn = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.slider_northyaw = new System.Windows.Forms.TrackBar();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.grpbox_worldspawn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slider_northyaw)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_northyaw
            // 
            this.lbl_northyaw.AutoSize = true;
            this.lbl_northyaw.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lbl_northyaw.Location = new System.Drawing.Point(17, 83);
            this.lbl_northyaw.Name = "lbl_northyaw";
            this.lbl_northyaw.Size = new System.Drawing.Size(84, 20);
            this.lbl_northyaw.TabIndex = 0;
            this.lbl_northyaw.Text = "Northyaw:";
            // 
            // lbl_color
            // 
            this.lbl_color.AutoSize = true;
            this.lbl_color.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lbl_color.Location = new System.Drawing.Point(35, 132);
            this.lbl_color.Name = "lbl_color";
            this.lbl_color.Size = new System.Drawing.Size(60, 20);
            this.lbl_color.TabIndex = 1;
            this.lbl_color.Text = "_color:";
            // 
            // lbl_ambient
            // 
            this.lbl_ambient.AutoSize = true;
            this.lbl_ambient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lbl_ambient.Location = new System.Drawing.Point(6, 219);
            this.lbl_ambient.Name = "lbl_ambient";
            this.lbl_ambient.Size = new System.Drawing.Size(73, 20);
            this.lbl_ambient.TabIndex = 2;
            this.lbl_ambient.Text = "ambient:";
            // 
            // lbl_classname
            // 
            this.lbl_classname.AutoSize = true;
            this.lbl_classname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lbl_classname.Location = new System.Drawing.Point(17, 26);
            this.lbl_classname.Name = "lbl_classname";
            this.lbl_classname.Size = new System.Drawing.Size(95, 20);
            this.lbl_classname.TabIndex = 3;
            this.lbl_classname.Text = "classname:";
            // 
            // lbl_suncolor
            // 
            this.lbl_suncolor.AutoSize = true;
            this.lbl_suncolor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lbl_suncolor.Location = new System.Drawing.Point(17, 345);
            this.lbl_suncolor.Name = "lbl_suncolor";
            this.lbl_suncolor.Size = new System.Drawing.Size(78, 20);
            this.lbl_suncolor.TabIndex = 4;
            this.lbl_suncolor.Text = "suncolor:";
            // 
            // lbl_sundiffusecolor
            // 
            this.lbl_sundiffusecolor.AutoSize = true;
            this.lbl_sundiffusecolor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lbl_sundiffusecolor.Location = new System.Drawing.Point(17, 381);
            this.lbl_sundiffusecolor.Name = "lbl_sundiffusecolor";
            this.lbl_sundiffusecolor.Size = new System.Drawing.Size(128, 20);
            this.lbl_sundiffusecolor.TabIndex = 5;
            this.lbl_sundiffusecolor.Text = "sundiffusecolor:";
            // 
            // lbl_contrastgain
            // 
            this.lbl_contrastgain.AutoSize = true;
            this.lbl_contrastgain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lbl_contrastgain.Location = new System.Drawing.Point(17, 494);
            this.lbl_contrastgain.Name = "lbl_contrastgain";
            this.lbl_contrastgain.Size = new System.Drawing.Size(106, 20);
            this.lbl_contrastgain.TabIndex = 6;
            this.lbl_contrastgain.Text = "contrastgain:";
            // 
            // lbl_sundirection
            // 
            this.lbl_sundirection.AutoSize = true;
            this.lbl_sundirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lbl_sundirection.Location = new System.Drawing.Point(17, 454);
            this.lbl_sundirection.Name = "lbl_sundirection";
            this.lbl_sundirection.Size = new System.Drawing.Size(105, 20);
            this.lbl_sundirection.TabIndex = 7;
            this.lbl_sundirection.Text = "sundirection:";
            // 
            // lbl_diffusefraction
            // 
            this.lbl_diffusefraction.AutoSize = true;
            this.lbl_diffusefraction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lbl_diffusefraction.Location = new System.Drawing.Point(6, 259);
            this.lbl_diffusefraction.Name = "lbl_diffusefraction";
            this.lbl_diffusefraction.Size = new System.Drawing.Size(120, 20);
            this.lbl_diffusefraction.TabIndex = 8;
            this.lbl_diffusefraction.Text = "diffusefraction:";
            // 
            // lbl_sunlight
            // 
            this.lbl_sunlight.AutoSize = true;
            this.lbl_sunlight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lbl_sunlight.Location = new System.Drawing.Point(17, 418);
            this.lbl_sunlight.Name = "lbl_sunlight";
            this.lbl_sunlight.Size = new System.Drawing.Size(67, 20);
            this.lbl_sunlight.TabIndex = 9;
            this.lbl_sunlight.Text = "sunlight";
            // 
            // grpbox_worldspawn
            // 
            this.grpbox_worldspawn.Controls.Add(this.slider_northyaw);
            this.grpbox_worldspawn.Controls.Add(this.textBox1);
            this.grpbox_worldspawn.Controls.Add(this.lbl_classname);
            this.grpbox_worldspawn.Controls.Add(this.lbl_contrastgain);
            this.grpbox_worldspawn.Controls.Add(this.lbl_diffusefraction);
            this.grpbox_worldspawn.Controls.Add(this.lbl_sunlight);
            this.grpbox_worldspawn.Controls.Add(this.lbl_northyaw);
            this.grpbox_worldspawn.Controls.Add(this.lbl_color);
            this.grpbox_worldspawn.Controls.Add(this.lbl_sundirection);
            this.grpbox_worldspawn.Controls.Add(this.lbl_ambient);
            this.grpbox_worldspawn.Controls.Add(this.lbl_suncolor);
            this.grpbox_worldspawn.Controls.Add(this.lbl_sundiffusecolor);
            this.grpbox_worldspawn.Location = new System.Drawing.Point(12, 12);
            this.grpbox_worldspawn.Name = "grpbox_worldspawn";
            this.grpbox_worldspawn.Size = new System.Drawing.Size(655, 563);
            this.grpbox_worldspawn.TabIndex = 10;
            this.grpbox_worldspawn.TabStop = false;
            this.grpbox_worldspawn.Text = "worldspawn";
            this.grpbox_worldspawn.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(118, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(156, 20);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "worldspawn";
            // 
            // slider_northyaw
            // 
            this.slider_northyaw.Location = new System.Drawing.Point(118, 83);
            this.slider_northyaw.Maximum = 359;
            this.slider_northyaw.Name = "slider_northyaw";
            this.slider_northyaw.Size = new System.Drawing.Size(237, 45);
            this.slider_northyaw.TabIndex = 11;
            this.slider_northyaw.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 755);
            this.Controls.Add(this.grpbox_worldspawn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.grpbox_worldspawn.ResumeLayout(false);
            this.grpbox_worldspawn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slider_northyaw)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_northyaw;
        private System.Windows.Forms.Label lbl_color;
        private System.Windows.Forms.Label lbl_ambient;
        private System.Windows.Forms.Label lbl_classname;
        private System.Windows.Forms.Label lbl_suncolor;
        private System.Windows.Forms.Label lbl_sundiffusecolor;
        private System.Windows.Forms.Label lbl_contrastgain;
        private System.Windows.Forms.Label lbl_sundirection;
        private System.Windows.Forms.Label lbl_diffusefraction;
        private System.Windows.Forms.Label lbl_sunlight;
        private System.Windows.Forms.GroupBox grpbox_worldspawn;
        private System.Windows.Forms.TrackBar slider_northyaw;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ColorDialog colorDialog2;
    }
}

