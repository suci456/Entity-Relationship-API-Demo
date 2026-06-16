namespace TableMapping.Entity.Model
{
    public class Account
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
    }
}
