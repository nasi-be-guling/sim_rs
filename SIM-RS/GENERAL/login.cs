﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Imaging;

namespace SIM_RS
{
    public partial class login : Form
    {

        C4Module.MainModule modMain = new C4Module.MainModule();
        C4Module.DatabaseModule modDb = new C4Module.DatabaseModule();
        C4Module.MessageModule modMsg = new C4Module.MessageModule();
        C4Module.SQLModule modSQL = new C4Module.SQLModule();
        C4Module.EncryptModule modEncrypt = new C4Module.EncryptModule();

        /*Private Variable*/

        string strSqlQuery = "";
        string strErr = "";
        string stridUser = "";
        string strnamaUser = "";
        bool isLoginSuccess = false;

        /*EOF Private Variable*/

        /*LOAD OTHER FORM       */
        /*IF NEEDED             */

       

        /*EOF LOAD OTHER FORM   */

        public login()
        {
            InitializeComponent();
        }      

        private void login_FormClosing(object sender, FormClosingEventArgs e)
        {

            //if (!isLoginSuccess)
            //{
            //    DialogResult msgDialog = MessageBox.Show("Apakah anda akan membatalkan login dan keluar dari program",
            //                                                "Informasi",
            //                                                MessageBoxButtons.YesNo,
            //                                                MessageBoxIcon.Question);

            //    if (msgDialog == DialogResult.No)
            //    {
            //        e.Cancel = true;
            //        return;
            //    }
            //}
            
        }

        private void login_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (stridUser.Equals(""))
            {
                halamanUtama fTCN = (halamanUtama)Application.OpenForms["halamanUtama"];
                fTCN.isForceQuit = true;
                fTCN.Close();
            }
            else
            {
                /*CALL / LOAD INFO IN MAIN FORM..*/

                halamanUtama fTCN = (halamanUtama)Application.OpenForms["halamanUtama"];

                fTCN.txtPetugas.Text = strnamaUser;
                //fTCN.txtUnitKerja.Text = cmbUnitKerja.Text.Trim().ToString();
                //fTCN.txtShift.Text = cmbShift.Text.Trim().ToString();

                fTCN.pvLoadInfoUser(stridUser);
                //fTCN.lbDaftarMenu.Focus();
                //fTCN.pbScreenCapture.Visible = false;                                   
            }
        }

        private void login_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                isLoginSuccess = false;
                this.Close();
            }
        }

        private void login_Shown(object sender, EventArgs e)
        {
            

            //fTCN.Opacity = 0.5;
        }


        private void login_Paint(object sender, PaintEventArgs e)
        {
            //halamanUtama fTCN = (halamanUtama)Application.OpenForms["halamanUtama"];

            //Bitmap bmpBlurr = Screenshot.TakeSnapshot(fTCN);
            ////BitmapFilter.GaussianBlur(bmpBlurr, 2);

            //fTCN.pbScreenCapture.Image = bmpBlurr;
            //fTCN.pbScreenCapture.Dock = DockStyle.Fill;
            //fTCN.pbScreenCapture.BringToFront();
            //fTCN.pbScreenCapture.Visible = true;
        }

        /*
     *  NAME        : metode login
     *  FUNCTION    : proses login ke halaman utama
     *  RESULT      : -
     *  CREATED     : Eka Rudito (eka@rudito.web.id)
     *  DATE        : 16-02-2013
     */

        private void pvLoginForm() 
        {
            this.strErr = "";
            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_BILLING_ERM;

            SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                return;
            }

            strSqlQuery = "SELECT id, nama " +
                          "FROM HIS_DAFTAR_USER " +
                          "WHERE nip_nbi = '" + modMain.pbstrBersihkanInput(txtuserId.Text) +
                          "' and sandi = '" + modEncrypt.EncryptToString(txtsandiUser.Text.Trim()) + "'";

            SqlDataReader reader = modDb.pbreaderSQL(conn, strSqlQuery, ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_GET, modMsg.TITLE_ERR);
                conn.Close();
                return;
            }

            if (reader.HasRows)
            {
                reader.Read();
                stridUser = modMain.pbstrgetCol(reader, 0, ref strErr, "");
                strnamaUser = modMain.pbstrgetCol(reader, 1, ref strErr, "");

            }
            reader.Close();
            conn.Close();

            if (stridUser.Equals(""))
            {
                MessageBox.Show("Username ato password salah, silahkan diulang  ('-')('-')");
                this.pvBersihkanForm();
            }
            else
                this.Close();        
        }

        private void btnKeluarProgram_Click(object sender, EventArgs e)
        {
            this.pvLoginForm();
        }

        private void txtuserId_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && (txtuserId.Text.Trim().ToString() != ""))
            {
                txtsandiUser.Focus();
            }
        }

        private void txtsandiUser_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && (txtsandiUser.Text.Trim().ToString() != ""))
            {
                btnKeluarProgram.Focus();
            }
        }

        private void pvBersihkanForm()
        {
            txtuserId.Text = "";
            txtsandiUser.Text = "";
            txtuserId.Focus();
        }

    }
       


    //public class ConvMatrix
    //{
    //    public int TopLeft = 0, TopMid = 0, TopRight = 0;
    //    public int MidLeft = 0, Pixel = 1, MidRight = 0;
    //    public int BottomLeft = 0, BottomMid = 0, BottomRight = 0;
    //    public int Factor = 1;
    //    public int Offset = 0;
    //    public void SetAll(int nVal)
    //    {
    //        TopLeft = TopMid = TopRight = MidLeft = Pixel = MidRight = BottomLeft = BottomMid = BottomRight = nVal;
    //    }
    //}

    //public class BitmapFilter
    //{
    //    private static bool Conv3x3(Bitmap b, ConvMatrix m)
    //    {
    //        // Avoid divide by zero errors
    //        if (0 == m.Factor) return false;

    //        Bitmap bSrc = (Bitmap)b.Clone();

    //        // GDI+ still lies to us - the return format is BGR, NOT RGB.
    //        BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
    //        BitmapData bmSrc = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

    //        int stride = bmData.Stride;
    //        int stride2 = stride * 2;
    //        System.IntPtr Scan0 = bmData.Scan0;
    //        System.IntPtr SrcScan0 = bmSrc.Scan0;

    //        unsafe
    //        {
    //            byte* p = (byte*)(void*)Scan0;
    //            byte* pSrc = (byte*)(void*)SrcScan0;

    //            int nOffset = stride + 6 - b.Width * 3;
    //            int nWidth = b.Width - 2;
    //            int nHeight = b.Height - 2;

    //            int nPixel;

    //            for (int y = 0; y < nHeight; ++y)
    //            {
    //                for (int x = 0; x < nWidth; ++x)
    //                {
    //                    nPixel = ((((pSrc[2] * m.TopLeft) + (pSrc[5] * m.TopMid) + (pSrc[8] * m.TopRight) +
    //                        (pSrc[2 + stride] * m.MidLeft) + (pSrc[5 + stride] * m.Pixel) + (pSrc[8 + stride] * m.MidRight) +
    //                        (pSrc[2 + stride2] * m.BottomLeft) + (pSrc[5 + stride2] * m.BottomMid) + (pSrc[8 + stride2] * m.BottomRight)) / m.Factor) + m.Offset);

    //                    if (nPixel < 0) nPixel = 0;
    //                    if (nPixel > 255) nPixel = 255;

    //                    p[5 + stride] = (byte)nPixel;

    //                    nPixel = ((((pSrc[1] * m.TopLeft) + (pSrc[4] * m.TopMid) + (pSrc[7] * m.TopRight) +
    //                        (pSrc[1 + stride] * m.MidLeft) + (pSrc[4 + stride] * m.Pixel) + (pSrc[7 + stride] * m.MidRight) +
    //                        (pSrc[1 + stride2] * m.BottomLeft) + (pSrc[4 + stride2] * m.BottomMid) + (pSrc[7 + stride2] * m.BottomRight)) / m.Factor) + m.Offset);

    //                    if (nPixel < 0) nPixel = 0;
    //                    if (nPixel > 255) nPixel = 255;

    //                    p[4 + stride] = (byte)nPixel;

    //                    nPixel = ((((pSrc[0] * m.TopLeft) + (pSrc[3] * m.TopMid) + (pSrc[6] * m.TopRight) +
    //                        (pSrc[0 + stride] * m.MidLeft) + (pSrc[3 + stride] * m.Pixel) + (pSrc[6 + stride] * m.MidRight) +
    //                        (pSrc[0 + stride2] * m.BottomLeft) + (pSrc[3 + stride2] * m.BottomMid) + (pSrc[6 + stride2] * m.BottomRight)) / m.Factor) + m.Offset);

    //                    if (nPixel < 0) nPixel = 0;
    //                    if (nPixel > 255) nPixel = 255;

    //                    p[3 + stride] = (byte)nPixel;

    //                    p += 3;
    //                    pSrc += 3;
    //                }

    //                p += nOffset;
    //                pSrc += nOffset;
    //            }
    //        }

    //        b.UnlockBits(bmData);
    //        bSrc.UnlockBits(bmSrc);

    //        return true;
    //    }

    //    public static bool GaussianBlur(Bitmap b, int nWeight /* default to 4*/)
    //    {
    //        ConvMatrix m = new ConvMatrix();
    //        m.SetAll(1);
    //        m.Pixel = nWeight;
    //        m.TopMid = m.MidLeft = m.MidRight = m.BottomMid = 2;
    //        m.Factor = nWeight + 12;

    //        return BitmapFilter.Conv3x3(b, m);
    //    }
    //}

    //class Screenshot
    //{
    //    public static Bitmap TakeSnapshot(Form ctl)
    //    {
    //        Bitmap bmp = new Bitmap(ctl.Size.Width, ctl.Size.Height);
    //        using (Graphics g = System.Drawing.Graphics.FromImage(bmp))
    //        {
    //            g.CopyFromScreen(
    //                ctl.PointToScreen(ctl.ClientRectangle.Location),
    //                new Point(0, 0), ctl.ClientRectangle.Size
    //            );
    //        }
    //        return bmp;
    //    }
    //}

}
