using CarWorkshop.Infrastructure.Persistence;

namespace CarWorkshop.Infrastructure.Seeders
{
    public class CarWorkshopSeeder
    {
        private readonly CarWorkshopDbContext _dbContext;

        public CarWorkshopSeeder(CarWorkshopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync() && !_dbContext.CarWorkshops.Any())
            {
                var mazdaAso = new Domain.Entities.CarWorkshop()
                {
                    Name = "Mazda ASO",
                    Description = "Autoryzowany serwis Mazda",
                    ContactDetails = new()
                    {
                        City = "Kraków",
                        Street = "Szewska 2",
                        PostalCode = "30-001",
                        PhoneNumber = "+48699222888"
                    }
                };
                mazdaAso.EncodeName();

                await _dbContext.CarWorkshops.AddAsync(mazdaAso);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
