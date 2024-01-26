using Practyc.Application.ApiResponse;
using Practyc.Application.RRModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practyc.Application.Abstraction.IService
{
    public interface IUserService
    {
        Task<ApiResponse<UserResponse>> Add(UserRequest model);


        Task<ApiResponse<UserResponse>> Update(UserUpdateRequest model);


        Task<ApiResponse<UserResponse>> Delete(Guid Id);


        Task<ApiResponse<LoginUserResponse>> LogIn(LoginUserRequest model);


        Task<ApiResponse<string>> ChangePassword(ChangeUserPassword model);


        Task <ApiResponse<UserResponse>> GetById(Guid Id);

        Task<ApiResponse<IEnumerable<UserResponse>>> GetUserByName(string Username);


        Task<ApiResponse<IEnumerable<UserResponse>>> GetUsers();

       
    }
}
