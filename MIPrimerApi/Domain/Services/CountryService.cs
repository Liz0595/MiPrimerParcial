using Microsoft.EntityFrameworkCore;
using MIPrimerApi.DAL.Entities;
using WebApi2025.Domain.Interfaces;

namespace MIPrimerApi.Domain.Services
{
    public class CountryService : ICountryService
    {

        private readonly DataBaseContext _context;

        public CountryService(DataBaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            try { 
            //var countries = await _context.Countries.ToListAsync();

            return await _context.Countries.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new Exception("An error occurred while retrieving the countries.", ex);
            }
        }

        public async Task<Country> GetCountryByIdAsync(Guid id)
        {
            try
            {

                // var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
                // var country = await _context.Countries.FindAsync();
                // var country = await _context.Countries.FirstAsync(c => c.Id == id);

                return await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new Exception("An error occurred while retrieving the country.", ex);
            }
        }

        public async Task<Country> CreateCountryAsync(Country country)
        {
            try { 
            country.Id = Guid.NewGuid(); 
            country.CreatedDate = DateTime.UtcNow;
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();
            return country;
            }
            catch (DbUpdateException ex)
            {
                // Log the exception or handle it as needed
                throw new Exception("An error occurred while creating the country.", ex);
            }
        }

        public Task<Country> DeleteCountryAsync(Guid id)
        {
            try
            {          
                var country = _context.Countries.FirstOrDefault(c => c.Id == id);
                if (country == null)
                {
                    throw new KeyNotFoundException("Country not found.");
                }
                _context.Countries.Remove(country);
                _context.SaveChanges();
                return Task.FromResult(country);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new Exception("An error occurred while deleting the country.", ex);
            }
        }

        public async Task<Country> EditCountryAsync(Country country)
        {
            try
            {
                country.ModifiedDate = DateTime.UtcNow;
                _context.Countries.Update(country);
                await _context.SaveChangesAsync();
                return country;
            }
            catch (DbUpdateException ex)
            {
                // Log the exception or handle it as needed
                throw new Exception("An error occurred while editing the country.", ex);
            }
        }

      
        
    }
}
