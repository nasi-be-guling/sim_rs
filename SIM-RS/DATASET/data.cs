using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIM_RS
{
    public partial class data
    {
        public class lstDaftarTarif
        {
            public string strKodeTarif { get; set; }
            public string strUraianTarif { get; set; }
            public double dblBiaya { get; set; }
            public string strSMF { get; set; }
        }
        public static List<lstDaftarTarif> grpLstDaftarTarif = new List<lstDaftarTarif>();
    }
}
