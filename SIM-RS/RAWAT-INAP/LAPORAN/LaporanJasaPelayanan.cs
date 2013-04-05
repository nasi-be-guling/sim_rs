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
    public partial class LaporanJasaPelayanan : Form
    {

        C4Module.MainModule modMain = new C4Module.MainModule();
        C4Module.DatabaseModule modDb = new C4Module.DatabaseModule();
        C4Module.MessageModule modMsg = new C4Module.MessageModule();
        C4Module.SQLModule modSQL = new C4Module.SQLModule();

        /*LOCAL VARIABLE*/
        string strQuerySQL = "";
        string strErr = "";


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
            public double dblRekapJp { get; set; }
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

        public class lstKASASKIN
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
            public double dblRekapJp { get; set; }
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
            public double dblRekapJp { get; set; }
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
            public double dblRekapJp { get; set; }
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
        List<lstKASASKIN> grpLstKASASKIN = new List<lstKASASKIN>();
        List<lstKASJKM> grpLstKASJKM = new List<lstKASJKM>();
        List<lstKASJKD> grpLstKASJKD = new List<lstKASJKD>();

        public LaporanJasaPelayanan()
        {
            InitializeComponent();
        }    

        private void bgWorkLoadFromDB_DoWork(object sender, DoWorkEventArgs e)
        {

            this.strErr = "";
            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_CONN;


            SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                return;
            }


            /* QUERY KASUM */
            this.strQuerySQL = "SELECT "+
                                    "BL_TRANSAKSI_1.Regbilling, "+                                              //0
                                    "MR_PASIEN.Nama, "+                                                         //1
                                    "MR_TRUANGAN.ruangan, " +                                                   //2
                                    "BL_TRANSAKSI_1.Jumlah, "+                                                  //3
                                    "BL_TRANSAKSI_1.subsidi, "+                                                 //4
                                    "BL_TRANSAKSI_1.tunai, " +                                                  //5
                                    "BL_TRANSAKSIDETAIL_1.Idbl_komponen, "+                                     //6
                                    "BL_TRANSAKSIDETAIL_1.Nilai, "+                                             //7
                                    "BL_TRANSAKSIDETAIL_1.Ringan, "+                                            //8
                                    "BL_KELTARIP.urutan, "+                                                     //9
                                    "BL_KELTARIP.rekapjp,"+                                                     //10
                                    "BL_TRANSAKSIDETAIL_1.Nilai - BL_TRANSAKSIDETAIL_1.Ringan as tunainya , "+  //11
                                    "BL_TRANSAKSIDETAIL_1.Noambil, "+                                           //12
                                    "BL_TRANSAKSIDETAIL_1.tglambil, "+                                          //13
                                    "BL_KELTARIP.Idbl_keltarip, "+                                              //14
                                    "BL_KELTARIP.Lapjp, "+                                                      //15
                                    "BL_TRANSAKSI_1.idmr_tsmf, "+                                               //16
                                    "MR_SMFTARIP.idmr_tupf, "+                                                  //17
                                    "BL_TRANSAKSI_1.idbl_tarip, "+                                              //18
                                    "BL_TRANSAKSI_1.uraiantarip, "+                                             //19
                                    "BL_TRANSAKSI_1.jml_kasus_tarip, "+                                         //20
                                    "BL_TRANSAKSI_1.idbl_transaksi, "+                                          //21
                                    "BL_KASUMUM.Idbl_Pembayaran, "+                                             //22
                                    "BL_TRANSAKSI_1.Tgltransaksi, "+                                            //23
                                    "BL_KASUMUM.Tanggal, "+                                                     //24
                                    "BL_TARIP.Idmr_jeniskelas, "+                                               //25
                                    "BL_TRANSAKSI_1.Idmr_truangan, "+                                           //26
                                    "MR_DOKTER.Idmr_dokter, "+                                                  //27
                                    "MR_DOKTER.Nama "+                                                          //28
                               "FROM BL_KELTARIP  With (nolock) "+
                               "INNER JOIN BL_TRANSAKSI_1 "+
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
                               "INNER JOIN MR_DOKTER " +
                                    "ON MR_DOKTER.Idmr_dokter = BL_TRANSAKSI_1.Idmr_dokter " +
                               "WHERE (BL_TRANSAKSI_1.Batal <> 'Y') "+
                                    "AND (BL_KASUMUM.Batal = '') "+
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

            SqlDataReader reader = modDb.pbreaderSQL(conn, strQuerySQL, ref strErr);
            if (strErr != "")
            {
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
                    itemKASUM.dblRekapJp = Convert.ToDouble(modMain.pbstrgetCol(reader, 10, ref strErr, ""));
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


            /* QUERY ASKESGAKIN*/
            this.strQuerySQL = " SELECT  "+
                                    "BL_TRANSAKSI.Regbilling, "+                                            //0
                                    "MR_PASIEN.Nama, "+                                                     //1
                                    "MR_TRUANGAN.ruangan, "+                                                //2
                                    "BL_TRANSAKSI.Jumlah, "+                                                //3
                                    "BL_TRANSAKSI.subsidi, "+                                               //4
                                    "BL_TRANSAKSI.tunai, "+                                                 //5
                                    "BL_TRANSAKSIDETAIL.Idbl_komponen, "+                                   //6
                                    "BL_TRANSAKSIDETAIL.Nilai, "+                                           //7
                                    "BL_TRANSAKSIDETAIL.Ringan, "+                                          //8
                                    "BL_KELTARIP.urutan, "+                                                 //9
                                    "BL_KELTARIP.rekapjp,"+                                                 //10
                                    "BL_TRANSAKSIDETAIL.Nilai - BL_TRANSAKSIDETAIL.Ringan as tunainya , "+  //11
                                    "BL_TRANSAKSIDETAIL.Noambil, "+                                         //12
                                    "BL_TRANSAKSIDETAIL.tglambil, "+                                        //13
                                    "BL_KELTARIP.Idbl_keltarip, "+                                          //14
                                    "BL_KELTARIP.Lapjp, "+                                                  //15
                                    "BL_TRANSAKSI.idmr_tsmf, "+                                             //16
                                    "MR_SMFTARIP.idmr_tupf, "+                                              //17
                                    "BL_TRANSAKSI.idbl_tarip, "+                                            //18
                                    "BL_TRANSAKSI.uraiantarip, "+                                           //19
                                    "BL_TRANSAKSI.jml_kasus_tarip, "+                                       //20
                                    "BL_TRANSAKSI.idbl_transaksi, "+                                        //21
                                    "BL_KASASKES.Idbl_Pembayaran, "+                                        //22
                                    "BL_TRANSAKSI.Tgltransaksi, "+                                          //23
                                    "BL_KASASKES.Tanggal, "+                                                //24
                                    "BL_TARIP.Idmr_jeniskelas, "+                                           //25
                                    "BL_TRANSAKSI.Idmr_truangan, "+                                         //26
                                    "MR_DOKTER.Idmr_dokter, " +                                             //27
                                    "MR_DOKTER.Nama " +                                                     //28
                               " FROM BL_KELTARIP With (nolock)  "+
                               " INNER JOIN BL_TRANSAKSI "+
                               " INNER JOIN BL_TRANSAKSIDETAIL "+
                                    "ON BL_TRANSAKSI.idbl_transaksi = BL_TRANSAKSIDETAIL.Idbl_transaksi "+
                               " INNER JOIN BL_TARIP "+
                                    "ON BL_TRANSAKSI.idbl_tarip = BL_TARIP.IdBl_tarip "+
                                    "ON BL_KELTARIP.Idbl_keltarip = BL_TARIP.Idbl_keltarip "+
                               " INNER JOIN MR_SMFTARIP "+
                                    "ON BL_TRANSAKSI.idmr_tsmf = MR_SMFTARIP.idmr_tsmf "+
                               " INNER JOIN BL_KASASKES "+
                                    "ON BL_TRANSAKSI.idbl_pembayaran = BL_KASASKES.Idbl_Pembayaran "+
                                        "AND BL_TRANSAKSI.idmr_mutasipasien = BL_KASASKES.idmr_mutasipasien "+
                               " INNER JOIN MR_PASIEN "+
                                    "ON BL_KASASKES.Idmr_pasien = MR_PASIEN.IDMR_PASIEN "+
                               " INNER JOIN MR_TRUANGAN "+
                                    "ON BL_KASASKES.Idmr_truangan = MR_TRUANGAN.idmr_truangan "+
                               " INNER JOIN MR_SJASKES "+
                                    "ON BL_KASASKES.idmr_mutasipasien = MR_SJASKES.idmr_mutasipasien "+
                               "INNER JOIN MR_DOKTER " +
                                    "ON MR_DOKTER.Idmr_dokter = BL_TRANSAKSI_1.Idmr_dokter " +
                               " WHERE (BL_TRANSAKSI.Batal <> 'Y') "+
                                  " AND (BL_KASASKES.Batal = '') "+
                                  " AND (MR_SJASKES.BATAL = '') "+
                                  " AND MR_SJASKES.idmr_tstatus = 'ASKESGAKIN' "+
                                  " AND (BL_TRANSAKSIDETAIL.Idbl_komponen <> 'JASA SARANA') "+
                                  " AND BL_KASASKES.Tanggal BETWEEN '" + dtpFilterTgl1.Value.ToString("MM/dd/yyyy 00:00:00") + 
                                    "' and '" + dtpFilterTgl2.Value.ToString("MM/dd/yyyy 23:59:59") + "' "+
                                  " AND BL_TARIP.pisahsetor = '' AND BL_KASASKES.jumlah > 0 "+
                                  " AND BL_TRANSAKSIDETAIL.noambil <> 999 "+
                                  " AND BL_TRANSAKSI.idmr_tsmf <> 'DARAH' and BL_TRANSAKSI.idmr_tsmf <> 'PENDORONG'"+
                                  " AND BL_TRANSAKSI.idmr_tsmf <> 'OBAT/ALKES-FARMASI' "+
                                  " AND BL_TRANSAKSI.idmr_tsmf <> 'OBAT/ALKES-KPRI'"+
                                  " AND BL_TRANSAKSI.idbl_pembayaran > 0 AND BL_KELTARIP.Lapjp <> '-'";

            reader = modDb.pbreaderSQL(conn, strQuerySQL, ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_GET, modMsg.TITLE_ERR);
                conn.Close();
                return;
            }

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    lstKASASKIN itemKASASKIN = new lstKASASKIN();

                    itemKASASKIN.strRegBilling = modMain.pbstrgetCol(reader, 0, ref strErr, "");
                    itemKASASKIN.strNama = modMain.pbstrgetCol(reader, 1, ref strErr, "");
                    itemKASASKIN.strRuangan = modMain.pbstrgetCol(reader, 2, ref strErr, "");
                    itemKASASKIN.dblJumlah = Convert.ToDouble(modMain.pbstrgetCol(reader, 3, ref strErr, ""));
                    itemKASASKIN.dblSubsidi = Convert.ToDouble(modMain.pbstrgetCol(reader, 4, ref strErr, ""));
                    itemKASASKIN.dblTunai = Convert.ToDouble(modMain.pbstrgetCol(reader, 5, ref strErr, ""));
                    itemKASASKIN.strIdBl_Komponen = modMain.pbstrgetCol(reader, 6, ref strErr, "");
                    itemKASASKIN.dblNilai = Convert.ToDouble(modMain.pbstrgetCol(reader, 7, ref strErr, ""));
                    itemKASASKIN.dblRingan = Convert.ToDouble(modMain.pbstrgetCol(reader, 8, ref strErr, ""));
                    itemKASASKIN.dblUrutan = Convert.ToDouble(modMain.pbstrgetCol(reader, 9, ref strErr, ""));
                    itemKASASKIN.dblRekapJp = Convert.ToDouble(modMain.pbstrgetCol(reader, 10, ref strErr, ""));
                    itemKASASKIN.dblTunainya = Convert.ToDouble(modMain.pbstrgetCol(reader, 11, ref strErr, ""));
                    itemKASASKIN.dblNoAmbil = Convert.ToDouble(modMain.pbstrgetCol(reader, 12, ref strErr, ""));
                    itemKASASKIN.dtTglAmbil = Convert.ToDateTime(modMain.pbstrgetCol(reader, 13, ref strErr, ""));
                    itemKASASKIN.strIdBl_KelTarip = modMain.pbstrgetCol(reader, 14, ref strErr, "");
                    itemKASASKIN.strLapJP = modMain.pbstrgetCol(reader, 15, ref strErr, "");
                    itemKASASKIN.strIdMR_TSMF = modMain.pbstrgetCol(reader, 16, ref strErr, "");
                    itemKASASKIN.strIdMR_TUPF = modMain.pbstrgetCol(reader, 17, ref strErr, "");
                    itemKASASKIN.strIdBl_Tarip = modMain.pbstrgetCol(reader, 18, ref strErr, "");
                    itemKASASKIN.strUraianTarip = modMain.pbstrgetCol(reader, 19, ref strErr, "");
                    itemKASASKIN.dblJumlahKasusTarip = Convert.ToDouble(modMain.pbstrgetCol(reader, 20, ref strErr, ""));
                    itemKASASKIN.strIdBl_Transaksi = modMain.pbstrgetCol(reader, 21, ref strErr, "");
                    itemKASASKIN.strIdBl_Pembayaran = modMain.pbstrgetCol(reader, 22, ref strErr, "");
                    itemKASASKIN.dtTglTransaksi = Convert.ToDateTime(modMain.pbstrgetCol(reader, 23, ref strErr, ""));
                    itemKASASKIN.dtTgl = Convert.ToDateTime(modMain.pbstrgetCol(reader, 24, ref strErr, ""));
                    itemKASASKIN.strIdMR_JenisKelas = modMain.pbstrgetCol(reader, 25, ref strErr, "");
                    itemKASASKIN.strIdMR_Ruangan = modMain.pbstrgetCol(reader, 26, ref strErr, "");
                    itemKASASKIN.strIdMR_Dokter = modMain.pbstrgetCol(reader, 27, ref strErr, "");
                    itemKASASKIN.strNamaDokter = modMain.pbstrgetCol(reader, 28, ref strErr, "");

                    grpLstKASASKIN.Add(itemKASASKIN);
                }
            }

            reader.Close();

            /* QUERY ASKES JAMKESMAS*/
            this.strQuerySQL = "SELECT  "+
                                    "BL_TRANSAKSI.Regbilling, "+                                            //0
                                    "MR_PASIEN.Nama, "+                                                     //1
                                    "MR_TRUANGAN.ruangan, "+                                                //2
                                    "BL_TRANSAKSI.Jumlah, "+                                                //3
                                    "BL_TRANSAKSI.subsidi, "+                                               //4
                                    "BL_TRANSAKSI.tunai, "+                                                 //5
                                    "BL_TRANSAKSIDETAIL.Idbl_komponen, "+                                   //6
                                    "BL_TRANSAKSIDETAIL.Nilai, "+                                           //7
                                    "BL_TRANSAKSIDETAIL.Ringan, "+                                          //8
                                    "BL_KELTARIP.urutan, "+                                                 //9
                                    "BL_KELTARIP.rekapjp,"+                                                 //10
                                    "BL_TRANSAKSIDETAIL.Nilai - BL_TRANSAKSIDETAIL.Ringan as tunainya , "+  //11
                                    "BL_TRANSAKSIDETAIL.Noambil,"+                                          //12
                                    "BL_TRANSAKSIDETAIL.tglambil, "+                                        //13
                                    "BL_KELTARIP.Idbl_keltarip, "+                                          //14
                                    "BL_KELTARIP.Lapjp, "+                                                  //15
                                    "BL_TRANSAKSI.idmr_tsmf, "+                                             //16
                                    "MR_SMFTARIP.idmr_tupf, "+                                              //17
                                    "BL_TRANSAKSI.idbl_tarip, "+                                            //18
                                    "BL_TRANSAKSI.uraiantarip, "+                                           //19
                                    "BL_TRANSAKSI.jml_kasus_tarip, "+                                       //20
                                    "BL_TRANSAKSI.idbl_transaksi, "+                                        //21
                                    "BL_KASASKES.Idbl_Pembayaran, "+                                        //22
                                    "BL_TRANSAKSI.Tgltransaksi, "+                                          //23
                                    "BL_KASASKES.Tanggal, "+                                                //24
                                    "BL_TARIP.Idmr_jeniskelas, "+                                           //25
                                    "BL_TRANSAKSI.Idmr_truangan, "+                                         //26
                                    "MR_DOKTER.Idmr_dokter, " +                                             //27
                                    "MR_DOKTER.Nama " +                                                     //28
                               "FROM BL_KELTARIP With (nolock)  "+
                               "INNER JOIN BL_TRANSAKSI "+
                               "INNER JOIN BL_TRANSAKSIDETAIL "+
                                    "ON BL_TRANSAKSI.idbl_transaksi = BL_TRANSAKSIDETAIL.Idbl_transaksi "+
                               "INNER JOIN BL_TARIP "+
                                    "ON BL_TRANSAKSI.idbl_tarip = BL_TARIP.IdBl_tarip "+
                                    "ON BL_KELTARIP.Idbl_keltarip = BL_TARIP.Idbl_keltarip "+
                               "INNER JOIN MR_SMFTARIP "+
                                    "ON BL_TRANSAKSI.idmr_tsmf = MR_SMFTARIP.idmr_tsmf "+
                               "INNER JOIN BL_KASASKES "+
                                    "ON BL_TRANSAKSI.idbl_pembayaran = BL_KASASKES.Idbl_Pembayaran "+
                                    "AND BL_TRANSAKSI.idmr_mutasipasien = BL_KASASKES.idmr_mutasipasien "+
                               "INNER JOIN MR_PASIEN "+
                                    "ON BL_KASASKES.Idmr_pasien = MR_PASIEN.IDMR_PASIEN "+
                               "INNER JOIN MR_TRUANGAN "+
                                    "ON BL_KASASKES.Idmr_truangan = MR_TRUANGAN.idmr_truangan "+
                               "INNER JOIN MR_SJASKES "+
                                    "ON BL_KASASKES.idmr_mutasipasien = MR_SJASKES.idmr_mutasipasien "+
                               "INNER JOIN MR_DOKTER " +
                                    "ON MR_DOKTER.Idmr_dokter = BL_TRANSAKSI_1.Idmr_dokter " +
                               "WHERE (BL_TRANSAKSI.Batal <> 'Y') AND (BL_KASASKES.Batal = '') "+
                                  " AND (MR_SJASKES.BATAL = '') AND MR_SJASKES.idmr_tstatus = 'ASKESJAMKESMAS' "+
                                  " AND (BL_TRANSAKSIDETAIL.Idbl_komponen <> 'JASA SARANA') "+
                                  " AND BL_KASASKES.Tanggal between '" + dtpFilterTgl1.Value.ToString("MM/dd/yyyy 00:00:00") + 
                                    "' AND '" + dtpFilterTgl2.Value.ToString("MM/dd/yyyy 23:59:59") + "' "+
                                  " AND BL_TARIP.pisahsetor = '' and BL_KASASKES.jumlah > 0 "+
                                  " AND BL_TRANSAKSIDETAIL.noambil <> 999 "+
                                  " AND BL_TRANSAKSI.idmr_tsmf <> 'DARAH' AND BL_TRANSAKSI.idmr_tsmf <> 'PENDORONG'"+
                                  " AND BL_TRANSAKSI.idmr_tsmf <> 'OBAT/ALKES-FARMASI' "+
                                  " AND BL_TRANSAKSI.idmr_tsmf <> 'OBAT/ALKES-KPRI'"+
                                  " AND BL_TRANSAKSI.idbl_pembayaran > 0 and BL_KELTARIP.Lapjp <> '-'";

            reader = modDb.pbreaderSQL(conn, strQuerySQL, ref strErr);
            if (strErr != "")
            {
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
                    itemKASJKM.dblRekapJp = Convert.ToDouble(modMain.pbstrgetCol(reader, 10, ref strErr, ""));
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



            /* QUERY ASKES JAMKESDA*/
            this.strQuerySQL = "SELECT  "+
                                    "BL_TRANSAKSI.Regbilling, "+                                            //0
                                    "MR_PASIEN.Nama, "+                                                     //1
                                    "MR_TRUANGAN.ruangan, " +                                               //2
                                    "BL_TRANSAKSI.Jumlah, "+                                                //3
                                    "BL_TRANSAKSI.subsidi, "+                                               //4
                                    "BL_TRANSAKSI.tunai, " +                                                //5
                                    "BL_TRANSAKSIDETAIL.Idbl_komponen, "+                                   //6
                                    "BL_TRANSAKSIDETAIL.Nilai, " +                                          //7
                                    "BL_TRANSAKSIDETAIL.Ringan, "+                                          //8
                                    "BL_KELTARIP.urutan, "+                                                 //9
                                    "BL_KELTARIP.rekapjp," +                                                //10
                                    "BL_TRANSAKSIDETAIL.Nilai - BL_TRANSAKSIDETAIL.Ringan as tunainya , " + //11
                                    "BL_TRANSAKSIDETAIL.Noambil,"+                                          //12
                                    "BL_TRANSAKSIDETAIL.tglambil, " +                                       //13
                                    "BL_KELTARIP.Idbl_keltarip, "+                                          //14
                                    "BL_KELTARIP.Lapjp, "+                                                  //15
                                    "BL_TRANSAKSI.idmr_tsmf, " +                                            //16
                                    "MR_SMFTARIP.idmr_tupf, "+                                              //17
                                    "BL_TRANSAKSI.idbl_tarip, "+                                            //18
                                    "BL_TRANSAKSI.uraiantarip, " +                                          //19
                                    "BL_TRANSAKSI.jml_kasus_tarip, "+                                       //20
                                    "BL_TRANSAKSI.idbl_transaksi, " +                                       //21
                                    "BL_KASASKES.Idbl_Pembayaran, "+                                        //22
                                    "BL_TRANSAKSI.Tgltransaksi, "+                                          //23
                                    "BL_KASASKES.Tanggal, " +                                               //24
                                    "BL_TARIP.Idmr_jeniskelas, "+                                           //25
                                    "BL_TRANSAKSI.Idmr_truangan, " +                                        //26
                                    "MR_DOKTER.Idmr_dokter, " +                                             //27
                                    "MR_DOKTER.Nama " +                                                     //28
                                " FROM BL_KELTARIP With (nolock)  "+
                                " INNER JOIN BL_TRANSAKSI "+
                                " INNER JOIN BL_TRANSAKSIDETAIL ON BL_TRANSAKSI.idbl_transaksi = BL_TRANSAKSIDETAIL.Idbl_transaksi " +
                                " INNER JOIN BL_TARIP "+
                                        "ON BL_TRANSAKSI.idbl_tarip = BL_TARIP.IdBl_tarip "+
                                        "ON BL_KELTARIP.Idbl_keltarip = BL_TARIP.Idbl_keltarip "+
                                " INNER JOIN MR_SMFTARIP "+
                                        "ON BL_TRANSAKSI.idmr_tsmf = MR_SMFTARIP.idmr_tsmf " +
                                " INNER JOIN BL_KASASKES "+
                                        "ON BL_TRANSAKSI.idbl_pembayaran = BL_KASASKES.Idbl_Pembayaran " +
                                  " AND BL_TRANSAKSI.idmr_mutasipasien = BL_KASASKES.idmr_mutasipasien " +
                                " INNER JOIN MR_PASIEN ON BL_KASASKES.Idmr_pasien = MR_PASIEN.IDMR_PASIEN " +
                                " INNER JOIN MR_TRUANGAN ON BL_KASASKES.Idmr_truangan = MR_TRUANGAN.idmr_truangan " +
                                " INNER JOIN MR_SJASKES ON BL_KASASKES.idmr_mutasipasien = MR_SJASKES.idmr_mutasipasien " +
                                "INNER JOIN MR_DOKTER " +
                                    "ON MR_DOKTER.Idmr_dokter = BL_TRANSAKSI_1.Idmr_dokter " +
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

            reader = modDb.pbreaderSQL(conn, strQuerySQL, ref strErr);
            if (strErr != "")
            {
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
                    itemKASJKD.dblRekapJp = Convert.ToDouble(modMain.pbstrgetCol(reader, 10, ref strErr, ""));
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


        }

        private void LaporanJasaPelayanan_Load(object sender, EventArgs e)
        {

        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
