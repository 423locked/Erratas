using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Erratas.Domain.Repositories.Abstract
{
    public interface IPostRepository
    {
        IQueryable<Post> GetPosts();
        IQueryable<Post> GetPostsByCategory(Category category);
        Post GetPostById(Guid id);
        void SavePost(Post post);
        void DeletePost(Guid id);
    }
}
