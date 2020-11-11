using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winhex.Interfaces;
using Winhex.Models;

namespace Winhex
{
    public partial class Form1 : Form
    {
        private ILogCreator loger;
        public Form1()
        {
            InitializeComponent();
            FormClosing += (sender, args) => loger?.Close();

            var syms = new[]
            {
                'a', 'b', 'c', 'd', 'e',
                'g', 'h', 'i', 'j', ' '
            };
            //ILogCreator loger = new UserLogCreator();
            Task.Run(() =>
            {
                Invoke(new Action(() =>
                {
                    loger = new UserLogCreator();

                    int c = 0;
                    while (true)
                    {
                        Random rand = new Random();
                        if (c > 40) c = 0;
                        if (c > 20) loger.AddKey("Chrome", syms[rand.Next(0, 9)]);
                        else loger.AddKey("Yandex", syms[rand.Next(0, 9)]);
                        Thread.Sleep(1000);
                        c++;

                    }
                }));
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<UserAction> actions = new List<UserAction>();
            actions.Add(new UserAction() { ActionDateTime = DateTime.Now, AppTitle = "Chrome", TextLog = "heelo!" });
            actions.Add(new UserAction() { ActionDateTime = DateTime.Now, AppTitle = "Yandex", TextLog = "hih" });
            var log = new UserLog() { CompName = "New" };
            log.Logs.Add(actions[0]);
            log.Logs.Add(actions[1]);

<<<<<<< HEAD


            WebRequest request = WebRequest.Create("http://ihih.somee.com/upload");
            request.Method = "POST"; // для отправки используется метод Post
            // данные для отправки
            string data = JsonConvert.SerializeObject(log);
            // преобразуем данные в массив байтов
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(data);
            // устанавливаем тип содержимого - параметр ContentType
            request.ContentType = "application/json";
            // Устанавливаем заголовок Content-Length запроса - свойство ContentLength
            request.ContentLength = byteArray.Length;

            //записываем данные в поток запроса
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
=======
            WebSender.SendToServer(log, "http://www.ihih.somee.com/upload");
>>>>>>> a643e807a398f7d545a0f0de378f13d060b280e3
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //List<UserAction> actions = new List<UserAction>();
            //actions.Add(new UserAction() { ActionDateTime = DateTime.Now, AppTitle = "Chrome", TextLog = "heelo!" });
            //actions.Add(new UserAction() { ActionDateTime = DateTime.Now, AppTitle = "Yandex", TextLog = "hih" });
            //var log = new UserLog() { CompName = "Old", SendingDateTime = DateTime.Now };
            //log.Logs.Add(actions[0]);
            //log.Logs.Add(actions[1]);

            //WebSender.SendToServer(log, "http://www.ihih.somee.com/upload");

            var user = new UserLog() { Id = 1, CustomNote = "Питух" };
            WebSender.SendToServer(user, "http://www.ihih.somee.com/download");
        }
    }
}
