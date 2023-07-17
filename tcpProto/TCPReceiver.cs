using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace tcpProto
{
    public class TCPReceiver
    {
        public static void StartTcpListenerThread(int port)
        {
            var tcpListener = new TcpListener(IPAddress.Any, port);
            tcpListener.Start();
            Thread tcpListenerThread = new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        var bytes = new byte[1024];
                        var currentConnection = tcpListener.AcceptTcpClient();
                        var stream = currentConnection.GetStream();
                        var numBytesReadFromStream = stream.Read(bytes, 0, bytes.Length);
                        var message = Encoding.ASCII.GetString(bytes, 0, numBytesReadFromStream);
                        Console.WriteLine(message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                }
            });
            tcpListenerThread.Start();
        }

    }
}
