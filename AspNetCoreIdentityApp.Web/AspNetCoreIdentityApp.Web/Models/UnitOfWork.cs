using AspNetCoreIdentityApp.Web.Models.Repositories;
using AspNetCoreIdentityApp.Web.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreIdentityApp.Web.Models
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IBookRepository Books { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Books = new BookRepository(context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
