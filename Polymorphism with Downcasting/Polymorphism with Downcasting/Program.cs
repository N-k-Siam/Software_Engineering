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

    public string depertment;
    public int publication;

    public override void WriteInfo()
    {
        Console.WriteLine("Teacher Info.");
        Console.WriteLine("---------------------");
        Console.WriteLine("Teacher Id : " + this.id);
        Console.WriteLine("Teacher Name : " + this.name);
        Console.WriteLine("Teacher Depertment Name : " + this.depertment);
        Console.WriteLine("Teacher Total Publication : " + this.publication);
    }
}


class Program
{
    static void Main(string[] args)
    {
        clsEmployee[] employee = new clsEmployee[2];



        clsTeacher teacher1 = new clsTeacher();

        teacher1.id = 1;
        teacher1.name = "Siam";
        teacher1.depertment = "CSE";
        teacher1.publication = 50;

        employee[0] = teacher1;

        clsTeacher teacher2 = new clsTeacher();

        teacher2.id = 2;
        teacher2.name = "Sourov";
        teacher2.depertment = "EEE";
        teacher2.publication = 20;

        employee[1] = teacher2;

        for (int i = 0; i <= 1; i++)
        {
            employee[i].WriteInfo();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }


        for (int i = 0; i <= 1; i++)
        {
            clsTeacher teacherDC = (clsTeacher)employee[i];

            teacherDC.WriteInfo();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }


    }
}