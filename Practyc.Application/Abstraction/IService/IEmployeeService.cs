using Practyc.Application.ApiResponse;
using Practyc.Application.RRModel;

namespace Practyc.Application.Abstraction.IService
{
    public interface IEmployeeService
    {
        Task<ApiResponse<EmployeeResponse>> Add(EmployeeRequest model);
    }
}
