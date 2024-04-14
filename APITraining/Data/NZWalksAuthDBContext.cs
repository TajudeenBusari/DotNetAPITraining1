using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace APITraining.Data
{
    public class NZWalksAuthDBContext : IdentityDbContext
    {
        public NZWalksAuthDBContext(DbContextOptions<NZWalksAuthDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            
            var readerRoleId = "c8089bb9-5d14-4dde-a363-4408114af8ae";
            var writerRoleId = "fc6acbf9-16f8-47ee-87c7-7e5fe9c5fcbc";

            //create a list of roles
            var roles = new List<IdentityRole> 
            { 
                //we will have two roles
                new IdentityRole
                {
                    Id = readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()
                },
                new IdentityRole
                {
                    Id= writerRoleId,
                    ConcurrencyStamp= writerRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);


        }
    }
}

/*ctrl . on the class name to generate a constructor
//the options is coming from our configuration 
in the program.cs file
Use the override OnModelCreating to seed/add data in the database
Generate GUID using the C# interractive
Add migration: Add-Migration "Creating Auth Database" -Context "NZWalksAuthDBContext"
Update Database: Update-Database -Context "NZWalksAuthDBContext"*/