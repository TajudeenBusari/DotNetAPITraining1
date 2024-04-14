using Web_API_Versioning.Models.Domain;

namespace Web_API_Versioning
{
    public class CountriesData
    {
        public static List<Country> Get()
        {
            var countries = new[]
            {
                new {Id = 1, Name = "Nigeria"},
                new {Id = 2, Name = "Cameroun"},
                new {Id = 3, Name = "Finland"},
                new {Id = 4, Name = "Somalia"},
                new {Id = 5, Name = "Ghana"},
                new {Id = 6, Name = "Sweden"},
                new {Id = 7, Name = "Senegal"},
                new {Id = 8, Name = "Portugal"},
                new {Id = 9, Name = "Mali"},
                new {Id = 10,Name = "Benin"}

            };
            return countries.Select(c => new Country { Id = c.Id, Name = c.Name }).ToList();

        }
    }
}
