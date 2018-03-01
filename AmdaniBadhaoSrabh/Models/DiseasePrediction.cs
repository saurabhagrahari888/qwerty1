using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmdaniBadhaoSrabh.Models
{
    public class DiseasePrediction
    {
        //public int FungalTemp;
        //public int FungalRf;
        //public int FungalRh;
        //public string FungalSeverity;
       public int ViralTemp;
        public int ViralRf;
        public int ViralRh;
        public string ViralSeverity;
      public int BacterialTemp ;
        public int BacterialRf;
        public int BacterialRh;
        public string BacterialSeverity;
        public int OtherPestTemp;
         public int OtherPestRf;
          public int OtherPestRh;
        public string OtherPestSeverity;

        //-----------------------
        List<int> FungalTemp = new List<int>();
        List<int> FungalRf = new List<int>();
        List<int> FungalRh = new List<int>();
        List<string> FungalSeverity = new List<string>();
    }
}