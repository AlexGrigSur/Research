using Grpc.Core;
using Grpc.Net.Client;
using Research_GRPC;
using System;

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
            GetAllUsersCollection(client);
            Console.WriteLine("*************");
            GetAllUsersStream(client);

        }

        private void GetRequest(UsersHandler.UsersHandlerClient client, int id)
        {
            var userID = new UserNumber()
            {
                Id = id
            };
            try
            {
                var reply = client.GetUsers(userID);
                Console.WriteLine($"GetRequest result: FirstName - {reply.FirstName}");
            }
            catch (RpcException e)
            {
                string error = (e.StatusCode == StatusCode.NotFound)
                    ? "Empty result:"
                    : "Server is unavailable:";
                Console.WriteLine("{0}",e.StatusCode);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unhandled exception: {0}",e.Message);
            }
        }
        private async void GetAllUsersStream(UsersHandler.UsersHandlerClient client)
        {
            Console.WriteLine("GetAllUsers request");
            try
            {
                using (var call = client.GetAllUsersStream(new Empty()))
                {
                    while (await call.ResponseStream.MoveNext())
                    {
                        var currentReply = call.ResponseStream.Current;
                        Console.WriteLine($"GetAllUsersStream reply: FirstName - {currentReply.FirstName}");
                    }
                }
            }
            catch (RpcException e)
            {
                string error = (e.StatusCode == StatusCode.NotFound)
                    ? "Empty result:"
                    : "Server is unavailable:";
                Console.WriteLine(error + " {0}", e.StatusCode);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unhandled exception: {0}",e.Message);
            }
        }
        private /*async*/ void GetAllUsersCollection(UsersHandler.UsersHandlerClient client)
        {
            Console.WriteLine("GetAllUsersCollection request");
            try
            {
                var result = client.GetAllUsersCollection(new Empty());//await client.GetAllUsersCollectionAsync(new Empty());
                for (int i = 0; i < result.Model.Count; ++i)
                {
                    Console.WriteLine($"GetAllUsers reply: FirstName - {result.Model[i].FirstName}");
                }
            }
            catch (RpcException e)
            {
                string error = (e.StatusCode == StatusCode.NotFound)
                    ? "Empty result:"
                    : "Server is unavailable:";
                Console.WriteLine(error + " {0}", e.StatusCode);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unhandled exception: {0}", e.Message);
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
                var reply = client.AddUser(model);
                Console.WriteLine($"SetRequest result: {reply.Id}");
            }
            catch (RpcException e)
            {
                string error = (e.StatusCode == StatusCode.Unknown)
                    ? "Empty result:"
                    : "Server is unavailable:";
                Console.WriteLine(error + " {0}", e.StatusCode);
            }
            catch (Exception)
            {
                Console.WriteLine("Unhandled exception");
            }
        }
    }
}