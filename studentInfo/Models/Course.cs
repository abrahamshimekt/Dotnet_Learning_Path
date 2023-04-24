public class Course{

    public long ID {get;set;}
    public string CourseName{get;set;}="";
    public string? CourseCode {get;set;}

    public ICollection<StudentCourse>? Students {get;set;}
    public Instructor? Instructor{get;set;}
    public Course(){}
    public Course( string CourseName, string CourseCode){
        this.CourseName = CourseName;
        this.CourseCode = CourseCode;
        this.Students = new List<StudentCourse>();
        this.Instructor = new Instructor();

    }
        
} 