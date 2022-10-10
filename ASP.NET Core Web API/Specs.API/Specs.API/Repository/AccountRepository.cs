using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SpecsAPI.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SpecsAPI.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _usermanager;
        //private readonly RoleManager<IdentityRole> _roleManager;
        public readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountRepository(UserManager<ApplicationUser> usermanager,
            //RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration)
        {
            _usermanager = usermanager;
            //_roleManager = roleManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        //public async Task<IdentityResult> SignUpAsync(SignUpModel signupModel)
        //{
        //    var userExist = await _usermanager.FindByNameAsync(signupModel.Email);
        //    if(userExist != null)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists" });
        //    }
        //    ApplicationUser user = new ApplicationUser()
        //    {
        //        FirstName = signupModel.FirstName,
        //        LastName = signupModel.LastName,
        //        Email = signupModel.Email,
        //        UserName = signupModel.Email
        //    };

        //    //if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
        //    //    await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
        //    //if (!await _roleManager.RoleExistsAsync(UserRoles.User))
        //    //    await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
        //    //if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
        //    //{
        //    //    await _usermanager.AddToRoleAsync(user, UserRoles.User);
        //    //}
            
        //    return await _usermanager.CreateAsync(user, signupModel.Password);
        //}

        //public async Task<IdentityResult> SignUpAdminAsync(SignUpModel signupModel)
        //{
        //    var userExist = await _usermanager.FindByNameAsync(signupModel.Email);
        //    if(userExist != null)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists" });
        //    }
        //    ApplicationUser user = new ApplicationUser()
        //    {
        //        FirstName = signupModel.FirstName,
        //        LastName = signupModel.LastName,
        //        Email = signupModel.Email,
        //        UserName = signupModel.Email
        //    };

        //    //if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
        //    //    await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
        //    //if (!await _roleManager.RoleExistsAsync(UserRoles.User))
        //    //    await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
        //    //if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
        //    //{
        //    //    await _usermanager.AddToRoleAsync(user, UserRoles.Admin);
        //    //}
            
        //    return await _usermanager.CreateAsync(user, signupModel.Password);
            
        //}

        //private IdentityResult StatusCode(int status500InternalServerError, Response response)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<string> LoginAsync(SignInModel signInModel)
        {
            var result = await _signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, false, false);

            if(!result.Succeeded)
            {
                return null;
            }

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, signInModel.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var authSigninKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuser"],
                audience: _configuration["JWT:validAudience"],
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256Signature)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
