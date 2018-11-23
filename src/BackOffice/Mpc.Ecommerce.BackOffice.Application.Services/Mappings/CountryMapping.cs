namespace Mpc.Ecommerce.BackOffice.Application.Services.Mappings
{
    using System.Collections.Generic;
    using System.Linq;
    using Mpc.Ecommerce.BackOffice.Application.Dto;
    using Mpc.Ecommerce.BackOffice.Domain.Models;

    public static class CountryMapping
    {
        /// <summary>
        /// Convert IEnumerable of UserModel to IEnumerable of UserDto 
        /// </summary>
        public static IEnumerable<CountryDto> ToDto(this IEnumerable<CountryModel> coutries)
        {
            return coutries?.Select(ToDto);
        }

        /// <summary>
        /// Convert Model to Dto
        /// </summary>
        public static CountryDto ToDto(this CountryModel country)
        {
            return country == null ? null : new CountryDto
            {
                Id = country.Id,
                Name = country.Name
            };
        }
    }
}
