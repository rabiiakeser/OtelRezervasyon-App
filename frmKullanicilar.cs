using OtelRezervasyon.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelRezervasyon
{
    public partial class frmKullanicilar : Form
    {
        DataTable dt = new DataTable();
        DialogResult dialogResult;
        OleDbConnection connection;


        public frmKullanicilar()
        {
            InitializeComponent();
            connection = DatabaseHelper.Connect();

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtKullaniciId.Text))
            {
                dialogResult = MessageBox.Show("Temizleme butonuna tıkladıktan sonra kullanıcı işlemine devam edin", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (string.IsNullOrEmpty(txtKullaniciAdi.Text) || string.IsNullOrEmpty(txtSifre.Text))
                {
                    dialogResult = MessageBox.Show("Tüm alanları doldurun", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string userName = txtKullaniciAdi.Text;
                    string password = txtSifre.Text;
                    bool isActive = chkAktif.Checked;

                    string query = "INSERT INTO tblKullanicilar(KullaniciAdi,Sifre,Aktif) VALUES (@KullaniciAdi,@Sifre,@Aktif)";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@KulllaniciAdi", userName);
                    command.Parameters.AddWithValue("@Sifre", password);
                    command.Parameters.AddWithValue("@Aktif", isActive);

                    int result = DatabaseHelper.ExecuteSql(command);
                    if (result > 0)
                    {
                        dialogResult = MessageBox.Show("Kullanıcı başarıyla eklendi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        LoadDataGridView();
                        ClearFormItemsHelper.ResetAllControls(this);

                    }
                }
            }

            
        }

        private void frmKullanicilar_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            dgKullanicilar.DataSource = null;
            string query = "SELECT * FROM tblKullanicilar WHERE Aktif=" + true;
            OleDbCommand command = new OleDbCommand(query, connection);

            dt = DatabaseHelper.LoadDataTable(command);
            if (dt.Rows.Count >= 1)
            {
                dgKullanicilar.DataSource = dt;

                dgKullanicilar.Columns[0].Visible = false;
                dgKullanicilar.Columns[2].Visible = false;

                dgKullanicilar.Columns[1].HeaderText = "Kullanıcı Adı";
                dgKullanicilar.Columns[3].HeaderText = "Durum";


            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKullaniciId.Text))
            {
                dialogResult = MessageBox.Show("Kullanıcı seçin", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                int userId = Convert.ToInt16(txtKullaniciId.Text);
                string userName = txtKullaniciAdi.Text;
                string password = txtSifre.Text;
                bool isActive = chkAktif.Checked;

                string query = "UPDATE tblKullanicilar SET KullaniciAdi=@KullaniciAdi,Sifre=@Sifre,Aktif=@Aktif WHERE KullaniciId=" + userId;

                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("@KullaniciAdi", userName);
                command.Parameters.AddWithValue("@Sifre", password);
                command.Parameters.AddWithValue("@Aktif", isActive);

                int result = DatabaseHelper.ExecuteSql(command);
                if (result > 0)
                {
                    dialogResult = MessageBox.Show("Kullanıcı başarıyla güncellendi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    LoadDataGridView();
                    ClearFormItemsHelper.ResetAllControls(this);

                }
            }
        }

        private void dgKullanicilar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgKullanicilar.SelectedRows.Count > 0)
            {
                if (e.RowIndex > -1)
                {
                    ClearFormItemsHelper.ResetAllControls(this);
                    txtKullaniciId.Text = dgKullanicilar.Rows[e.RowIndex].Cells[0].Value.ToString();
                    txtKullaniciAdi.Text = dgKullanicilar.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtSifre.Text = dgKullanicilar.Rows[e.RowIndex].Cells[2].Value.ToString();

                    chkAktif.Checked = (bool)dgKullanicilar.Rows[e.RowIndex].Cells[3].Value;

                }
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            ClearFormItemsHelper.ResetAllControls(this);

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKullaniciId.Text))
            {
                dialogResult = MessageBox.Show("Kullanıcı seçin", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                dialogResult = MessageBox.Show("Kullanıcıyı silmek istiyor musunuz ?", "Kullanıcı Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    int userId = Convert.ToInt16(txtKullaniciId.Text);
                    string query = "DELETE FROM tblKullanicilar WHERE KullaniciId=" + userId;
                    OleDbCommand command = new OleDbCommand(query, connection);

                    int result = DatabaseHelper.ExecuteSql(command);
                    if (result > 0)
                    {
                        dialogResult = MessageBox.Show("Kullanıcı başarıyla silindi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        LoadDataGridView();
                        ClearFormItemsHelper.ResetAllControls(this);

                    }
                }





            }
        }
    }
}
