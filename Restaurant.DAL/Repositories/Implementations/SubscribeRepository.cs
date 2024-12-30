using Restaurant.Core.Entities;
using Restaurant.DAL.DataContexts;
using Restaurant.DAL.Repositories.Abstractions;
using Restaurant.DAL.Repositories.Implementations.Generic;

namespace Restaurant.DAL.Repositories.Implementations
{

    public class SubscribeRepository : Repository<Subscribe>, ISubscribeRepository
    {
        public SubscribeRepository(AppDbContext context) : base(context)
        {
        }
    }
}
