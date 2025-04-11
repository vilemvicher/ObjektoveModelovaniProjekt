namespace ObjektoveModelovaniProjekt;

public class Student
{
    public int Id { get; }
    public string Name { get; }
    public List<Enrollment> Enrollments { get; } = new();

    public Student(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public double GetAverageGrade()
    {
        if (!Enrollments.Any()) return 0;
        
        return Enrollments.Average(e => (int)e.Grade);
    }

    public List<Course> GetPassedCourses()
    {
        return Enrollments
            .Where(e => e.Grade != Grade.Nedostatecne)
            .Select(e => e.Course)
            .ToList();
    }

    public override string ToString() => $"{Name} (ID: {Id})";
}