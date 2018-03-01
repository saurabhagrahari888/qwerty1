using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmdaniBadhaoSrabh.Models
{
    public class CropClass
    {
        public int CropId { get; set; }
        public string CropName { get; set; }
        public string IrrigationType { get; set; }
        public DateTime SowingDate { get; set; }
        public DateTime Active { get; set; }
        public int LandId { get; set; }

    }
}