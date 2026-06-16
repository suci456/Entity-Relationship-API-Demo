using ManyToMany.DatabaseDbcontext;
using ManyToMany.Entity.Model;
using ManyToMany.Entity.Request;
using ManyToMany.Entity.Response;
using Microsoft.EntityFrameworkCore;
using ManyToMany.Interface;

namespace ManyToMany.Interface
{
    public class StudentBr(ManyToManyDbContext context) : IStudentBr
    {
        public async Task<StudentResponse> AddStudent(StudentRequest request)
        {
            string name = request.Name.Trim().ToLower();

            Student? student = await context.Students
                .Include(s => s.StudentCourses)
                .ThenInclude(sc => sc.Course)
                .FirstOrDefaultAsync(x => x.Name.ToLower() == name);

            if (student == null)
            {
                student = new Student
                {
                    Name = request.Name,
                    StudentCourses = new List<StudentCourse>()
                };

              await context.Students.AddAsync(student);
            }

            foreach (CourseRequest item in request.Courses)
            {
                Course? course = await context.Courses
                    .FirstOrDefaultAsync(x => x.Title == item.Title);

                if (course == null)
                {
                    course = new Course
                    {
                        Title = item.Title
                    };
                }

                student.StudentCourses.Add(new StudentCourse
                {
                    Student = student,
                    Course = course
                });
            }

            await context.SaveChangesAsync();

            return student.ToResponse(); 
        }

        public async Task<List<StudentResponse>> GetUserAll()
        {
            List<Student> data = await context.Students
                .Include(s => s.StudentCourses)
                .ThenInclude(sc => sc.Course)
                .ToListAsync();

            return data.Select(s => s.ToResponse()).ToList(); 
        }
        public async Task<StudentResponse> UpdateStudent(StudentRequest request, long id)
        {
            Student student = await context.Students
                .Include(s => s.StudentCourses)
                .ThenInclude(sc => sc.Course)
                .FirstOrDefaultAsync(x => x.Id == id);

            

            student.Name = request.Name;

            if (request.Courses != null)
            {
                foreach (var item in request.Courses)
                {
                   
                  var existing = student.StudentCourses
                        .FirstOrDefault(sc => sc.CourseId == item.Id);

                    if (existing != null)
                    {
                        context.StudentCourses.Remove(existing);

                        
                        var newCourse = await context.Courses
                            .FirstOrDefaultAsync(x => x.Title.ToLower() == item.Title.ToLower());

                        if (newCourse == null)
                        {
                            
                            newCourse = new Course
                            {
                                Title = item.Title
                            };

                            await context.Courses.AddAsync(newCourse);
                            await context.SaveChangesAsync();
                        }

                        
                        student.StudentCourses.Add(new StudentCourse
                        {
                            StudentId = student.Id,
                            CourseId = newCourse.Id
                        });
                    }
                }
            }

            await context.SaveChangesAsync();

            return student.ToResponse();
        }
        public async Task<StudentResponse> DeleteStudent(long id)
        {
            Student? student = await context.Students
                .Include(s => s.StudentCourses)
                .ThenInclude(sc => sc.Course)
                .FirstOrDefaultAsync(x => x.Id == id);

            context.Students.Remove(student);
            await context.SaveChangesAsync();
            return student.ToResponse(); 
        }
        public async Task<StudentResponse> GetStudentById(long id)
        {
            Student? student = await context.Students
                .Include(s => s.StudentCourses)
                .ThenInclude(sc => sc.Course)
                .FirstOrDefaultAsync(x => x.Id == id);
            return student.ToResponse();
        }
    }
}

