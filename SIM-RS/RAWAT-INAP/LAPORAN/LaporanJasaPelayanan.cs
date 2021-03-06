﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using OfficeOpenXml;
using System.IO;

namespace SIM_RS.RAWAT_INAP
{
    public partial class LaporanJasaPelayanan : Form
    {

        C4Module.MainModule modMain = new C4Module.MainModule();
        C4Module.DatabaseModule modDb = new C4Module.DatabaseModule();
        C4Module.MessageModule modMsg = new C4Module.MessageModule();
        C4Module.SQLModule modSQL = new C4Module.SQLModule();

        /*LOCAL VARIABLE*/
        string strQuerySQL = "";
        string strErr = "";

        string strNamaFile = "";
        int intWaktuLoad = 0;
        int intPenandaProses = 0;


        public class lstKASUM
        {
            public string strRegBilling { get; set; }
            public string strNama { get; set; }
            public string strRuangan { get; set; }
            public double dblJumlah { get; set; }
            public double dblSubsidi { get; set; }
            public double dblTunai { get; set; }
            public string strIdBl_Komponen { get; set; }
            public double dblNilai { get; set; }
            public double dblRingan { get; set; }
            public double dblUrutan { get; set; }
            public string strRekapJp { get; set; }
            public double dblTunainya { get; set; }
            public double dblNoAmbil { get; set; }
            public DateTime dtTglAmbil { get; set; }
            public string strIdBl_KelTarip { get; set; }
            public string strLapJP { get; set; }
            public string strIdMR_TSMF { get; set; }
            public string strIdMR_TUPF { get; set; }
            public string strIdBl_Tarip { get; set; }
            public string strUraianTarip { get; set; }
            public double dblJumlahKasusTarip { get; set; }
            public string strIdBl_Transaksi { get; set; }
            public string strIdBl_Pembayaran { get; set; }
            public DateTime dtTglTransaksi { get; set; }
            public DateTime dtTgl { get; set; }
            public string strIdMR_JenisKelas { get; set; }
            public string strIdMR_Ruangan { get; set; }
            public string strIdMR_Dokter { get; set; }
            public string strNamaDokter { get; set; }
        }

        //public class lstKASASKIN
        //{
        //    public string strRegBilling { get; set; }
        //    public string strNama { get; set; }
        //    public string strRuangan { get; set; }
        //    public double dblJumlah { get; set; }
        //    public double dblSubsidi { get; set; }
        //    public double dblTunai { get; set; }
        //    public string strIdBl_Komponen { get; set; }
        //    public double dblNilai { get; set; }
        //    public double dblRingan { get; set; }
        //    public double dblUrutan { get; set; }
        //    public string strRekapJp { get; set; }
        //    public double dblTunainya { get; set; }
        //    public double dblNoAmbil { get; set; }
        //    public DateTime dtTglAmbil { get; set; }
        //    public string strIdBl_KelTarip { get; set; }
        //    public string strLapJP { get; set; }
        //    public string strIdMR_TSMF { get; set; }
        //    public string strIdMR_TUPF { get; set; }
        //    public string strIdBl_Tarip { get; set; }
        //    public string strUraianTarip { get; set; }
        //    public double dblJumlahKasusTarip { get; set; }
        //    public string strIdBl_Transaksi { get; set; }
        //    public string strIdBl_Pembayaran { get; set; }
        //    public DateTime dtTglTransaksi { get; set; }
        //    public DateTime dtTgl { get; set; }
        //    public string strIdMR_JenisKelas { get; set; }
        //    public string strIdMR_Ruangan { get; set; }
        //    public string strIdMR_Dokter { get; set; }
        //    public string strNamaDokter { get; set; }
        //}

        public class lstKASJKM
        {
            public string strRegBilling { get; set; }
            public string strNama { get; set; }
            public string strRuangan { get; set; }
            public double dblJumlah { get; set; }
            public double dblSubsidi { get; set; }
            public double dblTunai { get; set; }
            public string strIdBl_Komponen { get; set; }
            public double dblNilai { get; set; }
            public double dblRingan { get; set; }
            public double dblUrutan { get; set; }
            public string strRekapJp { get; set; }
            public double dblTunainya { get; set; }
            public double dblNoAmbil { get; set; }
            public DateTime dtTglAmbil { get; set; }
            public string strIdBl_KelTarip { get; set; }
            public string strLapJP { get; set; }
            public string strIdMR_TSMF { get; set; }
            public string strIdMR_TUPF { get; set; }
            public string strIdBl_Tarip { get; set; }
            public string strUraianTarip { get; set; }
            public double dblJumlahKasusTarip { get; set; }
            public string strIdBl_Transaksi { get; set; }
            public string strIdBl_Pembayaran { get; set; }
            public DateTime dtTglTransaksi { get; set; }
            public DateTime dtTgl { get; set; }
            public string strIdMR_JenisKelas { get; set; }
            public string strIdMR_Ruangan { get; set; }
            public string strIdMR_Dokter { get; set; }
            public string strNamaDokter { get; set; }
        }

        public class lstKASJKD
        {
            public string strRegBilling { get; set; }
            public string strNama { get; set; }
            public string strRuangan { get; set; }
            public double dblJumlah { get; set; }
            public double dblSubsidi { get; set; }
            public double dblTunai { get; set; }
            public string strIdBl_Komponen { get; set; }
            public double dblNilai { get; set; }
            public double dblRingan { get; set; }
            public double dblUrutan { get; set; }
            public string strRekapJp { get; set; }
            public double dblTunainya { get; set; }
            public double dblNoAmbil { get; set; }
            public DateTime dtTglAmbil { get; set; }
            public string strIdBl_KelTarip { get; set; }
            public string strLapJP { get; set; }
            public string strIdMR_TSMF { get; set; }
            public string strIdMR_TUPF { get; set; }
            public string strIdBl_Tarip { get; set; }
            public string strUraianTarip { get; set; }
            public double dblJumlahKasusTarip { get; set; }
            public string strIdBl_Transaksi { get; set; }
            public string strIdBl_Pembayaran { get; set; }
            public DateTime dtTglTransaksi { get; set; }
            public DateTime dtTgl { get; set; }
            public string strIdMR_JenisKelas { get; set; }
            public string strIdMR_Ruangan { get; set; }
            public string strIdMR_Dokter { get; set; }
            public string strNamaDokter { get; set; }
        }


        List<lstKASUM> grpLstKASUM = new List<lstKASUM>();
        //List<lstKASASKIN> grpLstKASASKIN = new List<lstKASASKIN>();
        List<lstKASJKM> grpLstKASJKM = new List<lstKASJKM>();
        List<lstKASJKD> grpLstKASJKD = new List<lstKASJKD>();


        public class lstKasumJP
        {
            public string strRegBilling { get; set; }
            public string strNama { get; set; }
            public string strRuangan { get; set; }
            public string strIdMR_TUPF { get; set; }
            public string strIdBl_Komponen { get; set; }
            public string strIdMR_TSMF { get; set; }
            public double dblTunainya { get; set; }
            public string strLapJP { get; set; }
            public string strRekapJP { get; set; }
        }

        public class lstKasumJA
        {
            public string strRegBilling { get; set; }
            public string strNama { get; set; }
            public string strRuangan { get; set; }
            public string strIdMR_TUPF { get; set; }
            public string strIdBl_Komponen { get; set; }
            public string strIdMR_TSMF { get; set; }
            public double dblTunainya { get; set; }
            public string strLapJP { get; set; }
            public string strRekapJP { get; set; }
        }

        public class lstReg
        {
            public string strRegBilling { get; set; }
            public string strNama { get; set; }
            public string strRuangan { get; set; }
            public string strIdMR_TUPF { get; set; }
            public string strIdMR_TSMF { get; set; }
        }

        List<lstKasumJP> grpLstKasumJP = new List<lstKasumJP>();
        List<lstKasumJA> grpLstKasumJA = new List<lstKasumJA>();
        List<lstReg> grpLstReg = new List<lstReg>();


        public class lstTransak
        {
            public string strRegbilling { get; set; }
            public string strNama { get; set; }
            public string strRuangan { get; set; }
            public string strUnit { get; set; }
            public string strSMF { get; set; }
            public double dblKonsul { get; set; }
            public double dblVisite { get; set; }
            public double dblOperasi { get; set; }
            public double dblTindakan { get; set; }
            public double dblDiagelect { get; set; }
            public double dblPemRK { get; set; }
        }
        List<lstTransak> grpTransak = new List<lstTransak>();

        public class lstKelTarip
        {
            public string strIdBl_KelTarip { get; set; }
            public int intUrutan { get; set; }
            public string strLapJP { get; set; }
            public string strRekapJP { get; set; }
        }
        List<lstKelTarip> grpKelTarip = new List<lstKelTarip>();


        public class lstTind
        {
            public string strUnit { get; set; }
            public double dblKonsul { get; set; }
            public double dblVisite { get; set; }
            public double dblOperasi { get; set; }
            public double dblTindakan { get; set; }
            public double dblDiagelect { get; set; }
            public double dblPemRK { get; set; }
        }
        List<lstTind> grpTind = new List<lstTind>();

        public class lstTransaknya
        {
            public string strRegBilling { get; set; }
            public string strNama {get; set;}
            public string strRuangan {get; set;}
            public string strUnit { get; set; }
            public double dblKonsul { get; set; }
            public double dblVisite { get; set; }
            public double dblOperasi { get; set; }
            public double dblTindakan { get; set; }
            public double dblDiagelect { get; set; }
            public double dblPemRK { get; set; }
        }
        List<lstTransaknya> grpTransaknya = new List<lstTransaknya>();



        /* OWN FUNCTION */

        private void pvCleanInput()
        {
            dtpFilterTgl1.Value = DateTime.Now;
            dtpFilterTgl2.Value = DateTime.Now;
            cmbJenisLaporan.SelectedIndex = -1;
            cmbUnit.SelectedIndex = -1;
            lvDaftarTindakan.Items.Clear();
            cmbPilihanExport.SelectedIndex = -1;
        }

        private void pvDisableObj()
        {
            cmbPilihanExport.Enabled = false;
            btnExport.Enabled = false;
            cmbJenisLaporan.Enabled = false;
            cmbUnit.Enabled = false;
            btnTampilkan.Enabled = false;

        }
        private void pvIniSialisasiObject()
        {
            int intNoUrutObject = 0;

            modMain.pvUrutkanTab(dtpFilterTgl1, ref intNoUrutObject, true);
            modMain.pvUrutkanTab(dtpFilterTgl2, ref intNoUrutObject, true);
            modMain.pvUrutkanTab(btnCari, ref intNoUrutObject);
            modMain.pvUrutkanTab(cmbJenisLaporan, ref intNoUrutObject, true);
            modMain.pvUrutkanTab(cmbUnit, ref intNoUrutObject, true);
            modMain.pvUrutkanTab(btnTampilkan, ref intNoUrutObject);
            modMain.pvUrutkanTab(cmbPilihanExport, ref intNoUrutObject, true);
            modMain.pvUrutkanTab(btnExport, ref intNoUrutObject);            
            modMain.pvUrutkanTab(lvDaftarTindakan, ref intNoUrutObject, true);
            this.pvDisableObj();
        }

        /* EOF OWN FUNCTION */
        


        public LaporanJasaPelayanan()
        {
            InitializeComponent();

            this.pvCleanInput();
            this.pvIniSialisasiObject();

        }    

        private void bgWorkLoadFromDB_DoWork(object sender, DoWorkEventArgs e)
        {
            /*CLEAN DATA*/

            grpLstKASUM.Clear();
            //grpLstKASASKIN.Clear();
            grpLstKASJKM.Clear();
            grpLstKASJKD.Clear();
            grpKelTarip.Clear();
            grpLstReg.Clear();            
            grpTransak.Clear();
            grpTransaknya.Clear();
            grpTind.Clear();


            dtpFilterTgl1.SafeControlInvoke(DateTimePicker => dtpFilterTgl1.Enabled = false);
            dtpFilterTgl2.SafeControlInvoke(DateTimePicker => dtpFilterTgl2.Enabled = false);
            cmbJenisLaporan.SafeControlInvoke(ComboBox => cmbJenisLaporan.Enabled = false);
            cmbUnit.SafeControlInvoke(ComboBox => cmbUnit.Enabled = false);
            btnCari.SafeControlInvoke(Button => btnCari.Enabled = false);
            lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = true);
            cmbPilihanExport.SafeControlInvoke(ComboBox => cmbPilihanExport.Enabled = false);
            btnExport.SafeControlInvoke(Button => btnExport.Enabled = false);
            btnTampilkan.SafeControlInvoke(Button => btnTampilkan.Enabled = false);

            this.strErr = "";
            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_CONN;


            SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {
                tmrBlink.Enabled = false;
                tmrBlink.Stop();
                lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = false);
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                return;
            }

            lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Text = "Proses Load - KELOMPOK TARIP");
            this.strQuerySQL = "SELECT Idbl_keltarip,Urutan,Lapjp,Rekapjp "+
                               "FROM BL_KELTARIP WITH (NOLOCK) "+
                               "WHERE lapjp <> '-' "+
                               "ORDER BY lapjp, urutan";

            SqlDataReader reader = modDb.pbreaderSQL(conn, strQuerySQL, ref strErr);
            if (strErr != "")
            {
                tmrBlink.Enabled = false;
                tmrBlink.Stop();
                lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = false);
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_GET, modMsg.TITLE_ERR);
                conn.Close();
                return;
            }

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    lstKelTarip itemKelTarip = new lstKelTarip();
                    itemKelTarip.strIdBl_KelTarip = modMain.pbstrgetCol(reader, 0, ref strErr, "");
                    itemKelTarip.intUrutan = Convert.ToInt32(modMain.pbstrgetCol(reader, 1, ref strErr, ""));
                    itemKelTarip.strLapJP = modMain.pbstrgetCol(reader, 2, ref strErr, "");
                    itemKelTarip.strRekapJP = modMain.pbstrgetCol(reader, 3, ref strErr, "");

                    grpKelTarip.Add(itemKelTarip);

                }
            }

            reader.Close();


            intWaktuLoad = 0;                
            intPenandaProses = 1;
            tmrWaktuLoad.Enabled = true;
            tmrWaktuLoad.Start();
            
            

            /* QUERY KASUM */
            this.strQuerySQL = "SELECT " +
                                    "BL_TRANSAKSI_1.Regbilling, " +                                              //0
                                    "MR_PASIEN.Nama, " +                                                         //1
                                    "MR_TRUANGAN.ruangan, " +                                                    //2
                                    "BL_TRANSAKSI_1.Jumlah, " +                                                  //3
                                    "BL_TRANSAKSI_1.subsidi, " +                                                 //4
                                    "BL_TRANSAKSI_1.tunai, " +                                                   //5
                                    "BL_TRANSAKSIDETAIL_1.Idbl_komponen, " +                                     //6
                                    "BL_TRANSAKSIDETAIL_1.Nilai, " +                                             //7
                                    "BL_TRANSAKSIDETAIL_1.Ringan, " +                                            //8
                                    "BL_KELTARIP.urutan, " +                                                     //9
                                    "BL_KELTARIP.rekapjp," +                                                     //10
                                    "BL_TRANSAKSIDETAIL_1.Nilai - BL_TRANSAKSIDETAIL_1.Ringan as tunainya , " +  //11
                                    "BL_TRANSAKSIDETAIL_1.Noambil, " +                                           //12
                                    "BL_TRANSAKSIDETAIL_1.tglambil, " +                                          //13
                                    "BL_KELTARIP.Idbl_keltarip, " +                                              //14
                                    "BL_KELTARIP.Lapjp, " +                                                      //15
                                    "BL_TRANSAKSI_1.idmr_tsmf, " +                                               //16
                                    "MR_SMFTARIP.idmr_tupf, " +                                                  //17
                                    "BL_TRANSAKSI_1.idbl_tarip, " +                                              //18
                                    "BL_TRANSAKSI_1.uraiantarip, " +                                             //19
                                    "BL_TRANSAKSI_1.jml_kasus_tarip, " +                                         //20
                                    "BL_TRANSAKSI_1.idbl_transaksi, " +                                          //21
                                    "BL_KASUMUM.Idbl_Pembayaran, " +                                             //22
                                    "BL_TRANSAKSI_1.Tgltransaksi, " +                                            //23
                                    "BL_KASUMUM.Tanggal, " +                                                     //24
                                    "BL_TARIP.Idmr_jeniskelas, " +                                               //25
                                    "BL_TRANSAKSI_1.Idmr_truangan, " +                                           //26
                                    "BL_TRANSAKSIDETAIL_1.idmr_dokter, " +                                                  //27
                                    "MR_DOKTER.Nama " +                                                          //28
                               "FROM BL_KELTARIP  With (nolock) "+
                               "INNER JOIN BL_TRANSAKSI_1 " +
                               "INNER JOIN BL_TRANSAKSIDETAIL_1 "+
                                    "ON BL_TRANSAKSI_1.idbl_transaksi = BL_TRANSAKSIDETAIL_1.Idbl_transaksi "+
                               "INNER JOIN BL_TARIP "+
                                    "ON BL_TRANSAKSI_1.idbl_tarip = BL_TARIP.IdBl_tarip "+
                                    "ON BL_KELTARIP.Idbl_keltarip = BL_TARIP.Idbl_keltarip "+
                               "INNER JOIN MR_SMFTARIP "+
                                    "ON BL_TRANSAKSI_1.idmr_tsmf = MR_SMFTARIP.idmr_tsmf "+
                               "INNER JOIN BL_KASUMUM "+
                                    "ON BL_TRANSAKSI_1.idbl_pembayaran = BL_KASUMUM.Idbl_Pembayaran "+
                                    " AND BL_TRANSAKSI_1.idmr_mutasipasien = BL_KASUMUM.idmr_mutasipasien "+
                               "INNER JOIN MR_PASIEN "+
                                    "ON BL_KASUMUM.Idmr_pasien = MR_PASIEN.IDMR_PASIEN "+
                               "INNER JOIN MR_TRUANGAN "+
                                    "ON BL_KASUMUM.Idmr_truangan = MR_TRUANGAN.idmr_truangan "+
                               "LEFT JOIN MR_DOKTER " +
                                    "ON BL_TRANSAKSIDETAIL_1.idmr_dokter = MR_DOKTER.idmr_dokter " +
                               "WHERE (BL_TRANSAKSI_1.Batal <> 'Y') " +
                                    "AND (BL_KASUMUM.Batal = '') " +
                                    " AND (BL_TRANSAKSIDETAIL_1.Idbl_komponen <> 'JASA SARANA') "+
                                    " AND BL_KASUMUM.Tanggal between '" + dtpFilterTgl1.Value.ToString("MM/dd/yyyy 00:00:00") + 
                                        "' AND '" + dtpFilterTgl2.Value.ToString("MM/dd/yyyy 23:59:59") +  "' "+
                                    " AND BL_TARIP.pisahsetor = '' "+
                                    " AND BL_TRANSAKSIDETAIL_1.noambil <> 999 "+
                                    " AND BL_TRANSAKSI_1.idmr_tsmf <> 'DARAH' "+
                                    " AND BL_TRANSAKSI_1.idmr_tsmf <> 'PENDORONG'"+
                                    " AND BL_TRANSAKSI_1.idmr_tsmf <> 'OBAT/ALKES-FARMASI' "+
                                    " AND BL_TRANSAKSI_1.idmr_tsmf <> 'OBAT/ALKES-KPRI'"+
                                    " AND BL_TRANSAKSI_1.idbl_pembayaran > 0 "+
                                    " AND BL_KELTARIP.Lapjp <> '-'";

            reader = modDb.pbreaderSQL(conn, strQuerySQL, ref strErr);
            if (strErr != "")
            {
                tmrBlink.Enabled = false;
                tmrBlink.Stop();
                lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = false);
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_GET, modMsg.TITLE_ERR);
                conn.Close();
                return;
            }

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    lstKASUM itemKASUM = new lstKASUM();

                    itemKASUM.strRegBilling = modMain.pbstrgetCol(reader, 0, ref strErr, "");
                    itemKASUM.strNama = modMain.pbstrgetCol(reader, 1, ref strErr, "");
                    itemKASUM.strRuangan = modMain.pbstrgetCol(reader, 2, ref strErr, "");
                    itemKASUM.dblJumlah = Convert.ToDouble(modMain.pbstrgetCol(reader, 3, ref strErr, ""));
                    itemKASUM.dblSubsidi = Convert.ToDouble(modMain.pbstrgetCol(reader, 4, ref strErr, ""));
                    itemKASUM.dblTunai = Convert.ToDouble(modMain.pbstrgetCol(reader, 5, ref strErr, ""));
                    itemKASUM.strIdBl_Komponen = modMain.pbstrgetCol(reader, 6, ref strErr, "");
                    itemKASUM.dblNilai = Convert.ToDouble(modMain.pbstrgetCol(reader, 7, ref strErr, ""));
                    itemKASUM.dblRingan = Convert.ToDouble(modMain.pbstrgetCol(reader, 8, ref strErr, ""));
                    itemKASUM.dblUrutan = Convert.ToDouble(modMain.pbstrgetCol(reader, 9, ref strErr, ""));
                    itemKASUM.strRekapJp = modMain.pbstrgetCol(reader, 10, ref strErr, "");
                    itemKASUM.dblTunainya = Convert.ToDouble(modMain.pbstrgetCol(reader, 11, ref strErr, ""));
                    itemKASUM.dblNoAmbil = Convert.ToDouble(modMain.pbstrgetCol(reader, 12, ref strErr, ""));
                    itemKASUM.dtTglAmbil = Convert.ToDateTime(modMain.pbstrgetCol(reader, 13, ref strErr, ""));
                    itemKASUM.strIdBl_KelTarip = modMain.pbstrgetCol(reader, 14, ref strErr, "");
                    itemKASUM.strLapJP = modMain.pbstrgetCol(reader, 15, ref strErr, "");
                    itemKASUM.strIdMR_TSMF = modMain.pbstrgetCol(reader, 16, ref strErr, "");
                    itemKASUM.strIdMR_TUPF = modMain.pbstrgetCol(reader, 17, ref strErr, "");
                    itemKASUM.strIdBl_Tarip = modMain.pbstrgetCol(reader, 18, ref strErr, "");
                    itemKASUM.strUraianTarip = modMain.pbstrgetCol(reader, 19, ref strErr, "");
                    itemKASUM.dblJumlahKasusTarip = Convert.ToDouble(modMain.pbstrgetCol(reader, 20, ref strErr, ""));
                    itemKASUM.strIdBl_Transaksi = modMain.pbstrgetCol(reader, 21, ref strErr, "");
                    itemKASUM.strIdBl_Pembayaran = modMain.pbstrgetCol(reader, 22, ref strErr, "");
                    itemKASUM.dtTglTransaksi = Convert.ToDateTime(modMain.pbstrgetCol(reader, 23, ref strErr, ""));
                    itemKASUM.dtTgl = Convert.ToDateTime(modMain.pbstrgetCol(reader, 24, ref strErr, ""));
                    itemKASUM.strIdMR_JenisKelas = modMain.pbstrgetCol(reader, 25, ref strErr, "");
                    itemKASUM.strIdMR_Ruangan = modMain.pbstrgetCol(reader, 26, ref strErr, "");
                    itemKASUM.strIdMR_Dokter = modMain.pbstrgetCol(reader, 27, ref strErr, "");
                    itemKASUM.strNamaDokter = modMain.pbstrgetCol(reader, 28, ref strErr, "");
                        
                    grpLstKASUM.Add(itemKASUM);
                }
            }

            reader.Close();
            conn.Close();

            if (grpLstKASUM.Count > 0)
            {
                /*JIKA DITEMUKAN DATA PADA grpLstKASUM maka lakukan perhitungan disini*/

                var KasumJP = (from fetch in grpLstKASUM
                               where (fetch.strIdBl_Komponen == "JASA PELAYANAN" && fetch.dblTunainya > 0)
                               group fetch by new 
                               {
                                   fetch.strRegBilling,
                                   fetch.strNama,
                                   fetch.strIdBl_Komponen,
                                   fetch.strLapJP,
                                   fetch.strIdMR_TUPF,
                                   fetch.strIdMR_TSMF,
                                   fetch.strRuangan
                                } into groupData                              
                              select new 
                              {
                                  regBilling = groupData.Key.strRegBilling,
                                    Nama = groupData.Key.strNama,
                                    Ruangan = groupData.Key.strRuangan,
                                    TUPF = groupData.Key.strIdMR_TUPF,
                                    IdBl_Komponen = groupData.Key.strIdBl_Komponen,
                                    IdMR_TSMF = groupData.Key.strIdMR_TSMF,
                                    tunainya = groupData.Sum(fetchKasum => fetchKasum.dblTunainya),
                                    LapJP = groupData.Key.strLapJP
                              }).OrderBy(groupData => groupData.regBilling).ToList();


                var KasumJA = (from fetch in grpLstKASUM
                               where (fetch.strIdBl_Komponen != "JASA PELAYANAN" && fetch.dblTunainya > 0)
                               group fetch by new
                               {
                                   fetch.strRegBilling,
                                   fetch.strNama,
                                   fetch.strIdBl_Komponen,
                                   fetch.strLapJP,
                                   fetch.strIdMR_TUPF,
                                   fetch.strIdMR_TSMF,
                                   fetch.strRuangan
                               } into groupData
                               select new
                               {
                                   regBilling = groupData.Key.strRegBilling,
                                   Nama = groupData.Key.strNama,
                                   Ruangan = groupData.Key.strRuangan,
                                   TUPF = groupData.Key.strIdMR_TUPF,
                                   IdBl_Komponen = groupData.Key.strIdBl_Komponen,
                                   IdMR_TSMF = groupData.Key.strIdMR_TSMF,
                                   tunainya = groupData.Sum(fetchKasum => fetchKasum.dblTunainya),
                                   LapJP = groupData.Key.strLapJP
                               }).OrderBy(groupData => groupData.regBilling).ToList();


                var reg = (from fetch in grpLstKASUM
                          select new
                          {
                              Regbilling = fetch.strRegBilling,
                              Nama = fetch.strNama,
                              Ruangan = fetch.strRuangan,
                              idmr_tupf = fetch.strIdMR_TUPF,
                              idmr_tsmf = fetch.strIdMR_TSMF
                          }).Distinct().OrderBy( a => a.Regbilling).ToList();


                if (reg.Count > 0)
                {
                    foreach (var fetch in reg)
                    {
                        lstTransak itemTransak = new lstTransak();
                        itemTransak.strRegbilling = fetch.Regbilling;
                        itemTransak.strNama = fetch.Nama;
                        itemTransak.strRuangan = fetch.Ruangan;
                        itemTransak.strUnit = fetch.idmr_tupf;
                        itemTransak.strSMF = fetch.idmr_tsmf;
                        itemTransak.dblKonsul = 0;
                        itemTransak.dblVisite = 0;
                        itemTransak.dblOperasi = 0;
                        itemTransak.dblTindakan = 0;
                        itemTransak.dblDiagelect = 0;
                        itemTransak.dblPemRK = 0;
                        grpTransak.Add(itemTransak);
                    }
                }


                if (grpTransak.Count > 0)
                {
                    /*JASA PELAYANAN*/
                    foreach (var fetchKasumJP in KasumJP)
                    {
                        
                        if (fetchKasumJP.LapJP.Substring(0, 1) == "1")
                        {
                            int intUrut = 0;
                            foreach (var fetchTransak in grpTransak)
                            {
                                if (fetchTransak.strRegbilling == fetchKasumJP.regBilling
                                    && fetchKasumJP.LapJP.Substring(0, 1) == "1"
                                    && fetchTransak.strRuangan == fetchKasumJP.Ruangan
                                    && fetchTransak.strSMF == fetchKasumJP.IdMR_TSMF)
                                {
                                    grpTransak[intUrut].dblKonsul = grpTransak[intUrut].dblKonsul + fetchKasumJP.tunainya;
                                    //fetchTransak.dblKonsul = fetchTransak.dblKonsul + fetchKasumJP.tunainya;
                                }
                                intUrut++;
                            } /* EOF foreach (var fetchTransak in grpTransak) */
                        } /* EOF if (fetchKasumJP.LapJP.Substring(1, 1) == "1") */

                        else if (fetchKasumJP.LapJP.Substring(0, 1) == "2")
                        {
                            int intUrut = 0;
                            foreach (var fetchTransak in grpTransak)
                            {
                                if (fetchTransak.strRegbilling == fetchKasumJP.regBilling
                                    && fetchKasumJP.LapJP.Substring(0, 1) == "2"
                                    && fetchTransak.strRuangan == fetchKasumJP.Ruangan
                                    && fetchTransak.strSMF == fetchKasumJP.IdMR_TSMF)
                                {
                                    grpTransak[intUrut].dblVisite = grpTransak[intUrut].dblVisite + fetchKasumJP.tunainya;
                                }
                                intUrut++;
                            } /* EOF foreach (var fetchTransak in grpTransak) */

                        } /* EOF else if (fetchKasumJP.LapJP.Substring(1, 1) == "2") */
                        else if (fetchKasumJP.LapJP.Substring(0, 1) == "3")
                        {
                            int intUrut = 0;
                            foreach (var fetchTransak in grpTransak)
                            {
                                if (fetchTransak.strRegbilling == fetchKasumJP.regBilling
                                    && fetchKasumJP.LapJP.Substring(0, 1) == "3"
                                    && fetchTransak.strRuangan == fetchKasumJP.Ruangan
                                    && fetchTransak.strSMF == fetchKasumJP.IdMR_TSMF)
                                {
                                    grpTransak[intUrut].dblOperasi = grpTransak[intUrut].dblOperasi + fetchKasumJP.tunainya;
                                }
                                intUrut++;
                            } /* EOF foreach (var fetchTransak in grpTransak) */

                        } /* EOF else if (fetchKasumJP.LapJP.Substring(1, 1) == "3") */
                        else if (fetchKasumJP.LapJP.Substring(0, 1) == "4")
                        {
                            int intUrut = 0;
                            foreach (var fetchTransak in grpTransak)
                            {
                                if (fetchTransak.strRegbilling == fetchKasumJP.regBilling
                                    && fetchKasumJP.LapJP.Substring(0, 1) == "4"
                                    && fetchTransak.strRuangan == fetchKasumJP.Ruangan
                                    && fetchTransak.strSMF == fetchKasumJP.IdMR_TSMF)
                                {
                                    grpTransak[intUrut].dblTindakan = grpTransak[intUrut].dblTindakan + fetchKasumJP.tunainya;
                                }
                                intUrut++;
                            } /* EOF foreach (var fetchTransak in grpTransak) */

                        } /* EOF else if (fetchKasumJP.LapJP.Substring(1, 1) == "4") */
                        else if (fetchKasumJP.LapJP.Substring(0, 1) == "5")
                        {
                            int intUrut = 0;
                            foreach (var fetchTransak in grpTransak)
                            {
                                if (fetchTransak.strRegbilling == fetchKasumJP.regBilling
                                    && fetchKasumJP.LapJP.Substring(0, 1) == "5"
                                    && fetchTransak.strRuangan == fetchKasumJP.Ruangan
                                    && fetchTransak.strSMF == fetchKasumJP.IdMR_TSMF)
                                {
                                    grpTransak[intUrut].dblDiagelect = grpTransak[intUrut].dblDiagelect + fetchKasumJP.tunainya;
                                }
                                intUrut++;
                            } /* EOF foreach (var fetchTransak in grpTransak) */

                        } /* EOF else if (fetchKasumJP.LapJP.Substring(1, 1) == "5") */
                        else if (fetchKasumJP.LapJP.Substring(0, 1) == "6")
                        {
                            int intUrut = 0;
                            foreach (var fetchTransak in grpTransak)
                            {
                                if (fetchTransak.strRegbilling == fetchKasumJP.regBilling
                                    && fetchKasumJP.LapJP.Substring(0, 1) == "6"
                                    && fetchTransak.strRuangan == fetchKasumJP.Ruangan
                                    && fetchTransak.strSMF == fetchKasumJP.IdMR_TSMF)
                                {
                                    grpTransak[intUrut].dblPemRK = grpTransak[intUrut].dblPemRK + fetchKasumJP.tunainya;
                                }
                                intUrut++;
                            } /* EOF foreach (var fetchTransak in grpTransak) */

                        } /* EOF else if (fetchKasumJP.LapJP.Substring(1, 1) == "6") */


                        /* 2 SAMPAI 6 */

                    } /* EOF foreach (var fetchKasumJP in KasumJP) */

                    /*JASA ANASTHESI*/

                    if (KasumJA.Count > 0)
                    {
                        foreach (var fetchKasumJA in KasumJA)
                        {

                            lstTransak itemTransak = new lstTransak();
                            itemTransak.strRegbilling = fetchKasumJA.regBilling;
                            itemTransak.strNama = fetchKasumJA.Nama;
                            itemTransak.strRuangan = fetchKasumJA.Ruangan;
                            itemTransak.strUnit = "ANASTHESI";
                            itemTransak.strSMF = fetchKasumJA.IdMR_TSMF;
                            itemTransak.dblKonsul = 0;
                            itemTransak.dblVisite = 0;
                            itemTransak.dblOperasi = fetchKasumJA.tunainya;
                            itemTransak.dblTindakan = 0;
                            itemTransak.dblDiagelect = 0;
                            itemTransak.dblPemRK = 0;
                            

                            grpTransak.Add(itemTransak);

                        } /* EOF foreach (var fetchKasumJA in KasumJA) */
                    }

                } /* EOF if (grpTransak.Count > 0) */
               

            } /* EOF if(grpLstKasum.Count > 0) */

            intWaktuLoad = 0;
            intPenandaProses = 2;            

            ///* QUERY ASKESGAKIN*/
            //this.strQuerySQL = " SELECT  " +
            //                        "BL_TRANSAKSI.Regbilling, " +                                            //0
            //                        "MR_PASIEN.Nama, " +                                                     //1
            //                        "MR_TRUANGAN.ruangan, " +                                                //2
            //                        "BL_TRANSAKSI.Jumlah, " +                                                //3
            //                        "BL_TRANSAKSI.subsidi, " +                                               //4
            //                        "BL_TRANSAKSI.tunai, " +                                                 //5
            //                        "BL_TRANSAKSIDETAIL.Idbl_komponen, " +                                   //6
            //                        "BL_TRANSAKSIDETAIL.Nilai, " +                                           //7
            //                        "BL_TRANSAKSIDETAIL.Ringan, " +                                          //8
            //                        "BL_KELTARIP.urutan, " +                                                 //9
            //                        "BL_KELTARIP.rekapjp," +                                                 //10
            //                        "BL_TRANSAKSIDETAIL.Nilai - BL_TRANSAKSIDETAIL.Ringan as tunainya , " +  //11
            //                        "BL_TRANSAKSIDETAIL.Noambil, " +                                         //12
            //                        "BL_TRANSAKSIDETAIL.tglambil, " +                                        //13
            //                        "BL_KELTARIP.Idbl_keltarip, " +                                          //14
            //                        "BL_KELTARIP.Lapjp, " +                                                  //15
            //                        "BL_TRANSAKSI.idmr_tsmf, " +                                             //16
            //                        "MR_SMFTARIP.idmr_tupf, " +                                              //17
            //                        "BL_TRANSAKSI.idbl_tarip, " +                                            //18
            //                        "BL_TRANSAKSI.uraiantarip, " +                                           //19
            //                        "BL_TRANSAKSI.jml_kasus_tarip, " +                                       //20
            //                        "BL_TRANSAKSI.idbl_transaksi, " +                                        //21
            //                        "BL_KASASKES.Idbl_Pembayaran, " +                                        //22
            //                        "BL_TRANSAKSI.Tgltransaksi, " +                                          //23
            //                        "BL_KASASKES.Tanggal, " +                                                //24
            //                        "BL_TARIP.Idmr_jeniskelas, " +                                           //25
            //                        "BL_TRANSAKSI.Idmr_truangan, " +                                         //26
            //                        "BL_TRANSAKSIDETAIL.Idmr_dokter, " +                                             //27
            //                        "MR_DOKTER.Nama " +                                                     //28
            //                   " FROM BL_KELTARIP With (nolock)  " +
            //                   " INNER JOIN BL_TRANSAKSI " +
            //                   " INNER JOIN BL_TRANSAKSIDETAIL " +
            //                        "ON BL_TRANSAKSI.idbl_transaksi = BL_TRANSAKSIDETAIL.Idbl_transaksi " +
            //                   " INNER JOIN BL_TARIP " +
            //                        "ON BL_TRANSAKSI.idbl_tarip = BL_TARIP.IdBl_tarip " +
            //                        "ON BL_KELTARIP.Idbl_keltarip = BL_TARIP.Idbl_keltarip " +
            //                   " INNER JOIN MR_SMFTARIP " +
            //                        "ON BL_TRANSAKSI.idmr_tsmf = MR_SMFTARIP.idmr_tsmf " +
            //                   " INNER JOIN BL_KASASKES " +
            //                        "ON BL_TRANSAKSI.idbl_pembayaran = BL_KASASKES.Idbl_Pembayaran " +
            //                            "AND BL_TRANSAKSI.idmr_mutasipasien = BL_KASASKES.idmr_mutasipasien " +
            //                   " INNER JOIN MR_PASIEN " +
            //                        "ON BL_KASASKES.Idmr_pasien = MR_PASIEN.IDMR_PASIEN " +
            //                   " INNER JOIN MR_TRUANGAN " +
            //                        "ON BL_KASASKES.Idmr_truangan = MR_TRUANGAN.idmr_truangan " +
            //                   " INNER JOIN MR_SJASKES " +
            //                        "ON BL_KASASKES.idmr_mutasipasien = MR_SJASKES.idmr_mutasipasien " +
            //                   "INNER JOIN MR_DOKTER " +
            //                        "ON MR_DOKTER.Idmr_dokter = BL_TRANSAKSIDETAIL.Idmr_dokter " +
            //                   " WHERE (BL_TRANSAKSI.Batal <> 'Y') " +
            //                      " AND (BL_KASASKES.Batal = '') " +
            //                      " AND (MR_SJASKES.BATAL = '') " +
            //                      " AND MR_SJASKES.idmr_tstatus = 'ASKESGAKIN' " +
            //                      " AND (BL_TRANSAKSIDETAIL.Idbl_komponen <> 'JASA SARANA') " +
            //                      " AND BL_KASASKES.Tanggal BETWEEN '" + dtpFilterTgl1.Value.ToString("MM/dd/yyyy 00:00:00") +
            //                        "' and '" + dtpFilterTgl2.Value.ToString("MM/dd/yyyy 23:59:59") + "' " +
            //                      " AND BL_TARIP.pisahsetor = '' AND BL_KASASKES.jumlah > 0 " +
            //                      " AND BL_TRANSAKSIDETAIL.noambil <> 999 " +
            //                      " AND BL_TRANSAKSI.idmr_tsmf <> 'DARAH' and BL_TRANSAKSI.idmr_tsmf <> 'PENDORONG'" +
            //                      " AND BL_TRANSAKSI.idmr_tsmf <> 'OBAT/ALKES-FARMASI' " +
            //                      " AND BL_TRANSAKSI.idmr_tsmf <> 'OBAT/ALKES-KPRI'" +
            //                      " AND BL_TRANSAKSI.idbl_pembayaran > 0 AND BL_KELTARIP.Lapjp <> '-'";

            //conn = modDb.pbconnKoneksiSQL(ref strErr);
            //if (strErr != "")
            //{
            //    tmrBlink.Enabled = false;
            //    tmrBlink.Stop();
            //    lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = false);
            //    modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
            //    return;
            //}

            //reader = modDb.pbreaderSQL(conn, strQuerySQL, ref strErr);
            //if (strErr != "")
            //{
            //    tmrBlink.Enabled = false;
            //    tmrBlink.Stop();
            //    lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = false);
            //    modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_GET, modMsg.TITLE_ERR);
            //    conn.Close();
            //    return;
            //}

            //if (reader.HasRows)
            //{
            //    while (reader.Read())
            //    {
            //        lstKASASKIN itemKASASKIN = new lstKASASKIN();

            //        itemKASASKIN.strRegBilling = modMain.pbstrgetCol(reader, 0, ref strErr, "");
            //        itemKASASKIN.strNama = modMain.pbstrgetCol(reader, 1, ref strErr, "");
            //        itemKASASKIN.strRuangan = modMain.pbstrgetCol(reader, 2, ref strErr, "");
            //        itemKASASKIN.dblJumlah = Convert.ToDouble(modMain.pbstrgetCol(reader, 3, ref strErr, ""));
            //        itemKASASKIN.dblSubsidi = Convert.ToDouble(modMain.pbstrgetCol(reader, 4, ref strErr, ""));
            //        itemKASASKIN.dblTunai = Convert.ToDouble(modMain.pbstrgetCol(reader, 5, ref strErr, ""));
            //        itemKASASKIN.strIdBl_Komponen = modMain.pbstrgetCol(reader, 6, ref strErr, "");
            //        itemKASASKIN.dblNilai = Convert.ToDouble(modMain.pbstrgetCol(reader, 7, ref strErr, ""));
            //        itemKASASKIN.dblRingan = Convert.ToDouble(modMain.pbstrgetCol(reader, 8, ref strErr, ""));
            //        itemKASASKIN.dblUrutan = Convert.ToDouble(modMain.pbstrgetCol(reader, 9, ref strErr, ""));
            //        itemKASASKIN.strRekapJp = modMain.pbstrgetCol(reader, 10, ref strErr, "");
            //        itemKASASKIN.dblTunainya = Convert.ToDouble(modMain.pbstrgetCol(reader, 11, ref strErr, ""));
            //        itemKASASKIN.dblNoAmbil = Convert.ToDouble(modMain.pbstrgetCol(reader, 12, ref strErr, ""));
            //        itemKASASKIN.dtTglAmbil = Convert.ToDateTime(modMain.pbstrgetCol(reader, 13, ref strErr, ""));
            //        itemKASASKIN.strIdBl_KelTarip = modMain.pbstrgetCol(reader, 14, ref strErr, "");
            //        itemKASASKIN.strLapJP = modMain.pbstrgetCol(reader, 15, ref strErr, "");
            //        itemKASASKIN.strIdMR_TSMF = modMain.pbstrgetCol(reader, 16, ref strErr, "");
            //        itemKASASKIN.strIdMR_TUPF = modMain.pbstrgetCol(reader, 17, ref strErr, "");
            //        itemKASASKIN.strIdBl_Tarip = modMain.pbstrgetCol(reader, 18, ref strErr, "");
            //        itemKASASKIN.strUraianTarip = modMain.pbstrgetCol(reader, 19, ref strErr, "");
            //        itemKASASKIN.dblJumlahKasusTarip = Convert.ToDouble(modMain.pbstrgetCol(reader, 20, ref strErr, ""));
            //        itemKASASKIN.strIdBl_Transaksi = modMain.pbstrgetCol(reader, 21, ref strErr, "");
            //        itemKASASKIN.strIdBl_Pembayaran = modMain.pbstrgetCol(reader, 22, ref strErr, "");
            //        itemKASASKIN.dtTglTransaksi = Convert.ToDateTime(modMain.pbstrgetCol(reader, 23, ref strErr, ""));
            //        itemKASASKIN.dtTgl = Convert.ToDateTime(modMain.pbstrgetCol(reader, 24, ref strErr, ""));
            //        itemKASASKIN.strIdMR_JenisKelas = modMain.pbstrgetCol(reader, 25, ref strErr, "");
            //        itemKASASKIN.strIdMR_Ruangan = modMain.pbstrgetCol(reader, 26, ref strErr, "");
            //        itemKASASKIN.strIdMR_Dokter = modMain.pbstrgetCol(reader, 27, ref strErr, "");
            //        itemKASASKIN.strNamaDokter = modMain.pbstrgetCol(reader, 28, ref strErr, "");

            //        grpLstKASASKIN.Add(itemKASASKIN);
            //    }
            //}
            //reader.Close();
            //conn.Close();

            ////MessageBox.Show(grpLstKASASKIN.Count.ToString());

            //if (grpLstKASASKIN.Count > 0)
            //{

            //    var KaskinJP = (from fetch in grpLstKASASKIN
            //                   where (fetch.strIdBl_Komponen == "JASA PELAYANAN" && fetch.dblTunainya > 0)
            //                   group fetch by new
            //                   {
            //                       fetch.strRegBilling,
            //                       fetch.strNama,
            //                       fetch.strIdBl_Komponen,
            //                       fetch.strLapJP,
            //                       fetch.strIdMR_TUPF,
            //                       fetch.strIdMR_TSMF,
            //                       fetch.strRuangan
            //                   } into groupData
            //                   select new
            //                   {
            //                       regBilling = groupData.Key.strRegBilling,
            //                       Nama = groupData.Key.strNama,
            //                       Ruangan = groupData.Key.strRuangan,
            //                       TUPF = groupData.Key.strIdMR_TUPF,
            //                       IdBl_Komponen = groupData.Key.strIdBl_Komponen,
            //                       IdMR_TSMF = groupData.Key.strIdMR_TSMF,
            //                       tunainya = groupData.Sum(fetchKasum => fetchKasum.dblTunainya),
            //                       LapJP = groupData.Key.strLapJP
            //                   }).OrderBy(groupData => groupData.regBilling).ToList();


            //    var KaskinJA = (from fetch in grpLstKASASKIN
            //                   where (fetch.strIdBl_Komponen != "JASA PELAYANAN" && fetch.dblTunainya > 0)
            //                   group fetch by new
            //                   {
            //                       fetch.strRegBilling,
            //                       fetch.strNama,
            //                       fetch.strIdBl_Komponen,
            //                       fetch.strLapJP,
            //                       fetch.strIdMR_TUPF,
            //                       fetch.strIdMR_TSMF,
            //                       fetch.strRuangan
            //                   } into groupData
            //                   select new
            //                   {
            //                       regBilling = groupData.Key.strRegBilling,
            //                       Nama = groupData.Key.strNama,
            //                       Ruangan = groupData.Key.strRuangan,
            //                       TUPF = groupData.Key.strIdMR_TUPF,
            //                       IdBl_Komponen = groupData.Key.strIdBl_Komponen,
            //                       IdMR_TSMF = groupData.Key.strIdMR_TSMF,
            //                       tunainya = groupData.Sum(fetchKasum => fetchKasum.dblTunainya),
            //                       LapJP = groupData.Key.strLapJP
            //                   }).OrderBy(groupData => groupData.regBilling).ToList();


            //    var reg = (from fetch in grpLstKASASKIN
            //               select new
            //               {
            //                   Regbilling = fetch.strRegBilling,
            //                   Nama = fetch.strNama,
            //                   Ruangan = fetch.strRuangan,
            //                   idmr_tupf = fetch.strIdMR_TUPF,
            //                   idmr_tsmf = fetch.strIdMR_TSMF
            //               }).Distinct().OrderBy(a => a.Regbilling).ToList();


            //    if (reg.Count > 0)
            //    {
            //        foreach (var fetch in reg)
            //        {
            //            lstTransak itemTransak = new lstTransak();
            //            itemTransak.strRegbilling = fetch.Regbilling;
            //            itemTransak.strNama = fetch.Nama;
            //            itemTransak.strRuangan = fetch.Ruangan;
            //            itemTransak.strUnit = fetch.idmr_tupf;
            //            itemTransak.strSMF = fetch.idmr_tsmf;
            //            itemTransak.dblKonsul = 0;
            //            itemTransak.dblVisite = 0;
            //            itemTransak.dblOperasi = 0;
            //            itemTransak.dblTindakan = 0;
            //            itemTransak.dblDiagelect = 0;
            //            itemTransak.dblPemRK = 0;
            //            grpTransak.Add(itemTransak);
            //        }
            //    }


            //    if (grpTransak.Count > 0)
            //    {
            //        /*JASA PELAYANAN*/
            //        foreach (var fetch in KaskinJP)
            //        {

            //            if (fetch.LapJP.Substring(0, 1) == "1")
            //            {
            //                int intUrut = 0;
            //                foreach (var fetchTransak in grpTransak)
            //                {
            //                    if (fetchTransak.strRegbilling == fetch.regBilling
            //                        && fetch.LapJP.Substring(0, 1) == "1"
            //                        && fetchTransak.strRuangan == fetch.Ruangan
            //                        && fetchTransak.strSMF == fetch.IdMR_TSMF)
            //                    {
            //                        grpTransak[intUrut].dblKonsul = grpTransak[intUrut].dblKonsul + fetch.tunainya;
            //                        //fetchTransak.dblKonsul = fetchTransak.dblKonsul + fetchKasumJP.tunainya;
            //                    }
            //                    intUrut++;
            //                } /* EOF foreach (var fetchTransak in grpTransak) */
            //            } /* EOF if (fetchKasumJP.LapJP.Substring(1, 1) == "1") */

            //            else if (fetch.LapJP.Substring(0, 1) == "2")
            //            {
            //                int intUrut = 0;
            //                foreach (var fetchTransak in grpTransak)
            //                {
            //                    if (fetchTransak.strRegbilling == fetch.regBilling
            //                        && fetch.LapJP.Substring(0, 1) == "2"
            //                        && fetchTransak.strRuangan == fetch.Ruangan
            //                        && fetchTransak.strSMF == fetch.IdMR_TSMF)
            //                    {
            //                        grpTransak[intUrut].dblVisite = grpTransak[intUrut].dblVisite + fetch.tunainya;
            //                    }
            //                    intUrut++;
            //                } /* EOF foreach (var fetchTransak in grpTransak) */

            //            } /* EOF else if (fetchKasumJP.LapJP.Substring(1, 1) == "2") */
            //            else if (fetch.LapJP.Substring(0, 1) == "3")
            //            {
            //                int intUrut = 0;
            //                foreach (var fetchTransak in grpTransak)
            //                {
            //                    if (fetchTransak.strRegbilling == fetch.regBilling
            //                        && fetch.LapJP.Substring(0, 1) == "3"
            //                        && fetchTransak.strRuangan == fetch.Ruangan
            //                        && fetchTransak.strSMF == fetch.IdMR_TSMF)
            //                    {
            //                        grpTransak[intUrut].dblOperasi = grpTransak[intUrut].dblOperasi + fetch.tunainya;
            //                    }
            //                    intUrut++;
            //                } /* EOF foreach (var fetchTransak in grpTransak) */

            //            } /* EOF else if (fetchKasumJP.LapJP.Substring(1, 1) == "3") */
            //            else if (fetch.LapJP.Substring(0, 1) == "4")
            //            {
            //                int intUrut = 0;
            //                foreach (var fetchTransak in grpTransak)
            //                {
            //                    if (fetchTransak.strRegbilling == fetch.regBilling
            //                        && fetch.LapJP.Substring(0, 1) == "4"
            //                        && fetchTransak.strRuangan == fetch.Ruangan
            //                        && fetchTransak.strSMF == fetch.IdMR_TSMF)
            //                    {
            //                        grpTransak[intUrut].dblTindakan = grpTransak[intUrut].dblTindakan + fetch.tunainya;
            //                    }
            //                    intUrut++;
            //                } /* EOF foreach (var fetchTransak in grpTransak) */

            //            } /* EOF else if (fetchKasumJP.LapJP.Substring(1, 1) == "4") */
            //            else if (fetch.LapJP.Substring(0, 1) == "5")
            //            {
            //                int intUrut = 0;
            //                foreach (var fetchTransak in grpTransak)
            //                {
            //                    if (fetchTransak.strRegbilling == fetch.regBilling
            //                        && fetch.LapJP.Substring(0, 1) == "5"
            //                        && fetchTransak.strRuangan == fetch.Ruangan
            //                        && fetchTransak.strSMF == fetch.IdMR_TSMF)
            //                    {
            //                        grpTransak[intUrut].dblDiagelect = grpTransak[intUrut].dblDiagelect + fetch.tunainya;
            //                    }
            //                    intUrut++;
            //                } /* EOF foreach (var fetchTransak in grpTransak) */

            //            } /* EOF else if (fetchKasumJP.LapJP.Substring(1, 1) == "5") */
            //            else if (fetch.LapJP.Substring(0, 1) == "6")
            //            {
            //                int intUrut = 0;
            //                foreach (var fetchTransak in grpTransak)
            //                {
            //                    if (fetchTransak.strRegbilling == fetch.regBilling
            //                        && fetch.LapJP.Substring(0, 1) == "6"
            //                        && fetchTransak.strRuangan == fetch.Ruangan
            //                        && fetchTransak.strSMF == fetch.IdMR_TSMF)
            //                    {
            //                        grpTransak[intUrut].dblPemRK = grpTransak[intUrut].dblPemRK + fetch.tunainya;
            //                    }
            //                    intUrut++;
            //                } /* EOF foreach (var fetchTransak in grpTransak) */

            //            } /* EOF else if (fetchKasumJP.LapJP.Substring(1, 1) == "6") */


            //            /* 2 SAMPAI 6 */

            //        } /* EOF foreach (var fetchKasumJP in KasumJP) */

            //        /*JASA ANASTHESI*/
            //        foreach (var fetch in KaskinJA)
            //        {

            //            lstTransak itemTransak = new lstTransak();
            //            itemTransak.strRegbilling = fetch.regBilling;
            //            itemTransak.strNama = fetch.Nama;
            //            itemTransak.strRuangan = fetch.Ruangan;
            //            itemTransak.strUnit = "ANASTHESI";
            //            itemTransak.strSMF = fetch.IdMR_TSMF;
            //            itemTransak.dblKonsul = 0;
            //            itemTransak.dblVisite = 0;
            //            itemTransak.dblOperasi = fetch.tunainya;
            //            itemTransak.dblTindakan = 0;
            //            itemTransak.dblDiagelect = 0;
            //            itemTransak.dblPemRK = 0;

            //            grpTransak.Add(itemTransak);

            //        } /* EOF foreach (var fetchKasumJA in KasumJA) */


            //    } /* EOF if (grpTransak.Count > 0) */



            //} /* EOF  if (grpLstKASASKIN.Count > 0) */
            


            intWaktuLoad = 0;
            intPenandaProses = 3;
                        

            /* QUERY ASKES JAMKESMAS*/
            this.strQuerySQL = "SELECT  " +
                                    "BL_TRANSAKSI.Regbilling, " +                                            //0
                                    "MR_PASIEN.Nama, " +                                                     //1
                                    "MR_TRUANGAN.ruangan, " +                                                //2
                                    "BL_TRANSAKSI.Jumlah, " +                                                //3
                                    "BL_TRANSAKSI.subsidi, " +                                               //4
                                    "BL_TRANSAKSI.tunai, " +                                                 //5
                                    "BL_TRANSAKSIDETAIL.Idbl_komponen, " +                                   //6
                                    "BL_TRANSAKSIDETAIL.Nilai, " +                                           //7
                                    "BL_TRANSAKSIDETAIL.Ringan, " +                                          //8
                                    "BL_KELTARIP.urutan, " +                                                 //9
                                    "BL_KELTARIP.rekapjp," +                                                 //10
                                    "BL_TRANSAKSIDETAIL.Nilai - BL_TRANSAKSIDETAIL.Ringan as tunainya , " +  //11
                                    "BL_TRANSAKSIDETAIL.Noambil," +                                          //12
                                    "BL_TRANSAKSIDETAIL.tglambil, " +                                        //13
                                    "BL_KELTARIP.Idbl_keltarip, " +                                          //14
                                    "BL_KELTARIP.Lapjp, " +                                                  //15
                                    "BL_TRANSAKSI.idmr_tsmf, " +                                             //16
                                    "MR_SMFTARIP.idmr_tupf, " +                                              //17
                                    "BL_TRANSAKSI.idbl_tarip, " +                                            //18
                                    "BL_TRANSAKSI.uraiantarip, " +                                           //19
                                    "BL_TRANSAKSI.jml_kasus_tarip, " +                                       //20
                                    "BL_TRANSAKSI.idbl_transaksi, " +                                        //21
                                    "BL_KASASKES.Idbl_Pembayaran, " +                                        //22
                                    "BL_TRANSAKSI.Tgltransaksi, " +                                          //23
                                    "BL_KASASKES.Tanggal, " +                                                //24
                                    "BL_TARIP.Idmr_jeniskelas, " +                                           //25
                                    "BL_TRANSAKSI.Idmr_truangan, " +                                         //26
                                    "MR_DOKTER.Idmr_dokter, " +                                             //27
                                    "MR_DOKTER.Nama " +                                                     //28
                               "FROM BL_KELTARIP With (nolock)  " +
                               "INNER JOIN BL_TRANSAKSI " +
                               "INNER JOIN BL_TRANSAKSIDETAIL " +
                                    "ON BL_TRANSAKSI.idbl_transaksi = BL_TRANSAKSIDETAIL.Idbl_transaksi " +
                               "INNER JOIN BL_TARIP " +
                                    "ON BL_TRANSAKSI.idbl_tarip = BL_TARIP.IdBl_tarip " +
                                    "ON BL_KELTARIP.Idbl_keltarip = BL_TARIP.Idbl_keltarip " +
                               "INNER JOIN MR_SMFTARIP " +
                                    "ON BL_TRANSAKSI.idmr_tsmf = MR_SMFTARIP.idmr_tsmf " +
                               "INNER JOIN BL_KASASKES " +
                                    "ON BL_TRANSAKSI.idbl_pembayaran = BL_KASASKES.Idbl_Pembayaran " +
                                    "AND BL_TRANSAKSI.idmr_mutasipasien = BL_KASASKES.idmr_mutasipasien " +
                               "INNER JOIN MR_PASIEN " +
                                    "ON BL_KASASKES.Idmr_pasien = MR_PASIEN.IDMR_PASIEN " +
                               "INNER JOIN MR_TRUANGAN " +
                                    "ON BL_KASASKES.Idmr_truangan = MR_TRUANGAN.idmr_truangan " +
                               "INNER JOIN MR_SJASKES " +
                                    "ON BL_KASASKES.idmr_mutasipasien = MR_SJASKES.idmr_mutasipasien " +
                               "INNER JOIN MR_DOKTER " +
                                    "ON MR_DOKTER.Idmr_dokter = BL_TRANSAKSIDETAIL.Idmr_dokter " +
                               "WHERE (BL_TRANSAKSI.Batal <> 'Y') AND (BL_KASASKES.Batal = '') " +
                                  " AND (MR_SJASKES.BATAL = '') AND MR_SJASKES.idmr_tstatus = 'ASKESJAMKESMAS' " +
                                  " AND (BL_TRANSAKSIDETAIL.Idbl_komponen <> 'JASA SARANA') " +
                                  " AND BL_KASASKES.Tanggal between '" + dtpFilterTgl1.Value.ToString("MM/dd/yyyy 00:00:00") +
                                    "' AND '" + dtpFilterTgl2.Value.ToString("MM/dd/yyyy 23:59:59") + "' " +
                                  " AND BL_TARIP.pisahsetor = '' and BL_KASASKES.jumlah > 0 " +
                                  " AND BL_TRANSAKSIDETAIL.noambil <> 999 " +
                                  " AND BL_TRANSAKSI.idmr_tsmf <> 'DARAH' AND BL_TRANSAKSI.idmr_tsmf <> 'PENDORONG'" +
                                  " AND BL_TRANSAKSI.idmr_tsmf <> 'OBAT/ALKES-FARMASI' " +
                                  " AND BL_TRANSAKSI.idmr_tsmf <> 'OBAT/ALKES-KPRI'" +
                                  " AND BL_TRANSAKSI.idbl_pembayaran > 0 and BL_KELTARIP.Lapjp <> '-'";

            conn = modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {
                tmrBlink.Enabled = false;
                tmrBlink.Stop();
                lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = false);
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                return;
            }

            reader = modDb.pbreaderSQL(conn, strQuerySQL, ref strErr);
            if (strErr != "")
            {
                tmrBlink.Enabled = false;
                tmrBlink.Stop();
                lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = false);
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_GET, modMsg.TITLE_ERR);
                conn.Close();
                return;
            }

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    lstKASJKM itemKASJKM = new lstKASJKM();

                    itemKASJKM.strRegBilling = modMain.pbstrgetCol(reader, 0, ref strErr, "");
                    itemKASJKM.strNama = modMain.pbstrgetCol(reader, 1, ref strErr, "");
                    itemKASJKM.strRuangan = modMain.pbstrgetCol(reader, 2, ref strErr, "");
                    itemKASJKM.dblJumlah = Convert.ToDouble(modMain.pbstrgetCol(reader, 3, ref strErr, ""));
                    itemKASJKM.dblSubsidi = Convert.ToDouble(modMain.pbstrgetCol(reader, 4, ref strErr, ""));
                    itemKASJKM.dblTunai = Convert.ToDouble(modMain.pbstrgetCol(reader, 5, ref strErr, ""));
                    itemKASJKM.strIdBl_Komponen = modMain.pbstrgetCol(reader, 6, ref strErr, "");
                    itemKASJKM.dblNilai = Convert.ToDouble(modMain.pbstrgetCol(reader, 7, ref strErr, ""));
                    itemKASJKM.dblRingan = Convert.ToDouble(modMain.pbstrgetCol(reader, 8, ref strErr, ""));
                    itemKASJKM.dblUrutan = Convert.ToDouble(modMain.pbstrgetCol(reader, 9, ref strErr, ""));
                    itemKASJKM.strRekapJp = modMain.pbstrgetCol(reader, 10, ref strErr, "");
                    itemKASJKM.dblTunainya = Convert.ToDouble(modMain.pbstrgetCol(reader, 11, ref strErr, ""));
                    itemKASJKM.dblNoAmbil = Convert.ToDouble(modMain.pbstrgetCol(reader, 12, ref strErr, ""));
                    itemKASJKM.dtTglAmbil = Convert.ToDateTime(modMain.pbstrgetCol(reader, 13, ref strErr, ""));
                    itemKASJKM.strIdBl_KelTarip = modMain.pbstrgetCol(reader, 14, ref strErr, "");
                    itemKASJKM.strLapJP = modMain.pbstrgetCol(reader, 15, ref strErr, "");
                    itemKASJKM.strIdMR_TSMF = modMain.pbstrgetCol(reader, 16, ref strErr, "");
                    itemKASJKM.strIdMR_TUPF = modMain.pbstrgetCol(reader, 17, ref strErr, "");
                    itemKASJKM.strIdBl_Tarip = modMain.pbstrgetCol(reader, 18, ref strErr, "");
                    itemKASJKM.strUraianTarip = modMain.pbstrgetCol(reader, 19, ref strErr, "");
                    itemKASJKM.dblJumlahKasusTarip = Convert.ToDouble(modMain.pbstrgetCol(reader, 20, ref strErr, ""));
                    itemKASJKM.strIdBl_Transaksi = modMain.pbstrgetCol(reader, 21, ref strErr, "");
                    itemKASJKM.strIdBl_Pembayaran = modMain.pbstrgetCol(reader, 22, ref strErr, "");
                    itemKASJKM.dtTglTransaksi = Convert.ToDateTime(modMain.pbstrgetCol(reader, 23, ref strErr, ""));
                    itemKASJKM.dtTgl = Convert.ToDateTime(modMain.pbstrgetCol(reader, 24, ref strErr, ""));
                    itemKASJKM.strIdMR_JenisKelas = modMain.pbstrgetCol(reader, 25, ref strErr, "");
                    itemKASJKM.strIdMR_Ruangan = modMain.pbstrgetCol(reader, 26, ref strErr, "");
                    itemKASJKM.strIdMR_Dokter = modMain.pbstrgetCol(reader, 27, ref strErr, "");
                    itemKASJKM.strNamaDokter = modMain.pbstrgetCol(reader, 28, ref strErr, "");

                    grpLstKASJKM.Add(itemKASJKM);
                }
            }

            reader.Close();
            conn.Close();

            if (grpLstKASJKM.Count > 0)
            {

                var KasJKMJP = (from fetch in grpLstKASJKM
                                where (fetch.strIdBl_Komponen == "JASA PELAYANAN" && fetch.dblTunainya > 0)
                                group fetch by new
                                {
                                    fetch.strRegBilling,
                                    fetch.strNama,
                                    fetch.strIdBl_Komponen,
                                    fetch.strLapJP,
                                    fetch.strIdMR_TUPF,
                                    fetch.strIdMR_TSMF,
                                    fetch.strRuangan
                                } into groupData
                                select new
                                {
                                    regBilling = groupData.Key.strRegBilling,
                                    Nama = groupData.Key.strNama,
                                    Ruangan = groupData.Key.strRuangan,
                                    TUPF = groupData.Key.strIdMR_TUPF,
                                    IdBl_Komponen = groupData.Key.strIdBl_Komponen,
                                    IdMR_TSMF = groupData.Key.strIdMR_TSMF,
                                    tunainya = groupData.Sum(fetchKasum => fetchKasum.dblTunainya),
                                    LapJP = groupData.Key.strLapJP
                                }).OrderBy(groupData => groupData.regBilling).ToList();


                var KasJKMJA = (from fetch in grpLstKASJKM
                                where (fetch.strIdBl_Komponen != "JASA PELAYANAN" && fetch.dblTunainya > 0)
                                group fetch by new
                                {
                                    fetch.strRegBilling,
                                    fetch.strNama,
                                    fetch.strIdBl_Komponen,
                                    fetch.strLapJP,
                                    fetch.strIdMR_TUPF,
                                    fetch.strIdMR_TSMF,
                                    fetch.strRuangan
                                } into groupData
                                select new
                                {
                                    regBilling = groupData.Key.strRegBilling,
                                    Nama = groupData.Key.strNama,
                                    Ruangan = groupData.Key.strRuangan,
                                    TUPF = groupData.Key.strIdMR_TUPF,
                                    IdBl_Komponen = groupData.Key.strIdBl_Komponen,
                                    IdMR_TSMF = groupData.Key.strIdMR_TSMF,
                                    tunainya = groupData.Sum(fetchKasum => fetchKasum.dblTunainya),
                                    LapJP = groupData.Key.strLapJP
                                }).OrderBy(groupData => groupData.regBilling).ToList();


                var reg = (from fetch in grpLstKASJKM
                           select new
                           {
                               Regbilling = fetch.strRegBilling,
                               Nama = fetch.strNama,
                               Ruangan = fetch.strRuangan,
                               idmr_tupf = fetch.strIdMR_TUPF,
                               idmr_tsmf = fetch.strIdMR_TSMF
                           }).Distinct().OrderBy(a => a.Regbilling).ToList();


                if (reg.Count > 0)
                {
                    foreach (var fetch in reg)
                    {
                        lstTransak itemTransak = new lstTransak();
                        itemTransak.strRegbilling = fetch.Regbilling;
                        itemTransak.strNama = fetch.Nama;
                        itemTransak.strRuangan = fetch.Ruangan;
                        itemTransak.strUnit = fetch.idmr_tupf;
                        itemTransak.strSMF = fetch.idmr_tsmf;
                        itemTransak.dblKonsul = 0;
                        itemTransak.dblVisite = 0;
                        itemTransak.dblOperasi = 0;
                        itemTransak.dblTindakan = 0;
                        itemTransak.dblDiagelect = 0;
                        itemTransak.dblPemRK = 0;
                        grpTransak.Add(itemTransak);
                    }
                }


                if (grpTransak.Count > 0)
                {
                    /*JASA PELAYANAN*/
                    foreach (var fetch in KasJKMJP)
                    {

                        if (fetch.LapJP.Substring(0, 1) == "1")
                        {
                            int intUrut = 0;
                            foreach (var fetchTransak in grpTransak)
                            {
                                if (fetchTransak.strRegbilling == fetch.regBilling
                                    && fetch.LapJP.Substring(0, 1) == "1"
                                    && fetchTransak.strRuangan == fetch.Ruangan
                                    && fetchTransak.strSMF == fetch.IdMR_TSMF)
                                {
                                    grpTransak[intUrut].dblKonsul = grpTransak[intUrut].dblKonsul + fetch.tunainya;
                                    //fetchTransak.dblKonsul = fetchTransak.dblKonsul + fetchKasumJP.tunainya;
                                }
                                intUrut++;
                            } /* EOF foreach (var fetchTransak in grpTransak) */
                        } /* EOF if (fetchKasumJP.LapJP.Substring(1, 1) == "1") */

                        else if (fetch.LapJP.Substring(0, 1) == "2")
                        {
                            int intUrut = 0;
                            foreach (var fetchTransak in grpTransak)
                            {
                                if (fetchTransak.strRegbilling == fetch.regBilling
                                    && fetch.LapJP.Substring(0, 1) == "2"
                                    && fetchTransak.strRuangan == fetch.Ruangan
                                    && fetchTransak.strSMF == fetch.IdMR_TSMF)
                                {
                                    grpTransak[intUrut].dblVisite = grpTransak[intUrut].dblVisite + fetch.tunainya;
                                }
                                intUrut++;
                            } /* EOF foreach (var fetchTransak in grpTransak) */

                        } /* EOF else if (fetchKasumJP.LapJP.Substring(1, 1) == "2") */
                        else if (fetch.LapJP.Substring(0, 1) == "3")
                        {
                            int intUrut = 0;
                            foreach (var fetchTransak in grpTransak)
                            {
                                if (fetchTransak.strRegbilling == fetch.regBilling
                                    && fetch.LapJP.Substring(0, 1) == "3"
                                    && fetchTransak.strRuangan == fetch.Ruangan
                                    && fetchTransak.strSMF == fetch.IdMR_TSMF)
                                {
                                    grpTransak[intUrut].dblOperasi = grpTransak[intUrut].dblOperasi + fetch.tunainya;
                                }
                                intUrut++;
                            } /* EOF foreach (var fetchTransak in grpTransak) */

                        } /* EOF else if (fetchKasumJP.LapJP.Substring(1, 1) == "3") */
                        else if (fetch.LapJP.Substring(0, 1) == "4")
                        {
                            int intUrut = 0;
                            foreach (var fetchTransak in grpTransak)
                            {
                                if (fetchTransak.strRegbilling == fetch.regBilling
                                    && fetch.LapJP.Substring(0, 1) == "4"
                                    && fetchTransak.strRuangan == fetch.Ruangan
                                    && fetchTransak.strSMF == fetch.IdMR_TSMF)
                                {
                                    grpTransak[intUrut].dblTindakan = grpTransak[intUrut].dblTindakan + fetch.tunainya;
                                }
                                intUrut++;
                            } /* EOF foreach (var fetchTransak in grpTransak) */

                        } /* EOF else if (fetchKasumJP.LapJP.Substring(1, 1) == "4") */
                        else if (fetch.LapJP.Substring(0, 1) == "5")
                        {
                            int intUrut = 0;
                            foreach (var fetchTransak in grpTransak)
                            {
                                if (fetchTransak.strRegbilling == fetch.regBilling
                                    && fetch.LapJP.Substring(0, 1) == "5"
                                    && fetchTransak.strRuangan == fetch.Ruangan
                                    && fetchTransak.strSMF == fetch.IdMR_TSMF)
                                {
                                    grpTransak[intUrut].dblDiagelect = grpTransak[intUrut].dblDiagelect + fetch.tunainya;
                                }
                                intUrut++;
                            } /* EOF foreach (var fetchTransak in grpTransak) */

                        } /* EOF else if (fetchKasumJP.LapJP.Substring(1, 1) == "5") */
                        else if (fetch.LapJP.Substring(0, 1) == "6")
                        {
                            int intUrut = 0;
                            foreach (var fetchTransak in grpTransak)
                            {
                                if (fetchTransak.strRegbilling == fetch.regBilling
                                    && fetch.LapJP.Substring(0, 1) == "6"
                                    && fetchTransak.strRuangan == fetch.Ruangan
                                    && fetchTransak.strSMF == fetch.IdMR_TSMF)
                                {
                                    grpTransak[intUrut].dblPemRK = grpTransak[intUrut].dblPemRK + fetch.tunainya;
                                }
                                intUrut++;
                            } /* EOF foreach (var fetchTransak in grpTransak) */

                        } /* EOF else if (fetchKasumJP.LapJP.Substring(1, 1) == "6") */


                        /* 2 SAMPAI 6 */

                    } /* EOF foreach (var fetchKasumJP in KasumJP) */

                    /*JASA ANASTHESI*/
                    foreach (var fetch in KasJKMJA)
                    {

                        lstTransak itemTransak = new lstTransak();
                        itemTransak.strRegbilling = fetch.regBilling;
                        itemTransak.strNama = fetch.Nama;
                        itemTransak.strRuangan = fetch.Ruangan;
                        itemTransak.strUnit = "ANASTHESI";
                        itemTransak.strSMF = fetch.IdMR_TSMF;
                        itemTransak.dblKonsul = 0;
                        itemTransak.dblVisite = 0;
                        itemTransak.dblOperasi = fetch.tunainya;
                        itemTransak.dblTindakan = 0;
                        itemTransak.dblDiagelect = 0;
                        itemTransak.dblPemRK = 0;

                        grpTransak.Add(itemTransak);

                    } /* EOF foreach (var fetch in KasJKMJA) */


                } /* EOF if (grpTransak.Count > 0) */



            } /* EOF  if (grpLstKasJKM.Count > 0) */


            intWaktuLoad = 0;
            intPenandaProses = 4;
            

            /* QUERY ASKES JAMKESDA*/
            this.strQuerySQL = "SELECT  " +
                                    "BL_TRANSAKSI.Regbilling, " +                                            //0
                                    "MR_PASIEN.Nama, " +                                                     //1
                                    "MR_TRUANGAN.ruangan, " +                                               //2
                                    "BL_TRANSAKSI.Jumlah, " +                                                //3
                                    "BL_TRANSAKSI.subsidi, " +                                               //4
                                    "BL_TRANSAKSI.tunai, " +                                                //5
                                    "BL_TRANSAKSIDETAIL.Idbl_komponen, " +                                   //6
                                    "BL_TRANSAKSIDETAIL.Nilai, " +                                          //7
                                    "BL_TRANSAKSIDETAIL.Ringan, " +                                          //8
                                    "BL_KELTARIP.urutan, " +                                                 //9
                                    "BL_KELTARIP.rekapjp," +                                                //10
                                    "BL_TRANSAKSIDETAIL.Nilai - BL_TRANSAKSIDETAIL.Ringan as tunainya , " + //11
                                    "BL_TRANSAKSIDETAIL.Noambil," +                                          //12
                                    "BL_TRANSAKSIDETAIL.tglambil, " +                                       //13
                                    "BL_KELTARIP.Idbl_keltarip, " +                                          //14
                                    "BL_KELTARIP.Lapjp, " +                                                  //15
                                    "BL_TRANSAKSI.idmr_tsmf, " +                                            //16
                                    "MR_SMFTARIP.idmr_tupf, " +                                              //17
                                    "BL_TRANSAKSI.idbl_tarip, " +                                            //18
                                    "BL_TRANSAKSI.uraiantarip, " +                                          //19
                                    "BL_TRANSAKSI.jml_kasus_tarip, " +                                       //20
                                    "BL_TRANSAKSI.idbl_transaksi, " +                                       //21
                                    "BL_KASASKES.Idbl_Pembayaran, " +                                        //22
                                    "BL_TRANSAKSI.Tgltransaksi, " +                                          //23
                                    "BL_KASASKES.Tanggal, " +                                               //24
                                    "BL_TARIP.Idmr_jeniskelas, " +                                           //25
                                    "BL_TRANSAKSI.Idmr_truangan, " +                                        //26
                                    "MR_DOKTER.Idmr_dokter, " +                                             //27
                                    "MR_DOKTER.Nama " +                                                     //28
                                " FROM BL_KELTARIP With (nolock)  " +
                                " INNER JOIN BL_TRANSAKSI " +
                                " INNER JOIN BL_TRANSAKSIDETAIL "+
                                        "ON BL_TRANSAKSI.idbl_transaksi = BL_TRANSAKSIDETAIL.Idbl_transaksi " +
                                " INNER JOIN BL_TARIP " +
                                        "ON BL_TRANSAKSI.idbl_tarip = BL_TARIP.IdBl_tarip " +
                                        "ON BL_KELTARIP.Idbl_keltarip = BL_TARIP.Idbl_keltarip " +
                                " INNER JOIN MR_SMFTARIP " +
                                        "ON BL_TRANSAKSI.idmr_tsmf = MR_SMFTARIP.idmr_tsmf " +
                                " INNER JOIN BL_KASASKES " +
                                        "ON BL_TRANSAKSI.idbl_pembayaran = BL_KASASKES.Idbl_Pembayaran " +
                                  " AND BL_TRANSAKSI.idmr_mutasipasien = BL_KASASKES.idmr_mutasipasien " +
                                " INNER JOIN MR_PASIEN ON BL_KASASKES.Idmr_pasien = MR_PASIEN.IDMR_PASIEN " +
                                " INNER JOIN MR_TRUANGAN ON BL_KASASKES.Idmr_truangan = MR_TRUANGAN.idmr_truangan " +
                                " INNER JOIN MR_SJASKES ON BL_KASASKES.idmr_mutasipasien = MR_SJASKES.idmr_mutasipasien " +
                                "INNER JOIN MR_DOKTER " +
                                    "ON MR_DOKTER.Idmr_dokter = BL_TRANSAKSIDETAIL.Idmr_dokter " +
                                " WHERE (BL_TRANSAKSI.Batal <> 'Y') AND (BL_KASASKES.Batal = '') " +
                                  " AND (MR_SJASKES.BATAL = '') and MR_SJASKES.idmr_tstatus = 'ASKESJAMKESDA' " +
                                  " AND (BL_TRANSAKSIDETAIL.Idbl_komponen <> 'JASA SARANA') " +
                                  " AND BL_KASASKES.Tanggal between '" + dtpFilterTgl1.Value.ToString("MM/dd/yyyy 00:00:00") +
                                  "' and '" + dtpFilterTgl2.Value.ToString("MM/dd/yyyy 23:59:59") + "' " +
                                  " AND BL_TARIP.pisahsetor = '' AND BL_KASASKES.jumlah > 0 " +
                                  " AND BL_TRANSAKSIDETAIL.noambil <> 999 " +
                                  " AND BL_TRANSAKSI.idmr_tsmf <> 'DARAH' and BL_TRANSAKSI.idmr_tsmf <> 'PENDORONG'" +
                                  " AND BL_TRANSAKSI.idmr_tsmf <> 'OBAT/ALKES-FARMASI' " +
                                  " AND BL_TRANSAKSI.idmr_tsmf <> 'OBAT/ALKES-KPRI'" +
                                  " AND BL_TRANSAKSI.idbl_pembayaran > 0 and BL_KELTARIP.Lapjp <> '-'";

            conn = modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {
                tmrBlink.Enabled = false;
                tmrBlink.Stop();
                lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = false);
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                return;
            }

            reader = modDb.pbreaderSQL(conn, strQuerySQL, ref strErr);
            if (strErr != "")
            {
                tmrBlink.Enabled = false;
                tmrBlink.Stop();
                lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = false);
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_GET, modMsg.TITLE_ERR);
                conn.Close();
                return;
            }

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    lstKASJKD itemKASJKD = new lstKASJKD();

                    itemKASJKD.strRegBilling = modMain.pbstrgetCol(reader, 0, ref strErr, "");
                    itemKASJKD.strNama = modMain.pbstrgetCol(reader, 1, ref strErr, "");
                    itemKASJKD.strRuangan = modMain.pbstrgetCol(reader, 2, ref strErr, "");
                    itemKASJKD.dblJumlah = Convert.ToDouble(modMain.pbstrgetCol(reader, 3, ref strErr, ""));
                    itemKASJKD.dblSubsidi = Convert.ToDouble(modMain.pbstrgetCol(reader, 4, ref strErr, ""));
                    itemKASJKD.dblTunai = Convert.ToDouble(modMain.pbstrgetCol(reader, 5, ref strErr, ""));
                    itemKASJKD.strIdBl_Komponen = modMain.pbstrgetCol(reader, 6, ref strErr, "");
                    itemKASJKD.dblNilai = Convert.ToDouble(modMain.pbstrgetCol(reader, 7, ref strErr, ""));
                    itemKASJKD.dblRingan = Convert.ToDouble(modMain.pbstrgetCol(reader, 8, ref strErr, ""));
                    itemKASJKD.dblUrutan = Convert.ToDouble(modMain.pbstrgetCol(reader, 9, ref strErr, ""));
                    itemKASJKD.strRekapJp = modMain.pbstrgetCol(reader, 10, ref strErr, "");
                    itemKASJKD.dblTunainya = Convert.ToDouble(modMain.pbstrgetCol(reader, 11, ref strErr, ""));
                    itemKASJKD.dblNoAmbil = Convert.ToDouble(modMain.pbstrgetCol(reader, 12, ref strErr, ""));
                    itemKASJKD.dtTglAmbil = Convert.ToDateTime(modMain.pbstrgetCol(reader, 13, ref strErr, ""));
                    itemKASJKD.strIdBl_KelTarip = modMain.pbstrgetCol(reader, 14, ref strErr, "");
                    itemKASJKD.strLapJP = modMain.pbstrgetCol(reader, 15, ref strErr, "");
                    itemKASJKD.strIdMR_TSMF = modMain.pbstrgetCol(reader, 16, ref strErr, "");
                    itemKASJKD.strIdMR_TUPF = modMain.pbstrgetCol(reader, 17, ref strErr, "");
                    itemKASJKD.strIdBl_Tarip = modMain.pbstrgetCol(reader, 18, ref strErr, "");
                    itemKASJKD.strUraianTarip = modMain.pbstrgetCol(reader, 19, ref strErr, "");
                    itemKASJKD.dblJumlahKasusTarip = Convert.ToDouble(modMain.pbstrgetCol(reader, 20, ref strErr, ""));
                    itemKASJKD.strIdBl_Transaksi = modMain.pbstrgetCol(reader, 21, ref strErr, "");
                    itemKASJKD.strIdBl_Pembayaran = modMain.pbstrgetCol(reader, 22, ref strErr, "");
                    itemKASJKD.dtTglTransaksi = Convert.ToDateTime(modMain.pbstrgetCol(reader, 23, ref strErr, ""));
                    itemKASJKD.dtTgl = Convert.ToDateTime(modMain.pbstrgetCol(reader, 24, ref strErr, ""));
                    itemKASJKD.strIdMR_JenisKelas = modMain.pbstrgetCol(reader, 25, ref strErr, "");
                    itemKASJKD.strIdMR_Ruangan = modMain.pbstrgetCol(reader, 26, ref strErr, "");
                    itemKASJKD.strIdMR_Dokter = modMain.pbstrgetCol(reader, 27, ref strErr, "");
                    itemKASJKD.strNamaDokter = modMain.pbstrgetCol(reader, 28, ref strErr, "");

                    grpLstKASJKD.Add(itemKASJKD);
                }
            }

            reader.Close();
            conn.Close();

            if (grpLstKASJKD.Count > 0)
            {

                var KasJKDJP = (from fetch in grpLstKASJKD
                                where (fetch.strIdBl_Komponen == "JASA PELAYANAN" && fetch.dblTunainya > 0)
                                group fetch by new
                                {
                                    fetch.strRegBilling,
                                    fetch.strNama,
                                    fetch.strIdBl_Komponen,
                                    fetch.strLapJP,
                                    fetch.strIdMR_TUPF,
                                    fetch.strIdMR_TSMF,
                                    fetch.strRuangan
                                } into groupData
                                select new
                                {
                                    regBilling = groupData.Key.strRegBilling,
                                    Nama = groupData.Key.strNama,
                                    Ruangan = groupData.Key.strRuangan,
                                    TUPF = groupData.Key.strIdMR_TUPF,
                                    IdBl_Komponen = groupData.Key.strIdBl_Komponen,
                                    IdMR_TSMF = groupData.Key.strIdMR_TSMF,
                                    tunainya = groupData.Sum(fetchKasum => fetchKasum.dblTunainya),
                                    LapJP = groupData.Key.strLapJP
                                }).OrderBy(groupData => groupData.regBilling).ToList();


                var KasJKDJA = (from fetch in grpLstKASJKD
                                where (fetch.strIdBl_Komponen != "JASA PELAYANAN" && fetch.dblTunainya > 0)
                                group fetch by new
                                {
                                    fetch.strRegBilling,
                                    fetch.strNama,
                                    fetch.strIdBl_Komponen,
                                    fetch.strLapJP,
                                    fetch.strIdMR_TUPF,
                                    fetch.strIdMR_TSMF,
                                    fetch.strRuangan
                                } into groupData
                                select new
                                {
                                    regBilling = groupData.Key.strRegBilling,
                                    Nama = groupData.Key.strNama,
                                    Ruangan = groupData.Key.strRuangan,
                                    TUPF = groupData.Key.strIdMR_TUPF,
                                    IdBl_Komponen = groupData.Key.strIdBl_Komponen,
                                    IdMR_TSMF = groupData.Key.strIdMR_TSMF,
                                    tunainya = groupData.Sum(fetchKasum => fetchKasum.dblTunainya),
                                    LapJP = groupData.Key.strLapJP
                                }).OrderBy(groupData => groupData.regBilling).ToList();


                var reg = (from fetch in grpLstKASJKD
                           select new
                           {
                               Regbilling = fetch.strRegBilling,
                               Nama = fetch.strNama,
                               Ruangan = fetch.strRuangan,
                               idmr_tupf = fetch.strIdMR_TUPF,
                               idmr_tsmf = fetch.strIdMR_TSMF
                           }).Distinct().OrderBy(a => a.Regbilling).ToList();


                if (reg.Count > 0)
                {
                    foreach (var fetch in reg)
                    {
                        lstTransak itemTransak = new lstTransak();
                        itemTransak.strRegbilling = fetch.Regbilling;
                        itemTransak.strNama = fetch.Nama;
                        itemTransak.strRuangan = fetch.Ruangan;
                        itemTransak.strUnit = fetch.idmr_tupf;
                        itemTransak.strSMF = fetch.idmr_tsmf;
                        itemTransak.dblKonsul = 0;
                        itemTransak.dblVisite = 0;
                        itemTransak.dblOperasi = 0;
                        itemTransak.dblTindakan = 0;
                        itemTransak.dblDiagelect = 0;
                        itemTransak.dblPemRK = 0;
                        grpTransak.Add(itemTransak);
                    }
                }


                if (grpTransak.Count > 0)
                {
                    /*JASA PELAYANAN*/
                    foreach (var fetch in KasJKDJP)
                    {

                        if (fetch.LapJP.Substring(0, 1) == "1")
                        {
                            int intUrut = 0;
                            foreach (var fetchTransak in grpTransak)
                            {
                                if (fetchTransak.strRegbilling == fetch.regBilling
                                    && fetch.LapJP.Substring(0, 1) == "1"
                                    && fetchTransak.strRuangan == fetch.Ruangan
                                    && fetchTransak.strSMF == fetch.IdMR_TSMF)
                                {
                                    grpTransak[intUrut].dblKonsul = grpTransak[intUrut].dblKonsul + fetch.tunainya;
                                    //fetchTransak.dblKonsul = fetchTransak.dblKonsul + fetchKasumJP.tunainya;
                                }
                                intUrut++;
                            } /* EOF foreach (var fetchTransak in grpTransak) */
                        } /* EOF if (fetchKasumJP.LapJP.Substring(1, 1) == "1") */

                        else if (fetch.LapJP.Substring(0, 1) == "2")
                        {
                            int intUrut = 0;
                            foreach (var fetchTransak in grpTransak)
                            {
                                if (fetchTransak.strRegbilling == fetch.regBilling
                                    && fetch.LapJP.Substring(0, 1) == "2"
                                    && fetchTransak.strRuangan == fetch.Ruangan
                                    && fetchTransak.strSMF == fetch.IdMR_TSMF)
                                {
                                    grpTransak[intUrut].dblVisite = grpTransak[intUrut].dblVisite + fetch.tunainya;
                                }
                                intUrut++;
                            } /* EOF foreach (var fetchTransak in grpTransak) */

                        } /* EOF else if (fetchKasumJP.LapJP.Substring(1, 1) == "2") */
                        else if (fetch.LapJP.Substring(0, 1) == "3")
                        {
                            int intUrut = 0;
                            foreach (var fetchTransak in grpTransak)
                            {
                                if (fetchTransak.strRegbilling == fetch.regBilling
                                    && fetch.LapJP.Substring(0, 1) == "3"
                                    && fetchTransak.strRuangan == fetch.Ruangan
                                    && fetchTransak.strSMF == fetch.IdMR_TSMF)
                                {
                                    grpTransak[intUrut].dblOperasi = grpTransak[intUrut].dblOperasi + fetch.tunainya;
                                }
                                intUrut++;
                            } /* EOF foreach (var fetchTransak in grpTransak) */

                        } /* EOF else if (fetchKasumJP.LapJP.Substring(1, 1) == "3") */
                        else if (fetch.LapJP.Substring(0, 1) == "4")
                        {
                            int intUrut = 0;
                            foreach (var fetchTransak in grpTransak)
                            {
                                if (fetchTransak.strRegbilling == fetch.regBilling
                                    && fetch.LapJP.Substring(0, 1) == "4"
                                    && fetchTransak.strRuangan == fetch.Ruangan
                                    && fetchTransak.strSMF == fetch.IdMR_TSMF)
                                {
                                    grpTransak[intUrut].dblTindakan = grpTransak[intUrut].dblTindakan + fetch.tunainya;
                                }
                                intUrut++;
                            } /* EOF foreach (var fetchTransak in grpTransak) */

                        } /* EOF else if (fetchKasumJP.LapJP.Substring(1, 1) == "4") */
                        else if (fetch.LapJP.Substring(0, 1) == "5")
                        {
                            int intUrut = 0;
                            foreach (var fetchTransak in grpTransak)
                            {
                                if (fetchTransak.strRegbilling == fetch.regBilling
                                    && fetch.LapJP.Substring(0, 1) == "5"
                                    && fetchTransak.strRuangan == fetch.Ruangan
                                    && fetchTransak.strSMF == fetch.IdMR_TSMF)
                                {
                                    grpTransak[intUrut].dblDiagelect = grpTransak[intUrut].dblDiagelect + fetch.tunainya;
                                }
                                intUrut++;
                            } /* EOF foreach (var fetchTransak in grpTransak) */

                        } /* EOF else if (fetchKasumJP.LapJP.Substring(1, 1) == "5") */
                        else if (fetch.LapJP.Substring(0, 1) == "6")
                        {
                            int intUrut = 0;
                            foreach (var fetchTransak in grpTransak)
                            {
                                if (fetchTransak.strRegbilling == fetch.regBilling
                                    && fetch.LapJP.Substring(0, 1) == "6"
                                    && fetchTransak.strRuangan == fetch.Ruangan
                                    && fetchTransak.strSMF == fetch.IdMR_TSMF)
                                {
                                    grpTransak[intUrut].dblPemRK = grpTransak[intUrut].dblPemRK + fetch.tunainya;
                                }
                                intUrut++;
                            } /* EOF foreach (var fetchTransak in grpTransak) */

                        } /* EOF else if (fetchKasumJP.LapJP.Substring(1, 1) == "6") */


                        /* 2 SAMPAI 6 */

                    } /* EOF foreach (var fetchKasumJP in KasumJP) */

                    /*JASA ANASTHESI*/
                    foreach (var fetch in KasJKDJA)
                    {

                        lstTransak itemTransak = new lstTransak();
                        itemTransak.strRegbilling = fetch.regBilling;
                        itemTransak.strNama = fetch.Nama;
                        itemTransak.strRuangan = fetch.Ruangan;
                        itemTransak.strUnit = "ANASTHESI";
                        itemTransak.strSMF = fetch.IdMR_TSMF;
                        itemTransak.dblKonsul = 0;
                        itemTransak.dblVisite = 0;
                        itemTransak.dblOperasi = fetch.tunainya;
                        itemTransak.dblTindakan = 0;
                        itemTransak.dblDiagelect = 0;
                        itemTransak.dblPemRK = 0;

                        grpTransak.Add(itemTransak);

                    } /* EOF foreach (var fetch in KasJKMJA) */


                } /* EOF if (grpTransak.Count > 0) */



            } /* EOF  if (grpLstKasJKM.Count > 0) */

            tmrWaktuLoad.Stop();                
            tmrWaktuLoad.Enabled = false;


            if (grpTransak.Count > 0)
            {
                var transaknya = (from x in grpTransak
                                  group x by new
                                  {
                                      x.strRegbilling,
                                      x.strUnit,
                                      x.strRuangan,
                                      x.strNama
                                  } into groupTransak
                                  select new
                                  {
                                      regBilling = groupTransak.Key.strRegbilling,
                                      Nama = groupTransak.Key.strNama,
                                      Ruangan = groupTransak.Key.strRuangan,
                                      Unit = groupTransak.Key.strUnit,
                                      konsul = groupTransak.Sum(x => x.dblKonsul),
                                      visite = groupTransak.Sum(x => x.dblVisite),
                                      operasi = groupTransak.Sum(x => x.dblOperasi),
                                      tindakan = groupTransak.Sum(x => x.dblTindakan),
                                      diagelect = groupTransak.Sum(x => x.dblDiagelect),
                                      pemrk = groupTransak.Sum(x => x.dblPemRK)
                                  }).ToList();

                foreach (var fetch in transaknya)
                {

                    lstTransaknya itemTransaknya = new lstTransaknya();
                    itemTransaknya.strRegBilling = fetch.regBilling;
                    itemTransaknya.strNama = fetch.Nama;
                    itemTransaknya.strRuangan = fetch.Ruangan;
                    itemTransaknya.strUnit = fetch.Unit;
                    itemTransaknya.dblKonsul = fetch.konsul;
                    itemTransaknya.dblVisite = fetch.visite;
                    itemTransaknya.dblOperasi = fetch.operasi;
                    itemTransaknya.dblTindakan = fetch.tindakan;
                    itemTransaknya.dblDiagelect = fetch.diagelect;
                    itemTransaknya.dblPemRK = fetch.pemrk;

                    grpTransaknya.Add(itemTransaknya);


                }

            }

            



            if (grpKelTarip.Count > 0)
            {

                var xsatu = (from x in grpKelTarip
                             where x.strIdBl_KelTarip.Substring(1, 1) == "1"
                             select x.strLapJP);

                var xdua = from x in grpKelTarip
                           where x.strIdBl_KelTarip.Substring(1, 1) == "2"
                           select x.strLapJP;

                var xtiga = from x in grpKelTarip
                            where x.strIdBl_KelTarip.Substring(1, 1) == "3"
                            select x.strLapJP;

                var xempat = from x in grpKelTarip
                             where x.strIdBl_KelTarip.Substring(1, 1) == "4"
                             select x.strLapJP;

                var xlima = from x in grpKelTarip
                            where x.strIdBl_KelTarip.Substring(1, 1) == "5"
                            select x.strLapJP;

                var xenam = from x in grpKelTarip
                            where x.strIdBl_KelTarip.Substring(1, 1) == "6"
                            select x.strLapJP;


            }


            //conn.Close();

            lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Text = "Proses Load - SELESAI");
            dtpFilterTgl1.SafeControlInvoke(DateTimePicker => dtpFilterTgl1.Enabled = false);
            dtpFilterTgl2.SafeControlInvoke(DateTimePicker => dtpFilterTgl2.Enabled = false);
            cmbJenisLaporan.SafeControlInvoke(ComboBox => cmbJenisLaporan.Enabled = true);
            cmbUnit.SafeControlInvoke(ComboBox => cmbUnit.Enabled = true);
            btnCari.SafeControlInvoke(Button => btnCari.Enabled = true);
            btnCari.SafeControlInvoke(Button => btnCari.Text = "Pilih Tanggal");
            cmbJenisLaporan.SafeControlInvoke(ComboBox => cmbJenisLaporan.Focus());
            cmbPilihanExport.SafeControlInvoke(ComboBox => cmbPilihanExport.Enabled = true);
            btnExport.SafeControlInvoke(Button => btnExport.Enabled = true);
            btnTampilkan.SafeControlInvoke(Button => btnTampilkan.Enabled = true);
        }

        private void LaporanJasaPelayanan_Load(object sender, EventArgs e)
        {

        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            if (dtpFilterTgl1.Enabled)
            {
                tmrBlink.Enabled = true;
                tmrBlink.Start();
                this.bgWorkLoadFromDB.RunWorkerAsync();
            }
            else
            {
                dtpFilterTgl1.Enabled = true;
                dtpFilterTgl2.Enabled = true;
                btnCari.Text = "&Proses";

                cmbJenisLaporan.Enabled = false;
                cmbUnit.Enabled = false;
                btnTampilkan.Enabled = false;
                cmbPilihanExport.Enabled = false;
                btnExport.Enabled = false;

            }
        }

        private void cmbJenisLaporan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (cmbJenisLaporan.Text.Trim().ToString() != "")
                {
                    if (cmbJenisLaporan.Text.Substring(1, 1) != "1")
                    {
                        var query = (from x in grpTransak
                                     select x.strUnit).Distinct();
                        cmbUnit.Items.Clear();
                        foreach (var fetch in query)
                        {
                            cmbUnit.Items.Add(fetch);
                        }
                    } /* EOF if (cmbJenisLaporan.Text.Substring(1, 1) != "1") */
                    else
                    {
                        cmbUnit.Enabled = false;

                        var KasumJP = (from x in grpTransak
                                       group x by new
                                       {
                                           x.strUnit
                                       } into groupData
                                       select new
                                       {
                                           groupData.Key.strUnit,
                                           konsul = groupData.Sum(x => x.dblKonsul),
                                           visite = groupData.Sum(x => x.dblVisite),
                                           operasi = groupData.Sum(x => x.dblOperasi),
                                           tindakan = groupData.Sum(x => x.dblTindakan),
                                           diagelect = groupData.Sum(x => x.dblDiagelect),
                                           pemrk = groupData.Sum(x => x.dblPemRK)
                                       });


                        if (KasumJP.Count() > 0)
                        {
                            foreach (var fetch in KasumJP)
                            {
                                lstTind itemTind = new lstTind();
                                itemTind.strUnit = fetch.strUnit;
                                itemTind.dblKonsul = fetch.konsul;
                                itemTind.dblVisite = fetch.visite;
                                itemTind.dblOperasi = fetch.operasi;
                                itemTind.dblTindakan = fetch.tindakan;
                                itemTind.dblDiagelect = fetch.diagelect;
                                itemTind.dblPemRK = fetch.pemrk;
                                grpTind.Add(itemTind);
                            }
                        }




                    } /* EOF else if (cmbJenisLaporan.Text.Substring(1, 1) != "1") */

                }

            }
        }

        private void dtpFilterTgl2_KeyPress(object sender, KeyPressEventArgs e)
        {           
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (var dialog = new System.Windows.Forms.SaveFileDialog())
            {
                dialog.Title = "Pilih Lokasi Export File";
                dialog.DefaultExt = "*.xlsx";
                dialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    strNamaFile = dialog.FileName;
                    // Save here
                }
            }

            if (strNamaFile.Trim().ToString() != "")
            {
                tmrBlink.Enabled = true;
                tmrBlink.Start();
                this.bgWorkExport.RunWorkerAsync();
            }
        }

        private void bgWorkExport_DoWork(object sender, DoWorkEventArgs e)
        {
            lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Text = "Proses Export");
            btnCari.SafeControlInvoke(Button => btnCari.Enabled = false);
            btnExport.SafeControlInvoke(Button => btnExport.Enabled = false);

            string strPilihanExport = "";
            cmbPilihanExport.SafeControlInvoke(ComboBox => strPilihanExport = cmbPilihanExport.Text);

            if (strPilihanExport.Trim().ToString() != "")
            {
                /*MEMULAI FETCHING TRANSAK*/
                FileInfo newFile = new FileInfo(strNamaFile);
                if (newFile.Exists)
                {
                    newFile.Delete();  // ensures we create a new workbook
                    newFile = new FileInfo(strNamaFile);
                }

                /* EXPORT REKAP*/
                if (strPilihanExport.Substring(0, 1) == "1")
                {
                    if (grpTransaknya.Count > 0)
                    {
                        using (ExcelPackage package = new ExcelPackage(newFile))
                        {
                            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(strPilihanExport);

                            //Add the headers
                            worksheet.Cells[1, 1].Value = "RegBilling";
                            worksheet.Cells[1, 2].Value = "Nama";
                            worksheet.Cells[1, 3].Value = "Ruangan";
                            worksheet.Cells[1, 4].Value = "Unit";
                            worksheet.Cells[1, 5].Value = "Konsul";
                            worksheet.Cells[1, 6].Value = "Visite";
                            worksheet.Cells[1, 7].Value = "Operasi";
                            worksheet.Cells[1, 8].Value = "Tindakan";
                            worksheet.Cells[1, 9].Value = "Diagelect";
                            worksheet.Cells[1, 10].Value = "PemRK";


                            int intStartRow = 2;

                            foreach (var fetchTransak in grpTransaknya)
                            {
                                lblInfoPencarian.SafeControlInvoke(
                                    Label => lblInfoPencarian.Text = "Proses Export " + 
                                        cmbPilihanExport.Text + " " + intStartRow.ToString() + " Baris");
                                worksheet.Cells[intStartRow, 1].Value = fetchTransak.strRegBilling;
                                worksheet.Cells[intStartRow, 2].Value = fetchTransak.strNama;
                                worksheet.Cells[intStartRow, 3].Value = fetchTransak.strRuangan;
                                worksheet.Cells[intStartRow, 4].Value = fetchTransak.strUnit;
                                worksheet.Cells[intStartRow, 5].Value = fetchTransak.dblKonsul;
                                worksheet.Cells[intStartRow, 6].Value = fetchTransak.dblVisite;
                                worksheet.Cells[intStartRow, 7].Value = fetchTransak.dblOperasi;
                                worksheet.Cells[intStartRow, 8].Value = fetchTransak.dblTindakan;
                                worksheet.Cells[intStartRow, 9].Value = fetchTransak.dblDiagelect;
                                worksheet.Cells[intStartRow, 10].Value = fetchTransak.dblPemRK;
                                intStartRow++;
                            }

                            lblInfoPencarian.SafeControlInvoke(
                                    Label => lblInfoPencarian.Text = "Proses Simpan Ke File " + strNamaFile);
                            package.Save();

                        }
                       

                    }
                    else
                    {
                        MessageBox.Show("Data tidak ada", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                } else if (strPilihanExport.Substring(0, 1) == "2")
                {
                    if (grpLstKASUM.Count > 0)
                    {

                        //var OrderKASUM = from x in grpLstKASUM
                        //                 orderby x.strRegBilling
                        //                 select x;

                        using (ExcelPackage package = new ExcelPackage(newFile))
                        {
                            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(strPilihanExport);

                            /*
                             *  public string strRegBilling { get; set; }
                                public string strNama { get; set; }
                                public string strRuangan { get; set; }
                                public double dblJumlah { get; set; }
                                public double dblSubsidi { get; set; }
                                public double dblTunai { get; set; }
                                public string strIdBl_Komponen { get; set; }
                                public double dblNilai { get; set; }
                                public double dblRingan { get; set; }
                                public double dblUrutan { get; set; }
                                public string strRekapJp { get; set; }
                                public double dblTunainya { get; set; }
                                public double dblNoAmbil { get; set; }
                                public DateTime dtTglAmbil { get; set; }
                                public string strIdBl_KelTarip { get; set; }
                                public string strLapJP { get; set; }
                                public string strIdMR_TSMF { get; set; }
                                public string strIdMR_TUPF { get; set; }
                                public string strIdBl_Tarip { get; set; }
                                public string strUraianTarip { get; set; }
                                public double dblJumlahKasusTarip { get; set; }
                                public string strIdBl_Transaksi { get; set; }
                                public string strIdBl_Pembayaran { get; set; }
                                public DateTime dtTglTransaksi { get; set; }
                                public DateTime dtTgl { get; set; }
                                public string strIdMR_JenisKelas { get; set; }
                                public string strIdMR_Ruangan { get; set; }
                                public string strIdMR_Dokter { get; set; }
                                public string strNamaDokter { get; set; }
                             */

                            //Add the headers
                            /*
                             * ASLI
                            worksheet.Cells[1, 1].Value = "RegBilling";
                            worksheet.Cells[1, 2].Value = "Nama";
                            worksheet.Cells[1, 3].Value = "Ruangan";
                            worksheet.Cells[1, 4].Value = "Jumlah";
                            worksheet.Cells[1, 5].Value = "Subsidi";
                            worksheet.Cells[1, 6].Value = "Tunai";
                            worksheet.Cells[1, 7].Value = "Komponen";
                            worksheet.Cells[1, 8].Value = "Nilai";
                            worksheet.Cells[1, 9].Value = "Ringan";
                            worksheet.Cells[1, 10].Value = "Urutan";
                            worksheet.Cells[1, 11].Value = "Rekap JP";
                            worksheet.Cells[1, 12].Value = "Tunainya";
                            worksheet.Cells[1, 13].Value = "No Ambil";
                            worksheet.Cells[1, 14].Value = "Tgl Ambil";
                            worksheet.Cells[1, 15].Value = "Kel Tarip";
                            worksheet.Cells[1, 16].Value = "Lap JP";
                            worksheet.Cells[1, 17].Value = "SMF";
                            worksheet.Cells[1, 18].Value = "UPF";
                            worksheet.Cells[1, 19].Value = "Tarip";
                            worksheet.Cells[1, 20].Value = "Uraian Tarip";
                            worksheet.Cells[1, 21].Value = "Jumlah Kasus Tarip";
                            worksheet.Cells[1, 22].Value = "Id Transaksi";
                            worksheet.Cells[1, 23].Value = "Id Pembayaran";
                            worksheet.Cells[1, 24].Value = "Tgl Transaksi";
                            worksheet.Cells[1, 25].Value = "Tanggal";
                            worksheet.Cells[1, 26].Value = "Jenis Kelas";
                            worksheet.Cells[1, 27].Value = "Ruangan";
                            worksheet.Cells[1, 28].Value = "Id Dokter";
                            worksheet.Cells[1, 29].Value = "Nama Dokter";
                            */

                            int intKolom = 1;
                            worksheet.Cells[1, intKolom].Value = "Nama";                //1
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "RegBilling";          //2
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Tanggal";             //3
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Ruangan";             //4
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Kel Tarip";           //5
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Uraian Tarip";        //6
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "SMF";                 //8
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Komponen";            //7                            
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Tunainya";            //9                            
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Jenis Kelas";         //10
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "idmr_ruangan";        //11
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "idmr_dokter";         //12
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Nama Dokter";         //13

                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Subsidi";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Tunai";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Jumlah";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Nilai";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Ringan";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Urutan";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Rekap JP";                           
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "No Ambil";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Tgl Ambil";                            
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Lap JP";
                           
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "UPF";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Tarip";                           
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Jumlah Kasus Tarip";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Id Transaksi";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Id Pembayaran";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Tgl Transaksi";
                           
                           

                            int intStartRow = 2;

                            foreach (var fetch in grpLstKASUM)
                            {

                                lblInfoPencarian.SafeControlInvoke(
                                    Label => lblInfoPencarian.Text = "Proses Export " +
                                        cmbPilihanExport.Text + " " + intStartRow.ToString() + " Baris");
                                /*
                                worksheet.Cells[intStartRow, 1].Value = fetch.strRegBilling;
                                worksheet.Cells[intStartRow, 2].Value = fetch.strNama;
                                worksheet.Cells[intStartRow, 3].Value = fetch.strRuangan;
                                worksheet.Cells[intStartRow, 4].Value = fetch.dblJumlah;                               
                                worksheet.Cells[intStartRow, 5].Value = fetch.dblSubsidi;
                                worksheet.Cells[intStartRow, 6].Value = fetch.dblTunai;
                                worksheet.Cells[intStartRow, 7].Value = fetch.strIdBl_Komponen;
                                worksheet.Cells[intStartRow, 8].Value = fetch.dblNilai;
                                worksheet.Cells[intStartRow, 9].Value = fetch.dblRingan;
                                worksheet.Cells[intStartRow, 10].Value = fetch.dblUrutan;
                                worksheet.Cells[intStartRow, 11].Value = fetch.strRekapJp;
                                worksheet.Cells[intStartRow, 12].Value = fetch.dblTunainya;
                                worksheet.Cells[intStartRow, 13].Value = fetch.dblNoAmbil;
                                worksheet.Cells[intStartRow, 14].Value = fetch.dtTglAmbil.ToString("dd-MMM-yyyy HH:mm:ss");
                                worksheet.Cells[intStartRow, 15].Value = fetch.strIdBl_KelTarip;
                                worksheet.Cells[intStartRow, 16].Value = fetch.strLapJP;
                                worksheet.Cells[intStartRow, 17].Value = fetch.strIdMR_TSMF;
                                worksheet.Cells[intStartRow, 18].Value = fetch.strIdMR_TUPF;
                                worksheet.Cells[intStartRow, 19].Value = fetch.strIdBl_Tarip;
                                worksheet.Cells[intStartRow, 20].Value = fetch.strUraianTarip;
                                worksheet.Cells[intStartRow, 21].Value = fetch.dblJumlahKasusTarip;
                                worksheet.Cells[intStartRow, 22].Value = fetch.strIdBl_Transaksi;
                                worksheet.Cells[intStartRow, 23].Value = fetch.strIdBl_Pembayaran;
                                worksheet.Cells[intStartRow, 24].Value = fetch.dtTglTransaksi.ToString("dd-MMM-yyyy HH:mm:ss");
                                worksheet.Cells[intStartRow, 25].Value = fetch.dtTgl.ToString("dd-MMM-yyyy HH:mm:ss");
                                worksheet.Cells[intStartRow, 26].Value = fetch.strIdMR_JenisKelas;
                                worksheet.Cells[intStartRow, 27].Value = fetch.strIdMR_Ruangan;
                                worksheet.Cells[intStartRow, 28].Value = fetch.strIdMR_Dokter;
                                worksheet.Cells[intStartRow, 29].Value = fetch.strNamaDokter;
                                */

                                intKolom = 1;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strNama;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strRegBilling;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.dtTglTransaksi.ToString("dd-MMM-yyyy HH:mm:ss");
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strRuangan;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strIdBl_KelTarip;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strUraianTarip;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strIdMR_TSMF;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strIdBl_Komponen;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.dblTunainya;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strIdMR_JenisKelas;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strIdMR_Ruangan;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strIdMR_Dokter;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strNamaDokter;

                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.dblSubsidi;                                                                
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.dblTunai;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.dblJumlah;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.dblNilai;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.dblRingan;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.dblUrutan;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strRekapJp;                              
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.dblNoAmbil;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.dtTglAmbil.ToString("dd-MMM-yyyy HH:mm:ss");                               
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strLapJP;                               
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strIdMR_TUPF;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strIdBl_Tarip;                               
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.dblJumlahKasusTarip;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strIdBl_Transaksi;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strIdBl_Pembayaran;                                
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.dtTgl.ToString("dd-MMM-yyyy HH:mm:ss");
                                


                                intStartRow++;
                            }

                            lblInfoPencarian.SafeControlInvoke(
                                    Label => lblInfoPencarian.Text = "Proses Simpan Ke File " + strNamaFile);
                            package.Save();

                        }
                    }
                    else
                    {
                        MessageBox.Show("Data tidak ada", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                //else if (strPilihanExport.Substring(0, 1) == "3")
                //{
                //    //if (grpLstKASASKIN.Count > 0)
                //    //{
                //    //    using (ExcelPackage package = new ExcelPackage(newFile))
                //    //    {
                //    //        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(strPilihanExport);                           

                //    //        //Add the headers
                //    //        worksheet.Cells[1, 1].Value = "RegBilling";
                //    //        worksheet.Cells[1, 2].Value = "Nama";
                //    //        worksheet.Cells[1, 3].Value = "Ruangan";
                //    //        worksheet.Cells[1, 4].Value = "Jumlah";
                //    //        worksheet.Cells[1, 5].Value = "Subsidi";
                //    //        worksheet.Cells[1, 6].Value = "Tunai";
                //    //        worksheet.Cells[1, 7].Value = "Komponen";
                //    //        worksheet.Cells[1, 8].Value = "Nilai";
                //    //        worksheet.Cells[1, 9].Value = "Ringan";
                //    //        worksheet.Cells[1, 10].Value = "Urutan";
                //    //        worksheet.Cells[1, 11].Value = "Rekap JP";
                //    //        worksheet.Cells[1, 12].Value = "Tunainya";
                //    //        worksheet.Cells[1, 13].Value = "No Ambil";
                //    //        worksheet.Cells[1, 14].Value = "Tgl Ambil";
                //    //        worksheet.Cells[1, 15].Value = "Kel Tarip";
                //    //        worksheet.Cells[1, 16].Value = "Lap JP";
                //    //        worksheet.Cells[1, 17].Value = "SMF";
                //    //        worksheet.Cells[1, 18].Value = "UPF";
                //    //        worksheet.Cells[1, 19].Value = "Tarip";
                //    //        worksheet.Cells[1, 20].Value = "Uraian Tarip";
                //    //        worksheet.Cells[1, 21].Value = "Jumlah Kasus Tarip";
                //    //        worksheet.Cells[1, 22].Value = "Id Transaksi";
                //    //        worksheet.Cells[1, 23].Value = "Id Pembayaran";
                //    //        worksheet.Cells[1, 24].Value = "Tgl Transaksi";
                //    //        worksheet.Cells[1, 25].Value = "Tanggal";
                //    //        worksheet.Cells[1, 26].Value = "Jenis Kelas";
                //    //        worksheet.Cells[1, 27].Value = "Ruangan";
                //    //        worksheet.Cells[1, 28].Value = "Id Dokter";
                //    //        worksheet.Cells[1, 29].Value = "Nama Dokter";

                //    //        int intStartRow = 2;

                //    //        foreach (var fetch in grpLstKASASKIN)
                //    //        {

                //    //            lblInfoPencarian.SafeControlInvoke(
                //    //                Label => lblInfoPencarian.Text = "Proses Export " +
                //    //                    cmbPilihanExport.Text + " " + intStartRow.ToString() + " Baris");

                //    //            worksheet.Cells[intStartRow, 1].Value = fetch.strRegBilling;
                //    //            worksheet.Cells[intStartRow, 2].Value = fetch.strNama;
                //    //            worksheet.Cells[intStartRow, 3].Value = fetch.strRuangan;
                //    //            worksheet.Cells[intStartRow, 4].Value = fetch.dblJumlah;
                //    //            worksheet.Cells[intStartRow, 5].Value = fetch.dblSubsidi;
                //    //            worksheet.Cells[intStartRow, 6].Value = fetch.dblTunai;
                //    //            worksheet.Cells[intStartRow, 7].Value = fetch.strIdBl_Komponen;
                //    //            worksheet.Cells[intStartRow, 8].Value = fetch.dblNilai;
                //    //            worksheet.Cells[intStartRow, 9].Value = fetch.dblRingan;
                //    //            worksheet.Cells[intStartRow, 10].Value = fetch.dblUrutan;
                //    //            worksheet.Cells[intStartRow, 11].Value = fetch.strRekapJp;
                //    //            worksheet.Cells[intStartRow, 12].Value = fetch.dblTunainya;
                //    //            worksheet.Cells[intStartRow, 13].Value = fetch.dblNoAmbil;
                //    //            worksheet.Cells[intStartRow, 14].Value = fetch.dtTglAmbil.ToString("dd/MM/yyyy");
                //    //            worksheet.Cells[intStartRow, 15].Value = fetch.strIdBl_KelTarip;
                //    //            worksheet.Cells[intStartRow, 16].Value = fetch.strLapJP;
                //    //            worksheet.Cells[intStartRow, 17].Value = fetch.strIdMR_TSMF;
                //    //            worksheet.Cells[intStartRow, 18].Value = fetch.strIdMR_TUPF;
                //    //            worksheet.Cells[intStartRow, 19].Value = fetch.strIdBl_Tarip;
                //    //            worksheet.Cells[intStartRow, 20].Value = fetch.strUraianTarip;
                //    //            worksheet.Cells[intStartRow, 21].Value = fetch.dblJumlahKasusTarip;
                //    //            worksheet.Cells[intStartRow, 22].Value = fetch.strIdBl_Transaksi;
                //    //            worksheet.Cells[intStartRow, 23].Value = fetch.strIdBl_Pembayaran;
                //    //            worksheet.Cells[intStartRow, 24].Value = fetch.dtTglTransaksi.ToString("dd/MM/yyyy");
                //    //            worksheet.Cells[intStartRow, 25].Value = fetch.dtTgl.ToString("dd/MM/yyyy");
                //    //            worksheet.Cells[intStartRow, 26].Value = fetch.strIdMR_JenisKelas;
                //    //            worksheet.Cells[intStartRow, 27].Value = fetch.strRuangan;
                //    //            worksheet.Cells[intStartRow, 28].Value = fetch.strIdMR_Dokter;
                //    //            worksheet.Cells[intStartRow, 29].Value = fetch.strNamaDokter;

                //    //            intStartRow++;
                //    //        }

                //    //        lblInfoPencarian.SafeControlInvoke(
                //    //                Label => lblInfoPencarian.Text = "Proses Simpan Ke File " + strNamaFile);
                //    //        package.Save();

                //    //    }
                //    //}
                //    //else
                //    //{
                //    //    MessageBox.Show("Data tidak ada", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    //}
            
                //}  /* EOF else if (strPilihanExport.Substring(0, 1) == "3") */
                else if (strPilihanExport.Substring(0, 1) == "3")
                {
                    if (grpLstKASJKM.Count > 0)
                    {
                        using (ExcelPackage package = new ExcelPackage(newFile))
                        {
                            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(strPilihanExport);

                            //Add the headers
                            /*
                             * ASLI
                            worksheet.Cells[1, 1].Value = "RegBilling";
                            worksheet.Cells[1, 2].Value = "Nama";
                            worksheet.Cells[1, 3].Value = "Ruangan";
                            worksheet.Cells[1, 4].Value = "Jumlah";
                            worksheet.Cells[1, 5].Value = "Subsidi";
                            worksheet.Cells[1, 6].Value = "Tunai";
                            worksheet.Cells[1, 7].Value = "Komponen";
                            worksheet.Cells[1, 8].Value = "Nilai";
                            worksheet.Cells[1, 9].Value = "Ringan";
                            worksheet.Cells[1, 10].Value = "Urutan";
                            worksheet.Cells[1, 11].Value = "Rekap JP";
                            worksheet.Cells[1, 12].Value = "Tunainya";
                            worksheet.Cells[1, 13].Value = "No Ambil";
                            worksheet.Cells[1, 14].Value = "Tgl Ambil";
                            worksheet.Cells[1, 15].Value = "Kel Tarip";
                            worksheet.Cells[1, 16].Value = "Lap JP";
                            worksheet.Cells[1, 17].Value = "SMF";
                            worksheet.Cells[1, 18].Value = "UPF";
                            worksheet.Cells[1, 19].Value = "Tarip";
                            worksheet.Cells[1, 20].Value = "Uraian Tarip";
                            worksheet.Cells[1, 21].Value = "Jumlah Kasus Tarip";
                            worksheet.Cells[1, 22].Value = "Id Transaksi";
                            worksheet.Cells[1, 23].Value = "Id Pembayaran";
                            worksheet.Cells[1, 24].Value = "Tgl Transaksi";
                            worksheet.Cells[1, 25].Value = "Tanggal";
                            worksheet.Cells[1, 26].Value = "Jenis Kelas";
                            worksheet.Cells[1, 27].Value = "idmr_ruangan";
                            worksheet.Cells[1, 28].Value = "idmr_dokter";
                            worksheet.Cells[1, 29].Value = "Nama Dokter";
                             */

                            int intKolom = 1;
                            worksheet.Cells[1, intKolom].Value = "Nama";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "RegBilling";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Tanggal";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Ruangan";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Kel Tarip";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Uraian Tarip";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "SMF";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Komponen";                            
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Tunainya";                            
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Jenis Kelas";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "idmr_ruangan";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "idmr_dokter";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Nama Dokter";

                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Subsidi";                                                        
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Tunai";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Jumlah";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Nilai";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Ringan";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Urutan";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Rekap JP";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "No Ambil";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Tgl Ambil";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Lap JP";

                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "UPF";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Tarip";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Jumlah Kasus Tarip";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Id Transaksi";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Id Pembayaran";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Tgl Transaksi";

                            int intStartRow = 2;

                            foreach (var fetch in grpLstKASJKM)
                            {

                                lblInfoPencarian.SafeControlInvoke(
                                    Label => lblInfoPencarian.Text = "Proses Export " +
                                        cmbPilihanExport.Text + " " + intStartRow.ToString() + " Baris");

                                /*
                                worksheet.Cells[intStartRow, 1].Value = fetch.strRegBilling;
                                worksheet.Cells[intStartRow, 2].Value = fetch.strNama;
                                worksheet.Cells[intStartRow, 3].Value = fetch.strRuangan;
                                worksheet.Cells[intStartRow, 4].Value = fetch.dblJumlah;
                                worksheet.Cells[intStartRow, 5].Value = fetch.dblSubsidi;
                                worksheet.Cells[intStartRow, 6].Value = fetch.dblTunai;
                                worksheet.Cells[intStartRow, 7].Value = fetch.strIdBl_Komponen;
                                worksheet.Cells[intStartRow, 8].Value = fetch.dblNilai.ToString();
                                worksheet.Cells[intStartRow, 9].Value = fetch.dblRingan;
                                worksheet.Cells[intStartRow, 10].Value = fetch.dblUrutan;
                                worksheet.Cells[intStartRow, 11].Value = fetch.strRekapJp;
                                worksheet.Cells[intStartRow, 12].Value = fetch.dblTunainya;
                                worksheet.Cells[intStartRow, 13].Value = fetch.dblNoAmbil;
                                worksheet.Cells[intStartRow, 14].Value = fetch.dtTglAmbil.ToString("dd/MM/yyyy");
                                worksheet.Cells[intStartRow, 15].Value = fetch.strIdBl_KelTarip;
                                worksheet.Cells[intStartRow, 16].Value = fetch.strLapJP;
                                worksheet.Cells[intStartRow, 17].Value = fetch.strIdMR_TSMF;
                                worksheet.Cells[intStartRow, 18].Value = fetch.strIdMR_TUPF;
                                worksheet.Cells[intStartRow, 19].Value = fetch.strIdBl_Tarip;
                                worksheet.Cells[intStartRow, 20].Value = fetch.strUraianTarip;
                                worksheet.Cells[intStartRow, 21].Value = fetch.dblJumlahKasusTarip;
                                worksheet.Cells[intStartRow, 22].Value = fetch.strIdBl_Transaksi;
                                worksheet.Cells[intStartRow, 23].Value = fetch.strIdBl_Pembayaran;
                                worksheet.Cells[intStartRow, 24].Value = fetch.dtTglTransaksi.ToString("dd/MM/yyyy");
                                worksheet.Cells[intStartRow, 25].Value = fetch.dtTgl.ToString("dd/MM/yyyy");
                                worksheet.Cells[intStartRow, 26].Value = fetch.strIdMR_JenisKelas;
                                worksheet.Cells[intStartRow, 27].Value = fetch.strIdMR_Ruangan;
                                worksheet.Cells[intStartRow, 28].Value = fetch.strIdMR_Dokter;
                                worksheet.Cells[intStartRow, 29].Value = fetch.strNamaDokter;
                                 */

                                intKolom = 1;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strNama;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strRegBilling;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.dtTglTransaksi.ToString("dd-MMM-yyyy HH:mm:ss");
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strRuangan;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strIdBl_KelTarip;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strUraianTarip;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strIdMR_TSMF;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strIdBl_Komponen;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.dblTunainya;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strIdMR_JenisKelas;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strIdMR_Ruangan;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strIdMR_Dokter;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strNamaDokter;

                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.dblSubsidi;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.dblTunai;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.dblJumlah;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.dblNilai;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.dblRingan;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.dblUrutan;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strRekapJp;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.dblNoAmbil;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.dtTglAmbil.ToString("dd-MMM-yyyy HH:mm:ss");
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strLapJP;

                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strIdMR_TUPF;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strIdBl_Tarip;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.dblJumlahKasusTarip;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strIdBl_Transaksi;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strIdBl_Pembayaran;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.dtTgl.ToString("dd-MMM-yyyy HH:mm:ss");


                                intStartRow++;
                            }

                            lblInfoPencarian.SafeControlInvoke(
                                    Label => lblInfoPencarian.Text = "Proses Simpan Ke File " + strNamaFile);
                            package.Save();

                        }

                    }
                    else
                    {
                        MessageBox.Show("Data tidak ada", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }  /* EOF else if (strPilihanExport.Substring(0, 1) == "4") */
                else if (strPilihanExport.Substring(0, 1) == "4")
                {
                    if (grpLstKASJKD.Count > 0)
                    {
                        using (ExcelPackage package = new ExcelPackage(newFile))
                        {
                            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(strPilihanExport);

                            //Add the headers
                            /*
                            worksheet.Cells[1, 1].Value = "RegBilling";
                            worksheet.Cells[1, 2].Value = "Nama";
                            worksheet.Cells[1, 3].Value = "Ruangan";
                            worksheet.Cells[1, 4].Value = "Jumlah";
                            worksheet.Cells[1, 5].Value = "Subsidi";
                            worksheet.Cells[1, 6].Value = "Tunai";
                            worksheet.Cells[1, 7].Value = "Komponen";
                            worksheet.Cells[1, 8].Value = "Nilai";
                            worksheet.Cells[1, 9].Value = "Ringan";
                            worksheet.Cells[1, 10].Value = "Urutan";
                            worksheet.Cells[1, 11].Value = "Rekap JP";
                            worksheet.Cells[1, 12].Value = "Tunainya";
                            worksheet.Cells[1, 13].Value = "No Ambil";
                            worksheet.Cells[1, 14].Value = "Tgl Ambil";
                            worksheet.Cells[1, 15].Value = "Kel Tarip";
                            worksheet.Cells[1, 16].Value = "Lap JP";
                            worksheet.Cells[1, 17].Value = "SMF";
                            worksheet.Cells[1, 18].Value = "UPF";
                            worksheet.Cells[1, 19].Value = "Tarip";
                            worksheet.Cells[1, 20].Value = "Uraian Tarip";
                            worksheet.Cells[1, 21].Value = "Jumlah Kasus Tarip";
                            worksheet.Cells[1, 22].Value = "Id Transaksi";
                            worksheet.Cells[1, 23].Value = "Id Pembayaran";
                            worksheet.Cells[1, 24].Value = "Tgl Transaksi";
                            worksheet.Cells[1, 25].Value = "Tanggal";
                            worksheet.Cells[1, 26].Value = "Jenis Kelas";
                            worksheet.Cells[1, 27].Value = "idmr_ruangan";
                            worksheet.Cells[1, 28].Value = "idmr_dokter";
                            worksheet.Cells[1, 29].Value = "Nama Dokter";
                             */

                            int intKolom = 1;
                            worksheet.Cells[1, intKolom].Value = "Nama";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "RegBilling";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Tanggal";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Ruangan";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Kel Tarip";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Uraian Tarip";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "SMF";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Komponen";                            
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Tunainya";                            
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Jenis Kelas";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "idmr_ruangan";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "idmr_dokter";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Nama Dokter";

                            
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Subsidi";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Tunai";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Jumlah";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Nilai";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Ringan";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Urutan";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Rekap JP";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "No Ambil";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Tgl Ambil";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Lap JP";

                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "UPF";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Tarip";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Jumlah Kasus Tarip";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Id Transaksi";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Id Pembayaran";
                            intKolom++;
                            worksheet.Cells[1, intKolom].Value = "Tgl Transaksi";

                            int intStartRow = 2;

                            foreach (var fetch in grpLstKASJKD)
                            {

                                lblInfoPencarian.SafeControlInvoke(
                                    Label => lblInfoPencarian.Text = "Proses Export " +
                                        cmbPilihanExport.Text + " " + intStartRow.ToString() + " Baris");

                                /*
                                worksheet.Cells[intStartRow, 1].Value = fetch.strRegBilling;
                                worksheet.Cells[intStartRow, 2].Value = fetch.strNama;
                                worksheet.Cells[intStartRow, 3].Value = fetch.strRuangan;
                                worksheet.Cells[intStartRow, 4].Value = fetch.dblJumlah;
                                worksheet.Cells[intStartRow, 5].Value = fetch.dblSubsidi;
                                worksheet.Cells[intStartRow, 6].Value = fetch.dblTunai;
                                worksheet.Cells[intStartRow, 7].Value = fetch.strIdBl_Komponen;
                                worksheet.Cells[intStartRow, 8].Value = fetch.dblNilai;
                                worksheet.Cells[intStartRow, 9].Value = fetch.dblRingan;
                                worksheet.Cells[intStartRow, 10].Value = fetch.dblUrutan;
                                worksheet.Cells[intStartRow, 11].Value = fetch.strRekapJp;
                                worksheet.Cells[intStartRow, 12].Value = fetch.dblTunainya;
                                worksheet.Cells[intStartRow, 13].Value = fetch.dblNoAmbil;
                                worksheet.Cells[intStartRow, 14].Value = fetch.dtTglAmbil.ToString("dd/MM/yyyy");
                                worksheet.Cells[intStartRow, 15].Value = fetch.strIdBl_KelTarip;
                                worksheet.Cells[intStartRow, 16].Value = fetch.strLapJP;
                                worksheet.Cells[intStartRow, 17].Value = fetch.strIdMR_TSMF;
                                worksheet.Cells[intStartRow, 18].Value = fetch.strIdMR_TUPF;
                                worksheet.Cells[intStartRow, 19].Value = fetch.strIdBl_Tarip;
                                worksheet.Cells[intStartRow, 20].Value = fetch.strUraianTarip;
                                worksheet.Cells[intStartRow, 21].Value = fetch.dblJumlahKasusTarip;
                                worksheet.Cells[intStartRow, 22].Value = fetch.strIdBl_Transaksi;
                                worksheet.Cells[intStartRow, 23].Value = fetch.strIdBl_Pembayaran;
                                worksheet.Cells[intStartRow, 24].Value = fetch.dtTglTransaksi.ToString("dd/MM/yyyy");
                                worksheet.Cells[intStartRow, 25].Value = fetch.dtTgl.ToString("dd/MM/yyyy");
                                worksheet.Cells[intStartRow, 26].Value = fetch.strIdMR_JenisKelas;
                                worksheet.Cells[intStartRow, 27].Value = fetch.strIdMR_Ruangan;
                                worksheet.Cells[intStartRow, 28].Value = fetch.strIdMR_Dokter;
                                worksheet.Cells[intStartRow, 29].Value = fetch.strNamaDokter;
                                */


                                intKolom = 1;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strNama;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strRegBilling;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.dtTglTransaksi.ToString("dd-MMM-yyyy HH:mm:ss");
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strRuangan;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strIdBl_KelTarip;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strUraianTarip;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strIdMR_TSMF;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strIdBl_Komponen;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.dblTunainya;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strIdMR_JenisKelas;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strIdMR_Ruangan;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strIdMR_Dokter;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strNamaDokter;

                                
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.dblSubsidi;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.dblTunai;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.dblJumlah;
                                intKolom++;                                
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.dblNilai;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.dblRingan;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.dblUrutan;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strRekapJp;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.dblNoAmbil;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.dtTglAmbil.ToString("dd-MMM-yyyy HH:mm:ss");
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strLapJP;

                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strIdMR_TUPF;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strIdBl_Tarip;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.dblJumlahKasusTarip;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strIdBl_Transaksi;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.strIdBl_Pembayaran;
                                intKolom++;
                                worksheet.Cells[intStartRow, intKolom].Value = fetch.dtTgl.ToString("dd-MMM-yyyy HH:mm:ss");


                                intStartRow++;
                            }

                            lblInfoPencarian.SafeControlInvoke(
                                    Label => lblInfoPencarian.Text = "Proses Simpan Ke File " + strNamaFile);
                            package.Save();

                        }

                    }
                    else
                    {
                        MessageBox.Show("Data tidak ada", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }  /* EOF else if (strPilihanExport.Substring(0, 1) == "5") */




            }
            else
            {
                MessageBox.Show("Anda harus memilih yang akan di export ?", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }




            btnCari.SafeControlInvoke(Button => btnCari.Enabled = true);
            btnExport.SafeControlInvoke(Button => btnExport.Enabled = true);
            lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Text = "Proses Export Selesai");
            
        }

        private void LaporanJasaPelayanan_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((bgWorkExport.IsBusy) || (bgWorkLoadFromDB.IsBusy))
            {
                MessageBox.Show("Masih ada proses, mohon tunggu sebentar", 
                                "Informasi", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Information);
                e.Cancel = true;
            }
        }

        private void tmrWaktuLoad_Tick(object sender, EventArgs e)
        {
            if (intPenandaProses == 1)
            {
                lblInfoPencarian.SafeControlInvoke(
                   Label => lblInfoPencarian.Text = "Proses Load - KASUM (" + intWaktuLoad.ToString() + " Detik )");
                //intWaktuLoad = 0;
            }
            else if (intPenandaProses == 2)
            {
                lblInfoPencarian.SafeControlInvoke(
                    Label => lblInfoPencarian.Text = "Proses Load - ASKESGAKIN (" + intWaktuLoad.ToString() + " Detik )");
                //intWaktuLoad = 0;
            }
            else if (intPenandaProses == 3)
            {
                lblInfoPencarian.SafeControlInvoke(
                    Label => lblInfoPencarian.Text = "Proses Load - ASKESJAMKESMAS (" + intWaktuLoad.ToString() + " Detik )");
                //intWaktuLoad = 0;
            }
            else if (intPenandaProses == 4)
            {
                lblInfoPencarian.SafeControlInvoke(
                    Label => lblInfoPencarian.Text = "Proses Load - ASKESJAMKESDA (" + intWaktuLoad.ToString() + " Detik )");
                //intWaktuLoad = 0;
            }
            intWaktuLoad++;
        }

        private void tmrBlink_Tick(object sender, EventArgs e)
        {
            if (lblInfoPencarian.ForeColor == Color.Black)
                lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.ForeColor = Color.Red);
            else
                lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.ForeColor = Color.Black);
        }

        private void btnTampilkan_Click(object sender, EventArgs e)
        {

        }

        private void cmbJenisLaporan_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbJenisLaporan.Text.Trim().ToString() == "1. REKAP")
            {
                var UnitGroup = (from x in grpTransaknya
                                 select x.strUnit).Distinct().OrderBy(a => a);

                cmbUnit.Items.Clear();
                foreach (var x in UnitGroup)
                {
                    cmbUnit.Items.Add(x);
                }                               

            }
            else
            {

            }
        }
    }
}
