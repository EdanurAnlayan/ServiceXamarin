
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceXamarin
{
    public static class LoginService
    {
        public static string Login(string username, string password)
        {
            var url = String.Format("https://"); 
            HttpWebRequest requestObj = (HttpWebRequest)WebRequest.Create(url);
            requestObj.Method = "Get";
            requestObj.PreAuthenticate = true;
            requestObj.Credentials = new NetworkCredential(username, password);
            HttpWebResponse responseObj = null;
            responseObj = (HttpWebResponse)requestObj.GetResponse();
            string strresult = null;
            using (Stream stream = responseObj.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                strresult = sr.ReadToEnd();
                sr.Close();
            }
            return strresult;
        }

    }
}
