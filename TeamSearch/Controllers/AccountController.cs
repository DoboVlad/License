using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly ITokenService _tokenService;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager
            ,ITokenService tokenService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> register(RegisterDTO user)
        {
            if (user.password != user.ConfirmPassword) return BadRequest("Passwords aren't the same");

            if (await emailExists(user.email)) return BadRequest("Email is already userd");

            var registerUser = new User
            {
                UserName = user.email,
                Email = user.email.ToLower(),
                firstName = user.firstName,
                lastName = user.lastName
            };

            var result = await userManager.CreateAsync(registerUser, user.password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return new UserDto
            {
                Id = registerUser.Id,
                email = registerUser.Email,
                token = _tokenService.CreateToken(registerUser)
            };
        }

        private async Task<bool> emailExists(string email)
        {
            return await userManager.Users.AnyAsync(x => x.Email == email);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> login(LoginDTO user)
        {
            var userToLogin = await userManager.FindByEmailAsync(user.email);

            if (userToLogin == null) return Unauthorized("Email or password are incorect");

            var result = await signInManager.CheckPasswordSignInAsync(userToLogin, user.password, false);

            if (!result.Succeeded)
            {
                return Unauthorized();
            }

            return new UserDto
            {
                Id = userToLogin.Id,
                email = userToLogin.Email,
                token = _tokenService.CreateToken(userToLogin)
            };
        }
    }
}
