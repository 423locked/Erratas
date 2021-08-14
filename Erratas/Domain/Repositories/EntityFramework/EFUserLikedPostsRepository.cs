using Erratas.Domain.Entities;
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

        public void AddPost(Guid userId, Guid postId)
        {
            
        }

        public List<UserLikedPosts> GetPosts(Guid userId)
        {
            return null;
        }
    }
}
