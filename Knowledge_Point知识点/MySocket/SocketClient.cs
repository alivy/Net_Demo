using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;

namespace Knowledge_Point知识点.MySocket
{
    public class  ClientInfo
    {
        public Socket Socket { get; set; }
        public bool IsOpen { get; set; }
        public string Address { get; set; }
    }

    // 管理Client
    public class  ClientManager
    {
        static List<ClientInfo> clientList = new List<ClientInfo>();
        public static void Add(ClientInfo info)
        {
            if (!IsExist(info.Address))
            {
                clientList.Add(info);
            }
        }
        public static bool IsExist(string address)
        {
            return clientList.Exists(item => string.Compare(address, item.Address, true) == 0);
        }
        public static bool IsExist(string address, bool isOpen)
        {
            return clientList.Exists(item => string.Compare(address, item.Address, true) == 0 && item.IsOpen == isOpen);
        }
        public static void Open(string address)
        {
            clientList.ForEach(item =>
            {
                if (string.Compare(address, item.Address, true) == 0)
                {
                    item.IsOpen = true;
                }
            });
        }
        public static void Close(string address = null)
        {
            clientList.ForEach(item =>
            {
                if (address == null || string.Compare(address, item.Address, true) == 0)
                {
                    item.IsOpen = false;
                    item.Socket.Shutdown(SocketShutdown.Both);
                }
            });
        }
        // 发送消息到ClientList
        public static void SendMsgToClientList(string msg, string address = null)
        {
            clientList.ForEach(item =>
            {
                if (item.IsOpen && (address == null || item.Address != address))
                {
                    SendMsgToClient(item.Socket, msg);
                }
            });
        }
        public static void SendMsgToClient(Socket client, string msg)
        {
            byte[] bt = ServerHelper.EncodeMsg(msg);
            client.BeginSend(bt, 0, bt.Length, SocketFlags.None, new AsyncCallback(SendTarget), client);
        }
        private static void SendTarget(IAsyncResult res)
        {
            //Socket client = (Socket)res.AsyncState;
            //int size = client.EndSend(res);
        }
    }

    // 接收消息
    public class  ReceiveHelper
    {
        public byte[] Bytes { get; set; }
        public void ReceiveTarget(IAsyncResult res)
        {
            Socket client = (Socket)res.AsyncState;
            int size = client.EndReceive(res);
            if (size > 0)
            {
                string address = client.RemoteEndPoint.ToString(); // 获取Client的IP和端口
                string stringdata = null;
                if (ClientManager.IsExist(address, false)) // 握手
                {
                    stringdata = Encoding.UTF8.GetString(Bytes, 0, size);
                    ClientManager.SendMsgToClient(client, ServerHelper.ResponseHeader(stringdata));
                    ClientManager.Open(address);
                }
                else
                {
                    stringdata = ServerHelper.DecodeMsg(Bytes, size);
                }
                if (stringdata.IndexOf("exit") > -1)
                {
                    ClientManager.SendMsgToClientList(address + "已从服务器断开", address);
                    ClientManager.Close(address);
                    Console.WriteLine(address + "已从服务器断开");
                    Console.WriteLine(address + " " + DateTimeOffset.Now.ToString("G"));
                    return;
                }
                else
                {
                    Console.WriteLine(stringdata);
                    Console.WriteLine(address + " " + DateTimeOffset.Now.ToString("G"));
                    ClientManager.SendMsgToClientList(stringdata, address);
                }
            }
            // 继续等待
            client.BeginReceive(Bytes, 0, Bytes.Length, SocketFlags.None, new AsyncCallback(ReceiveTarget), client);
        }
    }

    // 监听请求
    public class  AcceptHelper
    {
        public byte[] Bytes { get; set; }

        public void AcceptTarget(IAsyncResult res)
        {
            Socket server = (Socket)res.AsyncState;
            Socket client = server.EndAccept(res);
            string address = client.RemoteEndPoint.ToString();

            ClientManager.Add(new ClientInfo() { Socket = client, Address = address, IsOpen = false });
            ReceiveHelper rs = new ReceiveHelper() { Bytes = this.Bytes };
            IAsyncResult recres = client.BeginReceive(rs.Bytes, 0, rs.Bytes.Length, SocketFlags.None, new AsyncCallback(rs.ReceiveTarget), client);
            // 继续监听
            server.BeginAccept(new AsyncCallback(AcceptTarget), server);
        }
    }

    //public class  Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    //        server.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 200)); // 绑定IP+端口
    //        server.Listen(10); // 开始监听

    //        Console.WriteLine("等待连接...");

    //        AcceptHelper ca = new AcceptHelper() { Bytes = new byte[2048] };
    //        IAsyncResult res = server.BeginAccept(new AsyncCallback(ca.AcceptTarget), server);

    //        string str = string.Empty;
    //        while (str != "exit")
    //        {
    //            str = Console.ReadLine();
    //            Console.WriteLine("ME: " + DateTimeOffset.Now.ToString("G"));
    //            ClientManager.SendMsgToClientList(str);
    //        }
    //        ClientManager.Close();
    //        server.Close();
    //    }
    //}


}
