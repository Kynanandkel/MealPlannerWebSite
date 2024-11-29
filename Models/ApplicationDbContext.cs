using Microsoft.EntityFrameworkCore;

namespace MealPlanner.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Ingredient> ingredient { get; set; }
        public DbSet<Meal>  meal { get; set; }
        public DbSet<MealIngredient> mealIngredient { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredient>(entity => 
            {
                entity.HasKey(i => i.ID);
                entity.Property(i => i.Name).IsRequired();
            });

            modelBuilder.Entity<Meal>(entity => 
            {
                entity.HasKey(m => m.ID);
                entity.Property(m => m.Name).IsRequired();
            });

            modelBuilder.Entity<MealIngredient>(entity => 
            {
                entity.HasKey(mi => new {mi.mealId , mi.ingredientId });

                entity.HasOne(mi => mi.mealId).
                WithMany(m => m.MealIngredients).
                HasForeignKey(mi => mi.mealId).
                OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(mi => mi.ingredientId).
                WithMany(m => m.MealIngredients).
                HasForeignKey(mi => mi.ingredientId).
                OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}
