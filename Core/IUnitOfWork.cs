using System.Threading.Tasks;

namespace ASP_Angular.Core
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}