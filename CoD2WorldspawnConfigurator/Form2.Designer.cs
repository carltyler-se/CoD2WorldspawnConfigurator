namespace CoD2WorldspawnConfigurator
{
    partial class Form2
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
            this.listbox_stockworldspawns = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listbox_myworldspawns = new System.Windows.Forms.ListBox();
            this.textbox_worldspawndata = new System.Windows.Forms.TextBox();
            this.btn_copy = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listbox_stockworldspawns
            // 
            this.listbox_stockworldspawns.FormattingEnabled = true;
            this.listbox_stockworldspawns.Location = new System.Drawing.Point(0, 0);
            this.listbox_stockworldspawns.Name = "listbox_stockworldspawns";
            this.listbox_stockworldspawns.Size = new System.Drawing.Size(266, 225);
            this.listbox_stockworldspawns.TabIndex = 0;
            this.listbox_stockworldspawns.SelectedIndexChanged += new System.EventHandler(this.listbox_stockworldspawns_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(280, 255);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listbox_stockworldspawns);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(272, 229);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Stock Worldspawns";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listbox_myworldspawns);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(272, 229);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "My Worldspawns";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listbox_myworldspawns
            // 
            this.listbox_myworldspawns.FormattingEnabled = true;
            this.listbox_myworldspawns.Location = new System.Drawing.Point(0, 0);
            this.listbox_myworldspawns.Name = "listbox_myworldspawns";
            this.listbox_myworldspawns.Size = new System.Drawing.Size(266, 225);
            this.listbox_myworldspawns.TabIndex = 2;
            this.listbox_myworldspawns.SelectedIndexChanged += new System.EventHandler(this.listbox_myworldspawns_SelectedIndexChanged);
            // 
            // textbox_worldspawndata
            // 
            this.textbox_worldspawndata.Location = new System.Drawing.Point(294, 34);
            this.textbox_worldspawndata.Multiline = true;
            this.textbox_worldspawndata.Name = "textbox_worldspawndata";
            this.textbox_worldspawndata.ReadOnly = true;
            this.textbox_worldspawndata.Size = new System.Drawing.Size(270, 229);
            this.textbox_worldspawndata.TabIndex = 2;
            this.textbox_worldspawndata.WordWrap = false;
            // 
            // btn_copy
            // 
            this.btn_copy.Enabled = false;
            this.btn_copy.Location = new System.Drawing.Point(16, 269);
            this.btn_copy.Name = "btn_copy";
            this.btn_copy.Size = new System.Drawing.Size(82, 23);
            this.btn_copy.TabIndex = 3;
            this.btn_copy.Text = "Copy";
            this.btn_copy.UseVisualStyleBackColor = true;
            this.btn_copy.Click += new System.EventHandler(this.btn_copy_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(104, 269);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(82, 23);
            this.btn_cancel.TabIndex = 4;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 305);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_copy);
            this.Controls.Add(this.textbox_worldspawndata);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form2";
            this.Text = "Copy From...";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listbox_stockworldspawns;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox listbox_myworldspawns;
        private System.Windows.Forms.TextBox textbox_worldspawndata;
        private System.Windows.Forms.Button btn_copy;
        private System.Windows.Forms.Button btn_cancel;
    }
}