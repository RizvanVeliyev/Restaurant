using Restaurant.Core.Entities;
using Restaurant.DAL.DataContexts;
using Restaurant.DAL.Repositories.Abstractions;
using Restaurant.DAL.Repositories.Implementations.Generic;

namespace Restaurant.DAL.Repositories.Implementations;

internal class PaymentRepository : Repository<Payment>, IPaymentRepository
{
    public PaymentRepository(AppDbContext context) : base(context)
    {
    }
}
