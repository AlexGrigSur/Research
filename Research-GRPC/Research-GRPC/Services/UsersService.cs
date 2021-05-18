using System;
using System.Collections.Generic;
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

        public override Task<UserModel> GetUsers(UserNumber userNumber, ServerCallContext context)
        {
            try
            {
                var storage = DataStorage.GetInstance();
                lock (storage)
                {
                    var result = storage.GetUser(userNumber.Id);
                    if (result == null)
                    {
                        context.Status = new Status(StatusCode.NotFound, "Requested key not found");
                        return Task.FromResult(new UserModel());
                    }
                    return Task.FromResult(result);
                }
            }
            catch (Exception e)
            {
                context.Status = new Status(StatusCode.Internal, e.Message);
                Console.WriteLine(context.Status);
                return Task.FromResult(new UserModel());
            }
        }
        public override Task<UserNumber> AddUser(UserModel model, ServerCallContext context)
        {
            try
            {
                var storage = DataStorage.GetInstance();
                lock (storage)
                {
                    return Task.FromResult(new UserNumber()
                    {
                        Id = storage.AddUser(model)
                    });
                }
            }
            catch (Exception e)
            {
                context.Status = new Status(StatusCode.Internal, e.Message);
                Console.WriteLine(context.Status);
                return Task.FromResult(new UserNumber());
            }

        }
        public override Task<UserQuery> GetAllUsersCollection(Empty request, ServerCallContext context)
        {
            try
            {
                var storage = DataStorage.GetInstance();
                lock (storage)
                {
                    return Task.FromResult(new UserQuery()
                    {
                        ModelsList = { storage.GetAllUsers() }
                    });
                }
            }
            catch (Exception e)
            {
                context.Status = new Status(StatusCode.Internal, e.Message);
                Console.WriteLine(context.Status);
                return Task.FromResult(new UserQuery());
            }
        }
        public override async Task GetAllUsersStream(Empty request, IServerStreamWriter<UserModel> responseStream,
        ServerCallContext context)
        {
            try
            {
                var storage = DataStorage.GetInstance();
                List<UserModel> result;
                lock (storage)
                {
                    result = storage.GetAllUsers();
                }
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
    }
}