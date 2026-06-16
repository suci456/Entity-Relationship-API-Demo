using TableMapping.Entity.Request;
using TableMapping.Entity.Response;

namespace TableMapping.Interface
{
    public interface IUserBr
    {
        Task<UserResponse> AddUser(UserRequest request);
        Task<UserResponse> DeleteUser(long id);
        Task<UserResponse> GetUserId(long id);
        Task<UserResponse> UpdateUser(UserRequest request,long id);
     
    }
}
