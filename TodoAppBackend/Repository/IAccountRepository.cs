using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TodoAppBackend.Models;

namespace TodoAppBackend.Repository
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> Signup(SignupModel user);
        public Task<String> Login(SigninModel signinModel);

    }
}
