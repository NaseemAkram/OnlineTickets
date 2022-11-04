using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineTickets.Models;

namespace OnlineTickets.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelbilder)
        {
            modelbilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.ActorId,
                am.MovieId
            });


            modelbilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(m => m.Actors_Movies).HasForeignKey(m => m.MovieId);
            modelbilder.Entity<Actor_Movie>().HasOne(m => m.Actor).WithMany(m => m.Actors_Movies).HasForeignKey(m => m.ActorId);


            base.OnModelCreating(modelbilder);

        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor_Movie> Actors_Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producers { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

    }
}
