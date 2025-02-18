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
            Club club = new Club() { ClubID = 1 , ClubName = "club"};
            club.AddMember(sales);
            club.AddMember(emp);
            club.AddMember(board);


            foreach(var staff in club.Members)
            {
                Console.WriteLine(staff.EmployeeID);  
            }
            Console.WriteLine();
            sales.CheckTarget(20);
            Console.WriteLine();
            foreach (var staff in club.Members)
            {
                Console.WriteLine(staff.EmployeeID);
            }

        }
    }
}
