using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Repository
{
    public interface IBlogPostStorage
    {
        Task<IEnumerable<BlogPostOverview>> GetAll();

        Task<BlogPost> Get(int id);
    }
}