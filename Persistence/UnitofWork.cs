using System.Threading.Tasks;

namespace ASP_Angular.Persistence
{
    public class UnitofWork : IUnitOfWork
    {
        private readonly VegaDbContext context;

        public UnitofWork(VegaDbContext context)
        {
            this.context = context;
        }
        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}