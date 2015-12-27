using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Text.RegularExpressions;

namespace HomeManagementSite
{
    public class CurrencyConverter
    {

        public static string CurrencyConvert(decimal amount, string fromCurrency, string toCurrency)
        {
            if(fromCurrency == toCurrency)
            {
                return amount.ToString();
            }
            //Grab your values and build your Web Request to the API
            string apiURL = String.Format("https://www.google.com/finance/converter?a={0}&from={1}&to={2}&meta={3}", amount, fromCurrency, toCurrency, Guid.NewGuid().ToString());

            //Make your Web Request and grab the results
            var request = WebRequest.Create(apiURL);

            //Get the Response
            var streamReader = new StreamReader(request.GetResponse().GetResponseStream(), System.Text.Encoding.ASCII);

            //Grab your converted value (ie 2.45 USD)
            var result = Regex.Matches(streamReader.ReadToEnd(), "<span class=\"?bld\"?>([^<]+)</span>")[0].Groups[1].Value;

            //Get the Result
            return result;
        }

        //public static Dictionary<string, double> convRates = new Dictionary<string, double>() {
        //    { "ILSCAD", 0.36 },
        //    { "ILSUSD", 0.26 },
        //    {"CADILS", 2.81 },
        //    { "CADUSD", 0.73 },

        //    { "USDCAD", 1.37 },
        //    { "USDILS", 3.85 },

        //    { "USDUSD", 1 },
        //    { "CADCAD", 1 },
        //    { "ILSILS", 1 }
        //};

        public static Dictionary<string, double> convRates = new Dictionary<string, double>();

        public static double GetConvertionRate(string fromCurrency, string toCurrency)
        {
            double convRate;
            if (convRates.TryGetValue(fromCurrency + toCurrency, out convRate))
            {
                return convRate;
            }
            else
            {
                string convRateStr = CurrencyConvert( 1, fromCurrency, toCurrency);
                string[] words = convRateStr.Split(' ');
                convRate = Convert.ToDouble(words[0]);
                convRates.Add(fromCurrency + toCurrency, convRate);
                return convRate;
            }
        }

        private static double GetPairConvertionRateFromWeb(string fromCurrency, string toCurrency)
        {
            try
            {
                string xmlResult = null;
                string url;
                url = "http://www.webservicex.net/CurrencyConvertor.asmx/ConversionRate?FromCurrency=" + fromCurrency + "&ToCurrency=" + toCurrency + "";
                HttpWebRequest request      = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response    = (HttpWebResponse)request.GetResponse();
                StreamReader resStream      = new StreamReader(response.GetResponseStream());
                XmlDocument doc             = new XmlDocument();
                xmlResult                   = resStream.ReadToEnd();
                doc.LoadXml(xmlResult);
                string result = doc.GetElementsByTagName("double").Item(0).InnerText;
                return Convert.ToDouble(result);
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}