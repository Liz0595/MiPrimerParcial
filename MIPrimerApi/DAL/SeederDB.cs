using MIPrimerApi.DAL.Entities;
using System.Runtime.Serialization;

namespace MIPrimerApi.DAL
{
    public class SeederDB
    {
        private readonly DataBaseContext _context;


        public SeederDB(DataBaseContext context)
        {
            _context = context;
        }
        // metodo llamado SeedrAsync 
        // este metodo es una especie de MAIN()
        // este metodo tendra pobla las diferentes tablas de la base de datos

        public async Task SeedAsync()
        {
            // primero agregare un metodo propio de EF que hace las veces de comando update-database
            // en otras palabras: un metodo que crea la BD inmeditamente ponga en ejecucion mi API
            await _context.Database.EnsureCreatedAsync();

            // a partir de aqui vamos creando metodos que sirven para prepoblar la BD
            await PopulateCountriesAsync();

            await _context.SaveChangesAsync(); // este metodo es propio de EF Core y permite guardar los cambios en la BD

        }
        #region Private Methos
        private async Task PopulateCountriesAsync()
        {
            // el metodo Any () me indica si a tabla countries tiene el menos un registro
            // el metodo Any negada (!) indica que no hay absolutamente nada en la tabla Countries

            if (!_context.Countries.Any())
            {
                // asi creo un objeto pais con sus respectivos estados 
                _context.Countries.Add(new Country
                {
                    CreatedDate = DateTime.Now,
                    Name = "Colombia",
                    States = new List<State>()
                    {
                        new State
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Antioquia"

                        },

                        new State
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Cundinamarca"

                        }

                    }

                });

                _context.Countries.Add(new Country
                {
                    CreatedDate = DateTime.Now,
                    Name = "Argentina",
                    States = new List<State>()
                    {
                        new State
                    {
                        CreatedDate = DateTime.Now,
                        Name = "Buenos Aires"
                    }


                    }

                });

            }
        }
    }
    #endregion
}