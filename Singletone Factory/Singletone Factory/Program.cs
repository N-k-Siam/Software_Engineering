public sealed class University
{
    private static University instance = null;
    private string name = "Jashore University of science and technology";
    private string address = "Ambottola, Jashore";

    public static University getUniversityInstance()
    {
        if (instance == null)
            instance = new University();
        return instance;
    }

    public void getUniversityTnfo()
    {
        Console.WriteLine("----------------------------");
        Console.WriteLine(name + "," + address);
        Console.WriteLine("----------------------------");
    }
}


public class clsEmployee
{
    public int id;
    public string name;

    public virtual void writeInfo()
    {
        University oUni = new University();
        oUni.getUniversityTnfo();

        Console.WriteLine("Employee Info");
        Console.WriteLine("-----------------------");
        Console.WriteLine("Employee Id : " + this.id);
        Console.WriteLine("Employee Name : " + this.name);
    }
}

public class clsTeacherPhD : clsEmployee
{
    public int paper;
    public string designation;

    public override void writeInfo()
    {
        University oUni = new University();
        oUni.getUniversityTnfo();

        Console.WriteLine("Teacher Info");
        Console.WriteLine("-----------------------");
        Console.WriteLine("Teacher Id : " + this.id);
        Console.WriteLine("Teacher Name : " + this.name);
        Console.WriteLine("Teacher Designation : " + this.designation);
        Console.WriteLine("Total Publication : " + this.paper);
    }
}

public class clsTeacherNonPhD : clsEmployee
{
    public int paper;
    public string designation;

    public override void writeInfo()
    {
        University oUni = new University();
        oUni.getUniversityTnfo();

        Console.WriteLine("Teacher Info");
        Console.WriteLine("-----------------------");
        Console.WriteLine("Teacher Id : " + this.id);
        Console.WriteLine("Teacher Name : " + this.name);
        Console.WriteLine("Teacher Designation : " + this.designation);
        Console.WriteLine("Total Publication : " + this.paper);
    }
}

public class clsOfficer : clsEmployee
{
    public string office;

    public override void writeInfo()
    {
        University oUni = new University();
        oUni.getUniversityTnfo();

        Console.WriteLine("Officer Info");
        Console.WriteLine("-----------------------");
        Console.WriteLine("Officer Id : " + this.id);
        Console.WriteLine("Officer Name : " + this.name);
        Console.WriteLine("Officer Office : " + this.office);
    }
}

public class clsFacultyFactory
{
    public clsEmployee getTeacher(string Qualification)
    {
        if (Qualification == "PhD")
        {
            clsTeacherPhD teacher = new clsTeacherPhD();
            teacher.id = 1;
            teacher.name = "Siam";
            teacher.paper = 28;
            teacher.designation = "Assistant Professor";
            return teacher;
        }
        if (Qualification == "MSc")
        {
            clsTeacherNonPhD teacher = new clsTeacherNonPhD();
            teacher.id = 2;
            teacher.name = "Sourov";
            teacher.paper = 8;
            teacher.designation = "Lecturer";
            return teacher;
        }
        return null;
    }
}

public class Program
{
    static void Main(string[] args)
    {
        clsEmployee[] employees = new clsEmployee[3];

        clsFacultyFactory factory = new clsFacultyFactory();

        employees[0] = factory.getTeacher("PhD");
        employees[1] = factory.getTeacher("MSc");

        clsOfficer officer = new clsOfficer();
        officer.id = 3;
        officer.name = "Antu";
        officer.office = "HR";

        employees[2] = officer;

        for (int i = 0; i < 3; i++)
        {
            employees[i].writeInfo();
            Console.WriteLine();
        }
    }
}