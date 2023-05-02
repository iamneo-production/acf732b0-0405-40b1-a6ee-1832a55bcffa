using Microsoft.EntityFrameworkCore;
//using dotnetapp.Models;
using dotnetapp.Models;

namespace dotnetapp.Context
{
    public class yogaTrainerContext : DbContext
    {
        public yogaTrainerContext(DbContextOptions<yogaTrainerContext> options) : base(options) 
        { }
        public DbSet<AdminModel> adminModels { get; set; }
        public DbSet<UserModel> userModels { get; set; }
        public DbSet<LoginModel> loginModels { get; set; }
        public DbSet<JobModel> jobModels { get; set; }
        public DbSet<jobSeekerModel> jobSeekers { get; set; }
    }
}
