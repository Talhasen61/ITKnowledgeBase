using System.ComponentModel.DataAnnotations;

namespace ITKnowledgeBase.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Display(Name = "Kategori Adı")]

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        public ICollection<Article> Articles { get; set; } = new List<Article>();
    }
}