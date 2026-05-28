using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Order.Data.DBContext;
using Order.Data.Interfaces;
using Order.DTO.DTO.Request;
using Order.DTO.DTO.Response;
using Order.DTO.Models;

namespace Order.Data.Services
{
    public class UserService : IUserService
    {
        private readonly OrderDbContext _context;
        private readonly IMapper _mapper;
        public UserService(OrderDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async  Task<UserResponse> Create(UserRequest userRequest)
        {
            if (userRequest == null)
            {
                return null;

            }
            var user = _mapper.Map<User>(userRequest);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return _mapper.Map<UserResponse>(user);
        }

        public  async Task<bool> Delete(int id)
        {
            if (id <= 0)
            {
                return false;
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<UserResponse>> GetAll()
        {
           var users=  await _context.Users
                .AsNoTracking()
                .OrderByDescending(u => u.Id)
                .ToListAsync();
            return _mapper.Map<IEnumerable<UserResponse>>(users);
        }

        public async Task<UserResponse> GetById(int id)
        {
            
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
                {
                return null;
            }
            return _mapper.Map<UserResponse>(user);
        }

        public  async Task<UserResponse> Update(int id, UserRequest userRequest)
        {
            var user = await _context.Users.FindAsync(id);  


            if (user == null)
            {
                return null;
            }
            _mapper.Map(userRequest, user);
            await _context.SaveChangesAsync();
            return _mapper.Map<UserResponse>(user);
        }
    }
}
