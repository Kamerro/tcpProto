    using tcpProto;
    int Port = 20000;
    TCPReceiver.StartTcpListenerThread(Port);
    Thread.Sleep(300);
    TCPSender.StartTcpSendingThread(Port);