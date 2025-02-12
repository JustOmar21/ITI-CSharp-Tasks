using static Day_10.Program;

namespace Day_10
{
    public class Program
    {
        public enum LayOffCause
        { Age, Vacation, Resign, Target }
        static void Main(string[] args)
        {
            SalesPerson sales = new() { EmployeeID = 25 , AchievedTarget = 10};
            Employee emp = new() { EmployeeID = 21 };
            BoardMember board = new() { EmployeeID = 26 };

            Department department = new Department() { DeptName = "Ay"};
            department.AddStaff(emp);
            department.AddStaff(sales);
            department.AddStaff(board);


            foreach(var staff in department.Staff)
            {
                Console.WriteLine(staff.EmployeeID);  
            }
            Console.WriteLine();
            sales.CheckTarget(20);
            Console.WriteLine();
            foreach (var staff in department.Staff)
            {
                Console.WriteLine(staff.EmployeeID);
            }

        }
    }
}
