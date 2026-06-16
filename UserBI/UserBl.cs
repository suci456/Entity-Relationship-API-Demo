using TableMapping.Entity.Request;
using TableMapping.Entity.Response;
using TableMapping.Interface;

namespace TableMapping.Interface
{
    public class UserBl(IUserBr muserBr) :  IUserBl
    {
        public async Task<UserResponse> AddUser(UserRequest request)
        {
            return await muserBr.AddUser(request);
        }
        
        public async Task<UserResponse> GetUserId(long id)
        {
            return await muserBr.GetUserId(id);
        }
        public async Task<UserResponse> UpdateUser(UserRequest request,long id)
        {
            return await muserBr.UpdateUser(request,id);
        }

        public async Task<UserResponse> DeleteUser(long id)
        {
            return await muserBr.DeleteUser(id);
        }
        
    }
   
}
