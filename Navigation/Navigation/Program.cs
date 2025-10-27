using System.Security.Claims;

class clsDepartment
{
    public int departmentID;
    public string departmentName;

}

class clsEmployee
{
    public int id;
    public string name;

    public virtual void WriteInfo()
    {
        Console.WriteLine("Employee Info.");
        Console.WriteLine("---------------------");
        Console.WriteLine("Employee Id : " + this.id);
        Console.WriteLine("Employee Name : " + this.name);
    }
}

class clsTeacher : clsEmployee
{

    public int departmentID;
    public int publication;
    private clsDepartment oDepartmant;


    public clsDepartment Department
    {
        get
        {
            oDepartmant = new clsDepartment();

            if (this.departmentID == 1)
            {
                oDepartmant.departmentID = 1;
                oDepartmant.departmentName = "CSE";
            }
            if (this.departmentID == 2)
            {
                oDepartmant.departmentID = 2;
                oDepartmant.departmentName = "EEE";
            }



            return oDepartmant;
        }


    }

    public override void WriteInfo()
    {
        Console.WriteLine("Teacher Info.");
        Console.WriteLine("---------------------");
        Console.WriteLine("Teacher Id : " + this.id);
        Console.WriteLine("Teacher Name : " + this.name);
        Console.WriteLine("Teacher Department Name : " + this.Department.departmentName);
    }
}


class Program
{
    static void Main(string[] args)
    {
        clsEmployee[] employee = new clsEmployee[3];



        clsTeacher teacher1 = new clsTeacher();

        teacher1.id = 1;
        teacher1.name = "Siam";
        teacher1.departmentID = 1;

        employee[0] = teacher1;

        clsTeacher teacher2 = new clsTeacher();

        teacher2.id = 2;
        teacher2.name = "Sourov";
        teacher2.departmentID = 2;

        employee[1] = teacher2;

        clsTeacher teacher3 = new clsTeacher();
        teacher3.id = 3;
        teacher3.name = "Antu";
        teacher3.departmentID = 1;

        employee[2] = teacher3;

        for (int i = 0; i <= 2; i++)
        {
            employee[i].WriteInfo();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }



    }
}