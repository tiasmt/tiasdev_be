using System.Collections.Generic;
using backend.Models;

namespace backend.Repository
{
    public interface IBlogPostStorage
    {
        IEnumerable<BlogPostOverview> GetAll();

        BlogPost Get(int id);
    }
}