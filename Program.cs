using ObjektoveModelovaniProjekt;

var martin = new Student(1, "Martin");
var klara = new Student(2, "Klara");
var honza = new Student(3, "Honza");

var math = new Course("TAE76E", "Matematika");
var objectModelling = new Course("EIE82E", "Objektové modelování");
var cs = new Course("EIE72E", "Architektura počítačů");

var enrollments = new List<Enrollment>
{
    new (martin, math, Grade.Nedostatecne),
    new (martin, objectModelling, Grade.Vyborne),
    new (martin, cs, Grade.Dobre),
    new (klara, math, Grade.Dostatecne),
    new (klara, objectModelling, Grade.Chvalitebne),
    new (klara, cs, Grade.Nedostatecne),
    new (honza, math, Grade.Dobre),
    new (honza, objectModelling, Grade.Dostatecne),
    new (honza, cs, Grade.Vyborne)
};

var students = new[] { martin, klara, honza };

Console.WriteLine("Student Averages:");
foreach (var student in students)
{
    Console.WriteLine($"{student}: Average Grade = {student.GetAverageGrade():F2}");
}

Console.WriteLine("\nCourse Pass Rates:");
foreach (var course in new[] { math, objectModelling, cs })
{
    Console.WriteLine($"{course}: Pass Rate = {course.GetPassRate():F2}%");
}

Console.WriteLine("\nFailing Students in CS:");
foreach (var s in cs.GetFailingStudents())
{
    Console.WriteLine(s.Name);
}

Console.WriteLine("\nStudents with at least one failing grade:");
var studentsWithFailingGrades = students
    .Where(s => s.Enrollments.Any(e => e.Grade == Grade.Nedostatecne))
    .ToList();

foreach (var student in studentsWithFailingGrades)
{
    Console.WriteLine(student.Name);
}