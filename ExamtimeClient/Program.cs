using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExamtimeClient
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = new int[15];
            int datetime = 0;
            //Creates a UdpClient for reading incoming data.
            UdpClient udpReceiver = new UdpClient(9999);

            //Creates an IPEndPoint to record the IP Address and port number of the sender.  
            IPAddress ip = IPAddress.Parse("10.200.120.26");
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(ip, 9999);

            // This IPEndPoint will allow you to read datagrams sent from any ip-source on port 9999
            //IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 9999);
            // udpReceiver.Connect(RemoteIpEndPoint);

            // Blocks until a message returns on this socket from a remote host.
            Console.WriteLine("Receiver is blocked");
            try
            {
                while (true)
                {
                    Byte[] receiveBytes = udpReceiver.Receive(ref RemoteIpEndPoint);

                    string receivedData = Encoding.ASCII.GetString(receiveBytes);

                    

                    //string[] textLines = receivedData.Split(' ');

                    //for (int index = 0; index < textLines.Length; index++)
                    //    Console.WriteLine(textLines[index]);
                    //Console.WriteLine(textLines [3]);

                    //Console.ReadLine();

                    //string text1 = textLines[3];

                    //Console.WriteLine("text1:" + text1);

                    //datetime = datetime + Int32.Parse(text1);

                   

                    //Console.WriteLine("Datetime = " + text1);

                    //sumTemp = textLines[10];


                    

                    Console.WriteLine(" Sender: " + receivedData.ToString());
                    Console.WriteLine("This message was sent from " +
                                                RemoteIpEndPoint.Address.ToString() +
                                                " on their port number " +
                                                RemoteIpEndPoint.Port.ToString());
                    Thread.Sleep(200);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            //Console.WriteLine("Tempature:" + sumTemp );
            //Console.WriteLine("Room:" + sumRoom);
            //Console.WriteLine("Smoke in %:" + sumTemp / 100 * 100);
            //Console.ReadLine();
        }
    }
}
