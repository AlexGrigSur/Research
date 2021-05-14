using System;
using Grpc.Net.Client;
using Research_GRPC;

namespace Research_GRPC_Client
{
    // https://www.youtube.com/watch?v=QyxCX2GYHxk&ab_channel=IAmTimCorey
    class Program
    {
        static void Main(string[] args)
        {
            // APPSETTINGS.JSON
            string connectionData = ConfigManager.GetField("ConnectionStrings");
            var channel = GrpcChannel.ForAddress(connectionData);

            HelloRequest request = new HelloRequest(){Name = "Alex"};

            var client = new Greeter.GreeterClient(channel);

            SendMessage.Send(client,request).Wait();
            Console.ReadKey();
        }
    }
}
