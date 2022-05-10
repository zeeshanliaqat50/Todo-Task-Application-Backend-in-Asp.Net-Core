using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TodoAppBackend.Models;

namespace TodoAppBackend.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public UserManager<ApplicationUser> UserManager { get; }
        public SignInManager<ApplicationUser> SignInManager { get; }
        public IConfiguration Configuration { get; }

        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            Configuration = configuration;
        }

        public async Task<IdentityResult> Signup(SignupModel user)
        {
            ApplicationUser applicationUser = new ApplicationUser()
            {
                firstName = user.firstName,
                lastName= user.lastName,
                Email=user.email,
                UserName=user.email
            };
           return await  UserManager.CreateAsync(applicationUser,user.password);

        }

        public async Task<String> Login(SigninModel signinModel)
        {
            var result = await SignInManager.PasswordSignInAsync(signinModel.Email,signinModel.Password,false,false);
            if(!result.Succeeded)
            {
                return null;
            }

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, signinModel.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var authSigninKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: Configuration["JWT:validIssuer"],
                audience: Configuration["JWT:validIssuer"],
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256Signature)


                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    




    }
}
