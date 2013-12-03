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
            string url = "https://50c917650927c24546fa5414661f00c5:5f163f48cec88d8002755f1eb26195d8@ozpacktest-2.myshopify.com/admin/orders.xml";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/xml";
            request.Headers.Add("X-Shopify-Access-Token", "5f163f48cec88d8002755f1eb26195d8");
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
