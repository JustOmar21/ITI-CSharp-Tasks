using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Day_10.Program;

namespace Day_10
{
    internal class Department
    {
        public int DeptID { get; set; }
        public string DeptName { get; set; }

        public List<Employee> Staff { get; } = new List<Employee>();
        public void AddStaff(Employee E)
        {
            Staff.Add(E);
            E.EmployeeLayOff += RemoveStaff;
            ///Try Register for EmployeeLayOff Event Here
        }
        ///CallBackMethod
        public void RemoveStaff(object sender,
       EmployeeLayOffEventArgs e)
        {
            if (sender is BoardMember board && Staff.Contains(board))
            {
                if (e.Cause == LayOffCause.Resign)
                {
                    Staff.Remove(board);
                    Console.WriteLine($"Employee {board.EmployeeID} has resigned");
                }
            }
            if (sender is SalesPerson sale && Staff.Contains(sale))
            {
                Staff.Remove(sale);
                Console.WriteLine($"Employee {sale.EmployeeID} has been removed due to {e.Cause}");
            }
            else if (sender is Employee emp && Staff.Contains(emp))
            {
                Staff.Remove(emp);
                Console.WriteLine($"Employee {emp.EmployeeID} has been removed due to {e.Cause}");
            }
        }
    }
}
