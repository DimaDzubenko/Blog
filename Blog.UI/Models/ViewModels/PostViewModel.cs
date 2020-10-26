using Microsoft.AspNetCore.Http;

namespace Blog.UI.Models.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class PostViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int PostId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IFormFile Image { get; set; }
    }
}
