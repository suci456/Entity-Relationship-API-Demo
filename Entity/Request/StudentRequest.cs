namespace ManyToMany.Entity.Request
{
    public class StudentRequest
    {

        
        public string Name { get; set; }
            public List<CourseRequest> Courses { get; set; }
        
    }
}
