using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Knowledge_Point知识点.MySocket
{
    public class TcpClient
    {
        private static byte[] _buffer = new byte[102400];
        private static int _receiveCount = 0;
        private static string _receiveString = string.Empty;

        public TcpClient()
        {
            try
            {
                IPAddress ip = IPAddress.Parse("127.0.0.1");
                IPEndPoint ep = new IPEndPoint(ip, 9110);

                using (Socket transferSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    transferSocket.Connect(ep);
                    Console.WriteLine("connect success...");

                    ReceiveConsole(transferSocket);
                    ReceiveConsole(transferSocket);
                    while (true)
                    {
                        var input = Console.ReadLine();
                        transferSocket.Send(Encoding.UTF8.GetBytes(input));
                        Thread.Sleep(100);
                        if (input == "yes")
                            break;
                        else if (input == "no")
                        {
                            ReceiveConsole(transferSocket);
                            return;
                        }
                        else
                            ReceiveConsole(transferSocket);
                    }

                    ReceiveConsole(transferSocket);
                    var downloadPath = string.Empty;
                    while (true)
                    {
                        var input = Console.ReadLine();
                        try
                        {
                            DirectoryInfo di = new DirectoryInfo(input);
                            if (!di.Exists)
                            {
                                Console.WriteLine("path is invalid, please reset it.");
                                continue;
                            }
                            downloadPath = input;
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("path is invalid, please reset it.");
                        }
                    }

                    transferSocket.Send(Encoding.UTF8.GetBytes("yes"));
                    Thread.Sleep(100);

                    while (true)
                    {
                        if (ReceiveConsole(transferSocket) == "send argument")
                            break;
                    }

                    var tempCount = 0;
                    var bpp = new BreakPointPost();
                    while (tempCount < 5)
                    {
                        SetBreakPointPostArg(bpp, ReceiveConsole(transferSocket));
                        tempCount++;
                    }

                    Console.WriteLine("argument received.");
                    Console.WriteLine("");
                    downloadPath = Path.Combine(downloadPath, bpp.FileName);

                    transferSocket.Send(Encoding.UTF8.GetBytes("argument received"));
                    Thread.Sleep(100);

                    while (true)
                    {
                        _receiveCount = transferSocket.Receive(_buffer);
                        _receiveString = Encoding.UTF8.GetString(_buffer, 0, _receiveCount);
                        if (_receiveString == "start")
                        {
                            while (true)
                            {
                                _receiveCount = transferSocket.Receive(_buffer);
                                _receiveString = Encoding.UTF8.GetString(_buffer, 0, _receiveCount);
                                if (_receiveString.Contains("Index"))
                                {
                                    SetBreakPointPostArg(bpp, _receiveString);
                                    _buffer = new byte[bpp.PackageSize];
                                    _receiveCount = transferSocket.Receive(_buffer);
                                    if ((bpp.Index + 1) < bpp.PackageCount && _receiveCount != bpp.PackageSize)
                                        continue;
                                    Console.WriteLine(string.Format("{0} download progress is {1}/{2}({3})", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), bpp.Index, bpp.PackageCount, _receiveCount));
                                    FileWrite(downloadPath, bpp.Index, bpp.PackageSize, _receiveCount, _buffer);
                                    transferSocket.Send(Encoding.UTF8.GetBytes("success|" + bpp.Index));
                                    Thread.Sleep(100);
                                    if (bpp.Index + 1 == bpp.PackageCount)
                                        break;
                                }
                                else if (_receiveString == "stop")
                                {
                                    while (true)
                                    {
                                        if (ReceiveConsole(transferSocket) == "restart")
                                            break;
                                    }
                                }
                            }
                        }
                        if (bpp.Index + 1 == bpp.PackageCount)
                        {
                            bpp = null;
                            break;
                        }
                    }

                    while (true)
                    {
                        if (ReceiveConsole(transferSocket) == "finish")
                            break;
                    }


                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("disconnect...");
                Console.ReadKey();
            }
        }

        private static string ReceiveConsole(Socket socket)
        {
            _receiveCount = socket.Receive(_buffer);
            _receiveString = Encoding.UTF8.GetString(_buffer, 0, _receiveCount);
            Console.WriteLine("server : " + _receiveString);
            return _receiveString;
        }
        private static void SetBreakPointPostArg(BreakPointPost bpp, string value)
        {
            if (value.Contains("FileName"))
                bpp.FileName = value.Split('|')[1];
            if (value.Contains("FileSize"))
                bpp.FileSize = long.Parse(value.Split('|')[1]);
            if (value.Contains("PackageSize"))
                bpp.PackageSize = long.Parse(value.Split('|')[1]);
            if (value.Contains("PackageCount"))
                bpp.PackageCount = int.Parse(value.Split('|')[1]);
            if (value.Contains("Index"))
                bpp.Index = int.Parse(value.Split('|')[1]);
        }
        private static void FileWrite(string path, int index, long packageSize, int receiveSize, byte[] data)
        {
            using (System.IO.FileStream stream = System.IO.File.OpenWrite(path))
            {
                stream.Seek((long)index * (long)packageSize, System.IO.SeekOrigin.Begin);
                stream.Write(data, 0, receiveSize);
                stream.Flush();
            }
        }


        public class BreakPointPost
        {
            public string FileName { get; set; }
            public long FileSize { get; set; }
            public long PackageSize { get; set; }
            public int PackageCount { get; set; }
            public int Index { get; set; }
        }
    }
}
