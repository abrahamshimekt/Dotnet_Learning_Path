using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EduDbContext>(op=>op.UseNpgsql(builder.Configuration.GetConnectionString("EduDbConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var db = new EduDbContext()){
    Student student1 = new Student();
    student1.Name = "Abraham";
    student1.Courses = new List<StudentCourse>{new StudentCourse(StudentId:1,courseId:5)};
    student1.Cgpa = 3.98;
    student1.Email = "abrahfnca@gmail.com";
    student1.Stream = "AI";
    student1.Instructors = new List<InstructorStudent>{new InstructorStudent(StudentId:1,InstructorId:2)};
    
    Course course1 = new Course();
    course1.CourseName = "Maths";
    course1.CourseCode = "11113";
    course1.ID = 3;
    course1.Instructor = new Instructor(Name:"Shimekt",Email:"shimekt@gmail.com");
    course1.Students = new List<StudentCourse> {new StudentCourse(StudentId:4,courseId:3)};

    Instructor instructor1 = new Instructor();
    instructor1.Name = "Shimekt";
    instructor1.Email = "shimekt@gmail.com";
    instructor1.courses = new List<Course> {new Course(CourseName:"Maths",CourseCode:"11113")};
    instructor1.Students = new List<InstructorStudent> {new InstructorStudent(StudentId:3,InstructorId:5)};

    db.Students.Add(student1);
    db.Instructors.Add(instructor1);
    db.Courses.Add(course1);
    db.SaveChanges();
    
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
