using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SIM_RS.ADMIN
{
    public partial class LapCheckTransAndDetail : Form
    {

        C4Module.MainModule modMain = new C4Module.MainModule();
        C4Module.DatabaseModule modDb = new C4Module.DatabaseModule();
        C4Module.MessageModule modMsg = new C4Module.MessageModule();
        C4Module.SQLModule modSQL = new C4Module.SQLModule();

        /* PRIVATE VARIABLE */

        string strQuerySQL = "";
        string strErr = "";

        string strIdMutasiPasien = "";

        /* EOF PRIVATE VARIABLE */      
        
        public LapCheckTransAndDetail()
        {
            InitializeComponent();
        }


        private void pvCariData()
        {
           

        }

        private void LapCheckTransAndDetail_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            //this.cmbPilihanKelas.SelectedIndex = 0;
            this.lvDaftarTindakan.Height = 431;
            //this.pvCariData();
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LapCheckTransAndDetail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {  
                this.Close();
            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            //this.pvCariData();
            bgWork.RunWorkerAsync();
        }

        private void lvDaftarTindakan_MouseClick(object sender, MouseEventArgs e)
        {
            if ((e.Button == System.Windows.Forms.MouseButtons.Right) && (lvDaftarTindakan.Items.Count > 0))
            {
                cmsPerbaikan.Show(this.lvDaftarTindakan, e.Location);
            }
        }

        private void rubahToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pvLoadDataTindakan();
            lvDaftarTindakan.Height = 157;
            lvDaftarTindakan.Enabled = false;
            
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            lvDaftarTindakan.Height = 431;
            lvDaftarTindakan.Enabled = true;
            txtNamaDokter.Text = "";
        }

        private void pvLoadDataTindakan()
        {

            string strIdBlTransaksi = lvDaftarTindakan.SelectedItems[0].SubItems[5].Text;

            this.strErr = "";
            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_CONN;

            SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                return;
            }

            //MessageBox.Show(conn.ConnectionTimeout.ToString());         

          

            strQuerySQL = "SELECT " +
                                "regbilling, " +          //0
                                "idbl_tarip, " +          //1
                                "jumlah,  " +             //2
                                "idbl_transaksi, "+       //3
                                "uraiantarip, "+            //4 
                                "idmr_mutasipasien " +        //5                          
                            "FROM BL_TRANSAKSI WHERE idbl_transaksi = " + strIdBlTransaksi;

            SqlDataReader reader = modDb.pbreaderSQL(conn, strQuerySQL, ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_GET, modMsg.TITLE_ERR);
                conn.Close();
                return;
            }

            if (reader.HasRows)
            {
                reader.Read();

                lblIdTransaksi.Text = modMain.pbstrgetCol(reader,3,ref strErr,"");
                lblKodeTarif.Text = modMain.pbstrgetCol(reader, 1, ref strErr, "");
                lblBiayaTindakan.Text = modMain.pbstrgetCol(reader, 2, ref strErr, "");
                lblDeskripsiTindakan.Text = modMain.pbstrgetCol(reader, 4, ref strErr, "");
                strIdMutasiPasien = modMain.pbstrgetCol(reader, 5, ref strErr, "");
            }
           
            reader.Close();


            strQuerySQL = "SELECT " +
                                "idbl_tarip, " +
                                "idbl_komponen, " +
                                "bykomponen, " +
                                "Hak1, " +
                                "Hak2, " +
                                "Hak3, " +
                                "PrioritasTunai " +
                           "FROM BL_KOMPTARIP WHERE idbl_tarip = '" + lblKodeTarif.Text.Trim().ToString() + "'";

            reader = modDb.pbreaderSQL(conn, strQuerySQL, ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_GET, modMsg.TITLE_ERR);
                conn.Close();
                return;
            }

            lvDetailTindakan.Items.Clear();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    lvDetailTindakan.Items.Add(modMain.pbstrgetCol(reader,0,ref strErr,""));
                    lvDetailTindakan.Items[lvDetailTindakan.Items.Count - 1].SubItems.Add(modMain.pbstrgetCol(reader, 1, ref strErr, ""));
                    lvDetailTindakan.Items[lvDetailTindakan.Items.Count - 1].SubItems.Add(modMain.pbstrgetCol(reader, 2, ref strErr, ""));
                    lvDetailTindakan.Items[lvDetailTindakan.Items.Count - 1].SubItems.Add(modMain.pbstrgetCol(reader, 3, ref strErr, ""));
                    lvDetailTindakan.Items[lvDetailTindakan.Items.Count - 1].SubItems.Add(modMain.pbstrgetCol(reader, 4, ref strErr, ""));
                    lvDetailTindakan.Items[lvDetailTindakan.Items.Count - 1].SubItems.Add(modMain.pbstrgetCol(reader, 5, ref strErr, ""));
                    lvDetailTindakan.Items[lvDetailTindakan.Items.Count - 1].SubItems.Add(modMain.pbstrgetCol(reader, 6, ref strErr, ""));
                }

            }

            reader.Close();



            conn.Close();

            modSQL.pvAutoResizeLV(lvDetailTindakan, 7);

        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {

            this.strErr = "";
            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_CONN;

            SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                return;
            }

            SqlTransaction trans = conn.BeginTransaction();

            string strKodedokter = txtNamaDokter.Text.Trim().ToString();

            if (strKodedokter == "")
                strKodedokter = "-";

            for (int ii = 0; ii <= lvDetailTindakan.Items.Count-1; ii++)
            {

                string strKdDokter = txtNamaDokter.Text;

                //MessageBox.Show(lvDetailTindakan.Items[ii].SubItems[1].Text.Trim().ToString());

                string strIdBlKomponen = lvDetailTindakan.Items[ii].SubItems[1].Text.Trim().ToString();

                if (strIdBlKomponen.Trim().ToUpper().ToString() == ("JASA SARANA").ToUpper().ToString())
                    strKdDokter = "";

                //MessageBox.Show(strIdBlKomponen);

                this.strQuerySQL = "INSERT INTO BL_TRANSAKSIDETAIL_1 WITH (ROWLOCK) " +
                                           "(idmr_mutasipasien, idbl_transaksi, " +
                                           "idbl_komponen, idmr_dokter, " +
                                           "niltarip, niltamb, " +
                                           "nilai, nilaskes, " +
                                           "hak1, hak2, " +
                                           "hak3 ) VALUES " +
                                           "(" + strIdMutasiPasien + "," + lblIdTransaksi.Text + ",'" +
                                                   lvDetailTindakan.Items[ii].SubItems[1].Text + "','" + strKdDokter + "', " +
                                                   lvDetailTindakan.Items[ii].SubItems[2].Text + ", 0 " +
                                                   "," + lvDetailTindakan.Items[ii].SubItems[2].Text + ", 0 ," +
                                                   lvDetailTindakan.Items[ii].SubItems[3].Text +
                                                   "," + lvDetailTindakan.Items[ii].SubItems[4].Text +
                                                   "," + lvDetailTindakan.Items[ii].SubItems[5].Text + ")";

                modDb.pbWriteSQLTrans(conn, this.strQuerySQL, ref strErr, trans);
                if (strErr != "")
                {
                    modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                    trans.Rollback();
                    conn.Close();                  
                }

                

            }

            //reader.Close();
            trans.Commit();
            conn.Close();

            txtNamaDokter.Text = "";

            lvDaftarTindakan.Height = 431;
            lvDaftarTindakan.Enabled = true;

            lvDetailTindakan.Items.Clear();

        }

        private void exportExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (lvDaftarTindakan.Items.Count == 0)
            //{
            //    MessageBox.Show("Tidak ada data yang akan di export ke Excel",
            //                  "Informasi",
            //                  MessageBoxButtons.OK,
            //                  MessageBoxIcon.Information);
            //    return;
            //}

            //System.Globalization.CultureInfo oldCI = System.Threading.Thread.CurrentThread.CurrentCulture;
            //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");



            //Microsoft.Office.Interop.Excel.Application xla = new Microsoft.Office.Interop.Excel.Application();

            //xla.Visible = true;

            //Microsoft.Office.Interop.Excel.Workbook wb = xla.Workbooks.Add(Microsoft.Office.Interop.Excel.XlSheetType.xlWorksheet);

            //Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)xla.ActiveSheet;

            //int i = 2;

            //int j = 1;

            //var names = (from col in lvDaftarTindakan.Columns.Cast<ColumnHeader>()
            //             orderby col.DisplayIndex
            //             select col.Text).ToList();

            //foreach (string itemNames in names)
            //{

            //    ws.Cells[1, j] = itemNames;
            //    j++;
            //}

            //j = 1;

            //foreach (ListViewItem comp in lvDaftarTindakan.Items)
            //{

            //    ws.Cells[i, j] = comp.Text.ToString();

            //    //MessageBox.Show(comp.Text.ToString());

            //    foreach (ListViewItem.ListViewSubItem drv in comp.SubItems)
            //    {

            //        if (j == 4)
            //            ws.Cells[i, j] = modMain.removePoint(drv.Text.ToString());
            //        else if (j == 5)
            //            ws.Cells[i, j] = modMain.removePoint(drv.Text.ToString());
            //        else
            //            ws.Cells[i, j] = "'" + drv.Text.ToString();



            //        j++;

            //    }

            //    j = 1;

            //    i++;

            //}

            //System.Threading.Thread.CurrentThread.CurrentCulture = oldCI;
        }

        private void bgWork_DoWork(object sender, DoWorkEventArgs e)
        {

            lvDaftarTindakan.SafeControlInvoke(ListView => lvDaftarTindakan.Enabled = false);

            lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = true);

            btnCari.SafeControlInvoke(Button => btnCari.Enabled = false);

            this.strErr = "";
            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_CONN;

            SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                return;
            }

            //MessageBox.Show(conn.ConnectionTimeout.ToString());

            //strQuerySQL = "SELECT a.regbilling, a.idbl_tarip, a.jumlah,  "+
            //                "(SELECT SUM(niltarip) FROM BL_TRANSAKSIDETAIL AS b WHERE a.idbl_transaksi = b.idbl_transaksi) "+
            //              "FROM BL_TRANSAKSI AS a "+
            //              "WHERE a.Tgltransaksi BETWEEN '" + dtpFilterTgl.Value.ToString("MM/dd/yyyy 00:00:00") + 
            //              "' AND  '" + dtpFilterTgl.Value.ToString("MM/dd/yyyy 23:59:59") + "' ";

            //strQuerySQL = "SELECT "+
            //                    "a.regbilling, "+
            //                    "a.idbl_tarip, "+
            //                    "a.jumlah,  "+
            //                    "(SELECT SUM(nilai) FROM BL_TRANSAKSIDETAIL AS b WHERE a.idbl_transaksi = b.idbl_transaksi) as nilaiDetail, "+
            //                    "a.idbl_transaksi, a.TglTransaksi,a.idmr_Truangan " +
            //                "FROM BL_TRANSAKSI AS a " +
            //                    "INNER JOIN BL_TARIP AS c ON a.idbl_tarip = c.IdBl_tarip " +
            //                "WHERE (a.Tgltransaksi BETWEEN '" + dtpFilterTgl.Value.ToString("MM/dd/yyyy 00:00:00") + 
            //                        "' AND  '" + dtpFilterTgl.Value.ToString("MM/dd/yyyy 23:59:59") + "') " +
            //                "AND c.Idmr_jeniskelas = '" + cmbPilihanKelas.Text + "' AND a.Batal = '' "+
            //                "ORDER BY a.regbilling, a.TglTransaksi ASC";


            string strTglFilterAwal = "";
            string strTglFilterAkhir = "";

            dtpFilterTgl1.SafeControlInvoke(DateTimePicker => strTglFilterAwal = dtpFilterTgl1.Value.ToString("MM/dd/yyyy 00:00:00"));
            dtpFilterTgl1.SafeControlInvoke(DateTimePicker => strTglFilterAkhir = dtpFilterTgl2.Value.ToString("MM/dd/yyyy 23:59:59"));

            strQuerySQL = "SELECT " +
                              "BL_TRANSAKSI_1.regbilling, " +
                              "BL_TRANSAKSI_1.idbl_tarip, " +
                              "BL_TRANSAKSI_1.jumlah,  " +
                              "(SELECT SUM(BL_TRANSAKSIDETAIL_1.nilai) " +
                                "FROM BL_TRANSAKSIDETAIL_1 "+
                                "WHERE BL_TRANSAKSI_1.idbl_transaksi = BL_TRANSAKSIDETAIL_1.idbl_transaksi) as nilaiDetail, " +
                              "BL_TRANSAKSI_1.idbl_transaksi, BL_TRANSAKSI_1.TglTransaksi, BL_TRANSAKSI_1.idmr_Truangan " +
                          "FROM BL_TRANSAKSI_1 " +
                              "INNER JOIN BL_TARIP ON BL_TRANSAKSI_1.idbl_tarip = BL_TARIP.IdBl_tarip " +
                          "WHERE (BL_TRANSAKSI_1.Tgltransaksi BETWEEN '" + strTglFilterAwal +
                                  "' AND  '" + strTglFilterAkhir + "') " +
                          " AND BL_TRANSAKSI_1.Batal = '' " +
                          "ORDER BY BL_TRANSAKSI_1.regbilling";


            //"(SELECT SUM(nilai) FROM BL_TRANSAKSIDETAIL AS b WHERE a.idbl_transaksi = b.idbl_transaksi) IS NULL OR " +
            //                "(SELECT SUM(nilai) FROM BL_TRANSAKSIDETAIL AS b WHERE a.idbl_transaksi = b.idbl_transaksi) <> a.jumlah";


            SqlDataReader reader = modDb.pbreaderSQL(conn, strQuerySQL, ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_GET, modMsg.TITLE_ERR);
                conn.Close();
                return;
            }


            lvDaftarTindakan.SafeControlInvoke(ListView => lvDaftarTindakan.Items.Clear());

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    string strNilaiDetail = modMain.pbstrgetCol(reader, 3, ref strErr, "");

                    double dblNilaiDetail = -100;
                    double dblNilaiTrans = Convert.ToDouble(modMain.pbstrgetCol(reader, 2, ref strErr, ""));

                    bool isDisplay = false;

                    if (strNilaiDetail != "")
                    {
                        dblNilaiDetail = Convert.ToDouble(strNilaiDetail);

                        if (dblNilaiDetail != dblNilaiTrans)
                            isDisplay = true;
                        else
                            isDisplay = false;

                    }
                    else
                    {
                        isDisplay = true;
                    }



                    if (isDisplay)
                    {
                        lvDaftarTindakan.SafeControlInvoke(
                            ListView => lvDaftarTindakan.Items.Add(modMain.pbstrgetCol(reader, 0, ref strErr, "")));
                        lvDaftarTindakan.SafeControlInvoke(
                            ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(modMain.pbstrgetCol(reader, 5, ref strErr, "")));
                        lvDaftarTindakan.SafeControlInvoke(
                            ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(modMain.pbstrgetCol(reader, 1, ref strErr, "")));
                        lvDaftarTindakan.SafeControlInvoke(
                            ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(modMain.pbstrgetCol(reader, 2, ref strErr, "")));
                        lvDaftarTindakan.SafeControlInvoke(
                            ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(modMain.pbstrgetCol(reader, 3, ref strErr, "")));
                        lvDaftarTindakan.SafeControlInvoke(
                            ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(modMain.pbstrgetCol(reader, 4, ref strErr, "")));
                        lvDaftarTindakan.SafeControlInvoke(
                            ListView => lvDaftarTindakan.Items[lvDaftarTindakan.Items.Count - 1].SubItems.Add(modMain.pbstrgetCol(reader, 6, ref strErr, "")));
                    }
                    //lbDaftarMenu.Items.Add(modMain.pbstrgetCol(reader, 1, ref strErr, ""));
                }
            }


            lblInfoPencarian.SafeControlInvoke(Label => lblInfoPencarian.Visible = false);

            int intJmlYgDitampilkan = 0;

            lvDaftarTindakan.SafeControlInvoke(ListView => intJmlYgDitampilkan = lvDaftarTindakan.Items.Count);

            lblJumlahTindakan.SafeControlInvoke(Label => lblJumlahTindakan.Text = "Jumlah tindakan yang tidak tepat : " + intJmlYgDitampilkan.ToString());

            if (intJmlYgDitampilkan == 0)
            {
                MessageBox.Show("Data tidak ditemukan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            reader.Close();
            conn.Close();

            modSQL.pvAutoResizeLV(lvDaftarTindakan, 7);

            btnCari.SafeControlInvoke(Button => btnCari.Enabled = true);

            lvDaftarTindakan.SafeControlInvoke(ListView => lvDaftarTindakan.Enabled = true);



        }
    }
}
