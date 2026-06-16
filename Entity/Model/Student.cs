using ManyToMany.Entity.Response;

namespace ManyToMany.Entity.Model
{
    public class Student
    {
            public int Id { get; set; }
            public string Name { get; set; }

            public List<StudentCourse> StudentCourses { get; set; }


        public StudentResponse ToResponse()
        {
            return new StudentResponse
            {
                Id = this.Id,
                Name = this.Name,
                Courses = this.StudentCourses?
                    .Where(sc => sc.Course != null)
                    .Select(sc => new CourseResponse
                    {
                        Id = sc.Course.Id,
                        Title = sc.Course.Title
                    }).ToList()
            };
        }
    }
}
