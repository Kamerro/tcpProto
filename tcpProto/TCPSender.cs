using System.Net.Sockets;
using System.Net;
using System.Text;


public class TCPSender {
    public static void StartTcpSendingThread(int port)
    {
        var tcpSendingThread = new Thread(() =>
        {
            var tcpClient = new TcpClient("localhost", port);
            tcpClient.Client.Send(new byte[] {72,69,76,76,79,32,87,79,82,76,68});
        });
        tcpSendingThread.Start();
    }
}
