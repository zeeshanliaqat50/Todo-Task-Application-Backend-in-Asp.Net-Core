using System.ComponentModel.DataAnnotations.Schema;
using TodoAppBackend.Models;

namespace TodoAppBackend.Data
{
    public class Tasks
    {
        public int Id { get; set; }
        public string title { get; set; } = "";
        public string description { get; set; } = "";

        public bool isCompleted { get; set; }
            
        public ApplicationUser ApplicationUser { get; set;  }
    }
}
