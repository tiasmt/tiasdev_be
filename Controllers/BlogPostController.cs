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
        public IEnumerable<BlogPostOverview> GetAll()
        {
            // return _postsOverview;
            return _blogPostService.GetAllBlogPosts().Reverse();
        }

        [HttpGet("{id}")]
        public BlogPost Get(int id)
        {
            // return _posts[id -1];
            return _blogPostService.GetBlogPost(id);
        }
    }
}
