using Restaurant.Core.Entities;
using Restaurant.DAL.DataContexts;
using Restaurant.DAL.Repositories.Abstractions;
using Restaurant.DAL.Repositories.Implementations.Generic;

namespace Restaurant.DAL.Repositories.Implementations
{

    public class LanguageRepository : Repository<Language>, ILanguageRepository
    {
        public LanguageRepository(AppDbContext context) : base(context)
        {
        }
    }
}
