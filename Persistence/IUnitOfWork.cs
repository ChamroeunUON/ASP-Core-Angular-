using System.Threading.Tasks;

namespace ASP_Angular.Persistence
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}