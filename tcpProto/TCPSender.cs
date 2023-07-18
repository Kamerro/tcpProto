using System.Net.Sockets;
using System.Net;
using System.Text;


public class TCPSender {
    public static TcpListener tcpListener;
    public static TcpClient tcpClient;

    public static void StopThisConnection()
    {
        if (tcpListener is not null)        
            tcpListener.Stop();
        
    }
    public static void StartTcpSendingThread(int port)
    {
        var tcpSendingThread = new Thread(() =>
        {
            tcpClient = new TcpClient("localhost", port);
            tcpClient.Client.Send(new byte[] {72,69,76,76,79,32,87,79,82,76,68});
        });
        tcpSendingThread.Start();
        
    }
    public static void StartTcpListenerThread(int port)
        {
            tcpListener = new TcpListener(IPAddress.Any, port);
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
                        currentConnection.Close();
                        stream.Close();
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
