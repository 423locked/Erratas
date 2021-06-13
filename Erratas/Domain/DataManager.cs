using Erratas.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Erratas.Domain.Repositories
{
    public class DataManager
    {
        public ICategoryRepository Categories { get; set; }
        public IPostRepository Posts { get; set; }

        public DataManager(ICategoryRepository categoryRepository, IPostRepository postRepository)
        {
            Categories = categoryRepository;
            Posts = postRepository;
        }
    }
}
