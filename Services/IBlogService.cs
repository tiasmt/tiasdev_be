using System.Collections.Generic;
using backend.Models;

namespace backend.Services
{
    public interface IBlogPostService
    {
        IEnumerable<BlogPostOverview> GetAllBlogPosts();
        BlogPost GetBlogPost(int Id);

    }
}