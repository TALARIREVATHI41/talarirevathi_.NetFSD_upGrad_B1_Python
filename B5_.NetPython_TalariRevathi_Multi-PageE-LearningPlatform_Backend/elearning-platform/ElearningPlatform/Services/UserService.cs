using AutoMapper;
using ElearningPlatform.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace ElearningPlatform.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
      public async Task<UserDto> Register(UserDto dto)
{
    // ✅ Check duplicate email
    var existingUser = await _context.Users
        .FirstOrDefaultAsync(u => u.Email == dto.Email);

    if (existingUser != null)
        throw new Exception("Email already exists");

    var user = new User
    {
        FullName = dto.FullName,
        Email = dto.Email,
        PasswordHash = HashPassword(dto.Password), // ✅ FIX
        CreatedAt = DateTime.Now
    };

    _context.Users.Add(user);
    await _context.SaveChangesAsync();

    return _mapper.Map<UserDto>(user);
}

private string HashPassword(string password)
{
    using var sha256 = SHA256.Create();
    var bytes = Encoding.UTF8.GetBytes(password);
    var hash = sha256.ComputeHash(bytes);
    return Convert.ToBase64String(hash);
}
        public async Task<UserDto> GetById(int id)
{
    var user = await _context.Users.FindAsync(id);

    if (user == null)
        return null;

    return _mapper.Map<UserDto>(user);
}

       public async Task<bool> Update(int id, UserDto dto)
{
    var user = await _context.Users.FindAsync(id);

    if (user == null)
        return false;

    user.FullName = dto.FullName;
    user.Email = dto.Email;

    await _context.SaveChangesAsync();
    return true;
}
    }
}