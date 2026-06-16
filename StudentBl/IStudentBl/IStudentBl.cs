using ManyToMany.Entity.Request;
using ManyToMany.Entity.Response;
using ManyToMany.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ManyToMany.Interface
{
    public interface IStudentBl
    {
        Task<StudentResponse> AddStudent(StudentRequest request);
        Task<List<StudentResponse>> GetUserAll();

        Task<StudentResponse> UpdateStudent(StudentRequest request,long id);
        Task<StudentResponse> DeleteStudent(long id);
        Task<StudentResponse> GetStudentById(long id);
    }
}
