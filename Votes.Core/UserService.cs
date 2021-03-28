using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Votes.Core.CustomExceptions;
using Votes.Core.DTO;
using Votes.Core.Utilities;
using Votes.DB;

namespace Votes.Core
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IPasswordHasher _passwordHasher;
        public UserService(AppDbContext context, IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<AuthenticatedUser> SignIn(User user)
        {
            var dbUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == user.Email);

            if (dbUser == null || _passwordHasher.VerifyHashedPassword(dbUser.Password, user.Password) == PasswordVerificationResult.Failed)
            {
                throw new InvalidEmailPasswordException("Invalid Username or Password");
            }

            return new AuthenticatedUser
            {
                Token = JwtGenerator.GenerateUserToken(user.Email),
                Email = user.Email,
                Password = user.Password,
                Name = user.Name
            };
        }

        public async Task<AuthenticatedUser> SignUp(User user)
        {
            var checkUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Email.Equals(user.Email));

            if (checkUser != null)
            {
                throw new EmailAlreadyExistsException("Email Already Exists");
            }

            user.Password = _passwordHasher.HashPassword(user.Password);
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();

            return new AuthenticatedUser
            {
                Token = JwtGenerator.GenerateUserToken(user.Email),
                Email = user.Email,
                Password = user.Password,
                Name = user.Name
            };
        }
    }
}
