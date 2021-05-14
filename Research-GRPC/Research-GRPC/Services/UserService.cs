using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Research_GRPC.TempData;

namespace Research_GRPC
{
    public class UserService : UsersHandler.UsersHandlerBase
    {
        private readonly ILogger<UserService> _logger;
        public UserService(ILogger<UserService> logger)
        {
            _logger = logger;
        }

        public override async Task<UserModel> GetRequest(UserID userId, ServerCallContext context)
        {
            return DataStorage.GetData(userId.Id);
        }

        public override async Task<UserID> SetRequest(UserModel model, ServerCallContext context)
        {
            return new UserID() { Id = DataStorage.SetData(model) };
        }

        public override async Task GetAllUsers(Empty request, IServerStreamWriter<UserModel> responseStream,
            ServerCallContext context)
        {
            var result = DataStorage.GetAll();

            for (int i = 0; i < result.Length; ++i)
            {
                await responseStream.WriteAsync(result[i]);
            }
        }
    }
}