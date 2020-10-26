using Blog.DataLayer.Interfaces;
using Blog.DataLayer.Models;
using Microsoft.Extensions.Configuration;

namespace Blog.DataLayer.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class PostRepository : GenericRepository<Post>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public PostRepository(IConfiguration configuration) : base(configuration) { }
    }
}
