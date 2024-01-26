using Microsoft.AspNetCore.Mvc;
using Practyc.Application.Abstraction.IService;
using Practyc.Application.ApiResponse;
using Practyc.Application.RRModel;

namespace Practyce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService service;

        public UsersController(IUserService service)
        {
            this.service = service;
        }

        [HttpPost]

        public async Task<ApiResponse<UserResponse>> Add(UserRequest model)
        {
            
            return await service.Add(model);
        }

        [HttpGet]

        public async Task<ApiResponse<IEnumerable<UserResponse>>> GetAll()
        {
            return await service.GetUsers();
        }

        [HttpGet("{Id:guid}")]
        public async Task<ApiResponse<UserResponse>> GetById(Guid Id)
        {
            return await service.GetById(Id);

        }
        [HttpPut]
        public async Task<ApiResponse<UserResponse>> Update(UserUpdateRequest model)
        {
            return await service.Update(model);
        }
        [HttpDelete]

        public async Task<ApiResponse<UserResponse>> Delete(Guid Id)
        {
            return await service.Delete(Id);
        }

        [HttpGet("{Username}")]
        public async  Task<ApiResponse<IEnumerable<UserResponse>>> GetByUserName(string username)
        {
           return await service.GetUserByName(username);

        }
        [HttpPost("Login")]

        public async Task<ApiResponse<LoginUserResponse>> Login(LoginUserRequest model)
        {
            return await service.LogIn(model);
        }

        [HttpPost("ChangePassword")]
        public async Task<ApiResponse<string>> changePassword(ChangeUserPassword model)
        {
            return await service.ChangePassword(model);   

        }
         
    }
}
