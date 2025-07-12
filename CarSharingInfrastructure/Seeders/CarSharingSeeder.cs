using CarSharingDomain.DomainModels;
using CarSharingInfrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingInfrastructure.Seeders
{
    public class CarSharingSeeder
    {
        private readonly CarSharingDbContext _dbContext;

        public CarSharingSeeder(CarSharingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if(await _dbContext.Database.CanConnectAsync())
            {
                if(!_dbContext.CarProfileModels.Any())
                {
                    var Mazda6_Kombi = new CarProfileModel
                    {
                        Id = Guid.Parse("cd48433d-7bf2-4fab-9831-39d193c32bf2"),
                        Name = "Mazda 6 Kombi",
                        Description = "Specjalna wersja Mazdy 6, 20th Anniversary, oczarowuje wyjątkowymi," +
                        " eleganckimi elementami: dostępnym tylko w tej wersji lakierem w kolorze Artisan Red," +
                        " wysokiej jakości brązowym wnętrzem z akcentami wykonanymi z wyjątkowego zamszu" +
                        " Leganu® i skóry nappa oraz wieloma innymi niepowtarzalnymi detalami.",
                        Characteristics = new CarChatacteristics()
                        {
                            Engine = "SKYACTIV-G 194KM\r\n194 (143) [KM (kW)] | Silnik benzynowy",
                            Color = "ARTISAN RED",
                            Rims = "OBRĘCZE ALUMINIOWE 19\" 20TH ANNIVERSARY (OPONY 225/45)",
                            Upholstery = "EKSKLUZYWNA TAPICERKA SKÓRZANA NAPPA W KOLORZE BRĄZOWYM"
                        },
                        Image = default!,
                        PricePerDay = 200
                    };
                    await _dbContext.AddAsync(Mazda6_Kombi);
                    await _dbContext.SaveChangesAsync();

                }
            }
        }
    }
}
