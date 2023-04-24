public class InstructorStudent{
    public long StudentId{get;set;}
    public long InstructorId{get;set;}
    public Student? Student{get;set;}
    public Instructor? Instructor{get;set;}

    public InstructorStudent(long StudentId,long InstructorId){
        this.StudentId = StudentId;
        this.InstructorId = InstructorId;


    }


}