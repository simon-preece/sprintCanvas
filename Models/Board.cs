using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace sprintCanvas.Models
{
    public class Board
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = "My Board";

        // Optional owner/user id
        public string? OwnerId { get; set; }

        public ICollection<BoardColumn>? Columns { get; set; }
        public ICollection<SprintTask>? Tasks { get; set; }
    }
}
