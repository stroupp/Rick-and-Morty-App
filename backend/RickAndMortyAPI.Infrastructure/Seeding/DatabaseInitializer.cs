using Microsoft.Extensions.DependencyInjection;
using RickAndMortyAPI.Infrastructure.Data;
using RickAndMortyAPI.Core.Interfaces; // Ensure this is added to use ICharacterService
using System;
using System.Threading.Tasks;

namespace RickAndMortyAPI.Infrastructure.Seeding
{
    public static class DatabaseInitializer
    {
        public static async Task SeedDatabase(IServiceProvider serviceProvider, bool clearDatabase = false)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var scopedProvider = scope.ServiceProvider;
                try
                {
                    var dbContext = scopedProvider.GetRequiredService<ApplicationDbContext>();
                    var characterService = scopedProvider.GetRequiredService<ICharacterService>();

                    dbContext.Database.EnsureCreated();

                    if (clearDatabase)
                    {
                        ClearDatabase(dbContext);
                    }

                    if (!dbContext.Characters.Any() || !dbContext.Episodes.Any())
                    {
                        await characterService.GetAllCharactersAsync();
                        await characterService.GetAllEpisodesAndSaveAsync();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while seeding the database: {ex.Message}");
                }
            }
        }

        private static void ClearDatabase(ApplicationDbContext dbContext)
        {
            dbContext.Episodes.RemoveRange(dbContext.Episodes);
            dbContext.Characters.RemoveRange(dbContext.Characters);

            dbContext.SaveChanges();
        }
    }

    
}
