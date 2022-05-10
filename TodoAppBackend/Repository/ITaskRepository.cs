using TodoAppBackend.Data;
using TodoAppBackend.Models;

namespace TodoAppBackend.Repository
{
    public interface ITaskRepository
    {
        public Task SaveTask(TaskModel taskmodel);
        public Task<IEnumerable<Tasks>> GetTasks();

        public bool DeleteTask(int taskId);
    }
}
