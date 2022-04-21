using System;
using System.Linq;
using System.Threading.Tasks;
using Games.DataAcess;
using Games.DataAcess.Entities;
using Games.Domain.Interfaces;
using Games.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Games.Domain.Implementations
{
    public class UserService: IUserService
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly IJwtGenerator _jwtGenerator;
        protected readonly ApplicationDbContext _context;

        public UserService(
            ApplicationDbContext dbContext,
            IJwtGenerator jwtGenerator,
            SignInManager<UserEntity> signInManager,
            UserManager<UserEntity> userManager) 
        {
            _context = dbContext;
            _jwtGenerator = jwtGenerator;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public async Task<UserDto> Login(LoginDto request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new UnauthorizedAccessException();
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (!result.Succeeded) throw new UnauthorizedAccessException();

            var roles = await _userManager.GetRolesAsync(user);
            return new UserDto
            { 
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = _jwtGenerator.CreateToken(user,roles.ToList()),
                UserName = user.UserName,
                Roles = roles.ToList(),
            };
        }
        public async Task<UserDto> Register(RegistrationDto request)
        {
            if (await _context.Users.Where(x => x.Email == request.Email).AnyAsync())
            {
                throw new Exception("Email already exist");
            }

            if (await _context.Users.Where(x => x.UserName == request.UserName).AnyAsync())
            {
                throw new Exception("UserName already exist");
            }

            var newUser = new UserEntity
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                UserName = request.UserName
            };

            var result = await _userManager.CreateAsync(newUser, request.Password);

            if (result.Succeeded)
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == newUser.Email);
                await _userManager.AddToRoleAsync(user, "user");
                var roles = await _userManager.GetRolesAsync(user);

                return new UserDto
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Token = _jwtGenerator.CreateToken(newUser, roles.ToList()),
                    UserName = newUser.UserName,
                    Roles = roles.ToList()
                };
            }

            throw new Exception("Client creation failed");
        }
    }
}
