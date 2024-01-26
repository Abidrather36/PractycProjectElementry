using Microsoft.AspNetCore.Mvc;
using Practyc.Application.Abstraction.IService;
using Practyc.Application.ApiResponse;
using Practyc.Application.RRModel;
using System.Text;

namespace Practyce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService service;

        public StudentsController(IStudentService service)
        {
            this.service = service;
        }

        [HttpPost("SignUp")]

        public async Task<ApiResponse<StudentResponse>> SignUp(StudentRequest model)
        {
            return await service.AddStudent(model);

        }
        
        [HttpGet]

        public async Task<ApiResponse<IEnumerable<StudentResponse>>> Get()
        {
            return await service.GetStudents();
        }

        [HttpGet("{name}")]

        public async Task<ApiResponse<IEnumerable<StudentResponse>>> GetByName(string name)
        {
            return await service.GetStudentByName(name);

        }
        [HttpGet("{id:guid}")]
        public async Task<ApiResponse<StudentResponse>> GetById(Guid id)
        {
            return await service.GetStudentById(id);

        }

        [HttpGet("{rollNo:int}")]

        public async Task<ApiResponse<IEnumerable<StudentResponse>>> GetByRollNo(int rollNo)
        {
            return await service.GetStudentByRollNo(rollNo);
        }

        [HttpPut]
        public async Task<ApiResponse<StudentResponse>> Update(StudentUpdateRequest model)
        {
            return await service.UpdateStudent(model);
        }

        [HttpDelete]
        public async Task<int> Delete(Guid Id)
        {
          return await service.DeleteStudent(Id);

        }

        [HttpGet("Encoding")]
        public string Encoding1()
        {
            var str = "abidnaseer";
            var res = Encoding.UTF8.GetBytes(str);
            return Convert.ToBase64String(res);
        }
    }
}
