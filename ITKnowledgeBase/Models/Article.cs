using System.ComponentModel.DataAnnotations;

namespace ITKnowledgeBase.Models
{
    public class Article
    {
        public int Id { get; set; }

        [Display(Name = "Başlık")]
        [Required(ErrorMessage = "Başlık alanı zorunludur.")]
        [StringLength(200, ErrorMessage = "Başlık en fazla 200 karakter olabilir.")]
        public string Title { get; set; } = string.Empty;


        [Display(Name = "İçerik")]
        [Required(ErrorMessage = "İçerik alanı zorunludur.")]
        public string Content { get; set; } = string.Empty;

        [Display(Name = "Oluşturma Tarihi")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        
        public int CategoryId { get; set; }

        [Display(Name = "Kategori")]
        public Category? Category { get; set; }
    }
}
