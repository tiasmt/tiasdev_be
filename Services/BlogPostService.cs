using System.Text;
using System.Security.Claims;
using System;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using backend.Repository;
using System.Collections.Generic;
using backend.Models;
using System.Threading.Tasks;

namespace backend.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IBlogPostStorage _storage;

        public BlogPostService(IBlogPostStorage storage)
        {
            _storage = storage;
        }
        public async Task<IEnumerable<BlogPostOverview>> GetAllBlogPosts()
        {
           return await _storage.GetAll();
        }

        public async Task<BlogPost> GetBlogPost(int Id)
        {
            return await _storage.Get(Id);
        }
    }

}