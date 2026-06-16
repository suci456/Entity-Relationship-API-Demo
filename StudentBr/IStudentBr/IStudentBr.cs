using ManyToMany.Entity.Request;
using ManyToMany.Entity.Response;

namespace ManyToMany.Interface
{
    public interface IStudentBr
    {
        
            Task<StudentResponse> AddStudent(StudentRequest request);
            Task<List<StudentResponse>> GetUserAll();
        Task<StudentResponse> UpdateStudent(StudentRequest request,long id);
        Task<StudentResponse> DeleteStudent(long id);
        Task<StudentResponse> GetStudentById(long id);
    }
}
