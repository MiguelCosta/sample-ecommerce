namespace Mpc.Ecommerce.BackOffice.Application.Services.Countries
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Mpc.Ecommerce.BackOffice.Application.Dto;

    public interface ICountryService
    {
        Task<List<CountryDto>> GetAllAsync();
    }
}
