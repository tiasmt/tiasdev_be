using System.Text;
using System.Security.Claims;
using System;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using backend.Repository;
using System.Collections.Generic;
using backend.Models;

namespace backend.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IBlogPostStorage _storage;

        public BlogPostService(IBlogPostStorage storage)
        {
            _storage = storage;
        }
        public IEnumerable<BlogPostOverview> GetAllBlogPosts()
        {
            return _storage.GetAll();
        }

        public BlogPost GetBlogPost(int Id)
        {
            return _storage.Get(Id);
        }
    }

}