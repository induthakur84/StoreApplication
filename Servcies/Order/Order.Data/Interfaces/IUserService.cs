using Middleware;
using Order.DTO.DTO.Request;
using Order.DTO.DTO.Response;

namespace Order.Data.Interfaces
{
    [RegisterScoped]
    public interface IUserService
    {
        Task<UserResponse> Create(UserRequest userRequest);
        Task<UserResponse> Update(int id, UserRequest userRequest); 
        Task<bool> Delete(int id);
        Task<UserResponse> GetById(int id);
        Task<IEnumerable<UserResponse>> GetAll();
    }
}
