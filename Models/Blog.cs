using Microsoft.EntityFrameworkCore.Update.Internal;

namespace nov30task.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
