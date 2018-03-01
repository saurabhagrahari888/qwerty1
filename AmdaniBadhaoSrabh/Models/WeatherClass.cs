using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmdaniBadhaoSrabh.Models
{
    public class WeatherClass
    {
        public int Id { get; set; }
        public int DistrictId { get; set; }
        public double? MinTemp { get; set; }
        public double? MaxTemp { get; set; }
        public double? MeanRh { get; set; }
        public double? Rainfall { get; set; }
        public string DateC { get; set; }
        public int BaseweatherId { get; set; }
    }
}