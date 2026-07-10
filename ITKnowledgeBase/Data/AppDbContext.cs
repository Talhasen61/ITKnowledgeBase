using ITKnowledgeBase.Models;
using Microsoft.EntityFrameworkCore;

namespace ITKnowledgeBase.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Article> Articles { get; set; }
    }
}