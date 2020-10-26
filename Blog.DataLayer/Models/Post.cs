namespace Blog.DataLayer.Models
{
    /// <summary>
    /// Entity data model Post
    /// </summary>
    public class Post
    {
        /// <summary>
        /// Post id
        /// </summary>
        public int PostId { get; set; }
        /// <summary>
        /// Post title 
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Post content
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// Post image
        /// </summary>
        public byte[] Image { get; set; }
    }
}
