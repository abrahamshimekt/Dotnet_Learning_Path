public class Dorm{
    
    public long? ID{get;set;}
    public int DormNumber{get;set;}
    public string? DormBlock{get;set;}

    public  Student? Student {get;set;}
    public Dorm (){}
    public Dorm(int dormNumber,string dormBlock)
    {
        this.DormNumber = dormNumber;
        this.DormBlock = dormBlock;
        this.Student = new Student();
    }
}