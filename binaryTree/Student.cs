public class Student
{
    public string LastName { get; set; }
    public int Course { get; set; }
    public uint StudentID { get; set; }
    public double AverageGrade { get; set; }
    public string Citizenship { get; set; }

    public Student(string lastName, int course, uint studentID, double averageGrade, string citizenship)
    {
        LastName = lastName;
        Course = course;
        StudentID = studentID;
        AverageGrade = averageGrade;
        Citizenship = citizenship;
    }

    public override string ToString()
    {
        return $"{LastName,-15} {Course,-6} {StudentID,-12} {AverageGrade,-10:F2} {Citizenship,-10}";
    }
}
