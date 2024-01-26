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
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;
        private readonly IContextService contextService;
        private readonly IUserRepository userRepository;

        public StudentService(IStudentRepository studentRepository,IContextService contextService,IUserRepository userRepository)
        {
            this.studentRepository = studentRepository;
            this.contextService = contextService;
            this.userRepository = userRepository;
        }
        public async Task<ApiResponse<StudentResponse>> AddStudent(StudentRequest model)
        {

            User user = new User();


               user.Id = Guid.NewGuid();
               user.Username = model.Name;
               user.Address = "Athwajan";
               user.Salt = AppEncryption.CreateSalt();
               user.Password = AppEncryption.CreatepasswordHash("abidnaseer",user.Salt);
               user.Email = model.Email;
            
            Student student = new Student()
            {
                Id = user.Id,
                Name = model.Name,
                RollNo = model.Rollno,
                IsActive = true,
                DepartmentId=model.DepartmentId
            };
            int retVal=  await userRepository.InsertAsync(user);

            if (retVal > 0)
            {
               int retVal1=await  studentRepository.Insert(student);

                if(!(retVal1>0))

                      return ApiResponse<StudentResponse>.ErrorResponse("please try again ", StatusCode.BadRequest);

                return ApiResponse<StudentResponse>.SuccessResponse(new StudentResponse
                {
                    Id = student.Id,
                    Name = model.Name,
                    Rollno = model.Rollno,
                    DepartmentId=student.DepartmentId

                }, "Student Added Succesfully", StatusCode.Created);
            }
              return ApiResponse<StudentResponse>.ErrorResponse("please try again ", StatusCode.BadRequest);



        }

        public async Task<int> DeleteStudent(Guid id)
        {
          int delVal= await studentRepository.Delete(id);
            if (delVal == 0)
                return delVal;
            return delVal;
        }

        public async Task<ApiResponse<StudentResponse>> GetStudentById(Guid Id)
        {
          var byId= await studentRepository.GetById(Id);
            if (byId == null)
                return ApiResponse<StudentResponse>.ErrorResponse("please try again", StatusCode.BadRequest);

            return ApiResponse<StudentResponse>.SuccessResponse(new StudentResponse
            {
                Id=byId.Id,
                Name = byId.Name,   
                Rollno=byId.RollNo
            }, "Student details by Id", StatusCode.OK); 
        }

        public async Task<ApiResponse<IEnumerable<StudentResponse>>> GetStudentByName(string name)
        {
            var studentName=await studentRepository.FindBy(x => x.Name== name);
            if (studentName == null)
                return ApiResponse<IEnumerable<StudentResponse>>.ErrorResponse("please try again ",StatusCode.BadRequest);
            return ApiResponse<IEnumerable<StudentResponse>>.SuccessResponse( studentName.Select(x =>  new StudentResponse
            {
                Id=x.Id,
                Name=x.Name,
                Rollno=x.RollNo
            }),"Student details", StatusCode.OK);
        }

        public async Task<ApiResponse<IEnumerable<StudentResponse>>> GetStudentByRollNo(int rollNo)
        {
          var byrollNo= await studentRepository.FindBy(x => x.RollNo ==rollNo);
            if (byrollNo == null)

                return ApiResponse<IEnumerable<StudentResponse>>.ErrorResponse("cannot find ", StatusCode.BadRequest);

            return ApiResponse<IEnumerable<StudentResponse>>.SuccessResponse(byrollNo.Select(x=> new StudentResponse
            {
                Id=x.Id,
                Name=x.Name,
                Rollno=x.RollNo
            }), "Student Details By RollNo", StatusCode.OK);
        }

        public async Task<ApiResponse<IEnumerable<StudentResponse>>> GetStudents()
        {
            var students = await studentRepository.GetAll();
            if (students == null)
                return ApiResponse<IEnumerable<StudentResponse>>.ErrorResponse("please try again", StatusCode.BadRequest);

            return ApiResponse<IEnumerable<StudentResponse>>.SuccessResponse(students.Select(x => new StudentResponse
            {
                Id=x.Id,
                Name=x.Name,
                Rollno=x.RollNo,
                DepartmentId=x.DepartmentId
                
            }),"",StatusCode.OK);
        }

        public async  Task<ApiResponse<StudentResponse>> UpdateStudent(StudentUpdateRequest model)
        {
            Student studUpd = new Student()
            {
                Id = model.Id,
                Name = model.Name
            };
          int retVal= await studentRepository.Update(studUpd);
            if (retVal > 0)
                return ApiResponse<StudentResponse>.SuccessResponse( new StudentResponse
                {
                    Id=model.Id,
                    Name=model.Name
                },"Student Update Successfully", StatusCode.Accepted);

            return ApiResponse<StudentResponse>.ErrorResponse("Please try again", StatusCode.Accepted);
        }

        public string GetUserDetails()
        {
            Guid Id = contextService.UserId();
            return Id.ToString();
        }
    }
}
