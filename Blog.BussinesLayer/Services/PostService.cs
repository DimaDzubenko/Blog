using Blog.BussinesLayer.DataTransferObjects;
using Blog.BussinesLayer.Interfaces;
using Blog.DataLayer.Interfaces;
using Blog.DataLayer.Models;
using Blog.DataLayer.Repositories;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace Blog.BussinesLayer.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class PostService : IService<PostDTO>
    {
        /// <summary>
        /// 
        /// </summary>
        protected IGenericRepository<Post> repository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public PostService(IConfiguration configuration)
        {
            repository = new PostRepository(configuration);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="postViewModel"></param>
        public void Add(PostDTO postViewModel)
        {
            Post newPost = new Post
            {
                PostId = postViewModel.PostId,
                Title = postViewModel.Title,
                Content = postViewModel.Content,
                Image = postViewModel.Image
            };
            repository.Add(newPost);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(PostDTO entity)
        {
            Post delPost = repository.Get(entity.PostId);
            repository.Delete(delPost);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PostDTO Get(int id)
        {
            Post post = repository.Get(id);
            return new PostDTO
            {
                PostId = post.PostId,
                Title = post.Title,
                Content = post.Content,
                Image = post.Image
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PostDTO> GetAll()
        {
            return repository
                        .GetAll()
                          .Select(post => new PostDTO
                          {
                              PostId = post.PostId,
                              Title = post.Title,
                              Content = post.Content,
                              Image = post.Image
                          });
        }

        /// <summary>
        /// 
        /// </summary>
        public void Save()
        {
            repository.Save();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="postViewModel"></param>
        public void Update(PostDTO postViewModel)
        {
            Post newPost = repository.Get(postViewModel.PostId);
            if (newPost != null)
            {
                newPost.PostId = postViewModel.PostId;
                newPost.Title = postViewModel.Title;
                newPost.Content = postViewModel.Content;
                newPost.Image = postViewModel.Image;
            }
            repository.Save();
        }
    }
}
