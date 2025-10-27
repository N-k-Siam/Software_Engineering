class clsSalaryCalculator
{
    public double basicSalary;
    public AppointType eAppointType;

    public enum AppointType
    {
        Permanent,
        Temporary,
        Casual
    }

    public double getTotalSalary()
    {
        double totalSalary = 0;
        if (eAppointType == AppointType.Permanent)
        {
            totalSalary = basicSalary + basicSalary * 1;
            return totalSalary;
        }
        if (eAppointType == AppointType.Temporary)
        {
            totalSalary = basicSalary + basicSalary * 0.5;
            return totalSalary;
        }
        if (eAppointType == AppointType.Casual)
        {
            totalSalary = basicSalary + basicSalary * 0.1;
            return totalSalary;
        }
        else
        {
            throw new Exception("No Salary is defined.");
        }
    }


}


abstract class clsEmployee
{
    public int id;
    public string name;
    public double basicSalary;

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
        clsSalaryCalculator[] oCalc = new clsSalaryCalculator[2];




        clsTeacher teacher = new clsTeacher();

        teacher.id = 1;
        teacher.name = "Siam";
        teacher.department = "CSE";
        teacher.basicSalary = 100000;

        employee[0] = teacher;

        clsSalaryCalculator oCalcT = new clsSalaryCalculator();
        oCalcT.basicSalary = teacher.basicSalary;
        oCalcT.eAppointType = clsSalaryCalculator.AppointType.Permanent;

        oCalc[0] = oCalcT;



        clsOfficer officer = new clsOfficer();

        officer.id = 2;
        officer.name = "Antu";
        officer.office = "Administartive";
        officer.basicSalary = 50000;

        employee[1] = officer;

        clsSalaryCalculator oClacO = new clsSalaryCalculator();

        oClacO.basicSalary = officer.basicSalary;
        oClacO.eAppointType = clsSalaryCalculator.AppointType.Temporary;

        oCalc[1] = oClacO;






        for (int i = 0; i <= 1; i++)
        {
            employee[i].WriteInfo();
            Console.WriteLine("Total Salary is : " + oCalc[i].getTotalSalary());
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

    }
}

