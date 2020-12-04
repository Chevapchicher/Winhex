using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Threading;

namespace Winhex.Models
{
    public class WebSender
    {
        /// <summary>
        /// POST - запрос с сериализацией отсылаемого объекта
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="url"></param>
        /// <returns></returns>
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
                Thread.Sleep(500);
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