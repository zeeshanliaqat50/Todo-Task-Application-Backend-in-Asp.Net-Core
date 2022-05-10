using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TodoAppBackend.Data;
using TodoAppBackend.Models;

namespace TodoAppBackend.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public TaskRepository(UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor, TodoAppContext DbContext)
        {
            UserManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
            this.DbContext = DbContext;
        }

        public UserManager<ApplicationUser> UserManager { get; }
        public TodoAppContext DbContext { get; }

        public Task SaveTask(TaskModel taskmodel)
        {
          

            Tasks var = new Tasks()
            {
                title = taskmodel.title,
                description = taskmodel.description,
                isCompleted = taskmodel.isCompleted,
                ApplicationUser = this.getCurrentUser(),

            };
            this.DbContext.Tasks.Add(var);
            this.DbContext.SaveChangesAsync();
            return Task.CompletedTask;
        }
        public async Task<IEnumerable<Tasks>> GetTasks()
        {
            var currentUser = getCurrentUser();
            var currentUserTasks = await DbContext.Tasks.Where(x => x.ApplicationUser == currentUser).ToListAsync();

            return  currentUserTasks ;

        }
        public ApplicationUser getCurrentUser()
        {
            var x = httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated;
            var userId = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = UserManager.FindByIdAsync(userId).Result;

            return user;
        }
        public bool DeleteTask(int taskId)
        {
            var currentUser = getCurrentUser();
            var currentUserTasks =  DbContext.Tasks.Where(x => x.ApplicationUser == currentUser && x.Id==taskId).FirstOrDefault();
            if(currentUserTasks!=null)
            {
                
               
                DbContext.Tasks.Remove(currentUserTasks);
                DbContext.SaveChanges();
                    return true;
                
            }
            return false;

            

        }
    }
}
