using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateCreate { get; set; }
        public string Content { get; set; }
    }
}
