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
    public partial class frmMusteriler : Form
    {
        DataTable dt = new DataTable();
        DialogResult dialogResult;
        OleDbConnection connection;

        public frmMusteriler()
        {
            connection = DatabaseHelper.Connect();
            InitializeComponent();

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtTcKimlikNo.Text) || string.IsNullOrEmpty(txtAd.Text) || string.IsNullOrEmpty(txtSoyad.Text)
                || string.IsNullOrEmpty(txtTelefon.Text) || string.IsNullOrEmpty(txtEPosta.Text) || cmbCinsiyet.SelectedItem == null)
            {

                dialogResult = MessageBox.Show("Tüm alanları doldurun", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                bool isSuccess = CheckLength();

                if (isSuccess)
                {
                    string civilizationNumber = txtTcKimlikNo.Text;
                    string name = txtAd.Text;
                    string surname = txtSoyad.Text;
                    string gender = cmbCinsiyet.Text;
                    string phoneNumber = txtTelefon.Text;
                    string eMail = txtEPosta.Text;
                    DateTime dateOfBirth = dtDogumTarihi.Value.Date;
                    bool isActive = chkAktif.Checked;

                    string query = "INSERT INTO tblMusteriler (TcKimlikNo,Ad,Soyad,Cinsiyet,Telefon,EPosta,DogumTarihi,Aktif) VALUES(@TcKimlikNo,@Ad,@Soyad,@Cinsiyet,@Telefon,@EPosta,@DogumTarihi,@Aktif)";

                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@TcKimlikNo", civilizationNumber);
                    command.Parameters.AddWithValue("@Ad", name);
                    command.Parameters.AddWithValue("@Soyad", surname);
                    command.Parameters.AddWithValue("@Cinsiyet", gender);
                    command.Parameters.AddWithValue("@Telefon", phoneNumber);
                    command.Parameters.AddWithValue("@EPosta", eMail);
                    command.Parameters.AddWithValue("@DogumTarihi", dateOfBirth);
                    command.Parameters.AddWithValue("@Aktif", isActive);


                    int result = DatabaseHelper.ExecuteSql(command);
                    if (result > 0)
                    {
                        dialogResult = MessageBox.Show("Müşteri başarıyla eklendi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        LoadDataGridView();
                        ClearFormItemsHelper.ResetAllControls(this);

                    }
                }
               


            }

        }

        private void frmMusteriler_Load(object sender, EventArgs e)
        {
            LoadDataGridView();

        }


        private void LoadDataGridView()
        {
            dgMusteriler.DataSource = null;
            string query = "SELECT * FROM tblMusteriler";
            OleDbCommand command = new OleDbCommand(query, connection);

            dt = DatabaseHelper.LoadDataTable(command);
            if (dt.Rows.Count >= 1)
            {
                dgMusteriler.DataSource = dt;

                dgMusteriler.Columns[0].Visible = false;
                dgMusteriler.Columns[1].HeaderText = "Tc Kimlik No";
                dgMusteriler.Columns[2].HeaderText = "Ad";
                dgMusteriler.Columns[3].HeaderText = "Soyad";
                dgMusteriler.Columns[4].HeaderText = "Cinsiyet";
                dgMusteriler.Columns[5].HeaderText = "Telefon";
                dgMusteriler.Columns[6].HeaderText = "E-Posta";
                dgMusteriler.Columns[7].HeaderText = "Doğum Tarihi";
                dgMusteriler.Columns[8].HeaderText = "Durum";

            }
        }

        private void dgMusteriler_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgMusteriler.SelectedRows.Count > 0)
            {

                if (e.RowIndex > -1)
                {
                    ClearFormItemsHelper.ResetAllControls(this);
                    txtMusteriId.Text = dgMusteriler.Rows[e.RowIndex].Cells[0].Value.ToString();
                    txtTcKimlikNo.Text = dgMusteriler.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtAd.Text = dgMusteriler.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtSoyad.Text = dgMusteriler.Rows[e.RowIndex].Cells[3].Value.ToString();
                    cmbCinsiyet.SelectedText = dgMusteriler.Rows[e.RowIndex].Cells[4].Value.ToString();
                    txtTelefon.Text = dgMusteriler.Rows[e.RowIndex].Cells[5].Value.ToString();
                    txtEPosta.Text = dgMusteriler.Rows[e.RowIndex].Cells[6].Value.ToString();
                    dtDogumTarihi.Value = Convert.ToDateTime(dgMusteriler.Rows[e.RowIndex].Cells[7].Value);
                    chkAktif.Checked = (bool)dgMusteriler.Rows[e.RowIndex].Cells[8].Value;


                }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtMusteriId.Text))
            {
                dialogResult = MessageBox.Show("Müşteri seçin", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                bool isSuccess = CheckLength();
                if (isSuccess)
                {
                    int customerId = Convert.ToInt16(txtMusteriId.Text);
                    string civilizationNumber = txtTcKimlikNo.Text;
                    string name = txtAd.Text;
                    string surname = txtSoyad.Text;
                    string gender = cmbCinsiyet.Text;
                    string phoneNumber = txtTelefon.Text;
                    string eMail = txtEPosta.Text;
                    DateTime dateOfBirth = dtDogumTarihi.Value.Date;
                    bool isActive = chkAktif.Checked;



                    string query = "UPDATE tblMusteriler SET TcKimlikNo=@TcKimlikNo,Ad=@Ad,Soyad=@Soyad,Cinsiyet=@Cinsiyet,Telefon=@Telefon,EPosta=@EPosta,DogumTarihi=@DogumTarihi,Aktif=@Aktif WHERE MusteriId=" + customerId;



                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@TcKimlikNo", civilizationNumber);
                    command.Parameters.AddWithValue("@Ad", name);
                    command.Parameters.AddWithValue("@Soyad", surname);
                    command.Parameters.AddWithValue("@Cinsiyet", gender);
                    command.Parameters.AddWithValue("@Telefon", phoneNumber);
                    command.Parameters.AddWithValue("@EPosta", eMail);
                    command.Parameters.AddWithValue("@DogumTarihi", dateOfBirth);
                    command.Parameters.AddWithValue("@Aktif", isActive);

                    //DataTable dt = DatabaseHelper.LoadDataTable1(command);

                    //var ad = dt.Rows[0][1].ToString();

                    int result = DatabaseHelper.ExecuteSql(command);
                    if (result > 0)
                    {
                        dialogResult = MessageBox.Show("Müşteri başarıyla güncellendi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        LoadDataGridView();
                        ClearFormItemsHelper.ResetAllControls(this);

                    }
                }
               
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMusteriId.Text))
            {
                dialogResult = MessageBox.Show("Müşteri seçin", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                dialogResult = MessageBox.Show("Müşteriyi silmek istiyor musunuz ?", "Müşteri Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    int customerId = Convert.ToInt16(txtMusteriId.Text);
                    string query = "DELETE FROM tblMusteriler WHERE MusteriId=" + customerId;
                    OleDbCommand command = new OleDbCommand(query, connection);

                    int result = DatabaseHelper.ExecuteSql(command);
                    if (result > 0)
                    {
                        dialogResult = MessageBox.Show("Müşteri başarıyla silindi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        LoadDataGridView();
                        ClearFormItemsHelper.ResetAllControls(this);

                    }
                }





            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            ClearFormItemsHelper.ResetAllControls(this);

        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            string query = "";
            if (txtAra.Text != string.Empty)
                query += "Ad like '%" + txtAra.Text.Trim() + "%' or ";
            if (txtAra.Text != string.Empty)
                query += "Soyad like '%" + txtAra.Text.Trim() + "%' or ";

            if (txtAra.Text != string.Empty)
                query += "TcKimlikNo like '%" + txtAra.Text.Trim() + "%' or ";

            if (txtAra.Text != string.Empty)
                query += "Cinsiyet like '%" + txtAra.Text.Trim() + "%' or ";

            if (txtAra.Text != string.Empty)
                query += "Telefon like '%" + txtAra.Text.Trim() + "%' or ";

            if (txtAra.Text != string.Empty)
                query += "EPosta like '%" + txtAra.Text.Trim() + "%'";

           
            (dgMusteriler.DataSource as DataTable).DefaultView.RowFilter = query;
        }

        private void txtTcKimlikNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void txtTcKimlikNo_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txtTcKimlikNo_Leave(object sender, EventArgs e)
        {
            CheckLength();

        }

        private void txtTelefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void txtTelefon_Leave(object sender, EventArgs e)
        {
            CheckLength();

        }


        private bool CheckLength()
        {
            bool isSuccess = false;
            btnKaydet.Enabled = false;
            btnGuncelle.Enabled = false;

            if (!string.IsNullOrEmpty(txtTelefon.Text) && !string.IsNullOrEmpty(txtTcKimlikNo.Text))
            {
                if (txtTelefon.Text.Length != 11)
                {
                    dialogResult = MessageBox.Show("Telefon numarasını kontrol edin", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    if (txtTelefon.Text.Length == 11)
                    {
                        char firstCharacter = txtTelefon.Text[0];
                        if (firstCharacter != '0')
                        {
                            dialogResult = MessageBox.Show("Telefon numarasını başında 0 olacak şekilde girin", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            if (txtTcKimlikNo.Text.Length != 11)
                            {
                                dialogResult = MessageBox.Show("Tc Kimlik Numarasını 11 hane olacak şekilde girin", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            }

                            else
                            {
                                btnKaydet.Enabled = true;
                                btnGuncelle.Enabled = true;

                                isSuccess = true;
                            }
                        }

                    }

                }



            }

            return isSuccess;
          
        }

        private void txtAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);

        }

        private void txtSoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);

        }

        private void txtTcKimlikNo_MouseLeave(object sender, EventArgs e)
        {
            
        }
    }
}
