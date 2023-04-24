public class Student {
   
    public long ID {get;set;}
    public string Name {get;set;} ="";
    public string? Email{get;set;}
    public string Stream{get;set;} ="";
    public double Cgpa{get;set;}
    public Dorm? Dorm {get;set;}
    public ICollection<InstructorStudent>? Instructors {get;set;}
    public ICollection<StudentCourse>? Courses {get;set;}
    public Student(){}
    public Student ( string name , string email,string stream,
    double cgpa){
        
        this.Name = name;
        this.Email = email;
        this.Stream = stream;
        this.Cgpa = cgpa;
        this.Instructors = new List<InstructorStudent>();
        this.Courses = new List<StudentCourse>();
        this.Dorm = new Dorm();

    }

    

}