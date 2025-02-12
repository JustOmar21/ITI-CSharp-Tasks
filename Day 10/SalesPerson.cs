using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Day_10.Program;

namespace Day_10
{
    internal class SalesPerson : Employee
    {
        public int AchievedTarget { get; set; }
        public override bool RequestVacation(DateTime From, DateTime To)
        {
            var days = (From - To).Days;
            if (days > 0 && VacationStock >= days)
            {
                VacationStock -= days;
                return true;
            }
            return false;
        }
        public bool CheckTarget(int Quota)
        {
            if (AchievedTarget < Quota)
            {
                OnEmployeeLayOff(new EmployeeLayOffEventArgs() { Cause = LayOffCause.Target });
                return false;
            }
            return true;
        }
    }
}
