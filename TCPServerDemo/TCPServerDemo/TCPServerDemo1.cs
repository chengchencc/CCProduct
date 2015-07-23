using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPServerDemo
{
    class TCPServerDemo1
    {

        public TCPServerDemo1()
        {

        }

        public void Start()
        {
            //Parse将字符串转换为IP地址类型  
            IPAddress myIP = IPAddress.Parse("127.0.0.1");
            //构造一个TcpListener(IP地址,端口)对象,TCP服务端  
            TcpListener myServer = new TcpListener(myIP, 6688);

            //开始监听  
            myServer.Start();
            Console.WriteLine("等候一个连接...");

            //构造TCP客户端:接受连接请求  
            TcpClient client = myServer.AcceptTcpClient();
            Console.WriteLine("客户端已经连接...");

            //构造NetworkStream类,该类用于获取和操作网络流  
            NetworkStream stream = client.GetStream();
            //读数据流对象  
            StreamReader sr = new StreamReader(stream);
            //写数据流对象  
            StreamWriter sw = new StreamWriter(stream);

            while (true)
            {
                Console.WriteLine("客户端:" + sr.ReadLine());
                string msg = Console.ReadLine();
                sw.WriteLine(msg);
                sw.Flush();               //刷新流  
            }
            client.Close();               //关闭客户端  
        }

    }
}
