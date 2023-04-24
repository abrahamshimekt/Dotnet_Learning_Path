using Microsoft.EntityFrameworkCore;
public class EduDbContext : DbContext{
    public virtual DbSet<Student> Students {get;set;}
    public virtual DbSet<Instructor> Instructors{get;set;}
    public virtual DbSet<Course> Courses {get;set;}
    public virtual DbSet<Dorm> Dorms {get;set;}

    public virtual DbSet<StudentCourse> StudentCourses {get;set;}
    public virtual DbSet<InstructorStudent> InstructorStudents {get;set;}
    public EduDbContext(){}
    public EduDbContext(DbContextOptions<EduDbContext> options):base(options){

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("EduDbConnection");
    protected override void OnModelCreating(ModelBuilder modelBuilder){

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<StudentCourse>().HasKey(sc => new{sc.StudentId,sc.CourseId});

        modelBuilder.Entity<StudentCourse>()
        .HasOne(sc=>sc.Student)
        .WithMany(s=>s.Courses)
        .HasForeignKey(sc=>sc.StudentId);

        modelBuilder.Entity<StudentCourse>()
        .HasOne(sc=>sc.Course)
        .WithMany(c=>c.Students)
        .HasForeignKey(sc=>sc.CourseId);

        modelBuilder.Entity<InstructorStudent>().HasKey(Is=> new {Is.InstructorId,Is.StudentId});

        modelBuilder.Entity<InstructorStudent>()
        .HasOne(Is=>Is.Instructor)
        .WithMany(I=>I.Students)
        .HasForeignKey(Is=>Is.InstructorId);

        modelBuilder.Entity<InstructorStudent>()
        .HasOne(Is=>Is.Student)
        .WithMany(s=>s.Instructors)
        .HasForeignKey(Is=>Is.StudentId);

        modelBuilder.Entity<Student>()
        .HasOne(d=> d.Dorm)
        .WithOne(s=>s.Student)
        .HasForeignKey<Dorm>(x=>x.ID)
        .OnDelete(DeleteBehavior.Cascade)
        .HasConstraintName("FK_Student_Dorm");

        modelBuilder.Entity<Course>()
        .HasOne(I=>I.Instructor)
        .WithMany(c=>c.courses)
        .HasForeignKey(I=>I.ID)
        .OnDelete(DeleteBehavior.Cascade)
        .HasConstraintName("FK_Course_Instructor");

    
    }
    


}