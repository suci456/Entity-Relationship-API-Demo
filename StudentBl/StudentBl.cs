using ManyToMany.Entity.Request;
using ManyToMany.Entity.Response;
using ManyToMany.Interface;
using Microsoft.AspNetCore.Mvc;


namespace ManyToMany.Interface
{
    public class StudentBl(IStudentBr studentBr) : IStudentBl
    {
        public async Task<StudentResponse> AddStudent(StudentRequest request)
        {
            return await studentBr.AddStudent(request);
        }
        public async Task<List<StudentResponse>> GetUserAll()
        {
            return await studentBr.GetUserAll();
        }
        public async Task<StudentResponse> UpdateStudent(StudentRequest request,long id)
        {
            return await studentBr.UpdateStudent(request,id);
        }
        public async Task<StudentResponse> DeleteStudent(long id)
        {
            return await studentBr.DeleteStudent(id);
        }
       public async Task<StudentResponse> GetStudentById(long id)
        {
            return await studentBr.GetStudentById(id);
        }
    }
}
