namespace OneToMany.Entity.Model
{
    public class Order
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
