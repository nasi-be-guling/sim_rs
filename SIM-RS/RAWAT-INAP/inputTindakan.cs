using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SIM_RS.RAWAT_INAP
{
    public partial class inputTindakan : Form
    {

        C4Module.MainModule modMain = new C4Module.MainModule();
        C4Module.DatabaseModule modDb = new C4Module.DatabaseModule();
        C4Module.MessageModule modMsg = new C4Module.MessageModule();
        C4Module.SQLModule modSQL = new C4Module.SQLModule();


        string strQuerySQL = "";
        string strErr = "";

        AutoCompleteStringCollection listTarif = new AutoCompleteStringCollection();
        AutoCompleteStringCollection listDokter = new AutoCompleteStringCollection();
        AutoCompleteStringCollection listTempatLayanan = new AutoCompleteStringCollection();

        public class lstDaftarTarif
        {

            public string strKodeTarif { get; set; }
            public string strUraianTarif { get; set; }
            public double dblBiaya { get; set; }
            public string strTarifSMF { get; set; }

        }
        public List<lstDaftarTarif> grpLstDaftarTarif = new List<lstDaftarTarif>();


        public class lstDaftarTindakan
        {
            public int intNoUrut { get; set; }
            public string strKodeTarif { get; set; }
            public string strUraianTarif { get; set; }
            public double dblBiaya { get; set; }
            public string strKodeDokter { get; set; }
        }
        List<lstDaftarTindakan> grpLstDaftarTindakan = new List<lstDaftarTindakan>();


        public class lstDaftarDokter
        {
            public string strKodeDokter { get; set; }
            public string strNamaDokter { get; set; }
        }
        List<lstDaftarDokter> grpLstDaftarDokter = new List<lstDaftarDokter>();

        public class lstTempatLayanan
        {
            public string strKodeRuang { get; set; }
            public string strNamaRuang { get; set; }
        }
        List<lstTempatLayanan> grpLstTempatLayanan = new List<lstTempatLayanan>();


        /*  FUNCTION  */

        /*
        *  NAME        : pvLoadDataInisialasi
        *  FUNCTION    : Load data that need for this form on first time.
        *  RESULT      : -
        *  CREATED     : Eka Rudito (eka@rudito.web.id)
        *  DATE        : 19-02-2013    
        */

        private void pvLoadDataInisialasi()
        {
            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_CONN;

            SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                return;
            }

            this.strQuerySQL = "SELECT "+
                                    "ruangan, "+
                                    "idmr_truangan "+
                                "FROM MR_TRUANGAN WITH (NOLOCK) "+
                                "WHERE dipakai = 'Y' and SUBSTRING(ruangan,1,1) <> '-' "+
                                "ORDER BY ruangan";
            SqlDataReader reader = modDb.pbreaderSQL(conn, this.strQuerySQL, ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                conn.Close();
                return;
            }

            listTempatLayanan.Clear();
            //txtTempatLayanan.Items.Clear();
            grpLstTempatLayanan.Clear();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //cmbTempatLayanan.Items.Add(modMain.pbstrgetCol(reader,0,ref strErr,""));

                    listTempatLayanan.Add(modMain.pbstrgetCol(reader, 0, ref strErr, ""));

                    lstTempatLayanan itemTempatLayanan = new lstTempatLayanan();
                    itemTempatLayanan.strKodeRuang = modMain.pbstrgetCol(reader, 1, ref strErr, "");
                    itemTempatLayanan.strNamaRuang = modMain.pbstrgetCol(reader, 0, ref strErr, "");
                    grpLstTempatLayanan.Add(itemTempatLayanan);
                }

            }


            reader.Close();

            txtTempatLayanan.AutoCompleteCustomSource = listTempatLayanan;
            txtTempatLayanan.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtTempatLayanan.AutoCompleteSource = AutoCompleteSource.CustomSource;


            strQuerySQL = "SELECT " +
                                "BL_TARIP.idbl_tarip, " +        //0
                                "BL_TARIP.uraiantarip, " +       //1
                                "BL_TARIP.idmr_tsmf, " +         //2
                                "BL_TARIP.nilai " +             //3
                           "FROM BL_TARIP WITH (NOLOCK) " +                           
                           "WHERE BL_TARIP.nilai > 0 " +
                                "AND BL_TARIP.dipakai = 'Y'";

            reader = modDb.pbreaderSQL(conn, this.strQuerySQL, ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                conn.Close();
                return;
            }

            listTarif.Clear();
            grpLstDaftarTarif.Clear();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    listTarif.Add(modMain.pbstrgetCol(reader, 0, ref strErr, ""));
                    lstDaftarTarif itemDaftarTarif = new lstDaftarTarif();
                    itemDaftarTarif.strKodeTarif = modMain.pbstrgetCol(reader, 0, ref strErr, "");
                    itemDaftarTarif.strUraianTarif = modMain.pbstrgetCol(reader, 1, ref strErr, "");
                    itemDaftarTarif.dblBiaya = Convert.ToDouble(modMain.pbstrgetCol(reader, 3, ref strErr, ""));
                    itemDaftarTarif.strTarifSMF = modMain.pbstrgetCol(reader, 2, ref strErr, "");
                    grpLstDaftarTarif.Add(itemDaftarTarif);
                }
            }


            reader.Close();

            txtKodeTindakan.AutoCompleteCustomSource = listTarif;
            txtKodeTindakan.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtKodeTindakan.AutoCompleteSource = AutoCompleteSource.CustomSource;


            this.strQuerySQL = "SELECT " +
                                "MR_DOKTER.idmr_dokter, " +           //0
                                "MR_DOKTER.nama " +                  //1
                               "FROM MR_DOKTER WITH (NOLOCK) " +
                               "WHERE MR_DOKTER.dipakai = 'Y'";

            reader = modDb.pbreaderSQL(conn, this.strQuerySQL, ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                conn.Close();
                return;
            }

            listDokter.Clear();
            grpLstDaftarDokter.Clear();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    listDokter.Add(modMain.pbstrgetCol(reader, 1, ref strErr, ""));

                    lstDaftarDokter itemDaftarDokter = new lstDaftarDokter();
                    itemDaftarDokter.strKodeDokter = modMain.pbstrgetCol(reader, 0, ref strErr, "");
                    itemDaftarDokter.strNamaDokter = modMain.pbstrgetCol(reader, 1, ref strErr, "");

                    grpLstDaftarDokter.Add(itemDaftarDokter);


                }
            }


            reader.Close();




            txtNamaDokter.AutoCompleteCustomSource = listDokter;
            txtNamaDokter.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtNamaDokter.AutoCompleteSource = AutoCompleteSource.CustomSource;



            conn.Close();


            lblPetugas.Text = halamanUtama.strNamaUser;

        }


        /*
      *  NAME        : pvLoadDataPasien
      *  FUNCTION    : Load patient data from billing register
      *  RESULT      : -
      *  CREATED     : Eka Rudito (eka@rudito.web.id)
      *  DATE        : 19-02-2013    
      */

        private void pvLoadDataPasien(string _strNoTransBilling)
        {

            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_CONN;

            SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                return;
            }

            this.strQuerySQL = "SELECT " +
                                    "MR_PASIEN.nama, " +                        //0
                                    "MR_PASIEN.alamat, " +                      //1
                                    "MR_PASIEN.idmr_pasien, " +                 //2
                                    "MR_MUTASIPASIEN.idmr_mutasipasien, " +     //3
                                    "MR_TRUANGAN.ruangan, " +                   //4
                                    "MR_TEMPATLAYANAN.idmr_tempatlayanan, " +   //5
                                    "MR_TRUANGAN.idmr_jeniskelas, " +           //6
                                    "MR_MUTASIPASIEN.idmr_tstatus, " +          //7
                                    "MR_TRUANGAN.idmr_truangan, " +             //8
                                    "MR_MUTASIPASIEN.tanggal_mrs " +            //9
                               "FROM MR_PASIEN WITH (NOLOCK) " +
                               "INNER JOIN MR_MUTASIPASIEN " +
                                    "ON MR_PASIEN.idmr_pasien = MR_MUTASIPASIEN.idmr_pasien " +
                               "INNER JOIN MR_TEMPATLAYANAN " +
                                    "ON MR_MUTASIPASIEN.idmr_tempatlayanan = MR_TEMPATLAYANAN.idmr_tempatlayanan " +
                               "INNER JOIN MR_TRUANGAN " +
                                    "ON MR_TEMPATLAYANAN.idmr_truangan = MR_TRUANGAN.idmr_truangan " +
                               "WHERE MR_MUTASIPASIEN.sistem = 'IRNA' " +
                                    "AND MR_MUTASIPASIEN.batal = '' " +
                                    "AND MR_MUTASIPASIEN.lunas = '' " +
                                    "AND MR_MUTASIPASIEN.regbilling = '" + txtNoBilling.Text.Trim().ToString() + "'";
            SqlDataReader reader = modDb.pbreaderSQL(conn, this.strQuerySQL, ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                conn.Close();
                return;
            }

            if (reader.HasRows)
            {
                reader.Read();

                lblMRPasien.Text = modMain.pbstrgetCol(reader, 2, ref strErr, "");
                lblAlamatPasien.Text = modMain.pbstrgetCol(reader, 1, ref strErr, "");
                lblRuangan.Text = modMain.pbstrgetCol(reader, 4, ref strErr, "");
                lblKelas.Text = modMain.pbstrgetCol(reader, 6, ref strErr, "");
                lblStatusPasien.Text = modMain.pbstrgetCol(reader, 7, ref strErr, "");
                lblNamaPasien.Text = modMain.pbstrgetCol(reader, 0, ref strErr, "");

                this.pvEnableInput();
                this.dtpTglTindakan.Focus();
            }
            else
            {
                MessageBox.Show("No Register Billing tidak ditemukan ", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            conn.Close();

        }

        /*
     *  NAME        : pvDisableInput
     *  FUNCTION    : disable input on the first time or after save data
     *  RESULT      : -
     *  CREATED     : Eka Rudito (eka@rudito.web.id)
     *  DATE        : 19-02-2013    
     */
        private void pvDisableInput()
        {

            txtNoBilling.Enabled = true;
            lvDaftarTindakan.Enabled = false;
            txtTempatLayanan.Enabled = false;
            txtKodeTindakan.Enabled = false;
            txtNamaDokter.Enabled = false;
            dtpTglTindakan.Enabled = false;
            btnTampilDaftarTindakan.Enabled = false;
            btnTambahTindakan.Enabled = false;
        }

        /*
     *  NAME        : pvEnableInput
     *  FUNCTION    : enable input after enter and found billing registration number
     *  RESULT      : -
     *  CREATED     : Eka Rudito (eka@rudito.web.id)
     *  DATE        : 19-02-2013    
     */
        private void pvEnableInput()
        {
            txtNoBilling.Enabled = false;
            lvDaftarTindakan.Enabled = true;
            txtTempatLayanan.Enabled = true;
            txtKodeTindakan.Enabled = true;
            txtNamaDokter.Enabled = true;
            dtpTglTindakan.Enabled = true;
            btnTampilDaftarTindakan.Enabled = true;
            btnTambahTindakan.Enabled = true;
        }

        /*
     *  NAME        : pvIniSialisasiObject
     *  FUNCTION    : assign the tab index
     *  RESULT      : -
     *  CREATED     : Eka Rudito (eka@rudito.web.id)
     *  DATE        : 19-02-2013    
     */
        private void pvIniSialisasiObject()
        {
            int intNoUrutObject = 0;

            modMain.pvUrutkanTab(txtNoBilling, ref intNoUrutObject);
            modMain.pvUrutkanTab(dtpTglTindakan, ref intNoUrutObject,true);
            modMain.pvUrutkanTab(txtTempatLayanan, ref intNoUrutObject);
            modMain.pvUrutkanTab(txtKodeTindakan, ref intNoUrutObject);
            modMain.pvUrutkanTab(btnTampilDaftarTindakan, ref intNoUrutObject);
            modMain.pvUrutkanTab(txtNamaDokter, ref intNoUrutObject);
            modMain.pvUrutkanTab(btnTambahTindakan, ref intNoUrutObject);
            modMain.pvUrutkanTab(btnSimpanIsiTindakan, ref intNoUrutObject);
            modMain.pvUrutkanTab(btnKeluarIsiTindakan, ref intNoUrutObject);

        }

        private void pvCleanInput()
        {
            txtNoBilling.Text = "";
            lblAlamatPasien.Text = "";
            lblKelas.Text = "";
            lblMRPasien.Text = "";
            lblNamaPasien.Text = "";
            lblRuangan.Text = "";
            lblStatusPasien.Text = "";
            lvDaftarTindakan.Items.Clear();
            dtpTglTindakan.Value = halamanUtama.dtTglServer;
        }

        /* EOF FUNCTION*/

        public inputTindakan()
        {
            InitializeComponent();

            this.pvCleanInput();
            this.pvIniSialisasiObject();
            this.pvLoadDataInisialasi();            
            this.pvDisableInput();


        }

        private void inputTindakan_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void txtNoBilling_KeyPress(object sender, KeyPressEventArgs e)
        {            
            if (e.KeyChar == 13)
            {
                if (txtNoBilling.Text.Trim().ToString() == "")
                    return;

                this.pvLoadDataPasien(txtNoBilling.Text.Trim());
            }
        }

        private void btnKeluarIsiTindakan_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void inputTindakan_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!txtNoBilling.Enabled)
            {
                DialogResult msgDlg = MessageBox.Show("Apakah anda akan melakukan pembatalan isi tindakan ?",
                                                        "Konfirmasi",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question);

                if (msgDlg == DialogResult.No)
                    e.Cancel = true;
            }
        }

        private void txtKodeTindakan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }
       

        private void cmbTempatLayanan_Enter(object sender, EventArgs e)
        {
           
        }

        private void txtTempatLayanan_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && (txtTempatLayanan.Text != ""))
            {
                int intResultSearch = grpLstTempatLayanan.FindIndex(m => m.strNamaRuang == txtTempatLayanan.Text);

                if (intResultSearch == -1)
                {
                    MessageBox.Show("Nama Ruang yang anda masukkan tidak terdaftar",
                                    "Informasi",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    txtTempatLayanan.Focus();
                }
                else
                {
                    txtKodeTindakan.Focus();
                }
            }
            else if ((e.KeyCode == Keys.Enter) && (txtTempatLayanan.Text == ""))
            {
                /*  if EMPTY What should i do.. ;) */
                txtTempatLayanan.Text = lblRuangan.Text;
                txtKodeTindakan.Focus();

            }
        }

        private void txtTempatLayanan_Enter(object sender, EventArgs e)
        {
            txtTempatLayanan.Text = "";
            txtTempatLayanan.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtKodeTindakan_Enter(object sender, EventArgs e)
        {
            txtKodeTindakan.Text = "";
            txtKodeTindakan.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtNamaDokter_Enter(object sender, EventArgs e)
        {
            txtNamaDokter.Text = "";
            txtNamaDokter.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtKodeTindakan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNamaDokter.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

        }

        private void txtNamaDokter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTambahTindakan.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtNamaDokter_Leave(object sender, EventArgs e)
        {
            if (txtNamaDokter.Text.Trim().ToString() == "")
            {
                if (lblKelas.Text == "SATU")
                {
                    /* perlu ditanyakan apakah setiap tindakan kelas satu harus memilih dokter */

                }
            }
            else
            {
                /*Cek kode tindakan di database*/

                int intResultSearch = grpLstDaftarDokter.FindIndex(
                                        m => m.strNamaDokter == txtNamaDokter.Text.Trim().ToString());

                if (intResultSearch == -1)
                {
                    MessageBox.Show("Nama Dokter yang anda masukkan tidak terdaftar",
                                    "Informasi",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    txtKodeTindakan.Focus();

                }
            }
        }

        private void txtKodeTindakan_Leave(object sender, EventArgs e)
        {
            if (txtKodeTindakan.Text.Trim().ToString() == "")
            {
                btnTampilDaftarTindakan.Enabled = true;
            }
            else
            {
                /*Cek kode tindakan di database*/

                int intResultSearch = grpLstDaftarTarif.FindIndex(
                                        m => m.strKodeTarif == txtKodeTindakan.Text);

                if (intResultSearch == -1)
                {
                    MessageBox.Show("Kode tindakan yang anda masukkan tidak terdaftar",
                                    "Informasi",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    btnTampilDaftarTindakan.Enabled = true;
                    txtKodeTindakan.Focus();

                }
                else
                {

                    lblBiayaTindakan.Text = grpLstDaftarTarif[intResultSearch].dblBiaya.ToString();
                    lblDeskripsiTindakan.Text = grpLstDaftarTarif[intResultSearch].strUraianTarif;
                    btnTampilDaftarTindakan.Enabled = false;

                }
            }
        }

        private void inputTindakan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtTempatLayanan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtNamaDokter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }            
        }

        private void btnTampilDaftarTindakan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                daftarTindakan fDaftarTindakan = new daftarTindakan();
                fDaftarTindakan.ShowDialog();
            }
        }

        private void btnTampilDaftarTindakan_Click(object sender, EventArgs e)
        {
            daftarTindakan fDaftarTindakan = new daftarTindakan();
            fDaftarTindakan.ShowDialog();
        }

        private void btnTambahTindakan_Click(object sender, EventArgs e)
        {
            if (txtKodeTindakan.Text.Trim().ToString() == "")
            {
                MessageBox.Show("Kode Tindakan harus di isi terlebih dahulu",
                                "Informasi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                txtKodeTindakan.Focus();


            }
        }

      
    }
}
