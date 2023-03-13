using Assignment_04.Model;

namespace Assignment_04.DAL
{
    public class VideoDbContextInitialiser
    {
        private readonly VideoDbContext bmmContext;


        public VideoDbContextInitialiser(VideoDbContext context)
        {
            this.bmmContext = context;
        }

        public async Task InitialiseAsync()
        {
            try
            {
                await bmmContext.Database.EnsureCreatedAsync();

                if (bmmContext.Videos.Any())
                {
                    return;   // data seeded
                }
                else
                {
                    await TrySeedAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Initializing DB: {ex.Message}");
            }
        }

        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Initializing DB: {ex.Message}");
            }
        }

        public async Task TrySeedAsync()
        {
            try
            {
                await bmmContext.Videos.AddRangeAsync(new Videos[]
                {
                    new Videos{Title="Title1", Year="2020", Quantity=10},
                    new Videos{Title="Title2", Year="2021", Quantity=10},
                    new Videos{Title="Title3", Year="2022", Quantity=10},
                    new Videos{Title="Title4", Year="2020", Quantity=10},
                });

                bmmContext?.SaveChangesAsync();
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Error seesing data. {ex.Message}");
            }
        }
    }
}
