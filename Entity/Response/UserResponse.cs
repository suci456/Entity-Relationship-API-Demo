namespace TableMapping.Entity.Response
{
    public class UserResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public AccountResponse Account { get; set; }
    }
}
