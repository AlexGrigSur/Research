using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Research_GRPC.Storage;

namespace Research_GRPC
{
    public class UsersService : UsersHandler.UsersHandlerBase
    {
        private readonly ILogger<UsersService> _logger;
        public UsersService(ILogger<UsersService> logger)
        {
            _logger = logger;
        }

        public override Task<UserModel> GetUsers(UserNumber userNumber, ServerCallContext context)
        {
            var result = DataStorage.GetUser(userNumber.Id);
            if (result == null)
            {
                context.Status = new Status(StatusCode.NotFound, "Requested key not found");
                return Task.FromResult(new UserModel());
            }
            return Task.FromResult(result);
        }
        public override Task<UserNumber> AddUser(UserModel model, ServerCallContext context)
        {
            return Task.FromResult(new UserNumber()
            {
                Id = DataStorage.AddUser(model)
            });
        }
        public override Task<UserQuery> GetAllUsersCollection(Empty request, ServerCallContext context)
        {
            return Task.FromResult(new UserQuery()
            {
                ModelsList = { DataStorage.GetAllUsers() }
            });
        }

        public override async Task GetAllUsersStream(Empty request, IServerStreamWriter<UserModel> responseStream,
        ServerCallContext context)
        {
            var result = DataStorage.GetAllUsers();
            for (int i = 0; i < result.Count; ++i)
            {
                await Task.Delay(5000);
                await responseStream.WriteAsync(result[i]);
            }
        }
    }
}