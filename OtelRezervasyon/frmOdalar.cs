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
    public partial class frmOdalar : Form
    {
        DataTable dt = new DataTable();
        DialogResult dialogResult;
        OleDbConnection connection;

        public frmOdalar()
        {
            connection = DatabaseHelper.Connect();
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOdaNo.Text) || string.IsNullOrEmpty(txtFiyat.Text)
                || cmbOdaTip.Text == null)
            {
                dialogResult = MessageBox.Show("Lütfen tüm alanları doldurun", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int roomNo = Convert.ToInt16(txtOdaNo.Text);
                int roomNoTypeId = Convert.ToInt16(cmbOdaTip.SelectedValue);
                decimal price = Convert.ToDecimal(txtFiyat.Text);
                string explanation = txtAciklama.Text;
                bool isActive = chkAktif.Checked;

                string query = "INSERT INTO tblOdalar (OdaNo,OdaTipId,Fiyat,Aciklama,Aktif) VALUES(@OdaNo,@OdaTipId,@Fiyat,@Aciklama,@Aktif)";

                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("@OdaNo", roomNo);
                command.Parameters.AddWithValue("@OdaTipId", roomNoTypeId);
                command.Parameters.AddWithValue("@Fiyat", price);
                command.Parameters.AddWithValue("@Aciklama", explanation);
                command.Parameters.AddWithValue("@Aktif", isActive);

                int result = DatabaseHelper.ExecuteSql(command);
                if (result > 0)
                {
                    dialogResult = MessageBox.Show("Oda başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    LoadDataGridView();
                    ClearFormItemsHelper.ResetAllControls(this);


                }


            }
        }

        private void frmOdalar_Load(object sender, EventArgs e)
        {
            string query = "SELECT OdaTipId,Ad from tblOdaTipleri WHERE Aktif=@Aktif";
            OleDbCommand command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("Aktif", true);

            cmbOdaTip.DisplayMember = "Ad";
            cmbOdaTip.ValueMember = "OdaTipId";
            cmbOdaTip.DataSource = DatabaseHelper.LoadDataTable(command);

            LoadDataGridView();
        }


        private void LoadDataGridView()
        {
            dgOdalar.DataSource = null;
            string query = "SELECT ot.OdaTipId,o.OdaNo,ot.Ad,o.Fiyat,o.Aciklama,o.Aktif FROM tblOdalar o INNER JOIN tblOdaTipleri ot on o.OdaTipId=ot.OdaTipId";

            OleDbCommand command = new OleDbCommand(query, connection);
            dt = DatabaseHelper.LoadDataTable(command);
            if (dt.Rows.Count >= 1)
            {
                dgOdalar.DataSource = dt;
                dgOdalar.Columns[0].Visible = false;
                dgOdalar.Columns[1].HeaderText = "Oda No";
                dgOdalar.Columns[2].HeaderText = "Oda Tip";
                dgOdalar.Columns[3].HeaderText = "Fiyat";
                dgOdalar.Columns[4].HeaderText = "Durum";


            }
        }

        private void dgOdalar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgOdalar.SelectedRows.Count > 0)
            {
                if (e.RowIndex > -1)
                {
                    ClearFormItemsHelper.ResetAllControls(this);
                    txtOdaTip.Text = dgOdalar.Rows[e.RowIndex].Cells[0].Value.ToString();
                    txtEskiOdaNo.Text = dgOdalar.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtOdaNo.Text = dgOdalar.Rows[e.RowIndex].Cells[1].Value.ToString();
                    cmbOdaTip.SelectedText = dgOdalar.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtFiyat.Text = dgOdalar.Rows[e.RowIndex].Cells[3].Value.ToString();
                    txtAciklama.Text = dgOdalar.Rows[e.RowIndex].Cells[4].Value.ToString();
                    chkAktif.Checked = (bool)dgOdalar.Rows[e.RowIndex].Cells[5].Value;
                }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOdaNo.Text))
            {
                dialogResult = MessageBox.Show("Oda seçin", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                dialogResult = MessageBox.Show("Odayı silmek istiyor musunuz ?", "Müşteri Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    int roomNo = Convert.ToInt16(txtOdaNo.Text);
                    string query = "DELETE FROM tblOdalar WHERE OdaNo=" + roomNo;
                    OleDbCommand command = new OleDbCommand(query, connection);

                    int result = DatabaseHelper.ExecuteSql(command);
                    if (result > 0)
                    {
                        dialogResult = MessageBox.Show("Oda başarıyla silindi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        LoadDataGridView();
                        ClearFormItemsHelper.ResetAllControls(this);
                    }
                }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            string query = "";

            if (string.IsNullOrEmpty(txtOdaNo.Text))
            {
                dialogResult = MessageBox.Show("Oda seçiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int oldRoomNo = Convert.ToInt16(txtEskiOdaNo.Text);
                int roomNo = Convert.ToInt16(txtOdaNo.Text);
                int roomNoTypeId = Convert.ToInt16(txtOdaTip.Text);
                decimal price = Convert.ToDecimal(txtFiyat.Text);
                string explanation = txtAciklama.Text;
                bool isActive = chkAktif.Checked;

                if (roomNo != oldRoomNo)
                {
                    query = "UPDATE tblOdalar SET OdaNo=@OdaNo,OdaTipId=@OdaTipId,Fiyat=@Fiyat,Aciklama=@Aciklama,Aktif=@Aktif WHERE OdaNo=" + oldRoomNo;
                }
                else
                {
                    query = "UPDATE tblOdalar SET OdaNo=@OdaNo,OdaTipId=@OdaTipId,Fiyat=@Fiyat,Aciklama=@Aciklama,Aktif=@Aktif WHERE OdaNo=" + roomNo;
                }

               

                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("@OdaNo", roomNo);
                command.Parameters.AddWithValue("@OdaTipId", roomNoTypeId);
                command.Parameters.AddWithValue("@Fiyat", price);
                command.Parameters.AddWithValue("@Aciklama", explanation);
                command.Parameters.AddWithValue("@Aktif", isActive);

                int result = DatabaseHelper.ExecuteSql(command);
                if (result > 0)
                {
                    dialogResult = MessageBox.Show("Oda başarıyla güncellendi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    LoadDataGridView();
                    ClearFormItemsHelper.ResetAllControls(this);


                }

            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            ClearFormItemsHelper.ResetAllControls(this);

        }

        private void txtOdaNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void txtFiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
    }
}
