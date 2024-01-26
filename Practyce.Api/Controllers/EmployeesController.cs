using Microsoft.AspNetCore.Mvc;
using Practyc.Application.Abstraction.IService;
using Practyc.Application.ApiResponse;
using Practyc.Application.RRModel;

namespace Practyce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService service;

        public EmployeesController(IEmployeeService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<ApiResponse<EmployeeResponse>> SignUp(EmployeeRequest model)
        {
            return await  service.Add(model);
        }
    }
}
