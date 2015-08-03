using System;
using Hik.Communication.Scs.Communication.EndPoints.Tcp;
using Hik.Communication.ScsServices.Service;
 
namespace TCPServerDemo
{
    class Program2
    {
        static void Main(string[] args)
        {
            //Create a Scs Service application that runs on 10048 TCP port.
            var server = ScsServiceBuilder.CreateService(new ScsTcpEndPoint(10048));
            
            //Add Phone Book Service to service application
            server.AddService<IPhoneBookService, 
                       PhoneBookService>(new PhoneBookService());
            
            //Start server
            server.Start();
 
            //Wait user to stop server by pressing Enter
            Console.WriteLine(
                "Phone Book Server started successfully. Press enter to stop...");
            Console.ReadLine();
            
            //Stop server
            server.Stop();
        }
    }
}
