public class Instructor{
    public long ID {get;set;}
    public string Name {get;set;} ="";
    public string? Email{get;set;}
    public ICollection<Course>? courses{get;set;}
    public ICollection<InstructorStudent>? Students{get;set;}
    public Instructor(){}
    public Instructor (string Name,string Email){
      
        this.Name = Name;
        this.Email = Email;
        this.courses = new List< Course> ();
        this.Students = new List<InstructorStudent> ();
        
    }
}