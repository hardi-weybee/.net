using Microsoft.AspNetCore.Identity;
using SpecsAPI.Models;
using System.Threading.Tasks;

namespace SpecsAPI.Repository
{
    public interface IAccountRepository
    {
        //Task<IdentityResult> SignUpAsync(SignUpModel signupModel);
        Task<string> LoginAsync(SignInModel signInModel);
        //Task<IdentityResult> SignUpAdminAsync(SignUpModel signupModel);
    }
}