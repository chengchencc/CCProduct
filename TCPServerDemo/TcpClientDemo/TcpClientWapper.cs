using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace TcpClientDemo
{
    class TcpClientWapper
    {
        TcpClient _client;
        StreamReader _streamReader;
        StreamWriter _streamWriter;

        public TcpClientWapper(string serverIp,int port)
        {
            _client = new TcpClient();
            //_client.ReceiveTimeout();
            try
            {
                _client.Connect(serverIp, port);
            }
            catch (Exception ex)
            {
                
                throw new Exception("无法连接到服务器！");
            }
            //创建网络流,获取数据流  
            NetworkStream stream = _client.GetStream();
            //读数据流对象  
            _streamReader = new StreamReader(stream);
            //写数据流对象  
            _streamWriter = new StreamWriter(stream);
        }

        public string Communicate(string sendText)
        {
            _streamWriter.WriteLine(sendText);
            _streamWriter.Flush();            
            var received = _streamReader.ReadLine();//.Read(a,0,a.Length);
            return received;
        }

    }
}
