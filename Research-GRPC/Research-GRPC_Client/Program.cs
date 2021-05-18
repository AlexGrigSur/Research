using System;

namespace Research_GRPC_Client
{
    // https://www.youtube.com/watch?v=QyxCX2GYHxk&ab_channel=IAmTimCorey
    public class Program
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
            {
                connectionData = config["HostURL"];
            }

            new UsersHandlerTest().BeginTest(connectionData);
            Console.ReadKey();
        }
    }
}