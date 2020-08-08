using System.Net;
using BPDTSApiTests.Contexts;
using BPDTSApiTests.Services;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BPDTSApiTests.Steps
{
    [Binding]
    public class GetUsersSteps
    {
        private UsersServices _usersServices;
        private readonly TestRunContext _testRunContext;
        public GetUsersSteps(TestRunContext testRunContext)
        {
            _testRunContext = testRunContext;
        }

        [Given(@"I have initialise user client")]
        public void InitialiseUserClient()
        {
            _usersServices = new UsersServices();
        }

        [When(@"I get all users")]
        public void WhenIGetAllUsers()
        {
            _testRunContext.UsersResponse = _usersServices.GetAllUser();
        }

        [When(@"I get the users by city '(.*)'")]
        public void GetUserByCity(string city)
        {
            _testRunContext.City = city;
            _testRunContext.UsersResponse = _usersServices.GetUserByCity(_testRunContext.City);
        }

        [When(@"I get the user by id '(.*)'")]
        public void GetUserById(string userId)
        {
            _testRunContext.Id = userId;
            _testRunContext.UserResponse = _usersServices.GetUserById(_testRunContext.Id);
        }

        [When(@"I get instructions")]
        public void GetInstructions()
        {
            _testRunContext.InstructionsResponse = _usersServices.GetInstructions();
        }

        [Then(@"the response should return status code '(.*)'")]
        public void VerifyStatusCode(HttpStatusCode statusCode)
        {
            if (_testRunContext.UserResponse != null)
            {
                Assert.AreEqual(statusCode, _testRunContext.UserResponse.StatusCode, 
                    $"Expected status code is: '{statusCode}' is not same as actual status code: '{_testRunContext.UserResponse.StatusCode}'");
            }
            else if (_testRunContext.UsersResponse != null)
            {
                Assert.AreEqual(statusCode, _testRunContext.UsersResponse.StatusCode,
                    $"Expected status code is: '{statusCode}' is not same as actual status code: '{_testRunContext.UsersResponse.StatusCode}'");
            }
            else if (_testRunContext.InstructionsResponse != null)
            {
                Assert.AreEqual(statusCode, _testRunContext.InstructionsResponse.StatusCode,
                    $"Expected status code is: '{statusCode}' is not same as actual status code: '{_testRunContext.InstructionsResponse.StatusCode}'");
            }
            else
            {
                Assert.Fail("Response returns null");
            }
        }

        [Then(@"the response returns an error message (.*)")]
        public void VerifyErrorMessage(string error)
        {
            if (_testRunContext.UserResponse != null)
            {
                Assert.IsFalse(_testRunContext.UserResponse.IsSuccessStatusCode,
                    $"Users response success status code: '{_testRunContext.UserResponse.IsSuccessStatusCode}' is not same as expected: 'false'");
                Assert.IsTrue(_testRunContext.UserResponse.Error.Content.Contains(error),
                    $"Actual error message '{_testRunContext.UserResponse.Error.Content}' is not contains expected message '{error}'");
            }
            else if (_testRunContext.UsersResponse != null)
            {
                Assert.IsFalse(_testRunContext.UsersResponse.IsSuccessStatusCode, 
                    $"Users response success status code: '{_testRunContext.UsersResponse.IsSuccessStatusCode}' is not same as expected: 'false'");
                Assert.IsTrue(_testRunContext.UsersResponse.Error.Content.Contains(error),
                    $"Actual error message '{_testRunContext.UsersResponse.Error.Content}' is not contains expected message '{error}'");
            }
            else
            {
                Assert.Fail("Response returns null");
            }
        }

        [Then(@"the response contains a valid (.*) details")]
        public void ResponseContainsAValidUserDetails(string value)
        {
            switch(value)
            {
                case "user":
                    {
                        if (_testRunContext.Id != null)
                        {
                            Assert.IsNotNull(_testRunContext.UserResponse.Content, "User response is null");
                            Assert.IsTrue(_testRunContext.UserResponse.IsSuccessStatusCode,
                                $"Users response success status code: '{_testRunContext.UserResponse.IsSuccessStatusCode}' is not same as expected: 'true'");
                            Assert.AreEqual(_testRunContext.Id, _testRunContext.UserResponse.Content.Id, 
                                $"Expected id: '{_testRunContext.Id}' is not same as actual id: '{_testRunContext.UserResponse.Content.Id}'");
                        }
                        else
                        {
                            Assert.Fail("Response returns null");
                        }
                        break;
                    }
                case "users":
                    {
                        if (_testRunContext.City != null)
                        {
                            Assert.IsNotNull(_testRunContext.UsersResponse.Content, "Users response is null");
                            Assert.IsTrue(_testRunContext.UsersResponse.IsSuccessStatusCode,
                                $"Users response success status code: '{_testRunContext.UsersResponse.IsSuccessStatusCode}' is not same as expected: 'true'");
                            Assert.IsNull(_testRunContext.UsersResponse.Content[0].City);
                        }
                        else
                        {
                            Assert.IsNotNull(_testRunContext.UsersResponse.Content, "Users response is null");
                            Assert.IsTrue(_testRunContext.UsersResponse.Content.Count != 0, 
                                $"Expected users count is not equal to '0' but actual count is: '{_testRunContext.UsersResponse.Content.Count}'");
                        }
                        break;
                    }
                case "instructions":
                    {
                        Assert.IsNotNull(_testRunContext.InstructionsResponse.Content, "Users response is null");
                        Assert.IsTrue(_testRunContext.InstructionsResponse.Content.ToString().Contains(""),
                            $"Actual message '{_testRunContext.InstructionsResponse.Content.ToString()}' is not contains expected message '{"Create a short automated test for this API."}'");
                        break;
                    }
                default:
                    {
                        Assert.Fail($"Input value {value} doesn't match above cases");
                        break;
                    }
            }
        }
    }
}