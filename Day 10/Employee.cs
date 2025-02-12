using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Day_10.Program;

namespace Day_10
{
    public class EmployeeLayOffEventArgs : EventArgs
    {
        public LayOffCause Cause { get; set; }
    }
    internal class Employee
    {
        public event EventHandler<EmployeeLayOffEventArgs> EmployeeLayOff;

        protected virtual void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
        {
            EmployeeLayOff?.Invoke(this, e);
        }
        private DateTime birthDate;
        private int vacationStock;

        public int EmployeeID { get; set; }

        public virtual DateTime BirthDate
        {
            get { return birthDate; }
            set
            {
                if (DateTime.Now.Year - value.Year > 60)
                {
                    OnEmployeeLayOff(new EmployeeLayOffEventArgs() { Cause = LayOffCause.Age });
                }
                birthDate = value;
            }
        }

        public virtual int VacationStock { get; set; }

        public virtual bool RequestVacation(DateTime From, DateTime To)
        {
            var days = (From - To).Days;
            if (days > 0 && VacationStock >= days)
            {
                VacationStock -= days;
                return true;
            }
            if (VacationStock < days)
            {
                OnEmployeeLayOff(new EmployeeLayOffEventArgs() { Cause = LayOffCause.Vacation });
            }
            return false;
        }

        public void EndOfYearOperation()
        {
            throw new NotImplementedException();
        }
    }
}
