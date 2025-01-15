using Microsoft.EntityFrameworkCore;

namespace FamilyBudgetCalculator.Models
{
    /// <summary>
    /// Контекст приложения для базы данных
    /// </summary>
    public class ApplicationContext:DbContext
    {
        /// <summary>
        /// Таблица пользователи
        /// </summary>
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Type> Types { get; set; } = null!;
        public DbSet<Transaction> Transactions { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
    : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=FamilyBudget.db");
        }
    }
}
