using System;
using System.Drawing;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace CiBitMainServer.DBLogic
{
    public class PythonAPI : IPythonAPI
    {
        /// <summary>
        /// C# test to call Python HttpWeb RESTful API
        /// </summary>
        /// <param name="uirWebAPI">UIR web api link</param>
        /// <param name="exceptionMessage">Returned exception message</param>
        /// <returns>Web response string</returns>
        public string CSharpPythonRestfulApiSimpleTest(string uirWebAPI, string cibitId, out string exceptionMessage)
        {
            exceptionMessage = string.Empty;
            string webResponse = string.Empty;
            try
            {
                Uri uri = new Uri(uirWebAPI);
                WebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    dynamic User = new JObject();
                    User.cibitId = cibitId;
                    streamWriter.Write(User.ToString());
                }
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    webResponse = streamReader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                exceptionMessage = $"An error occurred. {ex.Message}";
            }
            return webResponse;
        }
    }   
}