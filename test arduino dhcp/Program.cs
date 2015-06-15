using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace test_arduino_dhcp
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(2020);
            server.Start();
            Console.WriteLine("avvio server");
            TcpClient arduino = server.AcceptTcpClient();

            Console.WriteLine("arduino connesso");


            while (true)
            {
                NetworkStream flusso = arduino.GetStream();

                byte[] buffer = new byte[arduino.ReceiveBufferSize];
                flusso.Read(buffer, 0, (int)arduino.ReceiveBufferSize);

                string s = Encoding.UTF8.GetString(buffer);
                s = s.Substring(0, s.IndexOf("\0"));
                Console.WriteLine(s);
            }
            Console.ReadKey();
        }
    }
}
