public sealed class University
{
    private static University instance = null;
    private string name = "Jashore University of Science and Technology";
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
        Console.WriteLine(name + ", " + address);
        Console.WriteLine("----------------------------");
    }
}

public class clsEmployee
{
    public int id;
    public string name;

    public virtual void writeInfo()
    {
        University oUni = University.getUniversityInstance();
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
        University oUni = University.getUniversityInstance();
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
        University oUni = University.getUniversityInstance();
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
        University oUni = University.getUniversityInstance();
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

public interface IEmployeeAdapter
{
    List<clsEmployee> getEmployees();
}

public class clsLegacyTeachingHRSystem
{
    public string[][] getTeachers()
    {
        string[][] sEmployees = new string[2][];

        sEmployees[0] = new string[] { "PhD", "Arif", "01/01/1979", "Jashore", "Assistant Professor", "CSE" };
        sEmployees[1] = new string[] { "MSc", "Rakib", "01/01/1982", "Khulna", "Lecturer", "EEE" };

        return sEmployees;
    }
}

public class clsTeacherAdapter : IEmployeeAdapter
{
    public List<clsEmployee> getEmployees()
    {
        List<clsEmployee> oEmployees = new List<clsEmployee>();

        clsLegacyTeachingHRSystem oLegacyTeachingHRSystem = new clsLegacyTeachingHRSystem();

        string[][] sEmployees = oLegacyTeachingHRSystem.getTeachers();

        foreach (string[] sEmployee in sEmployees)
        {
            clsFacultyFactory oFacultyFactory = new clsFacultyFactory();

            oEmployees.Add(oFacultyFactory.getTeacher(sEmployee[0]));
        }

        return oEmployees;
    }
}

public class clsLegacyOfficialHRSystem
{
    public string[][] getOfficers()
    {
        string[][] sEmployees = new string[2][];

        sEmployees[0] = new string[] { "Reza", "01/01/1979", "Jashore", "Clark (Grade-2)", "HR" };
        sEmployees[1] = new string[] { "Hakim", "01/01/1982", "Khulna", "Clark (Grade-3)", "ACC" };

        return sEmployees;
    }
}

public class clsOfficerAdapter : IEmployeeAdapter
{
    public List<clsEmployee> getEmployees()
    {
        List<clsEmployee> oEmployees = new List<clsEmployee>();

        clsLegacyOfficialHRSystem oLegacyOfficialHRSystem = new clsLegacyOfficialHRSystem();

        string[][] sEmployees = oLegacyOfficialHRSystem.getOfficers();

        foreach (string[] sEmployee in sEmployees)
        {
            clsOfficer oOfficer = new clsOfficer();

            oOfficer.name = sEmployee[0];
            oOfficer.id = 1;
            oOfficer.office = sEmployee[4];

            oEmployees.Add(oOfficer);
        }

        return oEmployees;
    }
}

class Program
{
    static void Main(string[] args)
    {
        clsEmployee[] oEmployees = new clsEmployee[2];
        clsFacultyFactory oFacultyFactory = new clsFacultyFactory();

        oEmployees[0] = oFacultyFactory.getTeacher("PhD");
        oEmployees[1] = oFacultyFactory.getTeacher("MSc");

        IEmployeeAdapter oAdapter = new clsOfficerAdapter();
        List<clsEmployee> officerList = oAdapter.getEmployees();

        Console.WriteLine("######### Teacher Info ##########");
        Console.WriteLine();
        foreach (clsEmployee oEmployee in oEmployees)
        {
            oEmployee.writeInfo();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        Console.WriteLine("######### Officer Info ##########");
        Console.WriteLine();
        foreach (clsEmployee oEmployee in officerList)
        {
            oEmployee.writeInfo();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        Console.ReadLine();
    }
}
