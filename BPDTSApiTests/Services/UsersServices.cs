using Refit;
using BPDTSApiTests.Helpers;
using BPDTSApiTests.Client;
using System.Configuration;
using System.Collections.Generic;

namespace BPDTSApiTests.Services
{
    public class UsersServices
    {
        private readonly IUsersClient _usersClient;

        public UsersServices()
        {
            _usersClient = RestService.For<IUsersClient>(ConfigurationManager.AppSettings["BaseUrl"]);
        }

        public ApiResponse<List<UserResponse>> GetAllUser()
        {
            return _usersClient.GetAllUsers("application/json").GetAwaiter().GetResult();
        }

        public ApiResponse<UserResponse> GetUserById(string id)
        {
            return _usersClient.GetUserById(id, "application/json").GetAwaiter().GetResult();
        }

        public ApiResponse<List<UserResponse>> GetUserByCity(string city)
        {
            return _usersClient.GetUserByCity(city, "application/json").GetAwaiter().GetResult();
        }

        public ApiResponse<InstructionsResponse> GetInstructions()
        {
            return _usersClient.GetInstructions("application/json").GetAwaiter().GetResult();
        }
    }
}