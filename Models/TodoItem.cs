using System.ComponentModel.DataAnnotations;

namespace Kronos_Server.Models
{
    public class TodoItem
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}