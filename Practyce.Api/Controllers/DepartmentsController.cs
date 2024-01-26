using Microsoft.AspNetCore.Mvc;
using Practyc.Application.Abstraction.IService;
using Practyc.Application.ApiResponse;
using static Practyc.Application.RRModel.Department;

namespace Practyce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService service;

        public DepartmentsController(IDepartmentService service)
        {
            this.service = service;
        }
        [HttpPost]
        public Task<ApiResponse<DepartmentResponse>> Add([FromBody] DepartmentRequest model)
        {
            return service.Add(model);
        }


        [HttpDelete("{id:guid}")]
        public Task<ApiResponse<DepartmentResponse>> Delete([FromRoute] Guid id)
        {
            return service.Delete(id);
        }


        [HttpGet]
        public Task<ApiResponse<IEnumerable<DepartmentResponse>>> GetAll()
        {
            return service.GetAll();
        }


        [HttpGet("{id:guid}")]
        public Task<ApiResponse<DepartmentResponse>> GetById([FromRoute] Guid id)
        {
            return service.GetById(id);
        }


        [HttpPut]
        public Task<ApiResponse<DepartmentResponse>> Update([FromBody] DepartmentUpdateRequest model)
        {
            return service.Update(model);
        }

    }
}
