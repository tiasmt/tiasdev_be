using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Services
{
    public interface IBlogPostService
    {
        Task<IEnumerable<BlogPostOverview>> GetAllBlogPosts();
        Task<BlogPost> GetBlogPost(int Id);

    }
}