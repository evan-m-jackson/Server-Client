using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace client
{
    public class Client
    {

        public static void Main(string[] args)
        {
            Console.WriteLine("Starting client...");

            TcpClient client = new TcpClient("127.0.0.1", 5000);
            NetworkStream stream = client.GetStream();
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);

            
            String input = "";

            while (input != "quit")
            {
                Console.Write("Enter text ('quit' to stop): ");
                input = Console.ReadLine();
                writer.WriteLine(input);
                writer.Flush();

                string lineReceived = reader.ReadLine();
                Console.WriteLine("Received from server: " + lineReceived);
                Console.Write("Enter text: 'quit' to stop: ");
            }

            writer.WriteLine("quit");
            writer.Flush();
        }
    }
}