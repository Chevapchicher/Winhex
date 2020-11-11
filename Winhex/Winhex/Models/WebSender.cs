using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace Winhex.Models
{
    public class WebSender
    {
        public static bool SendToServer(object obj, string url)
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback +=
                    (sender, certificate, chain, sslPolicyErrors) => true;
                ServicePointManager.SecurityProtocol =
                    SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                WebRequest
                    request = WebRequest.Create(url); //"http://www.ihih.somee.com/upload");//"https://localhost:5001/upload"); "https://localhost:44373/upload"

                request.Method = "POST"; // для отправки используется метод Post

                string data = JsonConvert.SerializeObject(obj);

                byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(data);
                request.ContentType = "application/json";
                request.ContentLength = byteArray.Length;

                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                }

                WebResponse response = request.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        Console.WriteLine(reader.ReadToEnd());
                    }
                }

                response.Close();
                Console.WriteLine("Запрос выполнен...");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}