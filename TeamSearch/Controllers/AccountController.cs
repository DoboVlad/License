using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TeamSearch.Data;
using TeamSearch.DTO;
using TeamSearch.Interfaces;
using TeamSearch.Models;

namespace TeamSearch.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;

        public AccountController(DataContext context, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> register(RegisterDTO user)
        {
            if (user.password != user.ConfirmPassword) return BadRequest("Passwords aren't the same");

            if (await emailExists(user.email)) return BadRequest("Email is already userd");

            using var hmac = new HMACSHA512();

            var registerUser = new User
            {
                email = user.email.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.password)),
                PasswordSalt = hmac.Key,
                firstName = user.firstName,
                lastName = user.lastName
            };

            _context.USERS.Add(registerUser);
            await _context.SaveChangesAsync();

            return new UserDto
            {
                Id = registerUser.Id,
                email = registerUser.email,
                token = _tokenService.CreateToken(registerUser)
            };
        }

        private async Task<bool> emailExists(string email)
        {
            return await _context.USERS.AnyAsync(x => x.email == email.ToLower());
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> login(LoginDTO user)
        {
            var userToLogin = await _context.USERS.SingleOrDefaultAsync(x => x.email == user.email);

            if (userToLogin == null) return Unauthorized("Email or password are incorect");

            using var hmac = new HMACSHA512(userToLogin.PasswordSalt);

            var encodedPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.password));

            for (int i = 0; i < encodedPassword.Length; i++)
            {
                if (encodedPassword[i] != userToLogin.PasswordHash[i])
                {
                    return Unauthorized("Email or password are incorect");
                }
            }

            return new UserDto
            {
                Id = userToLogin.Id,
                email = userToLogin.email,
                token = _tokenService.CreateToken(userToLogin)
            };
        }
    }
}
