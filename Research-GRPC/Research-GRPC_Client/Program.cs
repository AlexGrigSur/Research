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
            var config = new ConfigManager().GetConfiguration();
            string connectionData = config["HostURL"];

            new UsersHandlerTest().BeginTest(connectionData);

            Console.ReadKey();
        }
    }
}