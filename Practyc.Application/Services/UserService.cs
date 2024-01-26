using Convocation.Domain.Enums;
using Practyc.Application.Abstraction.IRepository;
using Practyc.Application.Abstraction.IService;
using Practyc.Application.ApiResponse;
using Practyc.Application.IIdentity;
using Practyc.Application.RRModel;
using Practyc.Application.Utils;
using Practyc.Domain.Entities;

namespace Practyc.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;
        private readonly IContextService contextService;

        public UserService(IUserRepository repository,IContextService contextService)
        {
            this.repository = repository;
            this.contextService = contextService;
        }
        public async Task<ApiResponse<UserResponse>> Add(UserRequest model)
        {
            User user = new User();
            user.Id = Guid.NewGuid();
            user.Username = model.UserName;
            user.Email = model.Email;
            user.Password = model.Password;
            user.Salt = AppEncryption.CreateSalt();
            int returnValue = await repository.InsertAsync(user);
            if(returnValue>0)
            {
                return ApiResponse<UserResponse>.SuccessResponse(new UserResponse
                {
                    Id = user.Id,
                    UserName = model.UserName,
                    Email = model.Email,
                }, "User Inserted Successfully", StatusCode.Created);
            }
            return ApiResponse<UserResponse>.ErrorResponse("something went wrong please try again", StatusCode.BadRequest);


        }

        public async Task<ApiResponse<string>> ChangePassword(ChangeUserPassword model)
        {
           var userId= contextService.UserId();
            var user =await repository.GetById(userId);
            
            if (user is null)
                return ApiResponse<string>.ErrorResponse("Please try again",StatusCode.BadGateway);

            if (!AppEncryption.ComparePassword(user.Password, model.OldPassword,user.Salt))
                return ApiResponse<string>.ErrorResponse("Invalid Credentials", StatusCode.BadGateway);


            return default;

        }

        public async Task<ApiResponse<UserResponse>> Delete(Guid Id)
        {
           int retVal=await repository.DeleteAsync(Id);
            if (retVal == 0)
                return ApiResponse<UserResponse>.ErrorResponse("Please try again", StatusCode.BadRequest);
            return ApiResponse<UserResponse>.SuccessResponse(null, "User Deleted Successfully", StatusCode.Accepted);
        }

        public async Task<ApiResponse<UserResponse>> GetById(Guid Id)
        {
          var userId =await repository.GetById(Id);
            if (userId == null)
                return ApiResponse<UserResponse>.ErrorResponse("please try again", StatusCode.BadRequest);

            return ApiResponse<UserResponse>.SuccessResponse(new UserResponse
            {
                Id=userId.Id,
                UserName=userId.Username,
                Email=userId.Email,
            }, "Information of User", StatusCode.OK);
        }

        public async Task<ApiResponse<IEnumerable<UserResponse>>> GetUserByName(string Username)
        {
          var UsrName= await repository.FindByAsync(x => x.Username == Username);
            if (UsrName == null)
                return ApiResponse<IEnumerable<UserResponse>>.ErrorResponse("no such UserName found", StatusCode.BadRequest);

            return ApiResponse<IEnumerable<UserResponse>>.SuccessResponse(UsrName.Select(u=> new UserResponse
            {
                Id = u.Id,
                UserName=u.Username,
                Email=u.Email,
            }), "Particaular UserName Matches", StatusCode.OK);
        }

        public async Task<ApiResponse<IEnumerable<UserResponse>>> GetUsers()
        {
            var userAll = await repository.GetAllAsync();
            if (userAll == null)
                return ApiResponse<IEnumerable<UserResponse>>.ErrorResponse("something went wrong ", StatusCode.BadGateway);

            return ApiResponse<IEnumerable<UserResponse>>.SuccessResponse(userAll.Select(x => new UserResponse
            {
                Id = x.Id,
                UserName = x.Username,
                Email = x.Email
            }), "Details of All Users", StatusCode.Continue);


        }

        public async Task<ApiResponse<LoginUserResponse>> LogIn(LoginUserRequest model)
        {
            var user = await repository.FirstOrDeafault(x => x.Username == model.UserName);
            if (user is null)
                return ApiResponse<LoginUserResponse>.ErrorResponse("Cannot leave Empty Credentials", StatusCode.BadRequest);
            var Pass=AppEncryption.ComparePassword(user.Password, model.Password, user.Salt);
            if (!Pass)
                return ApiResponse<LoginUserResponse>.ErrorResponse("Invalid Credentials ", StatusCode.BadGateway);

            LoginUserResponse logres = new LoginUserResponse
            {
                UserName = user.Username,
                Id = user.Id
            };

            return ApiResponse<LoginUserResponse>.SuccessResponse(logres, "login Successfully", StatusCode.Accepted);
        }

        public async Task<ApiResponse<UserResponse>> Update(UserUpdateRequest model)
        {
            User user = new User
            {
                Id = model.Id,
                Email=model.Email,
                Password="Qwerty123",
                Username = model.UserName,
                UpdatedOn = DateTimeOffset.Now

            };
            int retVal=await repository.UpdateAsync(user);
            if (retVal == 0)
                return ApiResponse<UserResponse>.ErrorResponse("somethimng went Wrong", StatusCode.BadRequest);

           
            return ApiResponse<UserResponse>.SuccessResponse(new UserResponse
            {
                Id = model.Id,
                UserName = model.UserName,
                Email = model.Email,

            }, "User Updated Succesfully", StatusCode.Accepted);
        }
    }
}
