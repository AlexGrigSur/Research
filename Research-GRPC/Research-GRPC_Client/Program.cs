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


            // make static configManager?
            var config = new ConfigManager().GetConfiguration();

            string connectionData = config["HostURL"];

            var channel = GrpcChannel.ForAddress(connectionData);

            UserModel model = new UserModel()
            {
                FirstName = "Hello",
                LastName = "it",
                Email = "is",
                Password = "me"
            };

            var client = new UsersHandler.UsersHandlerClient(channel);

            var replyID = client.SetRequest(model);
            Console.WriteLine("UserID:{0}",replyID.Id);

            var replyModel = client.GetRequest(replyID);
            Console.WriteLine("FirstName:{0}", replyModel.FirstName);

            Console.ReadKey();
        }
    }
}