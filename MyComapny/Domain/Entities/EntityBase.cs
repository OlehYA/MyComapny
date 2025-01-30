using System.ComponentModel.DataAnnotations;

namespace MyComapny.Domain.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Write name")]
        [Display(Name ="Name")]
        [MaxLength(100)]
        public string? Title { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    }
}
