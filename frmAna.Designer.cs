namespace OtelRezervasyon
{
    partial class frmAna
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.rezervasyonlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odalarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odaListesiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odaTipleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.müşterilerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kullanıcılarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rezervasyonlarToolStripMenuItem,
            this.odalarToolStripMenuItem,
            this.müşterilerToolStripMenuItem,
            this.kullanıcılarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1238, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // rezervasyonlarToolStripMenuItem
            // 
            this.rezervasyonlarToolStripMenuItem.Name = "rezervasyonlarToolStripMenuItem";
            this.rezervasyonlarToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.rezervasyonlarToolStripMenuItem.Text = "Rezervasyonlar";
            this.rezervasyonlarToolStripMenuItem.Click += new System.EventHandler(this.rezervasyonlarToolStripMenuItem_Click);
            // 
            // odalarToolStripMenuItem
            // 
            this.odalarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.odaListesiToolStripMenuItem,
            this.odaTipleriToolStripMenuItem});
            this.odalarToolStripMenuItem.Name = "odalarToolStripMenuItem";
            this.odalarToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.odalarToolStripMenuItem.Text = "Odalar";
            // 
            // odaListesiToolStripMenuItem
            // 
            this.odaListesiToolStripMenuItem.Name = "odaListesiToolStripMenuItem";
            this.odaListesiToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.odaListesiToolStripMenuItem.Text = "Oda Listesi";
            this.odaListesiToolStripMenuItem.Click += new System.EventHandler(this.odaListesiToolStripMenuItem_Click);
            // 
            // odaTipleriToolStripMenuItem
            // 
            this.odaTipleriToolStripMenuItem.Name = "odaTipleriToolStripMenuItem";
            this.odaTipleriToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.odaTipleriToolStripMenuItem.Text = "Oda Tipleri";
            this.odaTipleriToolStripMenuItem.Click += new System.EventHandler(this.odaTipleriToolStripMenuItem_Click);
            // 
            // müşterilerToolStripMenuItem
            // 
            this.müşterilerToolStripMenuItem.Name = "müşterilerToolStripMenuItem";
            this.müşterilerToolStripMenuItem.Size = new System.Drawing.Size(89, 24);
            this.müşterilerToolStripMenuItem.Text = "Müşteriler";
            this.müşterilerToolStripMenuItem.Click += new System.EventHandler(this.müşterilerToolStripMenuItem_Click);
            // 
            // kullanıcılarToolStripMenuItem
            // 
            this.kullanıcılarToolStripMenuItem.Name = "kullanıcılarToolStripMenuItem";
            this.kullanıcılarToolStripMenuItem.Size = new System.Drawing.Size(96, 24);
            this.kullanıcılarToolStripMenuItem.Text = "Kullanıcılar";
            this.kullanıcılarToolStripMenuItem.Click += new System.EventHandler(this.kullanıcılarToolStripMenuItem_Click);
            // 
            // frmAna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 439);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmAna";
            this.Text = "Ana Form";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem rezervasyonlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem odalarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem odaListesiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem odaTipleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem müşterilerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kullanıcılarToolStripMenuItem;
    }
}