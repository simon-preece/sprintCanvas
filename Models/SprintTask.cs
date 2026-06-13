using System.ComponentModel.DataAnnotations;

namespace sprintCanvas.Models
{
    public class SprintTask
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        // Comma-separated tags
        public string? Tags { get; set; }

        // Owning board and column
        public int BoardId { get; set; }
        public int ColumnId { get; set; }

        // Order within column for simple sorting
        public int Order { get; set; }

        // Optional owner/user id
        public string? OwnerId { get; set; }
    }
}
