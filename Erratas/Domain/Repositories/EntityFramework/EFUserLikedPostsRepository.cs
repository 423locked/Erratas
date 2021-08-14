using Erratas.Domain.Entities;
using Erratas.Domain.Repositories.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Erratas.Domain.Extensions;

namespace Erratas.Domain.Repositories.EntityFramework
{
    public class EFUserLikedPostsRepository : IUserLikedPostsRepository
    {
        private readonly AppDbContext context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IHttpContextAccessor httpContext;
        public EFUserLikedPostsRepository(AppDbContext dbContext, UserManager<IdentityUser> userManager, IHttpContextAccessor httpContext)
        {
            this.context = dbContext;
            this.userManager = userManager;
            this.httpContext = httpContext;
        }

        public void AddUser(Guid userId)
        {
            context.Entry(new UserLikedPosts { Id = userId, ListOfPosts = null }).State = EntityState.Added;
            context.SaveChanges();
        }

        public void AddPost(Guid postId)
        {
            Guid userId = httpContext.GetUserId();
            UserLikedPosts user = context.UserLikedPosts.FirstOrDefault(x => x.Id == userId);
            if (user.ListOfPosts == null) 
                user.ListOfPosts = postId.ToString();
            else 
                user.ListOfPosts += $" {postId.ToString()}";
            context.SaveChanges();
        }

        public UserLikedPosts GetUser(Guid userId)
        {
            return context.UserLikedPosts.FirstOrDefault(x => x.Id == userId);
        }

        public bool IsPostLiked(Guid postId)
        {
            Guid userId = httpContext.GetUserId();
            string posts = GetUser(userId).ListOfPosts;
            if (posts == null) return false;
            foreach(string post in posts.Split(' '))
            {
                if (postId.ToString() == post) return true;
            }
            return false;
        }
    }
}
