using Practyc.Application.ApiResponse;
using Practyc.Application.RRModel;



namespace Practyc.Application.Abstraction.IService
{
    public interface IStudentService
    {
        Task<ApiResponse<StudentResponse>> AddStudent(StudentRequest model);


        Task<ApiResponse<StudentResponse>> UpdateStudent(StudentUpdateRequest model);


        Task<int> DeleteStudent(Guid id);


        Task<ApiResponse<StudentResponse>> GetStudentById(Guid Id);


        Task<ApiResponse<IEnumerable<StudentResponse>>> GetStudents();


        Task<ApiResponse<IEnumerable<StudentResponse>>> GetStudentByName(string name);



        Task<ApiResponse<IEnumerable<StudentResponse>>> GetStudentByRollNo(int rollNo);


       
    }
}
