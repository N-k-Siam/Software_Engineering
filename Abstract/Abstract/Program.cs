abstract class clsEmployee
{
    public int id;
    public string name;

    public abstract void WriteInfo();

}

class clsTeacher : clsEmployee
{
    public string department;

    public override void WriteInfo()
    {
        Console.WriteLine("Teacher info");
        Console.WriteLine("----------------------------------");
        Console.WriteLine();
        Console.WriteLine("Teacher Id : " + this.id);
        Console.WriteLine("Teacher Name : " + this.name);
        Console.WriteLine("Teacher Departmet Name : " + this.department);


    }

}

class clsOfficer : clsEmployee
{
    public string office;

    public override void WriteInfo()
    {
        Console.WriteLine("Officer info");
        Console.WriteLine("----------------------------------");
        Console.WriteLine();
        Console.WriteLine("Officer Id : " + this.id);
        Console.WriteLine("Officer Name : " + this.name);
        Console.WriteLine("Officer Office Name : " + this.office);

    }
}

class Program
{
    static void Main(string[] args)
    {
        clsEmployee[] employee = new clsEmployee[2];



        clsTeacher teacher = new clsTeacher();

        teacher.id = 1;
        teacher.name = "Siam";
        teacher.department = "CSE";

        employee[0] = teacher;




        clsOfficer officer = new clsOfficer();

        officer.id = 2;
        officer.name = "Antu";
        officer.office = "Administartive";

        employee[1] = officer;



        //clsEmployee employee2 = new clsEmployee();

        //employee2.id = 3;
        //employee2.name = "Sourov";

        //employee[2] = employee2;


        for (int i = 0; i <= 1; i++)
        {
            employee[i].WriteInfo();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

    }
}

