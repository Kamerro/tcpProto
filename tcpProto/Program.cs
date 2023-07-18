/*    using tcpProto;
    TCPReceiver.StartTcpListenerThread(Port);*/
    int Port = 20000;
    TCPSender.StartTcpListenerThread(Port);
    Thread.Sleep(300);
    TCPSender.StartTcpSendingThread(Port);
    Thread.Sleep(300);
//TCPSender.StopThisConnection();
    