using APITraining.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace APITraining.Data
{
    public class NZWalksDBContext : DbContext
    {   //because we have multiple dbCOntext, we need to pass the type to each class
        public NZWalksDBContext(DbContextOptions<NZWalksDBContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        //collections inside the database
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        public DbSet <Image> Images{ get; set; }

        /*Seed some data here but before that, use the command
        //delete from Regions; in the sql server so there wont be any 
        //data in the database. Do same for difficulties
        //Create GUID from c# interractive window-->
        view-->other windows-->c# interractive. Use Guid.NewGuid()
        and press enter*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed data for Difficulties-->Easy, Medium, Hard
            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("9f480a29-56d8-48fb-859c-96321fcce1a3"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("8506a759-6f16-457d-9da7-b75b17cb45c6"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("b48ba3a6-d095-4b13-8226-5e6a8739f000"),
                    Name = "Hard"
                }
            };
            
            //actual seeding of Difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);


            //seed data for Regions
            var regions = new List<Region>()
            {
                new Region()
                {
                    Id = Guid.Parse("57f83532-2774-4349-b56a-70a21ca41b54"),
                    Name = "Lagos",
                    Code = "LAG",
                    RegionImageUrl = "https://www.istockphoto.com/fi/valokuva/afrikkalainen-megakaupunki-lagos-nigeria-gm1320231994-406863542"

                },
                new Region()
                {
                    Id = Guid.Parse("e1e558cf-26db-4961-9b51-effecc874f97"),
                    Name = "Osun",
                    Code = "OSU",
                    RegionImageUrl = "https://c8.alamy.com/comp/E8WAKE/streets-of-oshogbo-a-city-in-osun-state-nigeria-E8WAKE.jpg"

                },
                new Region()
                {
                    Id = Guid.Parse("e661ea9e-6cb4-47cd-bade-04c8017fea1e"),
                    Name = "Oyo",
                    Code = "OYO",
                    RegionImageUrl = "https://c8.alamy.com/comp/E8W8H1/streets-of-the-city-of-ibadan-oyo-state-nigeria-E8W8H1.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("f5d9c0b1-32fa-4e61-b705-1ae097e109f1"),
                    Name = "Ogun",
                    Code = "OGU",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/e/ef/The_First_Overhead_Bridge_in_Abeokuta_Ogun_State.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("269166c9-b4ca-4a63-b865-edccee3ab03f"),
                    Name = "Ondo",
                    Code = "OND",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/82/Idanre_Hills_Ondo_State.jpg/2560px-Idanre_Hills_Ondo_State.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("e39156e2-4672-4e38-a61f-bcd20af31397"),
                    Name = "Ekiti",
                    Code = "EKT",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/5/5c/The_Iworoko_mountain_05.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("019505d6-1c17-4372-83ab-1711030957ab"),
                    Name = "Kwara",
                    Code = "KWR",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/cb/Kwarastatedrummers.jpg/220px-Kwarastatedrummers.jpg"
                }

            };
            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
/*then create migration for the data-->
Add-Migration "name of migration"
and update-->
Update-Database
//IN SUMMARY WE HAVE seeded some data for Regions and Difficulties so
//we can use in Walk*/