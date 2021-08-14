using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Erratas.Domain.Repositories.Abstract
{
    public interface IUserLikedPostsRepository
    {
        string GetPosts(Guid userId);
        void AddPost(Guid userId, Guid postId);
    }
}
