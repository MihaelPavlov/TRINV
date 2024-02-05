using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TRINV.Infrastructure.Entities;
using TRINV.Infrastructure.Investements;

namespace TRINV.Infrastructure.Common.Persistance
{
    public class InvestTrackerDbContext : DbContext, IInvestmentDbContext
    {
        public InvestTrackerDbContext(
            DbContextOptions<InvestTrackerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Investment> Investments { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
