using Microsoft.EntityFrameworkCore;
using FinFlow.Core.Entities;

namespace FinFlow.Core.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ApprovalHistory> ApprovalHistories { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<WorkflowTask> WorkflowTasks { get; set; }

    }
}
