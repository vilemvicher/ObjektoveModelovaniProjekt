namespace ObjektoveModelovaniProjekt;

public class Course
{
   public string Code { get; }
   public string Title { get; }
   public List<Enrollment> Enrollments { get; } = new();

   public Course(string code, string title)
   {
      Code = code;
      Title = title;
   }

   public double GetPassRate()
   {
      if (!Enrollments.Any()) return 0;
      int passed = Enrollments.Count(e => e.Grade != Grade.Nedostatecne);
      return 100.0 * passed / Enrollments.Count;
   }

   public List<Student> GetFailingStudents()
   {
      return Enrollments
         .Where(e => e.Grade == Grade.Nedostatecne)
         .Select(e => e.Student)
         .ToList();
   }

   public override string ToString() => $"{Title} ({Code})";
}