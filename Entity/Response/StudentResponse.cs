namespace ManyToMany.Entity.Response
{
    
        public class StudentResponse
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public List<CourseResponse> Courses { get; set; }
        }
    
}
