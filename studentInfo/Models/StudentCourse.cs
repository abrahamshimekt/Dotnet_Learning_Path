public class StudentCourse
{
    public long StudentId { get; set; }
    public Student? Student { get; set; }
    public long CourseId { get; set; }
    public Course? Course { get; set; }
    public StudentCourse(){}
    public StudentCourse(long StudentId, long courseId){
        this.StudentId = StudentId;
        this.Student = new Student();
        this.CourseId = courseId;
        this.Course = new Course();

    }
}