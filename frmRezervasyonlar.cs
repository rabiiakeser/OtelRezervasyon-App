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
    public partial class frmRezervasyonlar : Form
    {

        DataTable dtReservations = new DataTable();
        DataTable dtRooms = new DataTable();
        DataTable dtCustomers = new DataTable();

        DialogResult dialogResult;
        OleDbConnection connection;

        public frmRezervasyonlar()
        {
            connection = DatabaseHelper.Connect();
            InitializeComponent();
        }

        private void frmRezervasyonlar_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }


        private void LoadDataGridView()
        {
            dgMusteriler.DataSource = null;
            dgOdalar.DataSource = null;
            dgRezervasyonlar.DataSource = null;


            string reservationQuery = "SELECT r.OdaNo,r.MusteriId,m.TcKimlikNo,m.Ad,m.Soyad,m.Telefon,r.GirisTarihi,r.CikisTarihi,r.Aktif,r.RezervasyonId FROM tblRezervasyonlar r INNER JOIN tblMusteriler m on r.MusteriId=m.MusteriId";

            string roomQuery = "SELECT ot.OdaTipId,o.OdaNo,ot.Ad,o.Fiyat,o.Aciklama,o.Aktif FROM tblOdalar o INNER JOIN tblOdaTipleri ot on o.OdaTipId=ot.OdaTipId";
            string customerQuery = "SELECT * FROM tblMusteriler";


            OleDbCommand reservationCommand = new OleDbCommand(reservationQuery, connection);
            reservationCommand.Parameters.AddWithValue("@Aktif", true);
            dtReservations = DatabaseHelper.LoadDataTable(reservationCommand);


            if (dtReservations.Rows.Count >= 1)
            {
                dgRezervasyonlar.DataSource = dtReservations;
                dgRezervasyonlar.Columns[0].HeaderText = "Oda No";
                dgRezervasyonlar.Columns[2].HeaderText = "Tc Kimlik No";
                dgRezervasyonlar.Columns[6].HeaderText = "Giriş Tarihi";
                dgRezervasyonlar.Columns[7].HeaderText = "Çıkış Tarihi";
                dgRezervasyonlar.Columns[9].Visible = false;
                dgRezervasyonlar.Columns[1].Visible = false;



            }

            //dt.Rows.Clear();

            OleDbCommand roomCommand = new OleDbCommand(roomQuery, connection);
            dtRooms = DatabaseHelper.LoadDataTable(roomCommand);
            roomCommand.Parameters.AddWithValue("@Aktif", true);

            if (dtRooms.Rows.Count >= 1)
            {
                dgOdalar.DataSource = dtRooms;
                dgOdalar.Columns[0].Visible = false;
                dgOdalar.Columns[1].HeaderText = "Oda No";
                dgOdalar.Columns[2].HeaderText = "Oda Tip";
                dgOdalar.Columns[3].HeaderText = "Fiyat";
                dgOdalar.Columns[4].HeaderText = "Durum";
            }

            //dt.Rows.Clear();

            OleDbCommand customerCommand = new OleDbCommand(customerQuery, connection);
            dtCustomers = DatabaseHelper.LoadDataTable(customerCommand);

            if (dtCustomers.Rows.Count >= 1)
            {
                dgMusteriler.DataSource = dtCustomers;
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


            //dt.Rows.Clear();

        }

        private void dgOdalar_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dgOdalar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgOdalar.SelectedRows.Count > 0)
            {
                if (e.RowIndex > -1)
                {
                    txtOdaNo.Text = dgOdalar.Rows[e.RowIndex].Cells[1].Value.ToString();

                }
            }
        }

        private void dgMusteriler_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgMusteriler.SelectedRows.Count > 0)
            {
                if (e.RowIndex > -1)
                {
                    txtMusteriNo.Text = dgMusteriler.Rows[e.RowIndex].Cells[0].Value.ToString();

                }
            }

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRezervasyonId.Text))
            {
                dialogResult = MessageBox.Show("Temizleme butonuna tıkladıktan sonra rezervasyon işlemine devam edin", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                int roomNo = Convert.ToInt16(txtOdaNo.Text);
                int customerId = Convert.ToInt16(txtMusteriNo.Text);
                DateTime dateOfEntry = dtpEntryDate.Value.Date;
                DateTime dateOfQuit = dtpQuitDate.Value.Date;
                bool isActive = chkAktif.Checked;

                string roomIsFullQuery = "SELECT * FROM tblRezervasyonlar WHERE OdaNo=" + roomNo + " AND Aktif=" + true;

                OleDbCommand roomIsFullCommand = new OleDbCommand(roomIsFullQuery, connection);
                //roomIsFullCommand.Parameters.AddWithValue("@GirisTarihi", dateOfEntry);
                //roomIsFullCommand.Parameters.AddWithValue("@OdaNo", roomNo);
                //roomIsFullCommand.Parameters.AddWithValue("@Aktif", true);


                dtReservations = DatabaseHelper.LoadDataTable(roomIsFullCommand);
                if (dtReservations.Rows.Count >= 1)
                {
                    bool hasReservation = RoomHasReservation(dateOfEntry, dateOfQuit);
                    if (hasReservation)
                    {
                        dialogResult = MessageBox.Show("Belirtilen tarihte odaya ait bir rezervasyon mevcut", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    else
                    {
                        if (dateOfQuit < dateOfEntry)
                        {
                            dialogResult = MessageBox.Show("Çıkış tarihi giriş tarihinden önce olamaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        else
                        {
                            string query = "INSERT INTO tblRezervasyonlar(OdaNo,MusteriId,GirisTarihi,CikisTarihi,Aktif) VALUES(@OdaNo,@MusteriId,@GirisTarihi,@CikisTarihi,@Aktif)";

                            OleDbCommand command = new OleDbCommand(query, connection);
                            command.Parameters.AddWithValue("@OdaNo", roomNo);
                            command.Parameters.AddWithValue("@MusteriId", customerId);
                            command.Parameters.AddWithValue("@GirisTarihi", dateOfEntry);
                            command.Parameters.AddWithValue("@CikisTarihi", dateOfQuit);
                            command.Parameters.AddWithValue("@Aktif", isActive);


                            int result = DatabaseHelper.ExecuteSql(command);
                            if (result > 0)
                            {
                                dialogResult = MessageBox.Show("Rezervasyon başarıyla yapıldı", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                LoadDataGridView();
                                ClearFormItemsHelper.ResetAllControls(this);

                            }


                        }

                    }

                }

                else
                {
                    string query = "INSERT INTO tblRezervasyonlar(OdaNo,MusteriId,GirisTarihi,CikisTarihi,Aktif) VALUES(@OdaNo,@MusteriId,@GirisTarihi,@CikisTarihi,@Aktif)";

                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@OdaNo", roomNo);
                    command.Parameters.AddWithValue("@MusteriId", customerId);
                    command.Parameters.AddWithValue("@GirisTarihi", dateOfEntry);
                    command.Parameters.AddWithValue("@CikisTarihi", dateOfQuit);
                    command.Parameters.AddWithValue("@Aktif", isActive);


                    int result = DatabaseHelper.ExecuteSql(command);
                    if (result > 0)
                    {
                        dialogResult = MessageBox.Show("Rezervasyon başarıyla yapıldı", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        LoadDataGridView();
                        ClearFormItemsHelper.ResetAllControls(this);

                    }
                }






            }

        }


        private bool RoomHasReservation(DateTime dateOfEntry, DateTime dateOfQuit)
        {
            bool hasReservation = false;
            for (int i = 0; i < dtReservations.Rows.Count; i++)
            {
                DateTime reservationDateOfEntry = Convert.ToDateTime(dtReservations.Rows[i]["GirisTarihi"]);
                DateTime reservationDateOfQuit = Convert.ToDateTime(dtReservations.Rows[i]["CikisTarihi"]);

                if (dateOfEntry >= reservationDateOfEntry)
                {
                    if (dateOfEntry <= reservationDateOfQuit)
                    {

                        hasReservation = true;
                    }
                }

                if (dateOfEntry <= reservationDateOfEntry)
                {
                    if (dateOfQuit >= reservationDateOfEntry && reservationDateOfQuit <= dateOfQuit)
                    {
                        hasReservation = true;
                    }
                }









            }
            return hasReservation;
        }
        private void dgRezervasyonlar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgRezervasyonlar.SelectedRows.Count > 0)
            {
                if (e.RowIndex > -1)
                {
                    ClearFormItemsHelper.ResetAllControls(this);
                    txtOdaNo.Text = dgRezervasyonlar.Rows[e.RowIndex].Cells[0].Value.ToString();
                    txtMusteriNo.Text = dgRezervasyonlar.Rows[e.RowIndex].Cells[1].Value.ToString();
                    dtpEntryDate.Value = Convert.ToDateTime(dgRezervasyonlar.Rows[e.RowIndex].Cells[6].Value);
                    dtpQuitDate.Value = Convert.ToDateTime(dgRezervasyonlar.Rows[e.RowIndex].Cells[7].Value);
                    chkAktif.Checked = (bool)dgRezervasyonlar.Rows[e.RowIndex].Cells[8].Value;
                    txtRezervasyonId.Text = dgRezervasyonlar.Rows[e.RowIndex].Cells[9].Value.ToString();


                }
            }
        }

        private void btnRezervasyonSil_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRezervasyonId.Text))
            {
                dialogResult = MessageBox.Show("Rezervasyon seçiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                dialogResult = MessageBox.Show("Rezervasyonu silmek istiyor musunuz ?", "Rezervasyon Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    //int roomNo = Convert.ToInt16(txtOdaNo.Text);
                    //int customerId = Convert.ToInt16(txtMusteriNo.Text);
                    //DateTime dateOfEntry = dtpEntryDate.Value.Date;
                    //DateTime dateOfQuit = dtpQuitDate.Value.Date;

                    int reservationId = Convert.ToInt16(txtRezervasyonId.Text);

                    string query = "DELETE FROM tblRezervasyonlar WHERE RezervasyonId=@RezervasyonId";

                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("RezervasyonId", reservationId);
                    //command.Parameters.AddWithValue("MusteriId", customerId);
                    //command.Parameters.AddWithValue("OdaNo", roomNo);
                    //command.Parameters.AddWithValue("GirisTarihi", dateOfEntry);
                    //command.Parameters.AddWithValue("CikisTarihi", dateOfQuit);



                    int result = DatabaseHelper.ExecuteSql(command);
                    if (result > 0)
                    {
                        dialogResult = MessageBox.Show("Rezervasyon başarıyla silindi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRezervasyonId.Text))
            {
                dialogResult = MessageBox.Show("Rezervasyon seçin", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                int roomNo = Convert.ToInt16(txtOdaNo.Text);
                int customerId = Convert.ToInt16(txtMusteriNo.Text);
                DateTime dateOfEntry = dtpEntryDate.Value.Date;
                DateTime dateOfQuit = dtpQuitDate.Value.Date;
                bool isChecked = chkAktif.Checked;
                int reservationId = Convert.ToInt16(txtRezervasyonId.Text);


                string roomIsFullQuery = "SELECT * FROM tblRezervasyonlar WHERE OdaNo=" + roomNo + " AND Aktif=" + true + " AND RezervasyonId<>" + reservationId;
                OleDbCommand roomIsFullCommand = new OleDbCommand(roomIsFullQuery, connection);

                dtReservations = DatabaseHelper.LoadDataTable(roomIsFullCommand);
                if (dtReservations.Rows.Count >= 1)
                {

                    bool hasReservation = RoomHasReservation(dateOfEntry, dateOfQuit);
                    if (hasReservation)
                    {
                        dialogResult = MessageBox.Show("Belirtilen tarihte odaya ait bir rezervasyon mevcut", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        string query = "UPDATE tblRezervasyonlar SET OdaNo=@OdaNo,MusteriId=@MusteriId,GirisTarihi=@GirisTarihi,CikisTarihi=@CikisTarihi,Aktif=@Aktif WHERE RezervasyonId=@RezervasyonId";

                        OleDbCommand updateReservationCommand = new OleDbCommand(query, connection);
                        updateReservationCommand.Parameters.AddWithValue("@OdaNo", roomNo);
                        updateReservationCommand.Parameters.AddWithValue("@MusteriId", customerId);
                        updateReservationCommand.Parameters.AddWithValue("@GirisTarihi", dateOfEntry);
                        updateReservationCommand.Parameters.AddWithValue("@CikisTarihi", dateOfQuit);
                        updateReservationCommand.Parameters.AddWithValue("@Aktif", isChecked);
                        updateReservationCommand.Parameters.AddWithValue("@RezervasyonId", reservationId);


                        int result = DatabaseHelper.ExecuteSql(updateReservationCommand);
                        if (result > 0)
                        {
                            dialogResult = MessageBox.Show("Rezervasyon başarıyla güncellendi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            LoadDataGridView();
                            ClearFormItemsHelper.ResetAllControls(this);

                        }
                    }

                }
                else
                {
                    string query = "UPDATE tblRezervasyonlar SET OdaNo=@OdaNo,MusteriId=@MusteriId,GirisTarihi=@GirisTarihi,CikisTarihi=@CikisTarihi,Aktif=@Aktif WHERE RezervasyonId=@RezervasyonId";

                    OleDbCommand updateReservationCommand = new OleDbCommand(query, connection);
                    updateReservationCommand.Parameters.AddWithValue("@OdaNo", roomNo);
                    updateReservationCommand.Parameters.AddWithValue("@MusteriId", customerId);
                    updateReservationCommand.Parameters.AddWithValue("@GirisTarihi", dateOfEntry);
                    updateReservationCommand.Parameters.AddWithValue("@CikisTarihi", dateOfQuit);
                    updateReservationCommand.Parameters.AddWithValue("@Aktif", isChecked);
                    updateReservationCommand.Parameters.AddWithValue("@RezervasyonId", reservationId);


                    int result = DatabaseHelper.ExecuteSql(updateReservationCommand);
                    if (result > 0)
                    {
                        dialogResult = MessageBox.Show("Rezervasyon başarıyla güncellendi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        LoadDataGridView();
                        ClearFormItemsHelper.ResetAllControls(this);

                    }
                }
            }
        }

        private void btnMusteriAra_Click(object sender, EventArgs e)
        {

        }

        private void txtMusteriAra_TextChanged(object sender, EventArgs e)
        {
            string query = "";
            if (txtMusteriAra.Text != string.Empty)
                query += "Ad like '%" + txtMusteriAra.Text.Trim() + "%' or ";
            if (txtMusteriAra.Text != string.Empty)
                query += "Soyad like '%" + txtMusteriAra.Text.Trim() + "%' or ";

            if (txtMusteriAra.Text != string.Empty)
                query += "TcKimlikNo like '%" + txtMusteriAra.Text.Trim() + "%' or ";

            if (txtMusteriAra.Text != string.Empty)
                query += "Cinsiyet like '%" + txtMusteriAra.Text.Trim() + "%' or ";

            if (txtMusteriAra.Text != string.Empty)
                query += "Telefon like '%" + txtMusteriAra.Text.Trim() + "%' or ";

            if (txtMusteriAra.Text != string.Empty)
                query += "EPosta like '%" + txtMusteriAra.Text.Trim() + "%'";

           
            (dgMusteriler.DataSource as DataTable).DefaultView.RowFilter = query;
        }

        private void txtOdaAra_TextChanged(object sender, EventArgs e)
        {
            string query = "";

            if (txtOdaAra.Text != string.Empty)
                query += "Convert(OdaNo, 'System.String') like '%" + txtOdaAra.Text + "%'";

           

            (dgOdalar.DataSource as DataTable).DefaultView.RowFilter = query;

        }

        private void txtRezervasyonAra_TextChanged(object sender, EventArgs e)
        {
            string query = "";

            if (txtRezervasyonAra.Text != string.Empty)
                query += "Convert(OdaNo, 'System.String') like '%" + txtRezervasyonAra.Text + "%'";
           

            (dgRezervasyonlar.DataSource as DataTable).DefaultView.RowFilter = query;
        }
    }
}
