namespace ObjektoveModelovaniProjekt;

public class Enrollment
{
    public Student Student { get; }
    public Course Course { get; }
    public Grade Grade { get; }
    
    public Enrollment(Student student, Course course, Grade grade)
    {
        Student = student;
        Course = course;
        Grade = grade;

        Student.Enrollments.Add(this);
        Course.Enrollments.Add(this);
    }

    public bool Passed => Grade <= Grade.Dostatecne;

    public override string ToString() => $"{Student.Name} - {Course.Title} : Grade {Grade}";
}