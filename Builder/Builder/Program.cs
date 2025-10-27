public sealed class University
{
    private static University UniversityInstance = null;
    private string sName = "Jashore University of Science and Technology";
    private string sAdress = "Ambottola, Jashore";

    public static University getUniversityInstance()
    {
        if (UniversityInstance == null)
        {
            University oUniversity = new University();
            UniversityInstance = oUniversity;
        }
        return UniversityInstance;
    }

    public void getUniversityTnfo()
    {
        Console.WriteLine("----------------------------");
        Console.WriteLine(sName + ", " + sAdress);
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

    public clsTeacherPhD(string name, int id, string designation, int paper)
    {
        this.name = name;
        this.id = id;
        this.designation = designation;
        this.paper = paper;
    }

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

    public clsTeacherNonPhD(string name, int id, string designation, int paper)
    {
        this.name = name;
        this.id = id;
        this.designation = designation;
        this.paper = paper;
    }

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

// Builder Pattern for Teacher creation
public class clsTeacherBuilder
{
    private string _name;
    private int _id;
    private string _designation;
    private int _papers;

    public clsTeacherBuilder setName(string name)
    {
        this._name = name;
        return this;
    }

    public clsTeacherBuilder setId(int id)
    {
        this._id = id;
        return this;
    }

    public clsTeacherBuilder setDesignation(string designation)
    {
        this._designation = designation;
        return this;
    }

    public clsTeacherBuilder setPapers(int papers)
    {
        this._papers = papers;
        return this;
    }

    public clsTeacherPhD buildTeacherPhD()
    {
        return new clsTeacherPhD(this._name, this._id, this._designation, this._papers);
    }

    public clsTeacherNonPhD buildTeacherNonPhD()
    {
        return new clsTeacherNonPhD(this._name, this._id, this._designation, this._papers);
    }
}

// Factory class for creating Teacher instances based on Qualification
public class clsFacultyFactory
{
    public clsEmployee getTeacher(string qualification, string name, int id, string designation, int paper)
    {
        if (qualification == "PhD")
        {
            clsTeacherPhD teacher = new clsTeacherBuilder()
                .setName(name)
                .setId(id)
                .setDesignation(designation)
                .setPapers(paper)
                .buildTeacherPhD();
            return teacher;
        }
        if (qualification == "MSc")
        {
            clsTeacherNonPhD teacher = new clsTeacherBuilder()
                .setName(name)
                .setId(id)
                .setDesignation(designation)
                .setPapers(paper)
                .buildTeacherNonPhD();
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
            oEmployees.Add(oFacultyFactory.getTeacher(sEmployee[0], sEmployee[1], 1, sEmployee[4], 10));
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

        oEmployees[0] = oFacultyFactory.getTeacher("PhD", "Siam", 1, "Assistant Professor", 28);
        oEmployees[1] = oFacultyFactory.getTeacher("MSc", "Sourov", 2, "Lecturer", 8);

        IEmployeeAdapter oAdapter = new clsOfficerAdapter();
        List<clsEmployee> officerList = oAdapter.getEmployees();

        Console.WriteLine("######### Teacher Info ##########");
        foreach (clsEmployee oEmployee in oEmployees)
        {
            oEmployee.writeInfo();
            Console.WriteLine();
        }

        Console.WriteLine("######### Officer Info ##########");
        foreach (clsEmployee oEmployee in officerList)
        {
            oEmployee.writeInfo();
            Console.WriteLine();
        }

        Console.ReadLine();
    }
}
