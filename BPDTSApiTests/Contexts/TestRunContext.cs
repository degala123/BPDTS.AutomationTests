using BPDTSApiTests.Helpers;
using Refit;
using System.Collections.Generic;

namespace BPDTSApiTests.Contexts
{
    public class TestRunContext
    {
        public ApiResponse<UserResponse> UserResponse { get; set; }
        public ApiResponse<List<UserResponse>> UsersResponse { get; set; }
        public ApiResponse<InstructionsResponse> InstructionsResponse { get; set; }
        public string Id { get; set; }
        public string City { get; set; }
    }
}
