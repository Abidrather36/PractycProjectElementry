using Practyc.Application.ApiResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Practyc.Application.RRModel.Department;

namespace Practyc.Application.Abstraction.IService
{
    public interface IDepartmentService
    {
        

            Task<ApiResponse<DepartmentResponse>> Add(DepartmentRequest model);

            Task<ApiResponse<DepartmentResponse>> GetById(Guid id);

            Task<ApiResponse<IEnumerable<DepartmentResponse>>> GetAll();

            Task<ApiResponse<DepartmentResponse>> Update(DepartmentUpdateRequest model);

            Task<ApiResponse<DepartmentResponse>> Delete(Guid id);

        
    }
}
