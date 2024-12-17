using AspNetCoreIdentityApp.Web.Models.Repositories;

namespace AspNetCoreIdentityApp.Web.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        IBookRepository Books { get; }
        int Complete();
    }
}
