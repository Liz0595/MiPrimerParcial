using Microsoft.AspNetCore.SignalR;
using MIPrimerApi.DAL.Entities;

namespace WebApi2025.Domain.Interfaces
{
    public interface ICountryService
    {

        Task<IEnumerable<Country>> GetCountriesAsync();

        Task<Country> CreateCountryAsync(Country country);

        Task<Country> GetCountryById(Guid id);

        Task<Country> EditCountryAsync(Country country);

        Task<Country> DeleteCountryAsync(Guid id);
    }
}