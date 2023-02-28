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
    public partial class frmGiris : Form
    {
        DialogResult dialogResult;
        public frmGiris()
        {
            InitializeComponent();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKullaniciAdi.Text) || string.IsNullOrEmpty(txtSifre.Text))
            {
                dialogResult = MessageBox.Show("Kullanıcı adı ve şifre boş geçilemez !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    OleDbConnection connection = DatabaseHelper.Connect();
                    string query = "SELECT * FROM tblKullanicilar WHERE KullaniciAdi=@KullaniciAdi AND Sifre=@Sifre AND Aktif=@Aktif";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@KullaniciAdi", txtKullaniciAdi.Text);
                    command.Parameters.AddWithValue("@Sifre", txtSifre.Text);
                    command.Parameters.AddWithValue("@Aktif", true);

                    DataTable dt = DatabaseHelper.LoadDataTable(command);
                    //DatabaseHelper.ExecuteSql("SELECT * from tblKullanicilar Where KullaniciAdi='" + txtKullaniciAdi.Text + "'");
                    if (dt.Rows.Count == 1)
                    {
                        frmAna frmAna = new frmAna();
                        frmAna.Show();
                    }
                    else
                    {
                        dialogResult = MessageBox.Show("Kullanıcı adı veya şifreyi kontrol ediniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }

                }
                catch (Exception ex)
                {
                    DialogResult dialogResult = MessageBox.Show(ex.Message.ToString(), "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
