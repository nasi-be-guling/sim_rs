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
        C4Module.EncryptModule modEncrypt = new C4Module.EncryptModule();

        /* DEFAULT PUBLIC READ ONLY REGISTER - REGEDIT*/
        
        public static string REG_ROOT = "Software\\ITIKOM";
        public static string REG_NAME_APP = "\\SIM-RS";

        public static string REG_BILLING_LAMA = "\\REG_BILLING_LAMA";
        public static string REG_BILLING_ERM = "\\REG_BILLING_ERM";
        public static string REG_ERM = "\\REG_ERM";


        public static string REG_SETTING = "\\Setting";

        public static string FULL_REG_BILLING_LAMA = REG_ROOT + REG_NAME_APP + REG_BILLING_LAMA;
        public static string FULL_REG_BILLING_ERM = REG_ROOT + REG_NAME_APP + REG_BILLING_ERM;
        public static string FULL_REG_ERM = REG_ROOT + REG_NAME_APP + REG_ERM;
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

        public static string strIPDBServer1 = "192.168.3.250";
        public static string strUserDBServer1 = "sa";
        public static string strPasswordDBServer1 = "ServerInkomFujitsu!23";
        public static string strPortDBServer1 = "1433";
        public static string strNameDBServer1 = "BILLING_NEW";

        public static string strIPDBServer2 = "192.168.3.250";
        public static string strUserDBServer2 = "sa";
        public static string strPasswordDBServer2 = "ServerInkomFujitsu!23";
        public static string strPortDBServer2 = "1433";
        public static string strNameDBServer2 = "ERM";
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


        /* HOLD VARIABLE OTHER FORM*/

        public class lstDaftarTarif
        {

            public string strKodeTarif { get; set; }
            public string strUraianTarif { get; set; }
            public double dblBiaya { get; set; }
            public string strSMF { get; set; }

        }
        public List<lstDaftarTarif> grpLstDaftarTarif = new List<lstDaftarTarif>();

        /* */


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
            //string strPlainText = "";
            bool isAdaRegistry = modMain.checkRegistry(FULL_REG_BILLING_LAMA.ToString());
            if (!isAdaRegistry)
            {
                /*jika belum ada, maka ini adalah kali pertama aplikasi dijalankan di PC tersebut..
                 *  oleh karena itu harus menampilkan setting login aplikasi..
                 */
                Registry.CurrentUser.CreateSubKey(FULL_REG_BILLING_LAMA.ToString());
                string strSandi = modEncrypt.EncryptToString(strPasswordDBServer);
                modMain.pbTulisRegistry(
                            strUserDBServer,
                            strSandi,
                            strIPDBServer,
                            strPortDBServer,
                            strNameDBServer,
                            FULL_REG_BILLING_LAMA.ToString());

                Registry.CurrentUser.CreateSubKey(FULL_REG_BILLING_ERM.ToString());
                string strSandi1 = modEncrypt.EncryptToString(strPasswordDBServer1);
                modMain.pbTulisRegistry(
                            strUserDBServer1,
                            strSandi1,
                            strIPDBServer1,
                            strPortDBServer1,
                            strNameDBServer1,
                            FULL_REG_BILLING_ERM.ToString());

                Registry.CurrentUser.CreateSubKey(FULL_REG_ERM.ToString());
                string strSandi2 = modEncrypt.EncryptToString(strPasswordDBServer2);
                modMain.pbTulisRegistry(
                            strUserDBServer2,
                            strSandi2,
                            strIPDBServer2,
                            strPortDBServer2,
                            strNameDBServer2,
                            FULL_REG_ERM.ToString());
            }
            else
            {
                C4Module.MainModule.strRegKey = FULL_REG_BILLING_LAMA; 
                string EncryptSandi = modEncrypt.EncryptToString(strPasswordDBServer);
                modMain.pbTulisRegistryItem("sql_akun_sandi", EncryptSandi);

                C4Module.MainModule.strRegKey = FULL_REG_BILLING_ERM;
                string EncryptSandi1 = modEncrypt.EncryptToString(strPasswordDBServer1);
                modMain.pbTulisRegistryItem("sql_akun_sandi", EncryptSandi1);

                C4Module.MainModule.strRegKey = FULL_REG_ERM;
                string EncryptSandi2 = modEncrypt.EncryptToString(strPasswordDBServer2);
                modMain.pbTulisRegistryItem("sql_akun_sandi", EncryptSandi2);
                
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
            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_BILLING_LAMA;
            modMain.pbBacaRegistry(
                                ref strNameDBServer, 
                                ref strPasswordDBServer, 
                                ref strIPDBServer, 
                                ref strPortDBServer, 
                                ref strNameDBServer);

            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_BILLING_ERM;
            modMain.pbBacaRegistry(
                                ref strNameDBServer1, 
                                ref strPasswordDBServer1, 
                                ref strIPDBServer1, 
                                ref strPortDBServer1, 
                                ref strNameDBServer1);

            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_ERM;
            modMain.pbBacaRegistry(
                                ref strNameDBServer2, 
                                ref strPasswordDBServer2, 
                                ref strIPDBServer2, 
                                ref strPortDBServer2, 
                                ref strNameDBServer2);

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
            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_BILLING_LAMA;

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
                            "AND BILPROGRAM.NamaFormERD <> '' "+
                            "ORDER BY BILHAKAKSES.urut ASC";

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
            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_BILLING_LAMA;

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
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


        }

        private void pvLoadInitialData()
        {

            this.strErr = "";
            C4Module.MainModule.strRegKey = halamanUtama.FULL_REG_BILLING_LAMA;

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

            //this.Location = Owner.Location;

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
      
       
    }


    

}
