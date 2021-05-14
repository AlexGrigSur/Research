using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Research_GRPC;

namespace Research_GRPC_Client
{
    public static class SendMessage
    {
        public static async Task Send(Greeter.GreeterClient client, HelloRequest input)
        {
            var reply = await client.SayHelloAsync(input);
            Console.WriteLine(reply.Message);
        }
    }
}
