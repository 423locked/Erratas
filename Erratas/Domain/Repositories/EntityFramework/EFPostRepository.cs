using Erratas.Domain.Entities;
using Erratas.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Erratas.Domain.Extensions;

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
            {
                post.DateAdded = DateTime.UtcNow;
                context.Entry(post).State = EntityState.Added;
            }
            else
            {
                if (post.TitleImagePath == null)
                    post.TitleImagePath = context.Posts.AsNoTracking().FirstOrDefault(x => x.Id == post.Id).TitleImagePath;
                context.Entry(post).State = EntityState.Modified;
            }

            context.SaveChanges();
        }

        public async Task<List<Post>> SearchPostsAsync(string keywords)
        {
            List<Post> result = new List<Post>();
            List<Post> posts = GetPosts().ToList();
            var titleTask = SearchInTitles(keywords, posts);
            var textTask = SearchInText(keywords, posts);
            List<Post> titlesList = await titleTask;
            List<Post> textList = await textTask;

            result.AddRange(titlesList);
            result.AddRange(textList);
            return result.Distinct().ToList();
        }

        public async Task<List<Post>> SearchInTitles(string keywords, List<Post> posts)
        {
            List<Post> returnList = new List<Post>();
            await Task.Run(() =>
            {
                for (int i = 0; i < posts.Count; i++)
                    if ( (posts[i].Title.ToLower().Contains(keywords.ToLower())) 
                        || (keywords.ToLower().Contains(posts[i].Title.ToLower())))
                    {
                        returnList.Add(posts[i]);
                    }
            });
            return returnList;
        }

        public async Task<List<Post>> SearchInText(string keywords, List<Post> posts)
        {
            List<Post> returnList = new List<Post>();
            await Task.Run(() =>
            {
                for (int i = 0; i < posts.Count; i++)
                    if (posts[i].Text != null)
                        if ((posts[i].Text.ToLower().Contains(keywords.ToLower()))
                            || (keywords.ToLower().Contains(posts[i].Text.ToLower())))
                        {
                            returnList.Add(posts[i]);
                        }
            });
            return returnList;
        }

        public void DeletePost(Guid id)
        {
            context.Posts.Remove(new Post { Id = id });
            context.SaveChanges();
        }

        public void LikePost(Guid id)
        {
            Post post = GetPostById(id);
            post.AmountOfLikes++;
            context.SaveChanges();
        }

        public void RemoveLike(Guid id)
        {
            Post post = GetPostById(id);
            post.AmountOfLikes--;
            context.SaveChanges();
        }
    }
}
