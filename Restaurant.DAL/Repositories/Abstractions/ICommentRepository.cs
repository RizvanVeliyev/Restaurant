using Restaurant.Core.Entities;
using Restaurant.DAL.Repositories.Abstractions.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DAL.Repositories.Abstractions
{
    public interface ICommentRepository : IRepository<Comment>
    {
    }

}
