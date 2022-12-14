using CoWorking.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CoWorking.Data.Access
{
    public class DomainDbContext : DbContext
    {
        public readonly IConfiguration Configuration;

        public DomainDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public DbSet<Area> Areas { set; get; }
        public DbSet<Booking> Bookings { set; get; }
        public DbSet<BookingDetail> BookingDetails { set; get; }
        public DbSet<CategoryService> CategoryServices { set; get; }
        public DbSet<CategoryOffice> CategoryOffices { set; get; }
        public DbSet<CategorySpace> CategorySpaces { set; get; }
        public DbSet<Customer> Customers { set; get; }
        public DbSet<User> Users { set; get; }
        public DbSet<FeedBack> FeedBacks { set; get; }
        public DbSet<Manager> Managers { set; get; }
        public DbSet<Office> Offices { set; get; }
        public DbSet<OfficeImage> OfficeImages { set; get; }
        public DbSet<OfficeInCategory> OfficeInCategories { set; get; }
        public DbSet<Role> Roles { set; get; }
        public DbSet<Service> Services { set; get; }
        public DbSet<Space> Spaces { set; get; }
        public DbSet<Staff> Staffs { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manager>(e =>
            {
                e.HasKey(x => new { x.OfficeId, x.StaffId });
            });
            modelBuilder.Entity<OfficeInCategory>(e =>
            {
                e.HasKey(x => new { x.OfficeId, x.CategoryOfficeId });
            });
        }
    }
}