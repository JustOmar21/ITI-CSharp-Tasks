using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Day_10.Program;

namespace Day_10
{
    internal class Club
    {
        public int ClubID { get; set; }
        public String ClubName { get; set; }
        List<Employee> Members;
        public void AddMember(Employee E)
        {
            Members.Add(E);
            E.EmployeeLayOff += RemoveMember;
            ///Try Register for EmployeeLayOff Event Here
        }
        ///CallBackMethod
        public void RemoveMember
       (object sender, EmployeeLayOffEventArgs e)
        {
            if (sender is BoardMember || e.Cause != LayOffCause.Vacation)
            {
                Console.WriteLine($"Board Memebers cannot be removed");
            }
            else if (sender is Employee emp && Members.Contains(emp))
            {
                Members.Remove(emp);
                Console.WriteLine($"Employee {emp.EmployeeID} has been removed due to {e.Cause}");
            }
            ///Employee Will not be removed from the Club if Age>60
            ///Employee will be removed from Club if Vacation Stock < 0
        }
    }
}
