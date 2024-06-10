public class Student : User
{
    public string StudentId { get; set; }

    public Student(string userId, string name, string studentId) : base(userId, name)
    {
        StudentId = studentId;
    }
}
