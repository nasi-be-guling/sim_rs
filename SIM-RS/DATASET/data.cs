using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIM_RS
{
    class data
    {
        public class lstDaftarTarif
        {
            public string strKodeTarif { get; set; }
            public string strUraianTarif { get; set; }
            public double dblBiaya { get; set; }
            public string strSMF { get; set; }
        }
        public static List<lstDaftarTarif> grpLstDaftarTarif = new List<lstDaftarTarif>();

        public class lstDaftarDokter
        {
            public string strKodeDokter { get; set; }
            public string strNamaDokter { get; set; }
            public string strSMF { get; set; }
        }
        public static List<lstDaftarDokter> grpLstDaftarDokter = new List<lstDaftarDokter>();

        public class lstTempatLayanan
        {
            public string strKodeRuang { get; set; }
            public string strNamaRuang { get; set; }
        }
        public static List<lstTempatLayanan> grpLstTempatLayanan = new List<lstTempatLayanan>();

    }
}
