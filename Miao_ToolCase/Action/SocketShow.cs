using Knowledge_Point知识点.MySocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Utils工具.ASPOSE;

namespace Miao_ToolCase.Action
{
    public class SocketShow : ShowInterface
    {
        public void Show()
        {
            var tcp = new System.Net.Sockets.TcpClient();
        }

        public void ClientManagerTest()
        {
            string str = string.Empty;
            while (str != "exit")
            {
                str = Console.ReadLine();
                Console.WriteLine("ME: " + DateTimeOffset.Now.ToString("G"));
                ClientManager.SendMsgToClientList(str);
            }
            ClientManager.Close();
        }

    }
}
