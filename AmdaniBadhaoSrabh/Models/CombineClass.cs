using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using System.Xml.XPath;

namespace AmdaniBadhaoSrabh.Models
{
    public class CombineClass
    {
        amdani_badaoEntities1 objdata = new amdani_badaoEntities1();
        user_land_by_crope objulbc = new user_land_by_crope();
        user_map objum = new user_map();
        stf objstf = new stf();
        UpdatedWeatherAnomaly objUpdatedWeatherAnomaly = new UpdatedWeatherAnomaly();
        crop_yield_value objCropYieldValue = new crop_yield_value();
        //----------------------------------
        UserClass ObjUserClass = new UserClass();
        WeatherClass ObjWeatherClass = new WeatherClass();

        //----------------------------------
        public int anomalyvalue;
        //--------------------------For Delete Above Variable
        public int FungalBaseTemp = 12;
        public int FungalMaxTemp = 35;
        public int FungalMeanRh = 75;
        public int ViralBaseTemp = 20;
        public int ViralMaxTemp = 38;
        public int ViralMeanRh = 55;
        public int BacterialBaseTemp = 15;
        public int BacterialMaxTemp = 35;
        public int BacterialMeanRh = 75;
        public int OtherPestBaseTemp = 21;
        public int OtherPestMaxTemp = 40;
        public int OtherPestMeanRh = 50;
        public string jdistrict;
        public int jsowingdate;
        public string wdatec;
        public int monthnumber;
        public string seasonname;
        public string jcropname;
        public double cropyieldvaluestore;
        //Reterieve the long term Anomaly
        string baseurl = "http://xml.customweather.com/xml?client=mahindra&client_password=j2SV7mq&product=cfs_prate_anomaly&id=820074";
        string baseurl1 = "http://xml.customweather.com/xml?client=mahindra&client_password=j2SV7mq&product=cfs_tmp_anomaly&id=820074";

        //----------------------------------
        public string Farmer()
        {
            var joindata = (from t in objdata.user_map
                            join s in objdata.user_land_by_crope on t.User_id equals s.Land_id
                            where s.id == 193
                            select new { s.Irrigation_type, s.Crop_Name, s.Variety_Name, s.Sowing_date, t.Plot_State, t.Plot_District }).FirstOrDefault();
            var joindatadistrict = joindata.Plot_District;
            jdistrict = joindatadistrict;
            var joindatasowingdate = joindata.Sowing_date;
            DateTime a = Convert.ToDateTime(joindatasowingdate);
            var b = a.ToString("dMM");
            var c = Convert.ToInt32(b);
            jsowingdate = c;
            var d = joindata.Crop_Name;
            jcropname = d;

            monthnumber = a.Month;
            if (monthnumber >= 10 || monthnumber <= 3)
            {
                seasonname = "Rabi";
            }
            else if (monthnumber >= 7 || monthnumber < 10)
            {
                seasonname = "Kharif";
            }


            //Return should be specific check.
            return null;
        }
        //    public async string LongTermForecast() //int districtid in parameters
        public string LongTermForecast() //int districtid in parameters to be pass and method should be async with await
        {
            var value = CallApi(baseurl);
            var valueTemp = CallApi(baseurl1);
            //This Method is mainly return the value in the display format in Json
            var list = JsonConvert.SerializeObject(value, Newtonsoft.Json.Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
            double[] Templist = null;
            double[] Precilist = null;
            int[] arraymonths = null;
            foreach (var element in value)
            {
                string anomaly_8 = element.Attributes("anomaly_8").First().Value;
                var p8 = anomaly_8.CompareTo("*") != 0 ? Convert.ToDouble(anomaly_8) : 0;
                string anomaly_7 = element.Attributes("anomaly_7").First().Value;
                var p7 = anomaly_7.CompareTo("*") != 0 ? Convert.ToDouble(anomaly_7) : 0;
                string anomaly_6 = element.Attributes("anomaly_6").First().Value;
                var p6 = anomaly_6.CompareTo("*") != 0 ? Convert.ToDouble(anomaly_6) : 0;
                string anomaly_5 = element.Attributes("anomaly_5").First().Value;
                var p5 = anomaly_5.CompareTo("*") != 0 ? Convert.ToDouble(anomaly_5) : 0;
                string anomaly_4 = element.Attributes("anomaly_4").First().Value;
                var p4 = anomaly_4.CompareTo("*") != 0 ? Convert.ToDouble(anomaly_4) : 0;
                string anomaly_3 = element.Attributes("anomaly_3").First().Value;
                var p3 = anomaly_3.CompareTo("*") != 0 ? Convert.ToDouble(anomaly_3) : 0;
                string anomaly_2 = element.Attributes("anomaly_2").First().Value;
                var p2 = anomaly_2.CompareTo("*") != 0 ? Convert.ToDouble(anomaly_2) : 0;
                string anomaly_1 = element.Attributes("anomaly_1").First().Value;
                var p1 = anomaly_1.CompareTo("*") != 0 ? Convert.ToDouble(anomaly_1) : 0;
                string anomaly_0 = element.Attributes("anomaly_0").First().Value;
                var p0 = anomaly_0.CompareTo("*") != 0 ? Convert.ToDouble(anomaly_0) : 0;

                Precilist = new double[] { p8, p7, p6, p5, p4, p3, p2, p1, p0 };

                var m8 = Convert.ToInt32(element.Attributes("month_8").First().Value.ToString().Substring(4, 2));
                var m7 = Convert.ToInt32(element.Attributes("month_7").First().Value.ToString().Substring(4, 2));
                var m6 = Convert.ToInt32(element.Attributes("month_6").First().Value.ToString().Substring(4, 2));
                var m5 = Convert.ToInt32(element.Attributes("month_5").First().Value.ToString().Substring(4, 2));
                var m4 = Convert.ToInt32(element.Attributes("month_4").First().Value.ToString().Substring(4, 2));
                var m3 = Convert.ToInt32(element.Attributes("month_3").First().Value.ToString().Substring(4, 2));
                var m2 = Convert.ToInt32(element.Attributes("month_2").First().Value.ToString().Substring(4, 2));
                var m1 = Convert.ToInt32(element.Attributes("month_1").First().Value.ToString().Substring(4, 2));
                var m0 = Convert.ToInt32(element.Attributes("month_0").First().Value.ToString().Substring(4, 2));
                arraymonths = new int[] { m8, m7, m6, m5, m4, m3, m2, m1, m0 };

            }
            //Data To call Second api in display
            foreach (var element in valueTemp)
            {
                string anomaly_8 = element.Attributes("anomaly_8").First().Value;
                var p8 = anomaly_8.CompareTo("*") != 0 ? Convert.ToDouble(anomaly_8) : 0;
                string anomaly_7 = element.Attributes("anomaly_7").First().Value;
                var p7 = anomaly_7.CompareTo("*") != 0 ? Convert.ToDouble(anomaly_7) : 0;
                string anomaly_6 = element.Attributes("anomaly_6").First().Value;
                var p6 = anomaly_6.CompareTo("*") != 0 ? Convert.ToDouble(anomaly_6) : 0;
                string anomaly_5 = element.Attributes("anomaly_5").First().Value;
                var p5 = anomaly_5.CompareTo("*") != 0 ? Convert.ToDouble(anomaly_5) : 0;
                string anomaly_4 = element.Attributes("anomaly_4").First().Value;
                var p4 = anomaly_4.CompareTo("*") != 0 ? Convert.ToDouble(anomaly_4) : 0;
                string anomaly_3 = element.Attributes("anomaly_3").First().Value;
                var p3 = anomaly_3.CompareTo("*") != 0 ? Convert.ToDouble(anomaly_3) : 0;
                string anomaly_2 = element.Attributes("anomaly_2").First().Value;
                var p2 = anomaly_2.CompareTo("*") != 0 ? Convert.ToDouble(anomaly_2) : 0;
                string anomaly_1 = element.Attributes("anomaly_1").First().Value;
                var p1 = anomaly_1.CompareTo("*") != 0 ? Convert.ToDouble(anomaly_1) : 0;
                string anomaly_0 = element.Attributes("anomaly_0").First().Value;
                var p0 = anomaly_0.CompareTo("*") != 0 ? Convert.ToDouble(anomaly_0) : 0;

                Templist = new double[] { p8, p7, p6, p5, p4, p3, p2, p1, p0 };
            }
            var a = 3;
            var b = a;
            var dist = (from t in objdata.stfs where t.id == b select new { t.District }).First();
            var wth = (from t in objdata.stfs where t.District == "Andaman" select new { t.Min_Temp, t.Max__Temp, t.Mean_RH, t.Rainfall, t.date_c,t.id }).ToList();
            //--------
            //  var wth = (from t in objdata.stfs where t.District == jdistrict select new { t.Min_Temp, t.Max__Temp, t.Mean_RH, t.Rainfall, t.date_c }).ToList();
            //--------

            // var abc = wth.Where(w => w.date_c >= jsowingdate).Select(w => w).ToList();
            var abc = (from t in wth where t.date_c >= 503 orderby t.id descending select new { t.Min_Temp, t.Max__Temp, t.Mean_RH, t.Rainfall, t.date_c }).ToList();
            //var def = abc.Where(a => a.)
            //Date Time To be Splitted
            DateTime current = DateTime.Now;
            int year = current.Year;
            int month = current.Month;
            int currentyear = year;
            foreach (var item in abc)
            {

                for (int i = 0; i < arraymonths.Length; i++)
                {
                    //Track the year, if not in same year, add one 
                    if (arraymonths[i] == month)
                    {
                        currentyear = year + 1;
                    }
                    else
                    {
                        currentyear = year;
                    }
                    // if (monthnumber == arraymonths[i])
                    if (month == arraymonths[i])
                    {
                        int days = DateTime.DaysInMonth(currentyear, arraymonths[i]);
                        // Now update weather table based on precipation and anamoly
                        objUpdatedWeatherAnomaly.CropAdvisoryId = b;

                        decimal v = Convert.ToDecimal(item.Min_Temp) + Convert.ToDecimal(Templist[i]);
                        decimal abcd = Math.Round(v, 1);
                     //////////   var abcd =((item.Min_Temp) + Convert.ToDecimal(Templist[i]));
                        objUpdatedWeatherAnomaly.UMinTemp = abcd;
                     ////////// var defg = (item.Max__Temp) + Convert.ToDecimal(Templist[i]);
                     decimal w =Convert.ToDecimal(item.Max__Temp) + Convert.ToDecimal(Templist[i]);
                        decimal defg = Math.Round(w, 1);
                        objUpdatedWeatherAnomaly.UMaxTemp = defg;
                        //----
                        double oRnF = Precilist[i] / days;
                        decimal u = Convert.ToDecimal(item.Rainfall) + Convert.ToDecimal(oRnF);
                        decimal Rainf = Math.Round(u, 1);
                        /////// //var Rainf = (item.Rainfall) + Convert.ToDecimal(oRnF);
                        objUpdatedWeatherAnomaly.URainfall = Rainf;
                        decimal q = Convert.ToDecimal(0.25);
                        decimal s = Convert.ToDecimal(99.9);
                        //declare MeanR only for Global declaration
                        decimal t = Convert.ToDecimal((item.Mean_RH)) + Convert.ToDecimal(item.Mean_RH) * Convert.ToDecimal((abcd + defg) / 200);
                        decimal MeanR = Math.Round(t, 1);
                      ///// // var MeanR = ((item.Mean_RH)) + (item.Mean_RH) * ((abcd + defg) / 200);
                        if (Rainf >= q)
                        {
                          objUpdatedWeatherAnomaly.UMeanRh = MeanR;
                        }
                        else if(MeanR >= s)
                        {
                            MeanR = s;
                                objUpdatedWeatherAnomaly.UMeanRh = MeanR;
                            }
                            else if (Rainf >= q)
                            {
                                objUpdatedWeatherAnomaly.UMeanRh = MeanR;
                            }
                         else
                            {
                            objUpdatedWeatherAnomaly.UMeanRh = MeanR;
                        }
                        //To Add data to new Database Create table entities and save into db.
                        objdata.UpdatedWeatherAnomalies.Add(objUpdatedWeatherAnomaly);
                        objdata.SaveChanges();
                    }
                }
            }
            return null;
        }
        //--------------------------------------
        // private async void UpdateShortTermWeatherData(int districtId)
        public string UpdateShortTermWeatherData()//district id and async and await should be use
        {
            //Firstly to call district Name
            //For Checking By bdm Sr   var district = (from t in objdata.dists where t.districtCode == 1 select new { t.name }).First();
            var x = CallApiSmall("http://xml.customweather.com/xml?client=mahindra&client_password=j2SV7mq&product=15day_expanded_forecast&id=820074");
            var wth = (from t in objdata.stfs where t.District == "Andaman" select new { t.Min_Temp, t.Max__Temp, t.Mean_RH, t.Rainfall, t.date_c }).ToList();
            foreach (var element in x)
            {
                //Reterieve the Weather Date
                string[] vals = element.Attributes("iso8601").First().Value.Split('T')[0].Split('-');
                var y = Convert.ToInt32(vals[0]);
                var m = Convert.ToInt32(vals[1]);
                var d = Convert.ToInt32(vals[2]);
                var dt = new DateTime(y, m, d);
                var e = dt.ToString("dMM");
                int g = Convert.ToInt32(e);
               
                var weath = (from t in objdata.stfs where (t.date_c == g) select new { t.date_c, t.Max__Temp, t.Mean_RH, t.Min_Temp, t.Rainfall }).First();
                var val = Convert.ToDouble(element.Attributes("low_temp").First().Value);
                var maxTemp = Convert.ToDouble(element.Attributes("high_temp").First().Value);
                var meanrh = Convert.ToDouble(element.Attributes("humidity").First().Value);
                var rainfall = element.Attributes("rainfall").First().Value == "*" ? 0.0 : Convert.ToDouble(element.Element("rainfall").Value);

            }
            return null;
        }


        //-----------------------------------
        IEnumerable<XElement> CallApi(string url)
        {
            var client = new HttpClient();
            var result = client.GetAsync(url).Result;
            var stream = result.Content.ReadAsStreamAsync().Result;
            var itemXml = XElement.Load(stream);
            var x = from a in itemXml.Elements("location") select a.Element("forecast");
            return x;
        }

        IEnumerable<XElement> CallApiSmall(string url)
        {
            var client = new HttpClient();
            var result = client.GetAsync(url).Result;
            var stream = result.Content.ReadAsStreamAsync().Result;
            var itemXml = XElement.Load(stream);
            var x = from a in itemXml.Elements("location") select a.Element("forecast");
           
            return x;
        }

        public string YieldValues()
        {
            var data = (from t in objdata.crop_yield_value where t.District == jdistrict && t.Season == seasonname && t.Crop == jcropname select t.Yield_kg).Average();
            if (data > 0)
            {
                cropyieldvaluestore = data;
            }
            else if (data == 0)
            {
                var data1 = (from t in objdata.crop_yield_value where t.District == jdistrict && t.Season == "Annual" && t.Crop == jcropname select t.Yield_kg).Average();
                if (data1 > 0)
                {
                    cropyieldvaluestore = data1;
                }
                else if (data1 == 0)
                {
                    var data2 = (from t in objdata.crop_yield_value where t.District == jdistrict && t.Crop == jcropname select t.Yield_kg).Average();
                    if (data2 > 0)
                    {
                        cropyieldvaluestore = data2;
                    }
                    else
                    {
                        cropyieldvaluestore = 0;
                    }
                }
                else
                {
                    cropyieldvaluestore = 0;
                }
                }
            else
            {
                cropyieldvaluestore = 0;
            }
            return null;
        }
         /// <summary>
         /// Work from here--------------------------------------------------------------------------------
         /// </summary>
         /// <returns></returns>
         public string ValuesReturnFromDatabaseInTheFormArray()
        {
 ////here below two line of code is written for Add the values of pe in the list.
 //       public dynamic pe;
 //       public List<dynamic> pevaluesinarray = new List<dynamic>();
 //           var data = (from t in objdata.TestArrays where t.district == "Andaman" select new { t.id, t.state, t.district, t.mintemp, t.maxtemp, t.rainfall, t.humidity }).ToArray();
 //           ////////Here this is written only for to read the values from array one by one in Below code.
 //           if (data != null)
 //           {
 //               for (int i = 0; i < data.Length; i++)
 //               {
 //                   var a = data[i];
 //                   var b = a.district;
 //                   var c = a.humidity;
 //                   var d = a.id;
 //                   var e = a.mintemp;
 //                   var f = a.maxtemp;
 //                   var g = a.rainfall;
 //                   var h = a.state;
 //                   ///pe is new variable to store minimum and maximum values of temprature
 //                   pe = e + f;
 //                   ///below one line code is used to add the pe values in to list and save or use some where.
 //                   pevaluesinarray.Add(pe);
 //               }
 //           }
                return null;
        }

        // public List<object> DiseasePrediction()
        public string DiseasePrediction()
        {
            int temp;
            int rf;
            int rh;
            string severity;
            List<int> FungalTemp = new List<int>();
            List<int> FungalRf = new List<int>();
            List<int> FungalRh = new List<int>();
            List<string> FungalSeverity = new List<string>();
            List<int> ViralTemp = new List<int>();
            List<int> ViralRf = new List<int>();
            List<int> ViralRh = new List<int>();
            List<string> ViralSeverity = new List<string>();
            List<int> BacterialTemp = new List<int>();
            List<int> BacterialRf = new List<int>();
            List<int> BacterialRh = new List<int>();
            List<string> BacterialSeverity = new List<string>();
            List<int> OtherPestTemp = new List<int>();
            List<int> OtherPestRf = new List<int>();
            List<int> OtherPestRh = new List<int>();
            List<string> OtherPestSeverity = new List<string>();
            // int a = anomalyvalue;//Define Anomaly Value at top and use them.

            //Create here List For Storing All data And we take Object Type Because We asses all data From a class and add all the things into list.
            List<object> lst = new List<object>();
            lst.Add(FungalTemp);
            lst.Add(FungalRf);
            lst.Add(FungalRh);
            lst.Add(FungalSeverity);
            //----------------------------------Logix Below------------------------------------//
            var data = (from t in objdata.stfs where t.District == "Andaman" select new { t.id, t.Min_Temp, t.Max__Temp, t.Mean_RH, t.Rainfall }).ToArray();
            for (int i = 0; i < data.Length; i++)
            {

                var a = data[i];
                int b = Convert.ToInt16(data[i].Min_Temp);
                int c = Convert.ToInt16(data[i].Max__Temp);
                int d = Convert.ToInt16(data[i].Rainfall);
                int e = Convert.ToInt16(data[i].Mean_RH);

                //----------------------------------Logix Above------------------------------------//
                //For Fungal Disease Prediction
                //for temp 
                if (b < FungalBaseTemp) // Here a is Mintemp Coming From Anomaly values
                {
                    temp = 1;
                    FungalTemp.Add(temp);
                }
                else if (c >= FungalMaxTemp) // here a is MaxTemp Coming From Anomaly Values
                {
                    temp = 0;
                    FungalTemp.Add(temp);
                }
                else
                {
                    temp = 1;
                    FungalTemp.Add(temp);
                }

                //For Rf
                if (d > 7.5)     //Here a is RainFall Coming from Anomaly data where Save.
                {
                    rf = 1;
                    FungalRf.Add(rf);
                }
                else
                {
                    rf = 0;
                    FungalRf.Add(rf);
                }
                //for rh
                if (e > FungalMeanRh)       //Here A is MeanRh Of anomaly database value which is coming.
                {
                    rh = 1;
                    FungalRh.Add(rh);
                }
                else
                {
                    rh = 0;
                    FungalRh.Add(rh);
                }

                //For Severity
                if (temp + rf + rh == 3)
                {
                    severity = "High Risk";
                    FungalSeverity.Add(severity);
                }
                else if (temp + rh + rf == 2)
                {
                    severity = "Low Risk";
                    FungalSeverity.Add(severity);
                }
                else if (temp + rh + rf == 1)
                {
                    severity = "Monitor";
                    FungalSeverity.Add(severity);
                }
                else
                {
                    severity = "No Risk";
                    FungalSeverity.Add(severity);
                }
                //// For Viral Disease Prediction----
                //for temp
                if (b >= ViralBaseTemp)
                {
                    temp = 1;
                    ViralTemp.Add(temp);
                }
                else if (c <= ViralMaxTemp)
                {
                    temp = 0;
                    ViralTemp.Add(temp);
                }
                else
                {
                    temp = 1;
                    ViralTemp.Add(temp);
                }
                // for rf
                if (d > 2.5)
                {
                    rf = 0;
                    ViralRf.Add(rf);
                }
                else
                {
                    rf = 1;
                    ViralRf.Add(rf);
                }
                ////for rh
                if (e < ViralMeanRh)
                {
                    rh = 1;
                    ViralRh.Add(rh);
                }
                else
                {
                    rh = 0;
                    ViralRh.Add(rh);
                }
                ////For severity
                if (temp + rh + rf == 3)
                {
                    severity = "High Risk";
                    ViralSeverity.Add(severity);
                }
                else if (temp + rh + rf == 2)
                {
                    severity = "Low Risk";
                    ViralSeverity.Add(severity);
                }
                else if (temp + rh + rf == 1)
                {
                    severity = "Monitor";
                    ViralSeverity.Add(severity);
                }
                else
                {
                    severity = "No Risk";
                    ViralSeverity.Add(severity);
                }
                /////For Bacterial Disease Prediction
                //for temp
                if (b >= BacterialBaseTemp)
                {
                    temp = 1;
                    BacterialTemp.Add(temp);
                }
                else if (c <= BacterialMaxTemp)
                {
                    temp = 0;
                    BacterialTemp.Add(temp);
                }
                else
                {
                    temp = 1;
                    BacterialTemp.Add(temp);
                }
                ////for rf
                if (d > 2.5)
                {
                    rf = 0;
                    BacterialRf.Add(rf);
                }
                else
                {
                    rf = 1;
                    BacterialRf.Add(rf);
                }
                ////for rh
                if (e < BacterialMeanRh)
                {
                    rh = 1;
                    BacterialRh.Add(rh);
                }
                else
                {
                    rh = 0;
                    BacterialRh.Add(rh);
                }
                /////for severity 
                if (temp + rf + rh == 3)
                {
                    severity = "High Risk";
                    BacterialSeverity.Add(severity);
                }
                else if (temp + rh + rf == 2)
                {
                    severity = "Low Risk";
                    BacterialSeverity.Add(severity);
                }
                else if (temp + rh + rf == 1)
                {
                    severity = "Monitor";
                    BacterialSeverity.Add(severity);
                }
                else
                {
                    severity = "No Risk";
                    BacterialSeverity.Add(severity);
                }
                ////For other Pest Prediction 
                //for temp
                if (b >= OtherPestBaseTemp)
                {
                    temp = 1;
                    OtherPestTemp.Add(temp);
                }
                else if (c <= OtherPestMaxTemp)
                {
                    temp = 0;
                    OtherPestTemp.Add(temp);
                }
                else
                {
                    temp = 1;
                    OtherPestTemp.Add(temp);
                }
                //for rf
                {
                    if (d > 2.5)
                    {
                        rf = 0;
                        OtherPestRf.Add(rf);
                    }
                    else
                    {
                        rf = 1;
                        OtherPestRf.Add(rf);
                    }
                }
                //For rh
                if (e < OtherPestMeanRh)
                {
                    rh = 1;
                    OtherPestRh.Add(rh);
                }
                else
                {
                    rh = 0;
                    OtherPestRh.Add(rh);
                }
                /////for severity 
                if (temp + rf + rh == 3)
                {
                    severity = "High Risk";
                    OtherPestSeverity.Add(severity);
                }
                else if (temp + rh + rf == 2)
                {
                    severity = "Low Risk";
                    OtherPestSeverity.Add(severity);
                }
                else if (temp + rh + rf == 1)
                {
                    severity = "Monitor";
                    OtherPestSeverity.Add(severity);
                }
                else
                {
                    severity = "No Risk";
                    OtherPestSeverity.Add(severity);
                }
            }
            return null;
           
        }
               
       //-------------All Functions should be end Above 
        }


    }
