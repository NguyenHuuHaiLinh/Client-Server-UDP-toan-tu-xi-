using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {

            Random rd = new Random();
            int recev;
            byte[] data = new byte[1024];
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 9050);
            Socket newsock  = new Socket(AddressFamily.InterNetwork,
                SocketType.Dgram, ProtocolType.Udp);
            // newsock la client
            newsock.Bind(ipep);
            Console.WriteLine("waiting for client...");
            IPEndPoint sender = ipep;
            EndPoint Remote = (EndPoint)ipep;
            recev = newsock.ReceiveFrom(data, ref Remote);
            Console.WriteLine("message received from {0}", Remote.ToString());
            while(true)
            {
                data = new byte[1024];
                recev = newsock.ReceiveFrom(data, ref Remote);
                string k = Encoding.ASCII.GetString(data, 0, recev);
                if (k == "1") Console.WriteLine(" {0} chon bua ", Remote.ToString());
                if (k == "2") Console.WriteLine(" {0} chon keo ", Remote.ToString());
                if (k == "3") Console.WriteLine(" {0} chon bao ", Remote.ToString());
                int n = rd.Next(1, 4);
                if (n == 1) Console.WriteLine("Ban chon Búa");
                if (n == 2) Console.WriteLine("Ban chon Kéo");
                if (n == 3) Console.WriteLine("Ban chon Bao");
                newsock.SendTo(Encoding.ASCII.GetBytes(n.ToString()),
                    recev, SocketFlags.None, Remote);

            }
            
           
        }
    }
}
