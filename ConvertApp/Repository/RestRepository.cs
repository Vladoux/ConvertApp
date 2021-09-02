using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ConvertApp.Model;
using Newtonsoft.Json;

namespace ConvertApp.Repository
{
    class RestRepository
    {
        private string _url = @"https://www.cbr-xml-daily.ru/daily_json.js";
        public Root GetCurs()
        {
            WebRequest request = HttpWebRequest.Create(_url);
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string jsonString = reader.ReadToEnd();
            Root valuteDate = JsonConvert.DeserializeObject<Root>(jsonString);
            return valuteDate;

        }

        
    }
}
