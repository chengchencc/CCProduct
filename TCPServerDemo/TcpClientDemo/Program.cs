using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Hik.Communication.Scs.Communication.EndPoints.Tcp;
using Hik.Communication.ScsServices.Client;
using TCPServerDemo;

namespace TcpClientDemo
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("please enter a server address......");
            var serverIp = Console.ReadLine();
            serverIp = "127.0.0.1";
            TcpClientWapper client = new TcpClientWapper(serverIp, 8866);

            while (true)
            {
                Console.WriteLine("请输入发送给服务器的内容。。。。。。");

                var sendMsg = Console.ReadLine();

                try
                {
                    var received = client.Communicate(sendMsg);
                    if (string.IsNullOrEmpty(received))
                    {
                        throw new Exception("连接中断");
                    }
                    Console.Write(received);
                    Console.WriteLine();
                }
                catch (Exception)
                {

                    throw new Exception("连接中断！");
                }

            }


        }


        static void Main1111(string[] args)
        {

            //Parse将字符串转换为IP地址类型  
            IPAddress myIP = IPAddress.Parse("127.0.0.1");
            //构造一个TcpClient类对象,TCP客户端  
            TcpClient client = new TcpClient();
            //与TCP服务器连接  
            client.Connect(myIP, 6688);
            Console.WriteLine("服务器已经连接...请输入对话内容...");

            //创建网络流,获取数据流  
            NetworkStream stream = client.GetStream();
            //读数据流对象  
            StreamReader sr = new StreamReader(stream);
            //写数据流对象  
            StreamWriter sw = new StreamWriter(stream);

            while (true)
            {
                string msg = Console.ReadLine();
                sw.WriteLine(msg);
                sw.Flush();             //刷新流  
                Console.WriteLine("服务器:" + sr.ReadLine());
            }
            client.Close();
            Console.Read();  
        }
    }
}
