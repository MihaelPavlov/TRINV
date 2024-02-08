using Microsoft.EntityFrameworkCore;
using TRINV.Infrastructure.Common.Persistance;
using TRINV.Infrastructure.Entities;

namespace TRINV.Infrastructure.Investements;

internal interface IInvestmentDbContext : IDbContext
{
    DbSet<Investment> Investments { get; }
}
