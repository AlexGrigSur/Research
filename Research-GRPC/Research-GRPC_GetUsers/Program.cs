using System;
using System.Threading;
using Grpc.Core;
using Grpc.Net.Client;
using Research_GRPC;
using Research_GRPC_Client;

namespace Research_GRPC_GetUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigManager().GetConfiguration();
            string connectionData;
            if (config == null)
            {
                Console.WriteLine("Critical error with config file occured");
                Console.WriteLine("Switching to manual mode");
                do
                {
                    Console.Write("Input HostURL(again): ");
                    connectionData = Console.ReadLine();
                    if (connectionData.Trim() != "" && Uri.IsWellFormedUriString(connectionData, UriKind.Absolute))
                    {
                        break;
                    }
                    Console.WriteLine("Wrong Host address. Try again");
                } while (true);
            }
            else
                connectionData = config["HostURL"];

            var channel = GrpcChannel.ForAddress(connectionData);
            var client = new UsersHandler.UsersHandlerClient(channel);

            var token = new CancellationTokenSource();
            ThreadPool.QueueUserWorkItem(
                obj =>
                {
                    BeginWork(token.Token, client);
                });

            Console.WriteLine("Press any key to stop spam");
            Console.ReadKey();

            token.Cancel();

            Console.WriteLine("Spam was stopped. Press any key to exit");
            Console.ReadKey();
        }

        static void BeginWork(CancellationToken token, UsersHandler.UsersHandlerClient client)
        {
            try
            {
                while (true && !token.IsCancellationRequested)
                {
                    client.GetUsers(new UserNumber() {Id = 0});
                }
            }
            catch (RpcException e)
            {
                Console.WriteLine(e.StatusCode);
            }
        }
    }
}