public class Teacher : User
{
    public string TeacherId { get; set; }
    public string Department { get; set; }

    public Teacher(string userId, string name, string teacherId, string department) : base(userId, name)
    {
        TeacherId = teacherId;
        Department = department;
    }
}
