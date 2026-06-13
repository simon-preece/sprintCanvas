using System.ComponentModel.DataAnnotations;

namespace sprintCanvas.Models
{
    public class BoardColumn
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        // Order of the column on the board
        public int Order { get; set; }

        public int BoardId { get; set; }
    }
}
