
using Microsoft.EntityFrameworkCore;

public class MovieDbContext : DbContext{

    public MovieDbContext(){}

    public virtual DbSet<Movie> Movies {get;set;}
    public virtual DbSet<Producer> Producers{get;set;}

    public MovieDbContext(DbContextOptions<MovieDbContext> options): base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Producer>()
        .HasMany(m=>m.Movies)
        .WithOne(p=>p.Producer)
        .OnDelete(DeleteBehavior.Cascade)
        .HasForeignKey("producer_movies");
    }

    

    

    

}