using System;
using System.IO;
using System.Net.Sockets;

namespace TcpClientSkat
{
    class Program
    {
        static void Main(string[] args)
        {
            //Opretter clientsocket med navn(IP) og på portnummer.
            TcpClient clientSocket = new TcpClient("127.0.0.1", 6789);
            Console.WriteLine("Client ready");
            
            //Opretter stream i socket og opretter read og write funktioner i streamen
            Stream ns = clientSocket.GetStream();  //provides a Stream
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true; // enable automatic flushing

            //Serverens åbning meddelelse modtages og skrives i console.
            string serverAnswer = sr.ReadLine();
            Console.WriteLine("Server: " + serverAnswer);

            while (true)
            {
                
                // Læser hvad der skrives i consolen og sender det til serveren.
                string message = Console.ReadLine();
                sw.WriteLine(message);

                //Hvis message er tom eller ingenting, så afbrydes loopet, serverens service og clienten lukkes.
                if (String.IsNullOrEmpty(message))
                {
                    break;
                }

                //Modtager og skriver serverens svar i consolen
                serverAnswer = sr.ReadLine();
                Console.WriteLine("Server: " + serverAnswer);

                // Læser hvad der skrives i consolen og sender det til serveren.
                message = Console.ReadLine();
                sw.WriteLine(message);

                //Hvis message er tom eller ingenting, så afbrydes loopet, serverens service og clienten lukkes.
                if (String.IsNullOrEmpty(message))
                {
                    break;
                }

                //Modtager og skriver serverens svar i consolen
                serverAnswer = sr.ReadLine();
                Console.WriteLine("Server: " + serverAnswer);
                serverAnswer = sr.ReadLine();
                Console.WriteLine("Server: " + serverAnswer);
            }
            
            //Lukker consolen og derefter streamen og socket.
            Console.WriteLine("No more from server. Press Enter");
            Console.ReadLine();

            ns.Close();

            clientSocket.Close();
        }
    }
}
