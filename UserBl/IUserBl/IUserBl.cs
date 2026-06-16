using OneToMany.Entity.Request;
using OneToMany.Entity.Response;


namespace OneToMany.Interface
{
    public interface IUserBl
    {
            Task<UserResponse> AddUser(UserRequest request);
            Task<List<UserResponse>> GetUserAll();
        Task<UserResponse> UpdateUser(UserRequest request,int id);
        Task<UserResponse> DeleteUser(int id);
        Task<UserResponse> GetUserById(int id);
    }
}
