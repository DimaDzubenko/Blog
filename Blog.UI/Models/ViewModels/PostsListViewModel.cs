using Blog.BussinesLayer.DataTransferObjects;
using System.Collections.Generic;

namespace Blog.UI.Models.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class PostsListViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<PostDTO> Posts { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public PageViewModel PageViewModel { get; set; }
    }
}
