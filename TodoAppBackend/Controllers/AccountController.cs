using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TodoAppBackend.Data;
using TodoAppBackend.Models;
using TodoAppBackend.Repository;

namespace TodoAppBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
  
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository accountRepository;
        private readonly ITaskRepository taskRepository;

        public IHttpContextAccessor HttpContextAccessor { get; }

        public AccountController(IAccountRepository accountRepository,ITaskRepository taskRepository)
        {
            this.accountRepository = accountRepository;
            this.taskRepository = taskRepository;
        }
        [HttpPost("signup")]
       public async Task<IActionResult> Signup([FromBody]SignupModel signupModel )
        {
            var result= await this.accountRepository.Signup(signupModel);
            if(result.Succeeded)
            {
                return Ok(new { 
                    status="true" });
            }

            return Unauthorized();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]SigninModel signinModel)
        {
            var result = await this.accountRepository.Login(signinModel);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();

            }
           
            return Ok(new
            {
                status =true,
                jwt= result.ToString()
            });
        }
        [HttpPost("savetask")]
        [Authorize]
        public IActionResult SaveTask([FromBody] TaskModel task)
        {
            this.taskRepository.SaveTask(task);

               return Ok();

        }
        [HttpGet("gettasks")]
        [Authorize]
        public async Task<IEnumerable<Tasks>> GetTasks()
        {
           var currentTaskList= await this.taskRepository.GetTasks();

            return currentTaskList;  ;
        }
        [HttpDelete("deletetask/{id:int}")]
        [Authorize]
        public async Task<IActionResult> DeleteTask([FromRoute] int id)
        {
            
            var r =  taskRepository.DeleteTask(id);
            if(r==true)
            return Ok(new
            {
                status = true,
            });

            return Ok(new
            {
                status = false,
            });
        }


    }
}
