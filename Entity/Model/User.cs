using TableMapping.Entity.Response;

namespace TableMapping.Entity.Model
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Account Account { get; set; }

        public UserResponse ToResponse()
        {
            return new UserResponse
            {
                Id = this.Id,
                Name = this.Name,
                Account = new AccountResponse
                {
                    Id = this.Account.Id,
                    AccountName = this.Account.Name,   
                    Number = this.Account.Number
                }
            };
        }

    }
}
