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
    public partial class frmOdaTipleri : Form
    {
        DataTable dt = new DataTable();
        DialogResult dialogResult;
        OleDbConnection connection;

        public frmOdaTipleri()
        {
            connection = DatabaseHelper.Connect();
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOdaTipAd.Text))
            {

                dialogResult = MessageBox.Show("Lütfen tüm alanları doldurun", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string roomTypeName = txtOdaTipAd.Text;
                bool isActive = chkAktif.Checked;

                string query = "INSERT INTO tblOdaTipleri (Ad,Aktif) VALUES (@Ad,@Aktif)";

                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("@Ad", roomTypeName);
                command.Parameters.AddWithValue("@Aktif", isActive);

                int result = DatabaseHelper.ExecuteSql(command);
                if (result > 0)
                {
                    dialogResult = MessageBox.Show("Oda tipi başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    LoadDataGridView();
                    ClearFormItemsHelper.ResetAllControls(this);


                }
            }
        }

        private void frmOdaTipleri_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            dgOdaTipleri.DataSource = null;

            string query = "SELECT * from tblOdaTipleri WHERE Aktif=@Aktif";

            OleDbCommand command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("@Aktif", true);
            dt = DatabaseHelper.LoadDataTable(command);

            if (dt.Rows.Count > 0)
            {
                dgOdaTipleri.DataSource = dt;
                dgOdaTipleri.Columns[0].Visible = false;
                dgOdaTipleri.Columns[1].HeaderText = "Oda Tip";
                dgOdaTipleri.Columns[2].HeaderText = "Durum";

            }

        }

        private void dgOdaTipleri_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgOdaTipleri.SelectedRows.Count > 0)
            {
                if (e.RowIndex > -1)
                {
                    ClearFormItemsHelper.ResetAllControls(this);
                    txtOdaTipId.Text = dgOdaTipleri.Rows[e.RowIndex].Cells[0].Value.ToString();
                    txtOdaTipAd.Text = dgOdaTipleri.Rows[e.RowIndex].Cells[1].Value.ToString();
                    chkAktif.Checked = (bool)dgOdaTipleri.Rows[e.RowIndex].Cells[2].Value;

                }
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            ClearFormItemsHelper.ResetAllControls(this);

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            string query = "";

            if (string.IsNullOrEmpty(txtOdaTipAd.Text))
            {
                dialogResult = MessageBox.Show("Oda tipini boş geçmeyin", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int roomTypeId = Convert.ToInt16(txtOdaTipId.Text);
                string roomTypeName = txtOdaTipAd.Text;
                bool isActive = chkAktif.Checked;

                query = "UPDATE tblOdaTipleri SET Ad=@Ad,Aktif=@Aktif WHERE OdaTipId=" + roomTypeId;

                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("@Ad", roomTypeName);
                command.Parameters.AddWithValue("@Aktif", isActive);

                int result = DatabaseHelper.ExecuteSql(command);
                if (result > 0)
                {
                    dialogResult = MessageBox.Show("Oda tipi başarıyla güncellendi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    LoadDataGridView();
                    ClearFormItemsHelper.ResetAllControls(this);


                }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            string query = "";
            if (string.IsNullOrEmpty(txtOdaTipId.Text))
            {
                dialogResult = MessageBox.Show("Oda tipi seçin", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int roomTypeId = Convert.ToInt16(txtOdaTipId.Text);
                query = "DELETE FROM tblOdaTipleri WHERE OdaTipId="+roomTypeId;

                OleDbCommand command = new OleDbCommand(query, connection);

                int result = DatabaseHelper.ExecuteSql(command);
                if (result > 0)
                {
                    dialogResult = MessageBox.Show("Oda tipi başarıyla silindi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    LoadDataGridView();
                    ClearFormItemsHelper.ResetAllControls(this);
                }
            }
        }
    }
}
