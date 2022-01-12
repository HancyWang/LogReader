namespace LogReader
{
    partial class Form_About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_About));
            this.label_sw_ver = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_sw_ver
            // 
            this.label_sw_ver.AutoSize = true;
            this.label_sw_ver.Location = new System.Drawing.Point(162, 92);
            this.label_sw_ver.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_sw_ver.Name = "label_sw_ver";
            this.label_sw_ver.Size = new System.Drawing.Size(190, 15);
            this.label_sw_ver.TabIndex = 1;
            this.label_sw_ver.Text = "Software Version：1.0.0";
            // 
            // Form_About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 221);
            this.Controls.Add(this.label_sw_ver);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_About";
            this.Text = "About";
            this.Load += new System.EventHandler(this.Form_About_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_sw_ver;
    }
}