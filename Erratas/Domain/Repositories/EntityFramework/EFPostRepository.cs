using Erratas.Domain.Entities;
using Erratas.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Erratas.Domain.Repositories.EntityFramework
{
    public class EFPostRepository : Abstract.IPostRepository
    {
        public readonly AppDbContext context;
        public EFPostRepository(AppDbContext context)
        {
            this.context = context;
        }


        public IQueryable<Post> GetPosts()
        {
            return context.Posts;
        }

        public IQueryable<Post> GetPostsByCategory(Category category)
        {
            return context.Posts.Where(p => p.Category == category.Title);
        }

        public Post GetPostById(Guid id)
        {
            return context.Posts.FirstOrDefault(p => p.Id == id);
        }

        public void SavePost(Post post)
        {
            if (post.Id == default)
                context.Entry(post).State = EntityState.Added;
            else
            {
                string oldImagePath = context.Posts.AsNoTracking().FirstOrDefault(p => p.Id == post.Id).TitleImagePath;
                if (post.TitleImagePath != oldImagePath || (oldImagePath == null && post.TitleImagePath != null))
                    context.Entry(post).State = EntityState.Modified;
            }

            context.SaveChanges();
        }

        public void DeletePost(Guid id)
        {
            context.Posts.Remove(new Post { Id = id });
            context.SaveChanges();
        }
    }
}
