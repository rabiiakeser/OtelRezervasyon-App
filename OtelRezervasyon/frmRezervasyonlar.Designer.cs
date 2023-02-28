namespace OtelRezervasyon
{
    partial class frmRezervasyonlar
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
            this.dgMusteriler = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgOdalar = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOdaNo = new System.Windows.Forms.TextBox();
            this.txtMusteriNo = new System.Windows.Forms.TextBox();
            this.dtpEntryDate = new System.Windows.Forms.DateTimePicker();
            this.dtpQuitDate = new System.Windows.Forms.DateTimePicker();
            this.chkAktif = new System.Windows.Forms.CheckBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.dgRezervasyonlar = new System.Windows.Forms.DataGridView();
            this.btnRezervasyonSil = new System.Windows.Forms.Button();
            this.btnDuzenle = new System.Windows.Forms.Button();
            this.txtRezervasyonId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMusteriAra = new System.Windows.Forms.TextBox();
            this.txtOdaAra = new System.Windows.Forms.TextBox();
            this.txtRezervasyonAra = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgMusteriler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgOdalar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRezervasyonlar)).BeginInit();
            this.SuspendLayout();
            // 
            // dgMusteriler
            // 
            this.dgMusteriler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMusteriler.Location = new System.Drawing.Point(0, 61);
            this.dgMusteriler.Name = "dgMusteriler";
            this.dgMusteriler.RowHeadersWidth = 51;
            this.dgMusteriler.RowTemplate.Height = 24;
            this.dgMusteriler.Size = new System.Drawing.Size(703, 177);
            this.dgMusteriler.TabIndex = 0;
            this.dgMusteriler.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgMusteriler_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 279);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Oda No :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 279);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Müşteri No :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(450, 279);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Giriş Tarihi :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(760, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Çıkış Tarihi : ";
            // 
            // dgOdalar
            // 
            this.dgOdalar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgOdalar.Location = new System.Drawing.Point(739, 61);
            this.dgOdalar.Name = "dgOdalar";
            this.dgOdalar.RowHeadersWidth = 51;
            this.dgOdalar.RowTemplate.Height = 24;
            this.dgOdalar.Size = new System.Drawing.Size(473, 177);
            this.dgOdalar.TabIndex = 5;
            this.dgOdalar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgOdalar_CellDoubleClick);
            this.dgOdalar.DoubleClick += new System.EventHandler(this.dgOdalar_DoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1075, 286);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Durum : ";
            // 
            // txtOdaNo
            // 
            this.txtOdaNo.Location = new System.Drawing.Point(83, 276);
            this.txtOdaNo.Name = "txtOdaNo";
            this.txtOdaNo.ReadOnly = true;
            this.txtOdaNo.Size = new System.Drawing.Size(100, 22);
            this.txtOdaNo.TabIndex = 7;
            // 
            // txtMusteriNo
            // 
            this.txtMusteriNo.Location = new System.Drawing.Point(314, 276);
            this.txtMusteriNo.Name = "txtMusteriNo";
            this.txtMusteriNo.ReadOnly = true;
            this.txtMusteriNo.Size = new System.Drawing.Size(100, 22);
            this.txtMusteriNo.TabIndex = 8;
            // 
            // dtpEntryDate
            // 
            this.dtpEntryDate.Location = new System.Drawing.Point(549, 279);
            this.dtpEntryDate.Name = "dtpEntryDate";
            this.dtpEntryDate.Size = new System.Drawing.Size(179, 22);
            this.dtpEntryDate.TabIndex = 9;
            // 
            // dtpQuitDate
            // 
            this.dtpQuitDate.Location = new System.Drawing.Point(859, 281);
            this.dtpQuitDate.Name = "dtpQuitDate";
            this.dtpQuitDate.Size = new System.Drawing.Size(179, 22);
            this.dtpQuitDate.TabIndex = 10;
            // 
            // chkAktif
            // 
            this.chkAktif.AutoSize = true;
            this.chkAktif.Location = new System.Drawing.Point(1143, 285);
            this.chkAktif.Name = "chkAktif";
            this.chkAktif.Size = new System.Drawing.Size(57, 21);
            this.chkAktif.TabIndex = 11;
            this.chkAktif.Text = "Aktif";
            this.chkAktif.UseVisualStyleBackColor = true;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(453, 419);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(101, 36);
            this.btnKaydet.TabIndex = 12;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnTemizle
            // 
            this.btnTemizle.Location = new System.Drawing.Point(672, 419);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(101, 36);
            this.btnTemizle.TabIndex = 13;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.UseVisualStyleBackColor = true;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // dgRezervasyonlar
            // 
            this.dgRezervasyonlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRezervasyonlar.Location = new System.Drawing.Point(0, 477);
            this.dgRezervasyonlar.Name = "dgRezervasyonlar";
            this.dgRezervasyonlar.RowHeadersWidth = 51;
            this.dgRezervasyonlar.RowTemplate.Height = 24;
            this.dgRezervasyonlar.Size = new System.Drawing.Size(1212, 451);
            this.dgRezervasyonlar.TabIndex = 16;
            this.dgRezervasyonlar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgRezervasyonlar_CellDoubleClick);
            // 
            // btnRezervasyonSil
            // 
            this.btnRezervasyonSil.Location = new System.Drawing.Point(779, 419);
            this.btnRezervasyonSil.Name = "btnRezervasyonSil";
            this.btnRezervasyonSil.Size = new System.Drawing.Size(101, 36);
            this.btnRezervasyonSil.TabIndex = 17;
            this.btnRezervasyonSil.Text = "Sil";
            this.btnRezervasyonSil.UseVisualStyleBackColor = true;
            this.btnRezervasyonSil.Click += new System.EventHandler(this.btnRezervasyonSil_Click);
            // 
            // btnDuzenle
            // 
            this.btnDuzenle.Location = new System.Drawing.Point(560, 419);
            this.btnDuzenle.Name = "btnDuzenle";
            this.btnDuzenle.Size = new System.Drawing.Size(101, 36);
            this.btnDuzenle.TabIndex = 18;
            this.btnDuzenle.Text = "Düzenle";
            this.btnDuzenle.UseVisualStyleBackColor = true;
            this.btnDuzenle.Click += new System.EventHandler(this.btnDuzenle_Click);
            // 
            // txtRezervasyonId
            // 
            this.txtRezervasyonId.Location = new System.Drawing.Point(956, 344);
            this.txtRezervasyonId.Name = "txtRezervasyonId";
            this.txtRezervasyonId.Size = new System.Drawing.Size(100, 22);
            this.txtRezervasyonId.TabIndex = 19;
            this.txtRezervasyonId.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 17);
            this.label6.TabIndex = 20;
            this.label6.Text = "Müşteri Ara :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(748, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 17);
            this.label7.TabIndex = 21;
            this.label7.Text = "Oda Ara :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 431);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 17);
            this.label8.TabIndex = 22;
            this.label8.Text = "Rezervasyon Ara :";
            // 
            // txtMusteriAra
            // 
            this.txtMusteriAra.Location = new System.Drawing.Point(126, 15);
            this.txtMusteriAra.Name = "txtMusteriAra";
            this.txtMusteriAra.Size = new System.Drawing.Size(159, 22);
            this.txtMusteriAra.TabIndex = 23;
            this.txtMusteriAra.TextChanged += new System.EventHandler(this.txtMusteriAra_TextChanged);
            // 
            // txtOdaAra
            // 
            this.txtOdaAra.Location = new System.Drawing.Point(823, 20);
            this.txtOdaAra.Name = "txtOdaAra";
            this.txtOdaAra.Size = new System.Drawing.Size(159, 22);
            this.txtOdaAra.TabIndex = 25;
            this.txtOdaAra.TextChanged += new System.EventHandler(this.txtOdaAra_TextChanged);
            // 
            // txtRezervasyonAra
            // 
            this.txtRezervasyonAra.Location = new System.Drawing.Point(176, 426);
            this.txtRezervasyonAra.Name = "txtRezervasyonAra";
            this.txtRezervasyonAra.Size = new System.Drawing.Size(159, 22);
            this.txtRezervasyonAra.TabIndex = 26;
            this.txtRezervasyonAra.TextChanged += new System.EventHandler(this.txtRezervasyonAra_TextChanged);
            // 
            // frmRezervasyonlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 926);
            this.Controls.Add(this.txtRezervasyonAra);
            this.Controls.Add(this.txtOdaAra);
            this.Controls.Add(this.txtMusteriAra);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtRezervasyonId);
            this.Controls.Add(this.btnDuzenle);
            this.Controls.Add(this.btnRezervasyonSil);
            this.Controls.Add(this.dgRezervasyonlar);
            this.Controls.Add(this.btnTemizle);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.chkAktif);
            this.Controls.Add(this.dtpQuitDate);
            this.Controls.Add(this.dtpEntryDate);
            this.Controls.Add(this.txtMusteriNo);
            this.Controls.Add(this.txtOdaNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgOdalar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgMusteriler);
            this.Name = "frmRezervasyonlar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rezervasyonlar";
            this.Load += new System.EventHandler(this.frmRezervasyonlar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgMusteriler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgOdalar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRezervasyonlar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgMusteriler;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgOdalar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOdaNo;
        private System.Windows.Forms.TextBox txtMusteriNo;
        private System.Windows.Forms.DateTimePicker dtpEntryDate;
        private System.Windows.Forms.DateTimePicker dtpQuitDate;
        private System.Windows.Forms.CheckBox chkAktif;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.DataGridView dgRezervasyonlar;
        private System.Windows.Forms.Button btnRezervasyonSil;
        private System.Windows.Forms.Button btnDuzenle;
        private System.Windows.Forms.TextBox txtRezervasyonId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMusteriAra;
        private System.Windows.Forms.TextBox txtOdaAra;
        private System.Windows.Forms.TextBox txtRezervasyonAra;
    }
}