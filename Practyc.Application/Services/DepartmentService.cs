using Convocation.Domain.Enums;
using Practyc.Application.Abstraction.IRepository;
using Practyc.Application.Abstraction.IService;
using Practyc.Application.ApiResponse;
using static Practyc.Application.RRModel.Department;
using Practyc.Domain.Entities;

namespace Practyc.Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository repository;

        public DepartmentService(IDepartmentRepository repository )
        {
            this.repository = repository;
        }

        public async Task<ApiResponse<DepartmentResponse>> Add(DepartmentRequest model)
        {
            if (await repository.FirstOrDeafault(x => x.DepartmentName == model.DepartmentName) is not null)
                return ApiResponse<DepartmentResponse>.ErrorResponse("Department already exists", StatusCode.BadRequest);
           
           Department dept = new Department();

            dept.Id = Guid.NewGuid();
            dept.DepartmentName = model.DepartmentName;
            int retVal= await repository.InsertAsync(dept);

          
            if (retVal > 0)
                return ApiResponse<DepartmentResponse>.SuccessResponse( new DepartmentResponse
                {
                    Id=dept.Id,
                    DepartmentName=model.DepartmentName,
                }, "Department added successfully", StatusCode.Created);

            return ApiResponse<DepartmentResponse>.ErrorResponse("Something went Wrong", StatusCode.InternalServerError); 
        }

        public Task<ApiResponse<DepartmentResponse>> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<IEnumerable<DepartmentResponse>>> GetAll()
        {
            var departments = await repository.GetAllAsync();

            if (departments.Any())
                return ApiResponse<IEnumerable<DepartmentResponse>>.SuccessResponse(departments.Select(x => new DepartmentResponse
                {
                    Id=x.Id,
                    DepartmentName=x.DepartmentName,
                })
                , $"Found {departments.Count()} departments", StatusCode.OK);

            return ApiResponse<IEnumerable<DepartmentResponse>>.ErrorResponse("No departments found", StatusCode.NotFound);
        }

        public async Task<ApiResponse<DepartmentResponse>> GetById(Guid id)
        {
            var department = await repository.GetById(id);

            if (department is not null)
                return ApiResponse<DepartmentResponse>.SuccessResponse( new DepartmentResponse
                {
                    Id=department.Id,
                    DepartmentName=department.DepartmentName,
                }, "Success", StatusCode.OK);

            return ApiResponse<DepartmentResponse>.ErrorResponse("No department found", StatusCode.NotFound);
        }

        public Task<ApiResponse<DepartmentResponse>> Update(DepartmentUpdateRequest model)
        {
            throw new NotImplementedException();
        }


        /*   if (await repository.FirstOrDefaultAsync<Department>(department => department.DepartmentName == model.DepartmentName) is not null)
               return ApiResponse<DepartmentResponse>.ErrorResponse("Department already exists", StatusCode.BadRequest);


           var department = mapper.Map<Department>(model);


           int returnValue = await repository.InsertAsync<Department>(department);
           if (returnValue > 0)
               return ApiResponse<DepartmentResponse>.SuccessResponse(mapper.Map<DepartmentResponse>(department), "Department added successfully", StatusCode.Created);

           return ApiResponse<DepartmentResponse>.ErrorResponse(ResponseMessages.ServerError, StatusCode.InternalServerError);*/
    }

       
     }
    

