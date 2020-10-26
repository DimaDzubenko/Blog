namespace Blog.BussinesLayer.DataTransferObjects
{
    /// <summary>
    /// 
    /// </summary>
    public class PostDTO
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
        public byte[] Image { get; set; }
    }
}
