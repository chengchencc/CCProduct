using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using Hik.Communication.Scs.Communication.EndPoints.Tcp;
using Hik.Communication.ScsServices.Service;
using Simple.Owin.Servers.Tcp;
 
namespace TCPServerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            TCPServerDemo2 tcpServer2 = new TCPServerDemo2();
            tcpServer2.Start();


        }


    }
}
