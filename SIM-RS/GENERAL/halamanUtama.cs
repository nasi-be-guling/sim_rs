using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SIM_RS
{
    public partial class halamanUtama : Form
    {

        C4Module.MainModule modMain = new C4Module.MainModule();
        C4Module.DatabaseModule modDb = new C4Module.DatabaseModule();
        C4Module.MessageModule modMsg = new C4Module.MessageModule();
        C4Module.SQLModule modSQL = new C4Module.SQLModule();

        public DateTime dtTglServer = DateTime.Now;
        public string strUserID = "";

        /*REGISTER - REGEDIT*/
        public static string REG_ROOT = "Software\\ITIKOM";
        public static string REG_NAME_APP = "\\SIM-RS";

        public static string REG_CONN = "\\Conn";
        public static string REG_SETTING = "\\Setting";

        public static string FULL_REG_CONN = REG_ROOT + REG_NAME_APP + REG_CONN;
        public static string FULL_REG_SETTING = REG_ROOT + REG_NAME_APP + REG_SETTING;

        
        /*EOF REGISTER - REGEDIT*/

        /*DEFAULT SETTING SERVER*/
        public static string strIPDBServer = "192.168.2.201";
        public static string strUserDBServer = "sa";
        public static string strPasswordDBServer = "";
        public static string strPortDBServer = "1433";
        public static string strNameDBServer = "BILLING";

        /*EOF DEFAULT SETTING SERVER*/


        /* VARIABLE APP */

        public bool isForceQuit = false;

        /**/



        /*PRIVATE FUNCTION*/

        private void pvInitialApp()
        {

            //string strIniFile = AppDomain.CurrentDomain.BaseDirectory + "/setting.ini";
            //C4Module.IniParser parser = new C4Module.IniParser(strIniFile);

            //string strNamaDB =  parser.GetSetting("connDepo", "nama_database");
            
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
                //MessageBox.Show("Tulis Registry Terlebih Dahulu");
                //this.Close();
            }
            
            isAdaRegistry = modMain.checkRegistry(FULL_REG_SETTING.ToString());
            if (!isAdaRegistry)
            {
                /*jika belum ada, maka ini adalah kali pertama aplikasi dijalankan di PC tersebut..
                 *  oleh karena itu harus menampilkan setting login aplikasi..
                 */
                Registry.CurrentUser.CreateSubKey(FULL_REG_SETTING.ToString());
                C4Module.MainModule.strRegKey = FULL_REG_SETTING;
                //modMain.pbTulisRegistryItem("KodeApotik", "");
                //modMain.pbTulisRegistryItem("KodePoli", "");
                modMain.pbTulisRegistryItem("Aplikasi", "Operator");

              
            }          

        }

        /*EOF PRIVATE FUNCTION*/


        public halamanUtama()
        {
            InitializeComponent();
            this.pvInitialApp();
        }

        private void btnKeluarProgram_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void halamanUtama_Load(object sender, EventArgs e)
        {
            lbDaftarMenu.Items.Clear();

            login fLogin = new login();
            fLogin.ShowDialog();

        }

        private void halamanUtama_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (isForceQuit)
            {
                e.Cancel = false;
                return;
            }

            DialogResult msgDialog = MessageBox.Show("Apakah anda akan keluar dari program", "Informasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (msgDialog == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
        }
    }
}
