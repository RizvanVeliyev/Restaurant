using Restaurant.Core.Entities;
using Restaurant.DAL.DataContexts;
using Restaurant.DAL.Repositories.Abstractions;
using Restaurant.DAL.Repositories.Implementations.Generic;

namespace Restaurant.DAL.Repositories.Implementations
{
    public class AvailableTimeRepository : Repository<AvailableTime>, IAvailableTimeRepository
    {
        public AvailableTimeRepository(AppDbContext context) : base(context)
        {
        }
    }
}
