using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Erratas.Domain.Repositories.Abstract
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetCategories();
        Category GetCategoryById(Guid id);
        Category GetCategoryByTitle(string title);
        void SaveCategory(Category category);
        void DeleteCategory(Guid id);
    }
}
