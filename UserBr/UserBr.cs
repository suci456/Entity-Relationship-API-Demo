using Microsoft.EntityFrameworkCore;
using TableMapping.DatabaseContext;
using TableMapping.Entity.Model;
using TableMapping.Entity.Request;
using TableMapping.Entity.Response;
using TableMapping.Interface;
public class UserBr(TableMappingDbContext tableMappingDbContext) : IUserBr
{
    public async Task<UserResponse> AddUser(UserRequest request)
    {
        User user = new User
        {
            Name = request.Name,
            Account = new Account
            {
                Name = request.AccountRequest.Name,
                Number = request.AccountRequest.Number
            }
        };

        await tableMappingDbContext.Users.AddAsync(user);
        await tableMappingDbContext.SaveChangesAsync();
        UserResponse response = user.ToResponse();
        return response;
    }

    public async Task<UserResponse> GetUserId(long id)
    {
        User user = await tableMappingDbContext.Users
            .Include(x => x.Account)
            .FirstOrDefaultAsync(x => x.Id == id);

        UserResponse response = user.ToResponse();

        return response; 
    }

    public async Task<UserResponse> UpdateUser(UserRequest request, long id)
    {
        User user = await tableMappingDbContext.Users
            .Include(x => x.Account)
            .FirstOrDefaultAsync(x => x.Id == id); 

        user.Name = request.Name;

        if (user.Account != null)
        {
            user.Account.Name = request.AccountRequest.Name;
            user.Account.Number = request.AccountRequest.Number;
        }

        await tableMappingDbContext.SaveChangesAsync();

        UserResponse response = user.ToResponse();
        return response;
    }

    public async Task<UserResponse> DeleteUser(long id)
    {
        User user = await tableMappingDbContext.Users
            .Include(x => x.Account)
            .FirstOrDefaultAsync(x => x.Id == id);

        tableMappingDbContext.Users.Remove(user);
        await tableMappingDbContext.SaveChangesAsync();
        UserResponse response = user.ToResponse();
        return response;
    }
}