using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Data.SqlClient;
using System.Reflection;
using System.Runtime.InteropServices;



namespace SIM_RS
{
    public partial class halamanUtama : Form
    {

        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEMTIME
        {
            public short wYear;
            public short wMonth;
            public short wDayOfWeek;
            public short wDay;
            public short wHour;
            public short wMinute;
            public short wSecond;
            public short wMilliseconds;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetSystemTime(ref SYSTEMTIME st);

        C4Module.MainModule modMain = new C4Module.MainModule();
        C4Module.DatabaseModule modDb = new C4Module.DatabaseModule();
        C4Module.MessageModule modMsg = new C4Module.MessageModule();
        C4Module.SQLModule modSQL = new C4Module.SQLModule();

        /* DEFAULT PUBLIC READ ONLY REGISTER - REGEDIT*/
        public static string REG_ROOT = "Software\\ITIKOM";
        public static string REG_NAME_APP = "\\SIM-RS";

        public static string REG_CONN = "\\Conn";
        public static string REG_SETTING = "\\Setting";

        public static string FULL_REG_CONN = REG_ROOT + REG_NAME_APP + REG_CONN;
        public static string FULL_REG_SETTING = REG_ROOT + REG_NAME_APP + REG_SETTING;

        public static DateTime dtTglServer = DateTime.Now;
        public static string strUserID = "";
        public static string strNamaUser = "";
        /* EOF DEFAULT PUBLIC READ ONLY REGISTER - REGEDIT*/


        /* DEFAULT PUBLIC READONLY VARIABLE CONNECTION SERVER */
        public static string strIPDBServer = "192.168.2.5";
        public static string strUserDBServer = "sa";
        public static string strPasswordDBServer = "";
        public static string strPortDBServer = "1032";
        public static string strNameDBServer = "BILLING";
        /* EOF DEFAULT PUBLIC READONLY VARIABLE CONNECTION SERVER */


        /* PUBLIC !READONLY VARIABLE APP */
        public bool isForceQuit = false;
        //public DateTime dtTglServer = DateTime.Now;
       

        public string strShiftPegawai = "";
        /* EOF PUBLIC !READONLY VARIABLE APP */


        /* PRIVATE VARIABLE */

        string strQuerySQL = "";
        string strErr = "";

        /* EOF PRIVATE VARIABLE */      



        /*PRIVATE FUNCTION*/

        private void pvAsignColor()
        {

            //Color clrBack = System.Drawing.ColorTranslator.FromHtml("#cecece");
            //Color clrBackForm = System.Drawing.ColorTranslator.FromHtml("#F1F1F1");
            //Color clrBackButton = System.Drawing.ColorTranslator.FromHtml("#DD4B39");
            //Color clrBackTitle = System.Drawing.ColorTranslator.FromHtml("#333333");
            //Color clrFontTitleColor = System.Drawing.ColorTranslator.FromHtml("#F1F1F1");

            //panel1.BackColor = clrBack;
            //panel2.BackColor = clrBack;
            //btnKeluarProgram.BackColor = clrBackButton;

            //label5.BackColor = clrBackTitle;
            //label5.ForeColor = clrFontTitleColor;


            //this.BackColor = clrBackForm;

        }




        /*
         *  NAME        : pvInitialApp
         *  FUNCTION    : Load initial variable that needed for application to run.
         *  RESULT      : -
         *  CREATED     : Eka Rudito (eka@rudito.web.id)
         *  DATE        : 15-02-2013
         */
        private void pvInitialApp()
        {
            bool isAdaRegistry = modMain.checkRegistry(FULL_REG_CONN.ToString());

            

            if (!isAdaRegistry)
            {
                /*jika belum ada, maka ini adalah kali pertama aplikasi dijalankan di PC tersebut..
                 *  oleh karena itu harus menampilkan setting login aplikasi..
                 */
                Registry.CurrentUser.CreateSubKey(FULL_REG_CONN.ToString());
                modMain.pbTulisRegistry(
                            strUserDBServer, 
                            strPasswordDBServer, 
                            strIPDBServer, 
                            strPortDBServer, 
                            strNameDBServer, 
                            FULL_REG_CONN.ToString());
            }
            
            isAdaRegistry = modMain.checkRegistry(FULL_REG_SETTING.ToString());
            if (!isAdaRegistry)
            {
                /*jika belum ada, maka ini adalah kali pertama aplikasi dijalankan di PC tersebut..
                 *  oleh karena itu harus menampilkan setting login aplikasi..
                 */
                Registry.CurrentUser.CreateSubKey(FULL_REG_SETTING.ToString());
                C4Module.MainModule.strRegKey = FULL_REG_SETTING;               
                modMain.pbTulisRegistryItem("Aplikasi", "Operator");

              
            }

            /*..READ SETTING FROM REGEDIT..*/
            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_CONN;
            modMain.pbBacaRegistry(ref strNameDBServer, ref strPasswordDBServer, ref strIPDBServer, ref strPortDBServer, ref strNameDBServer);

        }


        /*
        *  NAME        : pvLoadInfoUser
        *  FUNCTION    : Load data from Database info about user and privileges.
        *  RESULT      : info user on main form widget and list of privileges on listbox
        *  CREATED     : Eka Rudito (eka@rudito.web.id)
        *  DATE        : 15-02-2013
        */
        public void pvLoadInfoUser(string _strUserID)
        {
            lbDaftarMenu.Items.Clear();

            this.strErr = "";
            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_CONN;

            SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                return;
            }



            string strUserID = _strUserID;

            strQuerySQL = "SELECT BILHAKAKSES.idPetugas, BILHAKAKSES.idProgram, BILHAKAKSES.Grup, BILHAKAKSES.Urut " +
                          "FROM BILHAKAKSES "+
                            "LEFT JOIN BILPROGRAM ON BILPROGRAM.idProgram = BILHAKAKSES.idProgram " +
                          "WHERE BILHAKAKSES.idPetugas = '" + strUserID + 
                            "' AND BILPROGRAM.NamaFormERD IS NOT NULL "+
                            "AND BILPROGRAM.NamaFormERD <> ''";

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
                    lbDaftarMenu.Items.Add(modMain.pbstrgetCol(reader,1,ref strErr,""));
                }          
            }

            reader.Close();
            conn.Close();
        }


        /*
       *  NAME        : pvLoadForm
       *  FUNCTION    : call form within name from database.
       *  RESULT      : -
       *  CREATED     : Eka Rudito (eka@rudito.web.id)
       *  DATE        : 15-02-2013
       */
        private void pvLoadForm(string _strIDMenu)
        {

            string strNamaMenu = "";

            this.strErr = "";
            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_CONN;

            SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                return;
            }


            strQuerySQL = "SELECT NamaFormERD " +
                          "FROM BILPROGRAM " +
                          "WHERE idProgram = '" + _strIDMenu + "'";

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
                strNamaMenu = modMain.pbstrgetCol(reader, 0, ref strErr, "");
            }

            reader.Close();
            conn.Close();

            string strDefaultProjectName = "SIM_RS.";

            Type formType = Type.GetType(strDefaultProjectName + strNamaMenu);

            Form fLoadForm = modMain.pvfCekForm(formType);        

            try
            {

                ConstructorInfo ciInit = formType.GetConstructor(System.Type.EmptyTypes);
                Form fFormLoad = (Form)ciInit.Invoke(null);
                fFormLoad.Icon = this.Icon;
                fFormLoad.StartPosition = FormStartPosition.CenterScreen;
                fFormLoad.WindowState = FormWindowState.Maximized;
                fFormLoad.ShowDialog();
                     
            }
            catch (Exception)
            {
                MessageBox.Show("Form tidak dapat ditampilkan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


        }

        private void pvLoadInitialData()
        {

            this.strErr = "";
            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_CONN;

            SqlConnection conn = modDb.pbconnKoneksiSQL(ref strErr);
            if (strErr != "")
            {
                modMsg.pvDlgErr(modMsg.IS_DEV, strErr, modMsg.DB_CON, modMsg.TITLE_ERR);
                return;
            }
            
            strQuerySQL = "SELECT GETDATE()";

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
                halamanUtama.dtTglServer = Convert.ToDateTime(modMain.pbstrgetCol(reader,0,ref strErr,""));
            }

            reader.Close();
            conn.Close();

        }

        /*EOF PRIVATE FUNCTION*/


        public halamanUtama()
        {
            InitializeComponent();

            this.pvAsignColor();

            this.pvInitialApp();
            this.pvLoadInitialData();
            
        }

        private void btnKeluarProgram_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void halamanUtama_Load(object sender, EventArgs e)
        {
            /* i don't know this need administrator user or not */            

            //SYSTEMTIME st = new SYSTEMTIME();
            //st.wYear = Convert.ToInt16(dtTglServer.ToString("yyyy")); // must be short
            //st.wMonth = Convert.ToInt16(dtTglServer.ToString("MM"));
            //st.wDay = Convert.ToInt16(dtTglServer.ToString("dd"));
            //st.wHour = Convert.ToInt16(dtTglServer.ToString("HH"));
            //st.wMinute = Convert.ToInt16(dtTglServer.ToString("mm"));
            //st.wSecond = Convert.ToInt16(dtTglServer.ToString("ss"));
            

            //SetSystemTime(ref st); // invoke this method.

            //MessageBox.Show(dtTglServer.ToString("dd MMMM yyyy HH:mm:ss"));

            tssInfoServer.Text = "Server : " + strIPDBServer.ToString();
            timerWaktu.Interval = 1000;
            timerWaktu.Enabled = true;

            this.KeyPreview = true;

            lbDaftarMenu.Items.Clear();

        }

        private void halamanUtama_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (isForceQuit)
            {
                e.Cancel = false;
                return;
            }

            DialogResult msgDialog = MessageBox.Show("Apakah anda akan keluar dari program", "Informasi", 
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (msgDialog == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
        }

        private void lbDaftarMenu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {             
                string strSelectedMenu = lbDaftarMenu.SelectedItem.ToString();
                this.pvLoadForm(strSelectedMenu);
            }
        }

        private void lbDaftarMenu_DoubleClick(object sender, EventArgs e)
        {
            string strSelectedMenu = lbDaftarMenu.SelectedItem.ToString();
            this.pvLoadForm(strSelectedMenu);
        }

        private void halamanUtama_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void halamanUtama_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void halamanUtama_Activated(object sender, EventArgs e)
        {
            lbDaftarMenu.Select();

            if (lbDaftarMenu.Items.Count > 0)
            {
                lbDaftarMenu.SelectedIndex = 0;

            }

        }

        private void halamanUtama_Leave(object sender, EventArgs e)
        {

        }      

        private void timerWaktu_Tick(object sender, EventArgs e)
        {
            tssTglLengkap.Text = DateTime.Now.ToString("dd MMMM yyyy") + " " + DateTime.Now.ToString("HH:mm:ss");

        }

        private void halamanUtama_Shown(object sender, EventArgs e)
        {
            login fLogin = new login();
            fLogin.ShowDialog();

            strNamaUser = txtPetugas.Text;
        }

        private void halamanUtama_Paint(object sender, PaintEventArgs e)
        {
            //Bitmap bmpBlurr = Screenshot.TakeSnapshot(this);
            //BitmapFilter.GaussianBlur(bmpBlurr, 1);


            //pbScreenCapture.Image = bmpBlurr;
            //pbScreenCapture.Dock = DockStyle.Fill;
            //pbScreenCapture.BringToFront();
            //pbScreenCapture.Visible = true;
        }

       
    }


    

}
