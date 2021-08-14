using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Erratas.Domain.Entities
{
    public class UserLikedPosts
    {
        public Guid Id { get; set; }
        public List<Guid> ListOfPosts { get; set; }
    }
}
