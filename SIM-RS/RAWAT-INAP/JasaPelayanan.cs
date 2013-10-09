using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace SIM_RS.RAWAT_INAP
{
    public partial class JasaPelayanan : Form
    {

        C4Module.MainModule modMain = new C4Module.MainModule();
        C4Module.DatabaseModule modDb = new C4Module.DatabaseModule();
        C4Module.MessageModule modMsg = new C4Module.MessageModule();
        C4Module.SQLModule modSQL = new C4Module.SQLModule();
        C4Module.EncryptModule modEncrypt = new C4Module.EncryptModule();

        /*List - List yang dipakai*/
        public class lstDaftarDokter
        {
            public string strKodeDokter { get; set; }
            public string strNamaDokter { get; set; }
            public string strSMF { get; set; }
        }

        public class lstDaftarJasaPelayanan
        {
            public string strNoBilling { get; set; }
            public string strNamaPasien { get; set; }
            public string strStatusPasien { get; set; }
            public string strTglPulang { get; set; }
            public string strNamaTarif { get; set; }
            public double dblJasaMedis { get; set; }
            public double dblKeringanan { get; set; }
            public double dblHslBersih { get; set; }         
            public string strKodeDokter { get; set; }
            public string strKodeTransaksi{ get; set; }
        }
        
        List<lstDaftarJasaPelayanan> grpJasaPelayanan = new List<lstDaftarJasaPelayanan>();
        List<lstDaftarDokter> grpSemuaDokter = new List<lstDaftarDokter>();

        /*Daftar Autocomplete*/
        AutoCompleteStringCollection listDokter = new AutoCompleteStringCollection();




        public JasaPelayanan()
        {
            InitializeComponent();
            this.loadDataDokter();
        }

        public void loadDataDokter() {
            String strErr = "";

            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_BILLING_LAMA;

            SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {                
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                return;
            }

            String strQuerySQL = "SELECT " +
                                 "MR_DOKTER.idmr_dokter, " +                 //0
                                 "MR_DOKTER.nama, " +                        //1
                                 "MR_DOKTER.idmr_tsmf " +                    //2
                                 "FROM MR_DOKTER WITH (NOLOCK) " +
                                 "WHERE MR_DOKTER.dipakai = 'Y'";

            SqlDataReader reader = modDb.pbreaderSQL(conn, strQuerySQL, ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                conn.Close();
                return;
            }

            listDokter.Clear();
            grpSemuaDokter.Clear();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    listDokter.Add(modMain.pbstrgetCol(reader, 0, ref strErr, "") + " -- " + modMain.pbstrgetCol(reader, 1, ref strErr, ""));

                    lstDaftarDokter itemDaftarDokter = new lstDaftarDokter();
                    itemDaftarDokter.strKodeDokter = modMain.pbstrgetCol(reader, 0, ref strErr, "");
                    itemDaftarDokter.strNamaDokter = modMain.pbstrgetCol(reader, 1, ref strErr, "");
                    itemDaftarDokter.strNamaDokter = itemDaftarDokter.strNamaDokter.Trim().ToString();
                    itemDaftarDokter.strSMF = modMain.pbstrgetCol(reader, 2, ref strErr, "");

                    grpSemuaDokter.Add(itemDaftarDokter);
                }
            }



            reader.Close();

            txtNamaDokter.AutoCompleteCustomSource = listDokter;
            txtNamaDokter.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtNamaDokter.AutoCompleteSource = AutoCompleteSource.CustomSource;
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
                this.bgCariDataJaspel.RunWorkerAsync();
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
            string strKodeNama = txtNamaDokter.Text.Trim().ToString();

            String[] strArrPart = Regex.Split(strKodeNama, "--");

            string strKode = strArrPart[0].Trim().ToString();
            string strNama = strArrPart[1].Trim().ToString();
            lblKodeDokter.Text = strArrPart[0].Trim().ToString();

            int intResultSearch = grpSemuaDokter.FindIndex(
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
                //btnTambahKompDokter.Focus();

            }
        }

        private void bgCariDataJaspel_DoWork(object sender, DoWorkEventArgs e)
        {

            lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = true);
            txtNamaDokter.SafeControlInvoke(TextBox => txtNamaDokter.Enabled = false);
            String strErr = "";

            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_BILLING_LAMA;

            SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {

                lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = false);
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                return;
            }

            lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Text = "MENCARI JASA PELAYANAN");
            String strQuerySQL =
                    "SELECT BL_KASPAV.Regbilling, " +                                   //0
                    "MR_PASIEN.Nama, " +                                                //1
                    "BL_KASPAV.Idmr_Tstatus, " +                                        //2
                    "Convert(Varchar(12),BL_KASPAV.Tanggal,105), " +                    //3            
                    "BL_TRANSAKSI.Uraiantarip, " +                                      //4    
                    "BL_TRANSAKSIDETAIL.idbl_komponen, " +                              //5    
                    "BL_TRANSAKSIDETAIL.nilai, " +                                      //6
                    "BL_TRANSAKSIDETAIL.Ringan, " +                                     //7
                    "BL_TRANSAKSIDETAIL.nilai - BL_TRANSAKSIDETAIL.Ringan as tunai, " + //8
                    "BL_TRANSAKSIDETAIL.idmr_dokter, " +                                //9
                    "BL_TRANSAKSI.idbl_transaksi " +                                    //10
                    "FROM BL_TRANSAKSI  With (nolock) " +
                    "INNER JOIN BL_KASPAV ON BL_TRANSAKSI.idmr_mutasipasien = BL_KASPAV.Idmr_mutasipasien " +
                    "INNER JOIN BL_TRANSAKSIDETAIL ON BL_TRANSAKSI.idbl_transaksi = BL_TRANSAKSIDETAIL.idbl_transaksi " +
                    "INNER JOIN MR_PASIEN ON BL_KASPAV.Idmr_pasien = MR_PASIEN.IDMR_PASIEN " +
                    "INNER JOIN MR_DOKTER ON BL_TRANSAKSIDETAIL.idmr_dokter = MR_DOKTER.idmr_dokter " +
                    "WHERE (BL_TRANSAKSI.Batal = '') AND (BL_KASPAV.Batal = '') " +
                    "AND (BL_TRANSAKSIDETAIL.idbl_komponen = 'JASA PELAYANAN') " +
                    "AND (BL_TRANSAKSIDETAIL.noambil = 0) " +
                    "AND (BL_TRANSAKSIDETAIL.idbl_pembayaran > 0) " +
                    "AND BL_TRANSAKSIDETAIL.idmr_dokter = 'SP.BU.001' " +
                    "ORDER BY BL_KASPAV.Regbilling,BL_KASPAV.Tanggal,BL_TRANSAKSI.idbl_transaksi";

            SqlDataReader reader = modDb.pbreaderSQL(conn, strQuerySQL, ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                conn.Close();
                return;
            }

            grpJasaPelayanan.Clear();
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    lstDaftarJasaPelayanan itemJasaLayanan = new lstDaftarJasaPelayanan();
                    itemJasaLayanan.strNoBilling = modMain.pbstrgetCol(reader, 0, ref strErr, "");
                    itemJasaLayanan.strNamaPasien = modMain.pbstrgetCol(reader, 1, ref strErr, "");
                    itemJasaLayanan.strStatusPasien = modMain.pbstrgetCol(reader, 2, ref strErr, "");
                    itemJasaLayanan.strTglPulang = modMain.pbstrgetCol(reader, 3, ref strErr, "");
                    itemJasaLayanan.strNamaTarif = modMain.pbstrgetCol(reader, 4, ref strErr, "");
                    itemJasaLayanan.dblJasaMedis = Convert.ToDouble(modMain.pbstrgetCol(reader, 6, ref strErr, ""));
                    itemJasaLayanan.dblKeringanan = Convert.ToDouble(modMain.pbstrgetCol(reader, 7, ref strErr, ""));
                    itemJasaLayanan.dblHslBersih = Convert.ToDouble(modMain.pbstrgetCol(reader, 8, ref strErr, ""));
                    itemJasaLayanan.strKodeDokter = modMain.pbstrgetCol(reader, 9, ref strErr, "");
                    itemJasaLayanan.strKodeTransaksi = modMain.pbstrgetCol(reader, 10, ref strErr, "");
                    grpJasaPelayanan.Add(itemJasaLayanan);
                }

            }


            reader.Close();
            pvTampilList();
        }

        private void pvTampilList()
        {
            int noUrut = 1;
            var query = (from i in grpJasaPelayanan
                         select i);

            lvJasaPelayanan.Items.Clear();
            foreach (var jaspel in query)
            {
                lvJasaPelayanan.SafeControlInvoke(ListView => lvJasaPelayanan.Items.Add(noUrut.ToString()));
                lvJasaPelayanan.SafeControlInvoke(ListView => lvJasaPelayanan.Items[lvJasaPelayanan.Items.Count - 1].SubItems.Add(jaspel.strNoBilling));
                lvJasaPelayanan.SafeControlInvoke(ListView => lvJasaPelayanan.Items[lvJasaPelayanan.Items.Count - 1].SubItems.Add(jaspel.strNamaPasien));
                lvJasaPelayanan.SafeControlInvoke(ListView => lvJasaPelayanan.Items[lvJasaPelayanan.Items.Count - 1].SubItems.Add(jaspel.strStatusPasien));
                lvJasaPelayanan.SafeControlInvoke(ListView => lvJasaPelayanan.Items[lvJasaPelayanan.Items.Count - 1].SubItems.Add(jaspel.strTglPulang));
                lvJasaPelayanan.SafeControlInvoke(ListView => lvJasaPelayanan.Items[lvJasaPelayanan.Items.Count - 1].SubItems.Add(jaspel.strNamaTarif));
                lvJasaPelayanan.SafeControlInvoke(ListView => lvJasaPelayanan.Items[lvJasaPelayanan.Items.Count - 1].SubItems.Add(jaspel.dblJasaMedis.ToString()));
                lvJasaPelayanan.SafeControlInvoke(ListView => lvJasaPelayanan.Items[lvJasaPelayanan.Items.Count - 1].SubItems.Add(jaspel.dblKeringanan.ToString()));
                lvJasaPelayanan.SafeControlInvoke(ListView => lvJasaPelayanan.Items[lvJasaPelayanan.Items.Count - 1].SubItems.Add(jaspel.dblHslBersih.ToString()));
                noUrut++;
            }

            var suma = (from s in grpJasaPelayanan select s.dblHslBersih).Sum();
            lblTotalJasaPelayanan.SafeControlInvoke(Label => lblTotalJasaPelayanan.Text = string.Format(new System.Globalization.CultureInfo("id-ID"), "Rp. {0:n}", suma));
            
        }


        private void JasaPelayanan_Load(object sender, EventArgs e)
        {
            
        }




    }
}
