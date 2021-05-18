using Grpc.Core;
using Grpc.Net.Client;
using Research_GRPC;
using System;
using System.Threading.Tasks;

namespace Research_GRPC_Client
{
    public class UsersHandlerTest
    {
        public void BeginTest(string connectionString)
        {
            var channel = GrpcChannel.ForAddress(connectionString);
            var client = new UsersHandler.UsersHandlerClient(channel);

            GetSingleUser(client, 5);
            Console.WriteLine("*************");
            GetSingleUser(client, 1);
            Console.WriteLine("*************");
            AddUser(client);
            Console.WriteLine("*************");
            GetAllUsersCollection(client);
            Console.WriteLine("*************");
            GetAllUsersStream(client);
        }

        private void GetSingleUser(UsersHandler.UsersHandlerClient client, int id)
        {
            var userID = new UserNumber()
            {
                Id = id
            };
            try
            {
                var reply = client.GetSingleUser(userID);
                Console.WriteLine($"GetSingleUser result: FirstName - {reply.FirstName}");
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
        private async void GetAllUsersStream(UsersHandler.UsersHandlerClient client)
        {
            Console.WriteLine("GetAllUsers request");
            try
            {
                using (var call = client.GetAllUsersStream(new Empty()))
                {
                    while (await call.ResponseStream.MoveNext())
                    {
                        var reply = call.ResponseStream.Current;
                        Console.WriteLine($"GetAllUsersStream reply: [{reply.Key}] {reply.Model.FirstName}");
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
                Console.WriteLine("Unhandled exception: {0}", e.Message);
            }
        }
        private /*async*/ void GetAllUsersCollection(UsersHandler.UsersHandlerClient client)
        {
            Console.WriteLine("GetAllUsersCollection request");
            try
            {
                var reply = client.GetAllUsersCollection(new Empty());//await client.GetAllUsersCollectionAsync(new Empty());
                for (int i = 0; i < reply.ModelsList.Count; ++i)
                {
                    Console.WriteLine($"GetAllUsers reply: [{reply.ModelsList[i].Key}] {reply.ModelsList[i].Model.FirstName}");
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

        private void AddUser(UsersHandler.UsersHandlerClient client)
        {
            UserModel model = new UserModel()
            {
                FirstName = "Hello",
                LastName = "it",
                Email = "is",
                Password = "me"
            };
            UserModelWithKey userModelWithKey = new UserModelWithKey()
            {
                Key = 1,
                Model = model
            };
            try
            {
                var reply = client.AddUser(userModelWithKey);
                Console.WriteLine($"Inserted successfully");
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