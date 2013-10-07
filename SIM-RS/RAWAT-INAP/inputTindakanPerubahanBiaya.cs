using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;


namespace SIM_RS.RAWAT_INAP
{
    public partial class inputTindakanPerubahanBiaya : Form
    {

        C4Module.MainModule modMain = new C4Module.MainModule();
        C4Module.DatabaseModule modDb = new C4Module.DatabaseModule();
        C4Module.MessageModule modMsg = new C4Module.MessageModule();
        C4Module.SQLModule modSQL = new C4Module.SQLModule();
        C4Module.PrintModule modPrint = new C4Module.PrintModule();

        string strQuerySQL = "";
        string strErr = "";

        /*VARIABLE INSERT TO BL_TRANSAKSI*/
        string strIdMutasiPasien = "";
        string strIdMR_TempatLayanan = "";
        string strIdMR_TRuangan = "";

        int intUrutanTrans = 0;

        AutoCompleteStringCollection listTarif = new AutoCompleteStringCollection();
        AutoCompleteStringCollection listDokter = new AutoCompleteStringCollection();
        AutoCompleteStringCollection listTempatLayanan = new AutoCompleteStringCollection();

        public class lstDaftarTarif
        {
            public string strKodeTarif { get; set; }
            public string strUraianTarif { get; set; }
            public double dblBiaya { get; set; }
            public string strSMF { get; set; }
        }
        public List<lstDaftarTarif> grpLstDaftarTarif = new List<lstDaftarTarif>();

        public class lstDaftarKomponenTarif
        {
            public string strKodeTarif { get; set; }
            public string strId_Komponen { get; set; }
            public double dblByKomponen { get; set; }
            public double dblHak1 { get; set; }
            public double dblHak2 { get; set; }
            public double dblHak3 { get; set; }
            public int intPrioritasTunai { get; set; }
            public int intNoUrut { get; set; }
            public string strKodeDokter { get; set; }
            public string strNamaDokter { get; set; }
            public double dblNilaiTambah { get; set; }
            public double dblNilaiKeringanan { get; set; }
        }
        public List<lstDaftarKomponenTarif> grpLstDaftarKomponenTarif = new List<lstDaftarKomponenTarif>();
        public List<lstDaftarKomponenTarif> grpLstDaftarLengkapKomponenTarif = new List<lstDaftarKomponenTarif>();

        public class lstDaftarTindakan
        {
            public int intNoUrut { get; set; }
            public string strKodeTarif { get; set; }
            public string strUraianTarif { get; set; }
            public double dblBiaya { get; set; }
            public string strTSMFTindakan { get; set; }
            public string strTempatLayanan { get; set; }
            public int intIdTempatLayanan { get; set; }
            public string strIdMRRuangan { get; set; }
            public DateTime dtTgl { get; set; }
        }
        List<lstDaftarTindakan> grpLstDaftarTindakan = new List<lstDaftarTindakan>();
        List<lstDaftarKomponenTarif> grpLstDaftarTindakanDetail = new List<lstDaftarKomponenTarif>();
        List<lstDaftarKomponenTarif> grpLstTempTindakanDetail = new List<lstDaftarKomponenTarif>();


        public class lstDaftarDokter
        {
            public string strKodeDokter { get; set; }
            public string strNamaDokter { get; set; }
            public string strSMF { get; set; }
        }
        List<lstDaftarDokter> grpLstDaftarDokter = new List<lstDaftarDokter>();

        public class lstTempatLayanan
        {
            public string strKodeRuang { get; set; }
            public string strNamaRuang { get; set; }
        }
        List<lstTempatLayanan> grpLstTempatLayanan = new List<lstTempatLayanan>();

        public inputTindakanPerubahanBiaya()
        {
            InitializeComponent();
        }


        /* PRIVATE FUNCTION*/

        /*
        *  NAME        : pvEnableInput
        *  FUNCTION    : enable input after enter and found billing registration number
        *  RESULT      : -
        *  CREATED     : Eka Rudito (eka@rudito.web.id)
        *  DATE        : 19-02-2013    
        */
        private void pvEnableInput()
        {
            txtNoBilling.SafeControlInvoke(TextBox => txtNoBilling.Enabled = false);
            lvDaftarTindakan.SafeControlInvoke(ListView => lvDaftarTindakan.Enabled = true);
            txtTempatLayanan.SafeControlInvoke(TextBox => txtTempatLayanan.Enabled = true);
            txtKodeTindakan.SafeControlInvoke(TextBox => txtKodeTindakan.Enabled = true);
            txtNamaDokter.SafeControlInvoke(TextBox => txtNamaDokter.Enabled = true);
            dtpTglTindakan.SafeControlInvoke(DateTimePicker => dtpTglTindakan.Enabled = true);
            btnTampilDaftarTindakan.SafeControlInvoke(Button => btnTampilDaftarTindakan.Enabled = true);
            btnTambahTindakan.SafeControlInvoke(Button => btnTambahTindakan.Enabled = true);
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
            modMain.pvUrutkanTab(lblDaftarTindakan, ref intNoUrutObject);
            modMain.pvUrutkanTab(lvDaftarTindakan, ref intNoUrutObject);

            modMain.pvUrutkanTab(dtpTglTindakan, ref intNoUrutObject, true);
            modMain.pvUrutkanTab(txtTempatLayanan, ref intNoUrutObject);

            modMain.pvUrutkanTab(lblKodeTindakan, ref intNoUrutObject);
            modMain.pvUrutkanTab(txtKodeTindakan, ref intNoUrutObject);

            modMain.pvUrutkanTab(btnTampilDaftarTindakan, ref intNoUrutObject);

            modMain.pvUrutkanTab(lblKomponen, ref intNoUrutObject);
            modMain.pvUrutkanTab(cmbKomponenTarif, ref intNoUrutObject);

            modMain.pvUrutkanTab(lblDokter, ref intNoUrutObject);
            modMain.pvUrutkanTab(txtNamaDokter, ref intNoUrutObject);
            modMain.pvUrutkanTab(btnTambahKompDokter, ref intNoUrutObject);

            modMain.pvUrutkanTab(btnTambahTindakan, ref intNoUrutObject);
            modMain.pvUrutkanTab(btnSimpanIsiTindakan, ref intNoUrutObject);
            modMain.pvUrutkanTab(btnKeluarIsiTindakan, ref intNoUrutObject);

        }


        private void pvCleanInput()
        {
            txtNoBilling.Text = "";
            lblAlamatPasien.Text = "...";
            lblKelas.Text = "...";
            lblMRPasien.Text = "...";
            lblNamaPasien.Text = "...";
            lblRuangan.Text = "...";
            lblStatusPasien.Text = "...";
            lvDaftarTindakan.Items.Clear();
            dtpTglTindakan.Value = halamanUtama.dtTglServer;
            txtTempatLayanan.Text = "";

            grpLstDaftarTindakan.Clear();
            grpLstDaftarKomponenTarif.Clear();

            intUrutanTrans = 0;

        }

        /**/
        


        private void bgWork_DoWork(object sender, DoWorkEventArgs e)
        {
            txtNoBilling.SafeControlInvoke(TextBox => txtNoBilling.Enabled = false);

            lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = true);

            this.strErr = "";

            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_BILLING_LAMA;

            SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {
                //timerBlink.Stop();
                //timerBlink.Enabled = false;
                lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = false);
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                return;
            }


            string strNoBilling = "";
            txtNoBilling.SafeControlInvoke(TextBox => strNoBilling = txtNoBilling.Text.Trim().ToString());


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
                                    "MR_MUTASIPASIEN.tanggal_mrs, " +            //9
                                    "MR_MUTASIPASIEN.idMr_Subsistem " +            //10
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
                                    "AND MR_MUTASIPASIEN.regbilling = '" + strNoBilling + "'";
            SqlDataReader reader = modDb.pbreaderSQL(conn, this.strQuerySQL, ref strErr);
            if (strErr != "")
            {
                //timerBlink.Stop();
                //timerBlink.Enabled = false;
                lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = false);
                txtNoBilling.SafeControlInvoke(TextBox => txtNoBilling.Enabled = true);

                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                conn.Close();
                return;
            }

            if (reader.HasRows)
            {
                reader.Read();

                string strSubSistem = modMain.pbstrgetCol(reader, 10, ref strErr, "");
                //string strKelas = modMain.pbstrgetCol(reader, 6, ref strErr, "");

                //MessageBox.Show(strKelas.ToString());

                if (strSubSistem.Trim().ToString() != "PAV")
                {

                    //timerBlink.Stop();
                    //timerBlink.Enabled = false;
                    lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = false);
                    txtNoBilling.SafeControlInvoke(TextBox => txtNoBilling.Enabled = true);

                    MessageBox.Show("Pengentrian Tindakan ini hanya untuk Pasien Instalasi Pelayanan Utama (IPU)",
                                    "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    reader.Close();
                    conn.Close();
                    return;
                }

                lblMRPasien.SafeControlInvoke(Label => lblMRPasien.Text = modMain.pbstrgetCol(reader, 2, ref strErr, ""));
                lblAlamatPasien.SafeControlInvoke(Label => lblAlamatPasien.Text = modMain.pbstrgetCol(reader, 1, ref strErr, ""));
                lblRuangan.SafeControlInvoke(Label => lblRuangan.Text = modMain.pbstrgetCol(reader, 4, ref strErr, ""));
                lblKelas.SafeControlInvoke(Label => lblKelas.Text = modMain.pbstrgetCol(reader, 6, ref strErr, ""));
                lblStatusPasien.SafeControlInvoke(Label => lblStatusPasien.Text = modMain.pbstrgetCol(reader, 7, ref strErr, ""));
                lblNamaPasien.SafeControlInvoke(Label => lblNamaPasien.Text = modMain.pbstrgetCol(reader, 0, ref strErr, ""));

                strIdMR_TempatLayanan = modMain.pbstrgetCol(reader, 5, ref strErr, "");
                strIdMutasiPasien = modMain.pbstrgetCol(reader, 3, ref strErr, "");
                strIdMR_TRuangan = modMain.pbstrgetCol(reader, 4, ref strErr, "");

                this.pvEnableInput();
                dtpTglTindakan.SafeControlInvoke(DateTimePicker => dtpTglTindakan.Focus());
                btnKeluarIsiTindakan.SafeControlInvoke(Button => btnKeluarIsiTindakan.Text = "&BATAL");
            }
            else
            {

                //timerBlink.Stop();
                //timerBlink.Enabled = false;
                lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = false);
                txtNoBilling.SafeControlInvoke(TextBox => txtNoBilling.Enabled = true);

                MessageBox.Show("No Register Billing tidak ditemukan ", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            conn.Close();

            //timerBlink.Stop();
            //timerBlink.Enabled = false;
            lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = false);
        }

        private void inputTindakanPerubahanBiaya_Load(object sender, EventArgs e)
        {

        }

        private void txtKodeTindakan_Leave(object sender, EventArgs e)
        {
            if (txtKodeTindakan.Text.Trim().ToString() == "") //cek apakah kode tindakan harus ada isinya..
            {
                btnTampilDaftarTindakan.Enabled = true;
            }
            else //jika sudah terisi
            {
                /*Cek kode tindakan di database*/

                String[] strKodePart = Regex.Split(txtKodeTindakan.Text.Trim().ToString(), "--");

                string strKode = strKodePart[0].Trim().ToString();
                string strUraian = strKodePart[1].Trim().ToString();

                int intResultSearch = grpLstDaftarTarif.FindIndex(
                                        m => m.strKodeTarif == strKode);

                if (intResultSearch == -1) //dicek apakah tindakan tersebut ada di dalam database.
                {
                    MessageBox.Show("Kode tindakan yang anda masukkan tidak terdaftar",
                                    "Informasi",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    btnTampilDaftarTindakan.Enabled = true;
                    txtKodeTindakan.Focus();
                }
                else //jika tindakan tersebut ada maka proses selanjutnya.
                {

                    //Tampilkan detail komponen apa saja
                    var DetailKomponen = from x in grpLstDaftarLengkapKomponenTarif
                                         where x.strKodeTarif == strKode
                                         select x;

                    if (DetailKomponen.Count() > 0)
                    {
                        cmbKomponenTarif.Items.Clear();
                        cmbKomponenTarif.Enabled = true;
                        grpLstTempTindakanDetail.Clear();
                        foreach (lstDaftarKomponenTarif itemKomponen in DetailKomponen)
                        {
                            cmbKomponenTarif.Items.Add(itemKomponen.strId_Komponen);

                            lstDaftarKomponenTarif itemKomponenX = new lstDaftarKomponenTarif();
                            itemKomponenX.strKodeTarif = itemKomponen.strKodeTarif;
                            itemKomponenX.strId_Komponen = itemKomponen.strId_Komponen;
                            itemKomponenX.dblByKomponen = itemKomponen.dblByKomponen;
                            itemKomponenX.dblHak1 = itemKomponen.dblHak1;
                            itemKomponenX.dblHak2 = itemKomponen.dblHak2;
                            itemKomponenX.dblHak3 = itemKomponen.dblHak3;
                            itemKomponenX.intNoUrut = itemKomponen.intNoUrut;
                            itemKomponenX.intPrioritasTunai = itemKomponen.intPrioritasTunai;
                            itemKomponenX.strKodeDokter = "";
                            itemKomponenX.strNamaDokter = "";
                            grpLstTempTindakanDetail.Add(itemKomponenX);
                        }
                    }
                    else
                    {
                        //if result == 0 or less
                        cmbKomponenTarif.Enabled = false;
                    }

                    lblBiayaTindakan.Text = grpLstDaftarTarif[intResultSearch].dblBiaya.ToString();
                    lblDeskripsiTindakan.Text = grpLstDaftarTarif[intResultSearch].strUraianTarif;
                    btnTampilDaftarTindakan.Enabled = false;
                    txtKodeTindakan.Enabled = false;
                    if (cmbKomponenTarif.Enabled)
                    {
                        cmbKomponenTarif.Focus();
                    }
                }
            }
        }

        private void txtKodeTindakan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtKodeTindakan.Text.Trim().ToString() != "")
                    txtNamaDokter.Focus();
                else
                    btnTampilDaftarTindakan.Focus();

            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtKodeTindakan_Enter(object sender, EventArgs e)
        {
            txtKodeTindakan.Text = "";
            txtKodeTindakan.CharacterCasing = CharacterCasing.Upper;
            txtNamaDokter.Enabled = true;

            lblBiayaTindakan.Text = "...";
            lblDeskripsiTindakan.Text = "...";
            btnTampilDaftarTindakan.Enabled = true;
        }

        private void txtNamaDokter_Enter(object sender, EventArgs e)
        {
            txtNamaDokter.Text = "";
            txtNamaDokter.CharacterCasing = CharacterCasing.Upper;
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

        private void txtNamaDokter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
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

                string strKodeNama = txtNamaDokter.Text.Trim().ToString();

                String[] strArrPart = Regex.Split(strKodeNama, "--");

                string strKode = strArrPart[0].Trim().ToString();
                string strNama = strArrPart[1].Trim().ToString();

                int intResultSearch = grpLstDaftarDokter.FindIndex(
                                        m => m.strKodeDokter == strKode);

                if (intResultSearch == -1)
                {
                    MessageBox.Show("Nama Dokter yang anda masukkan tidak terdaftar",
                                    "Informasi",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    txtNamaDokter.Focus();

                }
                else
                {
                    btnTambahKompDokter.Focus();

                }


            }
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
                return;
            }

            String[] strSplitKode = Regex.Split(txtKodeTindakan.Text, "--");

            string strKodeTindakan = strSplitKode[0].Trim().ToString();
            string strUraianTindakan = strSplitKode[1].Trim().ToString();

            /* MASUKKAN PER TINDAKAN */
            lstDaftarTindakan itemTindakan = new lstDaftarTindakan();
            itemTindakan.strKodeTarif = strKodeTindakan;
            itemTindakan.intNoUrut = intUrutanTrans;
            itemTindakan.strUraianTarif = strUraianTindakan;
            itemTindakan.dblBiaya = Convert.ToDouble(lblBiayaTindakan.Text);
            itemTindakan.strTempatLayanan = txtTempatLayanan.Text;
            itemTindakan.intIdTempatLayanan = Convert.ToInt32(strIdMR_TempatLayanan);
            itemTindakan.dtTgl = dtpTglTindakan.Value;
            int intResult = grpLstDaftarTarif.FindIndex(m => m.strKodeTarif == strKodeTindakan);
            itemTindakan.strTSMFTindakan = grpLstDaftarTarif[intResult].strSMF;
            /*increment for identified every input kode for twice..*/
            grpLstDaftarTindakan.Add(itemTindakan);
            /* EOF MASUKKAN PER TINDAKAN */

            foreach (lstDaftarKomponenTarif x in grpLstTempTindakanDetail)
            {
                lstDaftarKomponenTarif itemKomponenTarif = new lstDaftarKomponenTarif();
                itemKomponenTarif.strKodeTarif = x.strKodeTarif;
                itemKomponenTarif.strId_Komponen = x.strId_Komponen;
                itemKomponenTarif.dblByKomponen = x.dblByKomponen;
                itemKomponenTarif.dblHak1 = x.dblHak1;
                itemKomponenTarif.dblHak2 = x.dblHak2;
                itemKomponenTarif.dblHak3 = x.dblHak3;
                itemKomponenTarif.intPrioritasTunai = x.intPrioritasTunai;
                itemKomponenTarif.intNoUrut = x.intNoUrut;
                itemKomponenTarif.strKodeDokter = "";
                itemKomponenTarif.strNamaDokter = "";
                grpLstDaftarTindakanDetail.Add(itemKomponenTarif);
            }

            grpLstTempTindakanDetail.Clear();

            int intUrutan = 1;

            lvDaftarTindakan.Items.Clear();

            grpLstDaftarTindakanDetail.ForEach(
                delegate(lstDaftarKomponenTarif x)
                {
                    lvDaftarTindakan.Items.Add((intUrutan.ToString()).ToString());
                    lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
                            x.strKodeTarif.ToString());
                    int intx = grpLstDaftarTindakan.FindIndex(m => m.strKodeTarif == x.strKodeTarif);
                    lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
                            grpLstDaftarTindakan[intx].strUraianTarif);
                    lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
                            x.strId_Komponen.ToString());
                    lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
                            x.dblByKomponen.ToString());
                    lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(
                            x.strNamaDokter);
                    intUrutan++;
                });

            //grpLstDaftarTindakan.ForEach(
            //    delegate(
            //        lstDaftarTindakan itemTindakanFetch) 
            //{
            //    lvDaftarTindakan.Items.Add((intUrutan.ToString()).ToString());
            //    lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(itemTindakanFetch.strKodeTarif.ToString());
            //    lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(itemTindakanFetch.strUraianTarif.ToString());
            //    lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(itemTindakanFetch.dblBiaya.ToString());
            //    //lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(itemTindakanFetch.strNamaDokter);
            //    lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(itemTindakanFetch.intNoUrut.ToString());
            //    intUrutan++;
            //});

            modSQL.pvAutoResizeLV(lvDaftarTindakan, 6);

            intUrutanTrans++;
            lblBiayaTindakan.Text = "...";
            lblDeskripsiTindakan.Text = "...";
            txtKodeTindakan.Text = "";
            txtNamaDokter.Text = "";
            //dtpTglTindakan.Focus();
            lvDaftarTindakan.HideSelection = false;
            grpLstTempTindakanDetail.Clear();

            txtKodeTindakan.Focus();

        }

        private void btnBatalTindakan_Click(object sender, EventArgs e)
        {
            txtKodeTindakan.Text = "";
            txtKodeTindakan.Enabled = true;
            cmbKomponenTarif.Items.Clear();
            txtNamaDokter.Text = "";
            grpLstTempTindakanDetail.Clear();
            lblBiayaTindakan.Text = "...";
            lblDeskripsiTindakan.Text = "...";
            cmbKomponenTarif.Enabled = true;

            txtKodeTindakan.Focus();
        }
    }
}
