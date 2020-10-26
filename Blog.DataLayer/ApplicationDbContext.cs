using Blog.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.DataLayer
{
    /// <summary>
    /// 
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Post> Posts { get; set; }
    }
}
