using BPDTSApiTests.Helpers;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BPDTSApiTests.Client
{
    public interface IUsersClient
    {
        [Get("/city/{city}/users")]
        Task<ApiResponse<List<UserResponse>>> GetUserByCity(string city, [Header("Content-Type")] string contentType);

        [Get("/user/{id}")]
        Task<ApiResponse<UserResponse>> GetUserById(string id, [Header("Content-Type")] string contentType);

        [Get("/users")]
        Task<ApiResponse<List<UserResponse>>> GetAllUsers([Header("Content-Type")] string contentType);

        [Get("/instructions")]
        Task<ApiResponse<InstructionsResponse>> GetInstructions([Header("Content-Type")] string contentType);
    }
}
