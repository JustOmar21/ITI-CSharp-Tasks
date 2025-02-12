using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Day_10.Program;

namespace Day_10
{
    internal class BoardMember : Employee
    {
        public override DateTime BirthDate { get; set; }
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
        public void Resign()
        {
            OnEmployeeLayOff(new EmployeeLayOffEventArgs() { Cause = LayOffCause.Resign });
        }
    }
}
