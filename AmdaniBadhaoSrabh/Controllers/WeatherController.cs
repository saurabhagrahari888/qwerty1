using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using System.Xml;
using System.Net.Http;
using Newtonsoft.Json;

//
using AmdaniBadhaoSrabh.Models;

namespace AmdaniBadhaoSrabh.Controllers
{
    public class WeatherController : Controller
    {
        //amdani_badaoEntities objdata = new amdani_badaoEntities();
        //user_land_by_crope objulbc = new user_land_by_crope();
        //user_map objum = new user_map();
        //stf objstf = new stf();
        //Class Objects
        CombineClass ObjCombineClass = new CombineClass();
        UserClass ObjUserClass = new UserClass();
        CropClass ObjCropClass = new CropClass();
        VarietyClass ObjVarietyClass = new VarietyClass();
        WeatherClass ObjWeatherClass = new WeatherClass();
        // GET: Weather
        //public string jdistrict;
        //public int jsowingdate;
        //public string wdatec;
        public ActionResult Index()
        {
            // var a = ObjCombineClass.UpdateShortTermWeatherData();
            var a = ObjCombineClass.DiseasePrediction();
            //var joindata = (from t in objdata.user_map
            //                join s in objdata.user_land_by_crope on t.User_id equals s.Land_id
            //                where s.id == 193
            //                select new { s.Irrigation_type, s.Crop_Name, s.Variety_Name, s.Sowing_date, t.Plot_State, t.Plot_District }).FirstOrDefault();
            //var joindatadistrict = joindata.Plot_District;
            //jdistrict = joindatadistrict;
            //var joindatasowingdate = joindata.Sowing_date;
            //DateTime a = Convert.ToDateTime(joindatasowingdate);
            //var b = a.ToString("dMM");
            //var c = Convert.ToInt32(b);
            //jsowingdate = c;
            //var joindatacropname = joindata.Crop_Name;

            // return Json(b, JsonRequestBehavior.AllowGet); 
             return View();
        }

        //For ApiCall All The Values-----New C
        //string baseurl = "http://xml.customweather.com/xml?client=mahindra&client_password=j2SV7mq&product=cfs_prate_anomaly&id=820074";
        //string baseurl1 = "http://xml.customweather.com/xml?client=mahindra&client_password=j2SV7mq&product=cfs_tmp_anomaly&id=820074";
        public async Task<ActionResult> LongTermForecast()
        {
            //var value = CallApi(baseurl);
            //var valueTemp = CallApi(baseurl1);
            ////This Method is mainly return the value in the display format in Json
            //var list = JsonConvert.SerializeObject(value, Newtonsoft.Json.Formatting.None, new JsonSerializerSettings()
            //{
            //    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            //});
            //double[] Templist = null;
            //double[] Precilist = null;
            //int[] arraymonths = null;
            //foreach (var element in value)
            //{
            //    string anomaly_8 = element.Attributes("anomaly_8").First().Value;
            //    var p8 = anomaly_8.CompareTo("*") != 0 ? Convert.ToDouble(anomaly_8) : 0;
            //    string anomaly_7 = element.Attributes("anomaly_7").First().Value;
            //    var p7 = anomaly_7.CompareTo("*") != 0 ? Convert.ToDouble(anomaly_7) : 0;
            //    string anomaly_6 = element.Attributes("anomaly_6").First().Value;
            //    var p6 = anomaly_6.CompareTo("*") != 0 ? Convert.ToDouble(anomaly_6) : 0;
            //    string anomaly_5 = element.Attributes("anomaly_5").First().Value;
            //    var p5 = anomaly_5.CompareTo("*") != 0 ? Convert.ToDouble(anomaly_5) : 0;
            //    string anomaly_4 = element.Attributes("anomaly_4").First().Value;
            //    var p4 = anomaly_4.CompareTo("*") != 0 ? Convert.ToDouble(anomaly_4) : 0;
            //    string anomaly_3 = element.Attributes("anomaly_3").First().Value;
            //    var p3 = anomaly_3.CompareTo("*") != 0 ? Convert.ToDouble(anomaly_3) : 0;
            //    string anomaly_2 = element.Attributes("anomaly_2").First().Value;
            //    var p2 = anomaly_2.CompareTo("*") != 0 ? Convert.ToDouble(anomaly_2) : 0;
            //    string anomaly_1 = element.Attributes("anomaly_1").First().Value;
            //    var p1 = anomaly_1.CompareTo("*") != 0 ? Convert.ToDouble(anomaly_1) : 0;
            //    string anomaly_0 = element.Attributes("anomaly_0").First().Value;
            //    var p0 = anomaly_0.CompareTo("*") != 0 ? Convert.ToDouble(anomaly_0) : 0;

            //    Precilist = new double[] { p8, p7, p6, p5, p4, p3, p2, p1, p0 };

            //    var m8 = Convert.ToInt32(element.Attributes("month_8").First().Value.ToString().Substring(4, 2));
            //    var m7 = Convert.ToInt32(element.Attributes("month_7").First().Value.ToString().Substring(4, 2));
            //    var m6 = Convert.ToInt32(element.Attributes("month_6").First().Value.ToString().Substring(4, 2));
            //    var m5 = Convert.ToInt32(element.Attributes("month_5").First().Value.ToString().Substring(4, 2));
            //    var m4 = Convert.ToInt32(element.Attributes("month_4").First().Value.ToString().Substring(4, 2));
            //    var m3 = Convert.ToInt32(element.Attributes("month_3").First().Value.ToString().Substring(4, 2));
            //    var m2 = Convert.ToInt32(element.Attributes("month_2").First().Value.ToString().Substring(4, 2));
            //    var m1 = Convert.ToInt32(element.Attributes("month_1").First().Value.ToString().Substring(4, 2));
            //    var m0 = Convert.ToInt32(element.Attributes("month_0").First().Value.ToString().Substring(4, 2));
            //    arraymonths = new int[] { m8, m7, m6, m5, m4, m3, m2, m1, m0 };

            //}
            ////Data To call Second api in display
            //foreach (var element in valueTemp)
            //{
            //    string anomaly_8 = element.Attributes("anomaly_8").First().Value;
            //    var p8 = anomaly_8.CompareTo("*") != 0 ? Convert.ToDouble(anomaly_8) : 0;
            //    string anomaly_7 = element.Attributes("anomaly_7").First().Value;
            //    var p7 = anomaly_7.CompareTo("*") != 0 ? Convert.ToDouble(anomaly_7) : 0;
            //    string anomaly_6 = element.Attributes("anomaly_6").First().Value;
            //    var p6 = anomaly_6.CompareTo("*") != 0 ? Convert.ToDouble(anomaly_6) : 0;
            //    string anomaly_5 = element.Attributes("anomaly_5").First().Value;
            //    var p5 = anomaly_5.CompareTo("*") != 0 ? Convert.ToDouble(anomaly_5) : 0;
            //    string anomaly_4 = element.Attributes("anomaly_4").First().Value;
            //    var p4 = anomaly_4.CompareTo("*") != 0 ? Convert.ToDouble(anomaly_4) : 0;
            //    string anomaly_3 = element.Attributes("anomaly_3").First().Value;
            //    var p3 = anomaly_3.CompareTo("*") != 0 ? Convert.ToDouble(anomaly_3) : 0;
            //    string anomaly_2 = element.Attributes("anomaly_2").First().Value;
            //    var p2 = anomaly_2.CompareTo("*") != 0 ? Convert.ToDouble(anomaly_2) : 0;
            //    string anomaly_1 = element.Attributes("anomaly_1").First().Value;
            //    var p1 = anomaly_1.CompareTo("*") != 0 ? Convert.ToDouble(anomaly_1) : 0;
            //    string anomaly_0 = element.Attributes("anomaly_0").First().Value;
            //    var p0 = anomaly_0.CompareTo("*") != 0 ? Convert.ToDouble(anomaly_0) : 0;

            //    Templist = new double[] { p8, p7, p6, p5, p4, p3, p2, p1, p0 };
            //}

            //district should be compare with value which come's from usermap plot_District
            //var wth = (from t in objdata.stfs where t.District ==  jdistrict select new { t.Min_Temp, t.Max__Temp, t.Mean_RH, t.Rainfall, t.date_c }).ToList();
            //var abc = wth.Where(w => w.date_c >= jsowingdate).Select(w => w).ToList();
            ////Date Time To be Splitted
            //DateTime current = DateTime.Now;
            //int year = current.Year;
            //int month = current.Month;
            //int currentyear = year;

            //foreach(WeatherClass weather in abc)
            //{
            //    for(int i =0;i< arraymonths.Length; i++)
            //    {

            //    }

            //}

            //return Json(Precilist, JsonRequestBehavior.AllowGet);
            return View();
        }

        //IEnumerable<XElement> CallApi(string url)
        //{
        //    var client = new HttpClient();
        //    var result = client.GetAsync(url).Result;
        //    var stream = result.Content.ReadAsStreamAsync().Result;
        //    var itemXml = XElement.Load(stream);
        //    var x = from a in itemXml.Elements("location")
        //            select a.Element("forecast");
        //    return x;

        //}
    }
}