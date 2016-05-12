using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using School.Models;

namespace School.Models
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
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<HistoryModel> HistoryModels { get; set; }

        public DbSet<PatronModel> PatronModels { get; set; }

        public DbSet<MaterialBaseModel> MaterialBaseModels { get; set; }

        public DbSet<BasePersonModel> BasePersonModels { get; set; }

        public DbSet<BaseScheduleYearModel> BaseScheduleYearModels { get; set; }

        public DbSet<BaseVacationsModel> BaseVacationsModels { get; set; }

        public DbSet<BaseOffDaysModel> BaseOffDaysModels { get; set; }

        public DbSet<BaseLentTermStartModel> BaseLentTermStartModels { get; set; }

        public DbSet<BaseLentTermEndModel> BaseLentTermEndModels { get; set; }

        public DbSet<BaseHoursModel> BaseHoursModels { get; set; }

        public DbSet<BaseConsultationsModel> BaseConsultationsModels { get; set; }

        public DbSet<BaseReceptionModel> BaseReceptionModels { get; set; }

        public DbSet<BaseSpecialtiesModel> BaseSpecialtiesModels { get; set; }

        public DbSet<BaseYearPlanReceptionModel> BaseYearPlanReceptionModels { get; set; }
    }
}