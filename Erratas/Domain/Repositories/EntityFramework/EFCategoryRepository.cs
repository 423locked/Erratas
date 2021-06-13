using Erratas.Domain.Entities;
using Erratas.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Erratas.Domain.Repositories.EntityFramework
{
    public class EFCategoryRepository : ICategoryRepository
    {
        public readonly AppDbContext context;
        public EFCategoryRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Category> GetCategories()
        {
            return context.Categories;
        }

        public Category GetCategoryById(Guid id)
        {
            return context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public Category GetCategoryByTitle(string title)
        {
            return context.Categories.FirstOrDefault(c => c.Title == title);
        }

        public void SaveCategory(Category category)
        {
            if (category.Id == default)
                context.Entry(category).State = EntityState.Added;
            else
                context.Entry(category).State = EntityState.Modified;

            context.SaveChanges();
        }

        public void DeleteCategory(Guid id)
        {   
            context.Categories.Remove(new Category { Id = id });
            context.SaveChanges();
        }
    }
}
