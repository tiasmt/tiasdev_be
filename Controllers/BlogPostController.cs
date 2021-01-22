using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using backend.Models;
using backend.Services;

namespace backend.Controllers
{
    [ApiController]
    [Route("rest/api/latest/posts")]
    public class BlogPostController : ControllerBase
    {
        private readonly ILogger<BlogPostController> _logger;
        private IBlogPostService _blogPostService;
        public BlogPostController(ILogger<BlogPostController> logger, IBlogPostService blogPostService)
        {
            _logger = logger;
            _blogPostService = blogPostService;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<BlogPostOverview>> GetAll()
        {
            var posts = await _blogPostService.GetAllBlogPosts();
            return posts.Reverse();
        }

        [HttpGet("{id}")]
        public async Task<BlogPost> Get(int id)
        {
            return await _blogPostService.GetBlogPost(id);
        }
    }
}
