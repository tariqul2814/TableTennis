using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TableTennis.DataAccess.DBContext;
using TableTennis.Services.DTO.Auth;
using TableTennis.Services.Schedule;

namespace TableTennis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Authentication : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _config;

        public Authentication(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, SignInManager<ApplicationUser> signInManager, IConfiguration config)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _config = config;
        }

        [HttpGet("Test")]
        public IActionResult Test()
        {
            return Ok("Test Ok");
        }

        [HttpGet("Login")]
        [Authorize(Roles = "SuperAdmin,User")]
        public async Task<IActionResult> Login(loginDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.UserName);

            if (user == null)
            {
                return Unauthorized();
            }

            var result = await _signInManager
                         .CheckPasswordSignInAsync(user, loginDTO.Password, false);

            if (result.Succeeded)
            {
                var role = await _userManager.GetRolesAsync(user);
                string roleAssigned = role[0];
                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, roleAssigned)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8
                    .GetBytes(_config.GetSection("AppSettings:Token").Value));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = creds
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);

                var sendToken = tokenHandler.WriteToken(token);

                return Ok(sendToken);
            }
            else
            {
                return Unauthorized();
            }

        }

        [Authorize(Roles = "SuperAdmin,User")]
        public async Task<IActionResult> Registration(RegistrationDTO registrationDTO)
        {
            try
            {
                if (!await _roleManager.RoleExistsAsync("SuperAdmin"))
                {
                    await _roleManager.CreateAsync(new ApplicationRole("SuperAdmin"));
                }

                if (!await _roleManager.RoleExistsAsync("Admin"))
                {
                    await _roleManager.CreateAsync(new ApplicationRole("Admin"));
                }

                var user = new ApplicationUser
                {
                    UserName = registrationDTO.Email,
                    Email = registrationDTO.Email,
                    PasswordHash = registrationDTO.Password
                };

                var success = await _userManager.CreateAsync(user, registrationDTO.Password);

                if (success.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Admin");
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception er)
            {
                return BadRequest();
            }
        }
    }
}
