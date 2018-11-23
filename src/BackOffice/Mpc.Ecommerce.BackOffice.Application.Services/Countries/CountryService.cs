namespace Mpc.Ecommerce.BackOffice.Application.Services.Countries
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Mpc.Ecommerce.BackOffice.Application.Dto;
    using Mpc.Ecommerce.BackOffice.Application.Services.Mappings;
    using Mpc.Ecommerce.BackOffice.Domain.Core;

    internal class CountryService : ICountryService
    {
        private IUnitOfWork _unitOfWork;

        public CountryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CountryDto>> GetAllAsync()
        {
            var countries = await _unitOfWork.CountriesRepository.GetAllAsync().ConfigureAwait(false);

            return countries.ToDto().ToList();
        }
    }
}
