using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ConsoleApp16
{
    internal class FakeWorker
    {
        private Random rnd = new Random();
        private int counter = 1;

        public FakeWorker()
        {
        }

        public void Start()
        {
            IPEndPoint ipe = new IPEndPoint(IPAddress.Loopback, 7064);
            using (UdpClient client = new UdpClient())
            {
                while (true)
                {
                    String str = GenerateString();
                    
                    byte[] bytes = Encoding.UTF8.GetBytes(str);
                    client.Send(bytes, bytes.Length, ipe);

                    Thread.Sleep(5000);
                }
            }

        }

        private string GenerateString()
        {
            int id = counter++;
            string name = "maskine " + rnd.Next(1,9);
            double temp = 37 + rnd.NextDouble() * 2;
            string loca = "sted " + rnd.Next(1, 9);
            string date = rnd.Next(1, 30) + "/" + rnd.Next(1, 12);
            string time = rnd.Next(1, 24) + ":" + rnd.Next(1, 60);

            
            return $"Id: {id}, Name: {name}, Temperature: {temp}, Location: {loca}, Date: {date}, Time: {time}";
        }
    }
}