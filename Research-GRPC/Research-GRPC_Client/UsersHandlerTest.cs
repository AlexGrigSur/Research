using Grpc.Core;
using Grpc.Net.Client;
using Research_GRPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research_GRPC_Client
{
    public class UsersHandlerTest
    {
        public void BeginTest(string connectionString)
        {
            var channel = GrpcChannel.ForAddress(connectionString);
            var client = new UsersHandler.UsersHandlerClient(channel);

            GetRequest(client, 5);
            Console.WriteLine("*************");
            GetRequest(client, 1);
            Console.WriteLine("*************");
            SetRequest(client);
            Console.WriteLine("*************");
            GetAllUsers(client);
        }

        private void GetRequest(UsersHandler.UsersHandlerClient client, int id)
        {
            UserID userID = new UserID()
            {
                Id = id
            };
            try
            {
                var reply = client.GetRequest(userID);
                Console.WriteLine($"GetRequest result: FirstName - {reply.FirstName}");
            }
            catch (Grpc.Core.RpcException)
            {
                Console.WriteLine("Result is null");
            }
            catch (Exception)
            {
                Console.WriteLine("Unhandled exception");
            }
        }
        private async void GetAllUsers(UsersHandler.UsersHandlerClient client)
        {
            Console.WriteLine("GetAllUsers request");
            try
            {
                using (var call = client.GetAllUsers(new Empty()))
                {
                    while (await call.ResponseStream.MoveNext())
                    {
                        var currentReply = call.ResponseStream.Current;
                        Console.WriteLine($"GetAllUsers reply: FirstName - {currentReply.FirstName}");
                    }
                }
            }
            catch(Exception)
            {
                Console.WriteLine("Unhandled exception");
            }
        }
        private void SetRequest(UsersHandler.UsersHandlerClient client)
        {
            UserModel model = new UserModel()
            {
                FirstName = "Hello",
                LastName = "it",
                Email = "is",
                Password = "me"
            };

            try
            {
                var reply = client.SetRequest(model);
                Console.WriteLine($"SetRequest result: {reply.Id}");
            }
            catch (Exception)
            {
                Console.WriteLine("Unhandled exception");
            }
        }
    }
}