using ConcreteNg.Shared.Models;
using Microsoft.EntityFrameworkCore;
using File = ConcreteNg.Shared.Models.File;

namespace ConcreteNg.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }
        public DbSet<ProjectTaskItem> ProjectTaskItems { get; set; }
        public DbSet<PricingListItem> PricingListItems { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<DiaryItem> DiaryItems { get; set; }
        public DbSet<File> Files { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PricingListItem>().Property(i => i.PricingListItemId).ValueGeneratedOnAdd();
            modelBuilder.Entity<ProjectTask>().Property(i => i.ProjectTaskId).ValueGeneratedOnAdd();
            modelBuilder.Entity<ProjectTaskItem>().Property(i => i.ProjectTaskItemId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Expense>().Property(i => i.ExpenseId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Partner>().Property(i => i.PartnerId).ValueGeneratedOnAdd();
            modelBuilder.Entity<DiaryItem>().Property(i => i.DiaryItemId).ValueGeneratedOnAdd();
            modelBuilder.Entity<File>().Property(i => i.FileId).ValueGeneratedOnAdd();
        }
    }
}