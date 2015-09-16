using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CarList.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        private List<Car> result;
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Car> Cars { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public async Task<List<string>> GetYears()
        {
            var years = await Database.SqlQuery<string>("GetYears").ToListAsync();
            return years;
        }

        public async Task<List<string>> GetMakes(string year)
        {

            var yearParam = new SqlParameter("@year", year);
            var years = await Database.SqlQuery<string>("GetMakes @year", yearParam).ToListAsync();
            return years;
        }

        public async Task<List<string>> GetModels(string year, string make) //pass the parameter, where year = xxxxx and make = xxxx
        {
            var yearParam = new SqlParameter("@year", year);
            var makeParam = new SqlParameter("@make", make);
            var modelnames = await Database.SqlQuery<string>("GetModels @year, @make").ToListAsync();
            return modelnames;
        }

        public async Task<List<Car>> GetCars(string year)
        {
            var yearParam = new SqlParameter("@year", year);
           
            var GetCarResults = await Database.SqlQuery<Car>("GetCars @year", yearParam).ToListAsync();

            return GetCarResults;
        }
    }
}


