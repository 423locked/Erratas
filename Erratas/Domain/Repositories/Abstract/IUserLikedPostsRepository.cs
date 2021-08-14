using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Erratas.Domain.Repositories.Abstract
{
    public interface IUserLikedPostsRepository
    {
        UserLikedPosts GetUser(Guid userId);
        void AddUser(Guid userId);
        void AddPost(Guid postId);
        bool IsPostLiked(Guid postId);
    }
}
