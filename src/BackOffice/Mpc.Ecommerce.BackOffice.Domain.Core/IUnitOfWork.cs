namespace Mpc.Ecommerce.BackOffice.Domain.Core
{
    using System.Threading.Tasks;
    using Mpc.Ecommerce.BackOffice.Domain.Core.Repositories;

    public interface IUnitOfWork
    {
        ICountriesRepository CountriesRepository { get; }

        IUsersRepository UsersRepository { get; }

        Task SaveChangesAsync();
    }
}
