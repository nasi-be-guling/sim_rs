using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Excel;

namespace SIM_RS.ADMIN
{
    public partial class daftarTarif : Form
    {
        public daftarTarif()
        {
            InitializeComponent();
        }


        /*OWNED FUNCTION*/

        private void pvEnableSatuanForm()
        {
            txtKode.Enabled = true;
            txtKelompok.Enabled = true;
            cmbKelas.Enabled = true;
            txtUraian.Enabled = true;
            txtSMF.Enabled = true;            
            chkDipakai.Enabled = true;

            txtNamaFileExcel.Enabled = false;
            btnLoadExcel.Enabled = false;

            txtNamaFileExcel.Text = "";
        }

        private void pvDisableSatuanForm()
        {
            txtKode.Enabled = false;
            txtKelompok.Enabled = false;
            cmbKelas.Enabled = false;
            txtUraian.Enabled = false;
            txtSMF.Enabled = false;
            chkDipakai.Enabled = false;

            txtNamaFileExcel.Enabled = true;
            btnLoadExcel.Enabled = true;

            txtKode.Text = "";
            txtKelompok.Text = "";
            cmbKelas.Text = "";
            txtUraian.Text = "";
            txtSMF.Text = "";
            chkDipakai.Checked = false;
        }

        

        private bool pvReadFileEXCEL(string _strFilePath)
        {

            FileStream stream = File.Open(_strFilePath, FileMode.Open, FileAccess.Read);
            //1. Reading from a binary Excel file ('97-2003 format; *.xls)
            IExcelDataReader excelReader = null;
            excelReader = ExcelReaderFactory.CreateBinaryReader(stream);

            if (!excelReader.IsValid)
            {
                //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
                excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                MessageBox.Show("EXCEL 2007 Format");                
            }

            //3. DataSet - The result of each spreadsheet will be created in the result.Tables
            DataSet result = excelReader.AsDataSet();
            //4. DataSet - Create column names from first row

            //excelReader.IsFirstRowAsColumnNames = true;
            //DataSet result = excelReader.AsDataSet();

            //5. Data Reader methods
            while (excelReader.Read())
            {
                //excelReader.GetInt32(0);
            }

            //6. Free resources (IExcelDataReader is IDisposable)
            excelReader.Close();
            return true;
        }

        /*EOF PRIVATE FUNCTION*/

        private void btnKeluarIsiTindakan_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void daftarTarif_Load(object sender, EventArgs e)
        {

        }

        private void rbtSatuan_Click(object sender, EventArgs e)
        {
            this.pvEnableSatuanForm();
        }

        private void rbtMulti_Click(object sender, EventArgs e)
        {
            this.pvDisableSatuanForm();
        }

        private void btnLoadExcel_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Cari File EXCEL xls / xlsx";
            openFileDialog1.Filter = "Excel (2003-2007) Files|*.xls;*.xlsx";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                //System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog1.FileName);
                //MessageBox.Show(sr.ReadToEnd());

                this.pvReadFileEXCEL(openFileDialog1.FileName);

                //sr.Close();
            }
        }
    }
}
