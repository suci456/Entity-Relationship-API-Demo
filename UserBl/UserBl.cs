using OneToMany.Entity.Request;
using OneToMany.Entity.Response;
using OneToMany.Interface;



namespace OneToMany.Interface
{
    public class UserBl(IUserBr muserBr) : IUserBl
    {
        public async Task<UserResponse> AddUser(UserRequest request)
        {
            return await muserBr.AddUser(request);
        }

        public async Task<List<UserResponse>> GetUserAll()
        {
            return await muserBr.GetUserAll();
        }
        public async Task<UserResponse> UpdateUser(UserRequest request,int id)
        {
            return await muserBr.UpdateUser(request,id);
        }

        public async Task<UserResponse> DeleteUser(int id)
        {
            return await muserBr.DeleteUser(id);
        }
        public async Task<UserResponse> GetUserById(int id)
        {
            return await muserBr.GetUserById(id);
        }
    }
}
