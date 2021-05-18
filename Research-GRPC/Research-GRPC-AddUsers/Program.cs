using System;
using System.Threading;
using Grpc.Core;
using Grpc.Net.Client;
using Research_GRPC;
using Research_GRPC_Client;

namespace Research_GRPC_AddUsers
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

            var ct = new CancellationTokenSource();
            ThreadPool.QueueUserWorkItem(
                obj =>
                {
                    BeginWork(ct.Token,client);
                },
                ct.Token);

            Console.WriteLine("Press any key to stop spam");
            Console.ReadKey();

            ct.Cancel();

            Console.WriteLine("Spam was stopped. Press any key to exit");
            Console.ReadKey();
        }

        static void BeginWork(CancellationToken token, UsersHandler.UsersHandlerClient client)
        {
            while (true && !token.IsCancellationRequested)
            {
                try
                {
                    client.AddUser(new UserModel()
                    {
                        FirstName = "Spam"
                    });
                }
                catch (RpcException e)
                {
                    Console.WriteLine(e.StatusCode);
                }
            }
        }
    }
}