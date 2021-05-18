using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Research_GRPC.Storage;

namespace Research_GRPC
{
    // unite all exceptions ??
    public class UsersService : UsersHandler.UsersHandlerBase
    {
        private readonly ILogger<UsersService> _logger;
        public UsersService(ILogger<UsersService> logger)
        {
            _logger = logger;
        }

        public override Task<UserModel> GetSingleUser(UserNumber userNumber, ServerCallContext context)
        {
            try
            {
                var result = DataStorage.GetInstance().GetUser(userNumber.Id);
                if (result == null)
                {
                    context.Status = new Status(StatusCode.NotFound, "Requested key not found");
                    return Task.FromResult(new UserModel());
                }
                return Task.FromResult(result);
            }
            catch (Exception e)
            {
                context.Status = new Status(StatusCode.Internal, e.Message);
                Console.WriteLine(context.Status);
                return Task.FromResult(new UserModel());
            }
        }
        public override Task<Empty> AddUser(UserModelWithKey model, ServerCallContext context)
        {
            try
            {
                DataStorage.GetInstance().AddUser(model);
                return Task.FromResult(new Empty());
            }
            catch (Exception e)
            {
                context.Status = new Status(StatusCode.Internal, e.Message);
                Console.WriteLine(context.Status);
                return Task.FromResult(new Empty());
            }

        }
        public override Task<UserQuery> GetAllUsersCollection(Empty request, ServerCallContext context)
        {
            try
            {
                return Task.FromResult(new UserQuery()
                {
                    ModelsList = { DictionaryToUserModelWithKeyListAdapter(DataStorage.GetInstance().GetAllUsers()) }
                });
            }
            catch (Exception e)
            {
                context.Status = new Status(StatusCode.Internal, e.Message);
                Console.WriteLine(context.Status);
                return Task.FromResult(new UserQuery());
            }
        }
        public override async Task GetAllUsersStream(Empty request, IServerStreamWriter<UserModelWithKey> responseStream,
        ServerCallContext context)
        {
            try
            {
                var result = DictionaryToUserModelWithKeyListAdapter(DataStorage.GetInstance().GetAllUsers());
                if (result != null)
                {
                    for (int i = 0; i < result.Count; ++i)
                    {
                        await Task.Delay(2000);
                        await responseStream.WriteAsync(result[i]);
                    }
                }
            }
            catch (Exception e)
            {
                context.Status = new Status(StatusCode.Internal, e.Message);
                Console.WriteLine(context.Status);
            }
        }
        private List<UserModelWithKey> DictionaryToUserModelWithKeyListAdapter(Dictionary<int, UserModel> dict)
        {
            List<UserModelWithKey> result = new List<UserModelWithKey>(dict.Count);
            foreach (var keyValue in dict)
            {
                result.Add(new UserModelWithKey()
                {
                    Key = keyValue.Key,
                    Model = keyValue.Value
                });
            }
            return result;
        }
    }
}