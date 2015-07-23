using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TCPServerDemo
{
    class TCPServerDemo2
    {
        Func<string, string,string> DoSomething;
        int clientId = 1;
        public TCPServerDemo2()
        {
            DoSomething = (name,data) =>
        {
            Console.WriteLine(name + data);
            return "OK";
        };
        }



        public void Start()
        {
            try
            {
                //构造一个TcpListener(IP地址,端口)对象,TCP服务端  
                TcpListener tcpListener = new TcpListener(IPAddress.Any, 6688);

                //开始监听  
                tcpListener.Start();
                Console.WriteLine("等候一个连接...");

                while (true)
                {
                    TcpClient client = tcpListener.AcceptTcpClient();
                    Thread tcpHandlerThread = new Thread(new ParameterizedThreadStart(tcpHandler));
                    tcpHandlerThread.Start(client);
                }
            }
            catch (SocketException e)
            {
                
               // throw;
            }
            
        }

        private void tcpHandler(object client)
        {
            TcpClient mClient = (TcpClient)client;
            var clientName = "客户端" + clientId + "- ip(" + mClient.Client.RemoteEndPoint.ToString() + ")";
            Console.WriteLine(clientName + "已连接...");
            clientId++;
            //构造NetworkStream类,该类用于获取和操作网络流  
            NetworkStream stream = mClient.GetStream();
            //读数据流对象  
            StreamReader sr = new StreamReader(stream);
            //写数据流对象  
            StreamWriter sw = new StreamWriter(stream);
            sw.AutoFlush = true;

            while (true)
            {
                if (mClient.Connected)
                {
                    try
                    {
                        var data = sr.ReadLine();
                        var re = DoSomething(clientName,data);
                        sw.WriteLine(re);
                    }
                    catch (SocketException ex)
                    {
                        if (ex.ErrorCode == 1)
                            mClient.Close();
                        else
                            throw ex;
                    }catch(IOException){
                        break;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else
                    mClient.Close();
            }
            mClient.Close();
        }



    }
}
