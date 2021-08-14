using Erratas.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Erratas.Domain.Repositories.EntityFramework
{
    public class EFUserLikedPostsRepository : IUserLikedPostsRepository
    {
        public readonly AppDbContext context;
        public EFUserLikedPostsRepository(AppDbContext dbContext)
        {
            this.context = dbContext;
        }

        void AddPost(Guid userId, Guid postId)
        {
            
        }

        string GetPosts(Guid userId)
        {
            
        }
    }
}
