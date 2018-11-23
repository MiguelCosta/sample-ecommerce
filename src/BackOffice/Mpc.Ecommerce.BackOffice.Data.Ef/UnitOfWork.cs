namespace Mpc.Ecommerce.BackOffice.Data.Ef
{
    using System.Threading.Tasks;
    using Mpc.Ecommerce.BackOffice.Data.Ef.Repositories;
    using Mpc.Ecommerce.BackOffice.Domain.Core;
    using Mpc.Ecommerce.BackOffice.Domain.Core.Repositories;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            CountriesRepository = new CountriesRepository(_context);
            UsersRepository = new UsersRepository(_context);
        }

        public ICountriesRepository CountriesRepository { get; }

        public IUsersRepository UsersRepository { get; }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
