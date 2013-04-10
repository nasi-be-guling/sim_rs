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
    public partial class LapKasBKP : Form
    {

        C4Module.MainModule modMain = new C4Module.MainModule();
        C4Module.DatabaseModule modDb = new C4Module.DatabaseModule();
        C4Module.MessageModule modMsg = new C4Module.MessageModule();
        C4Module.SQLModule modSQL = new C4Module.SQLModule();

        /*LOCAL VARIABLE*/
        string strQuerySQL = "";
        string strErr = "";

        public class lstKasum
        {

            public string strIdBl_KelTarip { get; set; }
            public string strPisahSetor { get; set; }
            public string strIdMR_TSMF { get; set; }
            public string strIdBl_Norek { get; set; }
            public string strUraianRek { get; set; }
            public string strIdBl_Komponen { get; set; }
            public int intLapUrut { get; set; }
            public double dblTunainya { get; set; }
            public double dblNilai { get; set; }
            public double dblRingan { get; set; }
            public double dblTunai { get; set; }
            public string strIdBl_Transaksi { get; set; }

        }
        List<lstKasum> grpKasum = new List<lstKasum>();

        public class lstKasAskes
        {
            public double dblTunai { get; set; }
            public string strIdMR_Status { get; set; }
        }
        List<lstKasAskes> grpKasAskes = new List<lstKasAskes>();

        public class lstAdmAskes
        {
            public string strIdMR_Mutasipasien { get; set; }
            public double dblJumlah { get; set; }
            public string strIdBl_KelTarip { get; set; }
            public string strPisahSetor { get; set; }
        }
        List<lstAdmAskes> grpAdmAkses = new List<lstAdmAskes>();

        public class lstKasAskin
        {
            public string strIdBl_KelTarip { get; set; }
            public string strPisahSetor { get; set; }
            public string strIdMR_TSMF { get; set; }
            public string strIdBl_Komponen { get; set; }
            public int intLapUrut { get; set; }
            public double dblTunainya { get; set; }
            public double dblNilai { get; set; }
            public double dblRingan { get; set; }
            public double dblTunai { get; set; }
            public string strIdBl_Transaksi { get; set; }
        }
        List<lstKasAskin> grpKasAskin = new List<lstKasAskin>();

        public class lstKasJamkesmas
        {
            public string strIdBl_KelTarip { get; set; }
            public string strPisahSetor { get; set; }
            public string strIdMR_TSMF { get; set; }
            public string strIdBl_Komponen { get; set; }
            public int intLapUrut { get; set; }
            public double dblTunainya { get; set; }
            public double dblNilai { get; set; }
            public double dblRingan { get; set; }
            public double dblTunai { get; set; }
            public string strIdBl_Transaksi { get; set; }
        }
        List<lstKasJamkesmas> grpKasJamkesmas = new List<lstKasJamkesmas>();

        public class lstKasJamkesda
        {
            public string strIdBl_KelTarip { get; set; }
            public string strPisahSetor { get; set; }
            public string strIdMR_TSMF { get; set; }
            public string strIdBl_Komponen { get; set; }
            public int intLapUrut { get; set; }
            public double dblTunainya { get; set; }
            public double dblNilai { get; set; }
            public double dblRingan { get; set; }
            public double dblTunai { get; set; }
            public string strIdBl_Transaksi { get; set; }
        }
        List<lstKasJamkesda> grpKasJamkesda = new List<lstKasJamkesda>();

        public class lstKasLain
        {
            public string strIdBl_KelTarip { get; set; }
            public string strIdMR_TSMF { get; set; }
            public string strIdBl_Komponen { get; set; }
            public int intLapUrut { get; set; }
            public double dblTunainya { get; set; }
            public double dblNilai { get; set; }
            public double dblJumlah { get; set; }
            public string strIdBl_TransLain { get; set; }
        }
        List<lstKasLain> grpKasLain = new List<lstKasLain>();

        public class lstKelTarip
        {
            public string strIdBl_KelTarip { get; set; }
            public int intUrutan { get; set; }
            public string strLapJP { get; set; }
            public string strRekapJP { get; set; }
        }
        List<lstKelTarip> grpKelTarip = new List<lstKelTarip>();


        public class lstNOREK
        {

            public string strIdBl_NoRek { get; set; }
            public string strUraianRek { get; set; }
            public string strDipakai { get; set; }

        }
        List<lstNOREK> grpNorek = new List<lstNOREK>();


        public class lstTransak
        {
            public string strUraian { get; set; }
            public double dblJSum { get; set; }
            public double dblJPum { get; set; }
            public double dblJaum { get; set; }
            public double dblJSAsk { get; set; }
            public double dblJPAsk { get; set; }
            public double dblJAAsk { get; set; }
            public double dblJSPav { get; set; }
            public double dblJPPav { get; set; }
            public double dblJAPav { get; set; }
        }
        List<lstTransak> grpTransak = new List<lstTransak>();

        public LapKasBKP()
        {
            InitializeComponent();
        }       

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bgWork_DoWork(object sender, DoWorkEventArgs e)
        {

            this.strErr = "";
            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_CONN;


            SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                return;
            }


            this.strQuerySQL = "Select Idbl_Norek,Uraianrek,Dipakai " +
                               "FROM BL_NOREK With (nolock) " +
                               "WHERE IDBL_NOREK <> '-' order by IDBL_NOREK";

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

                    lstNOREK itemNorek = new lstNOREK();
                    itemNorek.strIdBl_NoRek = modMain.pbstrgetCol(reader, 0, ref strErr, "");
                    itemNorek.strUraianRek = modMain.pbstrgetCol(reader, 1, ref strErr, "");
                    itemNorek.strDipakai = modMain.pbstrgetCol(reader, 2, ref strErr, "");
                    grpNorek.Add(itemNorek);

                }
            }

            reader.Close();


            this.strQuerySQL = "SELECT Idbl_keltarip,Urutan,Lapjp,Rekapjp " +
                               "FROM BL_KELTARIP WITH (NOLOCK) " +
                               "WHERE lapjp <> '-' " +
                               "ORDER BY lapjp, urutan";

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

                    lstKelTarip itemKelTarip = new lstKelTarip();
                    itemKelTarip.strIdBl_KelTarip = modMain.pbstrgetCol(reader, 0, ref strErr, "");
                    itemKelTarip.intUrutan = Convert.ToInt32(modMain.pbstrgetCol(reader, 1, ref strErr, ""));
                    itemKelTarip.strLapJP = modMain.pbstrgetCol(reader, 2, ref strErr, "");
                    itemKelTarip.strRekapJP = modMain.pbstrgetCol(reader, 3, ref strErr, "");

                    grpKelTarip.Add(itemKelTarip);

                }
            }

            reader.Close();

            this.strQuerySQL = "SELECT "+
                                    "BL_TARIP.Idbl_keltarip, "+                                                 //0
                                    "BL_TARIP.pisahsetor, "+                                                    //1
                                    "BL_TRANSAKSI_1.idmr_tsmf, " +                                              //2
                                    "BL_TARIP.idbl_norek, "+                                                    //3
                                    "BL_TARIP.uraianrek, " +                                                    //4
                                    "BL_TRANSAKSIDETAIL_1.idbl_komponen, "+                                     //5
                                    "BL_KOMPONEN.Lapurut, " +                                                   //6
                                    "BL_TRANSAKSIDETAIL_1.nilai - BL_TRANSAKSIDETAIL_1.Ringan AS TUNAINYA, " +  //7
                                    "BL_TRANSAKSIDETAIL_1.nilai, "+                                             //8
                                    "BL_TRANSAKSIDETAIL_1.Ringan, " +                                           //9
                                    "BL_TRANSAKSI_1.TUNAI, "+                                                   //10
                                    "BL_TRANSAKSIDETAIL_1.idbl_transaksi " +                                    //11
                               "FROM BL_TRANSAKSI_1  With (nolock) "+
                               "INNER JOIN BL_TRANSAKSIDETAIL_1 "+
                                    "ON BL_TRANSAKSI_1.idbl_transaksi = BL_TRANSAKSIDETAIL_1.idbl_transaksi " +
                               "INNER JOIN BL_TARIP "+
                                    "ON BL_TRANSAKSI_1.idbl_tarip = BL_TARIP.IdBl_tarip " +
                               "INNER JOIN BL_KASUMUM "+
                                    "ON BL_TRANSAKSI_1.idbl_pembayaran = BL_KASUMUM.Idbl_Pembayaran "+
                                    "AND BL_TRANSAKSI_1.idmr_mutasipasien = BL_KASUMUM.idmr_mutasipasien " +
                               "INNER JOIN BL_KOMPONEN "+
                                    "ON BL_TRANSAKSIDETAIL_1.idbl_komponen = BL_KOMPONEN.idbl_komponen" +
                               "WHERE "+
                                    "BL_KASUMUM.Batal = '' "+
                                    "AND BL_TRANSAKSI_1.batal = ''" +
                                    "AND BL_KASUMUM.Tanggal between '" + dtpFilterTgl1.Value.ToString("MM/dd/yyyy 00:00:00") +
                                        "' AND '" + dtpFilterTgl2.Value.ToString("MM/dd/yyyy 23:59:59") + "' " +
                                    "AND BL_TRANSAKSI_1.idmr_tsmf <> 'DARAH' "+
                                    "AND BL_TRANSAKSI_1.idmr_tsmf <> 'PENDORONG'" +
                                    "AND BL_TRANSAKSI_1.idmr_tsmf <> 'DEPO FARMASI' " +
                                    "AND BL_TRANSAKSI_1.idmr_tsmf <> 'OBAT/ALKES-KPRI'" +
                                    "AND BL_TARIP.pisahsetor = ''";

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

                    lstKasum itemKasum = new lstKasum();
                    itemKasum.strIdBl_KelTarip = modMain.pbstrgetCol(reader, 0, ref strErr, "");
                    itemKasum.strPisahSetor = modMain.pbstrgetCol(reader, 1, ref strErr, "");
                    itemKasum.strIdMR_TSMF = modMain.pbstrgetCol(reader, 2, ref strErr, "");
                    itemKasum.strIdBl_Norek = modMain.pbstrgetCol(reader, 3, ref strErr, "");
                    itemKasum.strUraianRek = modMain.pbstrgetCol(reader, 4, ref strErr, "");
                    itemKasum.strIdBl_Komponen = modMain.pbstrgetCol(reader, 5, ref strErr, "");
                    itemKasum.intLapUrut = Convert.ToInt32(modMain.pbstrgetCol(reader, 6, ref strErr, ""));
                    itemKasum.dblTunainya = Convert.ToDouble(modMain.pbstrgetCol(reader, 7, ref strErr, ""));
                    itemKasum.dblNilai = Convert.ToDouble(modMain.pbstrgetCol(reader, 8, ref strErr, ""));
                    itemKasum.dblRingan = Convert.ToDouble(modMain.pbstrgetCol(reader, 9, ref strErr, ""));
                    itemKasum.dblTunai = Convert.ToDouble(modMain.pbstrgetCol(reader, 10, ref strErr, ""));
                    itemKasum.strIdBl_Transaksi = modMain.pbstrgetCol(reader, 11, ref strErr, "");
                    grpKasum.Add(itemKasum);

                }
            }

            reader.Close();


            this.strQuerySQL = "SELECT "+
                                    "BL_KASASKES.JUMLAH + BL_KASASKES.nonrs AS TUNAI, "+
                                    "MR_SJASKES.idmr_tstatus "+
                               "FROM BL_KASASKES  With (nolock) "+
                               "INNER JOIN MR_SJASKES "+
                                    "ON BL_KASASKES.idmr_mutasipasien = MR_SJASKES.idmr_mutasipasien "+
                               "WHERE BL_KASASKES.Batal = '' AND MR_SJASKES.Batal = '' "+
                                    "AND MR_SJASKES.idmr_tstatus = 'ASKES' "+
                                    "AND BL_KASASKES.Tanggal between '" + dtpFilterTgl1.Value.ToString("MM/dd/yyyy 00:00:00") +
                                        "' AND '" + dtpFilterTgl2.Value.ToString("MM/dd/yyyy 23:59:59") + "'";
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

                    lstKasAskes itemKasAskes = new lstKasAskes();
                    itemKasAskes.strIdMR_Status = modMain.pbstrgetCol(reader, 0, ref strErr, "");
                    itemKasAskes.dblTunai = Convert.ToDouble(modMain.pbstrgetCol(reader, 1, ref strErr, ""));
                    grpKasAskes.Add(itemKasAskes);

                }
            }

            reader.Close();


            this.strQuerySQL = "SELECT "+
                                    "BL_KASASKES.Idmr_mutasipasien, "+
                                    "BL_TRANSAKSI.JUMLAH, "+
                                    "BL_TARIP.Idbl_keltarip, "+
                                    "BL_TARIP.pisahsetor "+
                               "FROM BL_KASASKES With (nolock) "+
                               "INNER JOIN BL_TRANSAKSI "+
                                    "ON BL_KASASKES.Idmr_mutasipasien = BL_TRANSAKSI.idmr_mutasipasien "+
                               "INNER JOIN BL_TARIP "+
                                    "ON BL_TRANSAKSI.idbl_tarip = BL_TARIP.IdBl_tarip "+
                               "INNER JOIN MR_SJASKES "+
                                    "ON BL_KASASKES.idmr_mutasipasien = MR_SJASKES.idmr_mutasipasien "+ 
                               "WHERE BL_KASASKES.Batal = '' "+
                                    "AND BL_TRANSAKSI.batal = '' "+
                                    "AND BL_TRANSAKSI.idmr_tsmf = 'ADMINISTRASI' "+
                                    "AND BL_TARIP.pisahsetor <> '' "+
                                    "AND MR_SJASKES.Batal = '' "+
                                    "AND MR_SJASKES.idmr_tstatus = 'ASKES' "+
                                    "AND BL_KASASKES.Tanggal between '" + dtpFilterTgl1.Value.ToString("MM/dd/yyyy 00:00:00") +
                                        "' AND '" + dtpFilterTgl2.Value.ToString("MM/dd/yyyy 23:59:59") + "' ";

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

                    lstAdmAskes itemAdmAskes = new lstAdmAskes();
                    itemAdmAskes.strIdMR_Mutasipasien = modMain.pbstrgetCol(reader, 0, ref strErr, "");
                    itemAdmAskes.dblJumlah = Convert.ToDouble(modMain.pbstrgetCol(reader, 1, ref strErr, ""));
                    itemAdmAskes.strIdBl_KelTarip = modMain.pbstrgetCol(reader, 2, ref strErr, "");
                    itemAdmAskes.strPisahSetor = modMain.pbstrgetCol(reader, 3, ref strErr, "");
                    grpAdmAkses.Add(itemAdmAskes);

                }
            }

            reader.Close();


            this.strQuerySQL = "SELECT "+
                                    "BL_TARIP.Idbl_keltarip, "+
                                    "BL_TARIP.pisahsetor,"+
                                    "BL_TRANSAKSI.idmr_tsmf, "+
                                    "BL_TRANSAKSIDETAIL.idbl_komponen, "+
                                    "BL_KOMPONEN.Lapurut, "+
                                    "BL_TRANSAKSIDETAIL.nilai - BL_TRANSAKSIDETAIL.Ringan AS TUNAINYA,"+
                                    "BL_TRANSAKSIDETAIL.nilai, "+
                                    "BL_TRANSAKSIDETAIL.Ringan, "+
                                    "BL_TRANSAKSI.JUMLAH AS TUNAI, "+
                                    "BL_TRANSAKSIDETAIL.idbl_transaksi "+
                               "FROM BL_TRANSAKSI  With (nolock) "+
                               "INNER JOIN BL_TRANSAKSIDETAIL "+
                                    "ON BL_TRANSAKSI.idbl_transaksi = BL_TRANSAKSIDETAIL.idbl_transaksi "+
                               "INNER JOIN BL_TARIP "+
                                    "ON BL_TRANSAKSI.idbl_tarip = BL_TARIP.IdBl_tarip "+
                               "INNER JOIN BL_KASASKES "+
                                    "ON BL_TRANSAKSI.idbl_pembayaran = BL_KASASKES.Idbl_Pembayaran "+
                                    "AND BL_TRANSAKSI.idmr_mutasipasien = BL_KASASKES.idmr_mutasipasien "+
                               "INNER JOIN BL_KOMPONEN "+
                                    "ON BL_TRANSAKSIDETAIL.idbl_komponen = BL_KOMPONEN.idbl_komponen"+
                               "INNER JOIN MR_SJASKES "+
                                    "ON BL_KASASKES.idmr_mutasipasien = MR_SJASKES.idmr_mutasipasien "+
                               "WHERE BL_KASASKES.Batal = '' "+
                                    "AND BL_TRANSAKSI.batal = '' "+
                                    "AND MR_SJASKES.Batal = '' "+
                                    "AND BL_TRANSAKSI.idmr_tsmf <> 'DARAH' "+
                                    "AND BL_TRANSAKSI.idmr_tsmf <> 'PENDORONG'  "+
                                    "AND BL_TRANSAKSI.idmr_tsmf <> 'DEPO FARMASI' "+
                                    "AND BL_TRANSAKSI.idmr_tsmf <> 'OBAT/ALKES-KPRI' "+
                                    "AND BL_TARIP.pisahsetor = '' "+
                                    "AND BL_KASASKES.jumlah > 0 "+
                                    "AND BL_KASASKES.Tanggal between '" + dtpFilterTgl1.Value.ToString("MM/dd/yyyy 00:00:00") +
                                        "' AND '" + dtpFilterTgl2.Value.ToString("MM/dd/yyyy 23:59:59") + "' " +
                                    "AND MR_SJASKES.idmr_tstatus = 'ASKESGAKIN'";


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

                    lstKasAskin itemKasAskin = new lstKasAskin();
                    itemKasAskin.strIdBl_KelTarip = modMain.pbstrgetCol(reader, 0, ref strErr, "");
                    itemKasAskin.strPisahSetor = modMain.pbstrgetCol(reader, 1, ref strErr, "");
                    itemKasAskin.strIdMR_TSMF = modMain.pbstrgetCol(reader, 2, ref strErr, "");
                    itemKasAskin.strIdBl_Komponen = modMain.pbstrgetCol(reader, 3, ref strErr, "");
                    itemKasAskin.intLapUrut = Convert.ToInt32(modMain.pbstrgetCol(reader, 4, ref strErr, ""));
                    itemKasAskin.dblTunainya = Convert.ToDouble(modMain.pbstrgetCol(reader, 5, ref strErr, ""));
                    itemKasAskin.dblNilai = Convert.ToDouble(modMain.pbstrgetCol(reader, 6, ref strErr, ""));
                    itemKasAskin.dblRingan = Convert.ToDouble(modMain.pbstrgetCol(reader, 7, ref strErr, ""));
                    itemKasAskin.dblTunai = Convert.ToDouble(modMain.pbstrgetCol(reader, 8, ref strErr, ""));
                    itemKasAskin.strIdBl_Transaksi = modMain.pbstrgetCol(reader, 9, ref strErr, "");
                    grpKasAskin.Add(itemKasAskin);

                }
            }

            reader.Close();


            this.strQuerySQL = "SELECT "+
                                    "BL_TARIP.Idbl_keltarip, "+
                                    "BL_TARIP.pisahsetor,"+
                                    "BL_TRANSAKSI.idmr_tsmf, "+
                                    "BL_TRANSAKSIDETAIL.idbl_komponen, "+
                                    "BL_KOMPONEN.Lapurut, "+
                                    "BL_TRANSAKSIDETAIL.nilai - BL_TRANSAKSIDETAIL.Ringan AS TUNAINYA, "+
                                    "BL_TRANSAKSIDETAIL.nilai, "+
                                    "BL_TRANSAKSIDETAIL.Ringan, "+
                                    "BL_TRANSAKSI.JUMLAH AS TUNAI, "+
                                    "BL_TRANSAKSIDETAIL.idbl_transaksi "+
                               "FROM BL_TRANSAKSI  With (nolock) "+
                                "INNER JOIN BL_TRANSAKSIDETAIL "+
                                    "ON BL_TRANSAKSI.idbl_transaksi = BL_TRANSAKSIDETAIL.idbl_transaksi "+
                               "INNER JOIN BL_TARIP "+
                                    "ON BL_TRANSAKSI.idbl_tarip = BL_TARIP.IdBl_tarip "+
                               "INNER JOIN BL_KASASKES "+
                                    "ON BL_TRANSAKSI.idbl_pembayaran = BL_KASASKES.Idbl_Pembayaran "+
                                    "AND BL_TRANSAKSI.idmr_mutasipasien = BL_KASASKES.idmr_mutasipasien "+
                               "INNER JOIN BL_KOMPONEN "+
                                    "ON BL_TRANSAKSIDETAIL.idbl_komponen = BL_KOMPONEN.idbl_komponen"+
                               "INNER JOIN MR_SJASKES "+
                                    "ON BL_KASASKES.idmr_mutasipasien = MR_SJASKES.idmr_mutasipasien "+
                               "WHERE BL_KASASKES.Batal = '' "+
                                    "AND BL_TRANSAKSI.batal = '' "+
                                    "AND MR_SJASKES.Batal = ''"+
                                    "AND BL_TRANSAKSI.idmr_tsmf <> 'DARAH' "+
                                    "AND BL_TRANSAKSI.idmr_tsmf <> 'PENDORONG' "+
                                    "AND BL_TRANSAKSI.idmr_tsmf <> 'DEPO FARMASI' "+
                                    "AND BL_TRANSAKSI.idmr_tsmf <> 'OBAT/ALKES-KPRI' "+
                                    "AND BL_TARIP.pisahsetor = '' and BL_KASASKES.jumlah > 0 "+
                                    "AND BL_KASASKES.Tanggal between '" + dtpFilterTgl1.Value.ToString("MM/dd/yyyy 00:00:00") +
                                        "' AND '" + dtpFilterTgl2.Value.ToString("MM/dd/yyyy 23:59:59") + "' " +
                                    "AND MR_SJASKES.idmr_tstatus = 'ASKESJAMKESMAS'";

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

                    lstKasJamkesmas itemKasJamkesmas = new lstKasJamkesmas();
                    itemKasJamkesmas.strIdBl_KelTarip = modMain.pbstrgetCol(reader, 0, ref strErr, "");
                    itemKasJamkesmas.strPisahSetor = modMain.pbstrgetCol(reader, 1, ref strErr, "");
                    itemKasJamkesmas.strIdMR_TSMF = modMain.pbstrgetCol(reader, 2, ref strErr, "");
                    itemKasJamkesmas.strIdBl_Komponen = modMain.pbstrgetCol(reader, 3, ref strErr, "");
                    itemKasJamkesmas.intLapUrut = Convert.ToInt32(modMain.pbstrgetCol(reader, 4, ref strErr, ""));
                    itemKasJamkesmas.dblTunainya = Convert.ToDouble(modMain.pbstrgetCol(reader, 5, ref strErr, ""));
                    itemKasJamkesmas.dblNilai = Convert.ToDouble(modMain.pbstrgetCol(reader, 6, ref strErr, ""));
                    itemKasJamkesmas.dblRingan = Convert.ToDouble(modMain.pbstrgetCol(reader, 7, ref strErr, ""));
                    itemKasJamkesmas.dblTunai = Convert.ToDouble(modMain.pbstrgetCol(reader, 8, ref strErr, ""));
                    itemKasJamkesmas.strIdBl_Transaksi = modMain.pbstrgetCol(reader, 9, ref strErr, "");
                    grpKasJamkesmas.Add(itemKasJamkesmas);

                }
            }

            reader.Close();


            this.strQuerySQL = "SELECT "+
                                    "BL_TARIP.Idbl_keltarip, "+
                                    "BL_TRANSLAIN.idmr_tsmf, "+
                                    "BL_TRANSLAINDET.idbl_komponen, "+
                                    "BL_KOMPONEN.Lapurut, "+
                                    "BL_TRANSLAINDET.nilai AS TUNAINYA, "+
                                    "BL_TRANSLAINDET.nilai, "+
                                    "BL_TRANSLAIN.jumlah, "+
                                    "BL_TRANSLAINDET.idbl_translain "+
                            "FROM BL_TRANSLAIN  With (nolock) "+
                            "INNER JOIN BL_TRANSLAINDET "+
                                    "ON BL_TRANSLAIN.idbl_translain = BL_TRANSLAINDET.idbl_translain "+
                            "INNER JOIN BL_TARIP "+
                                    "ON BL_TRANSLAIN.idbl_tarip = BL_TARIP.IdBl_tarip "+
                            "INNER JOIN BL_KASLAIN "+
                                    "ON BL_TRANSLAIN.idbl_kaslain = BL_KASLAIN.Idbl_kaslain "+
                            "INNER JOIN BL_KOMPONEN "+
                                    "ON BL_TRANSLAINDET.idbl_komponen = BL_KOMPONEN.idbl_komponen"+
                            "WHERE BL_KASLAIN.Batal = '' "+
                                    "AND BL_TRANSLAIN.Batal = '' "+
                                    "AND BL_KASLAIN.Tanggal between '" + dtpFilterTgl1.Value.ToString("MM/dd/yyyy 00:00:00") +
                                        "' AND '" + dtpFilterTgl2.Value.ToString("MM/dd/yyyy 23:59:59") + "' " +
                                    "AND BL_TRANSLAIN.idmr_tsmf <> 'DARAH' "+
                                    "AND BL_TRANSLAIN.idmr_tsmf <> 'PENDORONG' "+
                                    "AND BL_TRANSLAIN.idmr_tsmf <> 'DEPO FARMASI' "+
                                    "AND BL_TRANSLAIN.idmr_tsmf <> 'OBAT/ALKES-KPRI' "+
                                    "ORDER BY BL_TARIP.Idbl_keltarip, BL_TRANSLAINDET.idbl_komponen";

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

                    lstKasLain itemKasLain = new lstKasLain();
                    itemKasLain.strIdBl_KelTarip = modMain.pbstrgetCol(reader, 0, ref strErr, "");
                    itemKasLain.strIdMR_TSMF = modMain.pbstrgetCol(reader, 1, ref strErr, "");
                    itemKasLain.strIdBl_Komponen = modMain.pbstrgetCol(reader, 2, ref strErr, "");
                    itemKasLain.intLapUrut = Convert.ToInt32(modMain.pbstrgetCol(reader, 3, ref strErr, ""));
                    itemKasLain.dblTunainya = Convert.ToDouble(modMain.pbstrgetCol(reader, 4, ref strErr, ""));
                    itemKasLain.dblNilai = Convert.ToDouble(modMain.pbstrgetCol(reader, 5, ref strErr, ""));
                    itemKasLain.strIdBl_TransLain = modMain.pbstrgetCol(reader, 6, ref strErr, "");
                    grpKasLain.Add(itemKasLain);

                }
            }

            reader.Close();


            conn.Close();


        }
        

        private void bgWork_1_DoWork(object sender, DoWorkEventArgs e)
        {

            string strKode = "";
            string strNomor = "";
            string strHari = "";

            cmbKode.SafeControlInvoke(ComboBox => strKode =  cmbKode.Text);
            txtNomor.SafeControlInvoke(TextBox => strNomor = txtNomor.Text);
            txtHari.SafeControlInvoke(TextBox => strHari = txtHari.Text);

            if (strKode != "")                
            {

                string strJudulNo = "NOMOR : " + strNomor+"/RET/RSU";
                string strJudulHr = "HARI  : " + strHari;

                if (strKode == "KELOMPOK TARIP")
                {

                    if (grpKelTarip.Count > 0)
                    {

                        foreach (var fetch in grpKelTarip)
                        {

                            lstTransak itemTransak = new lstTransak();
                            itemTransak.strUraian = fetch.strIdBl_KelTarip;
                            itemTransak.dblJSum = 0;
                            itemTransak.dblJPum = 0;
                            itemTransak.dblJaum = 0;
                            itemTransak.dblJSAsk = 0;
                            itemTransak.dblJPAsk = 0;
                            itemTransak.dblJAAsk = 0;
                            itemTransak.dblJSPav = 0;
                            itemTransak.dblJPPav = 0;
                            itemTransak.dblJAPav = 0;
                        }                    
                    }

                    /* UMUM */
                    if (grpKasum.Count > 0)
                    {
                        var Kasumum = (from x in grpKasum
                                       group x by new 
                                       { 
                                           x.strIdBl_KelTarip, 
                                           x.strIdBl_Komponen,
                                           x.intLapUrut
                                       } into groupKasum
                                       select new 
                                       { 
                                           KelTarip = groupKasum.Key.strIdBl_KelTarip,
                                           Komponen = groupKasum.Key.strIdBl_Komponen,
                                           LapUrut = groupKasum.Key.intLapUrut,
                                           Tunainya = groupKasum.Sum(x => x.dblTunainya)
                                       }).ToList();

                        int intUrutan = 0;
                        foreach (var fetchTransak in grpTransak)
                        {
                            foreach (var fetchKasUmum in Kasumum)
                            {
                                if (fetchTransak.strUraian == fetchKasUmum.KelTarip)
                                {
                                    if (fetchKasUmum.LapUrut == 1)
                                        grpTransak[intUrutan].dblJSum= fetchKasUmum.Tunainya;
                                    else if (fetchKasUmum.LapUrut == 2)
                                        grpTransak[intUrutan].dblJPum = fetchKasUmum.Tunainya;
                                    else if (fetchKasUmum.LapUrut == 3)
                                        grpTransak[intUrutan].dblJaum = fetchKasUmum.Tunainya;
                                }
                            }
                            intUrutan++;
                        }
                    }


                    if (grpKasAskes.Count > 0)
                    {



                    }


                }
                else if (strKode == "")
                {

                }



            }
        }

       
    }
}
