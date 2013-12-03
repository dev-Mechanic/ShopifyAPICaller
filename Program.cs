using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ShopifyOrdersPoller
{
    class Program
    {
        static void Main(string[] args)
        {
            //Call Tester
            string url = "https://APIKEY:APIPASSWORD@SHOPNAME.myshopify.com/admin/orders.xml";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/xml";
            request.Headers.Add("X-Shopify-Access-Token", "APIPASSWORD");
            request.Method = "GET";


            var response = (HttpWebResponse)request.GetResponse();
            string result = null;

            using (Stream stream = response.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                result = sr.ReadToEnd();
                sr.Close();
            }


            Console.WriteLine(result);

            Console.ReadKey(true);
        }
    }
}
