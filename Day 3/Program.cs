namespace Day_3
{
    enum Gender:byte { Male,Female}
    [Flags]
    enum Security : byte { Guest = 0x01 , Developer = 0x02 , Secretary = 0x04 , DBA = 0x08}
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee[] emps = new Employee[3];

            for(int i = 0;i < emps.Length;i++)
            {
                emps[i] = new Employee();

                Console.Write($"Employee {i + 1}'s ID: ");
                emps[i].setID(Convert.ToInt32(Console.ReadLine()));

                Console.Write($"Employee {i + 1}'s Salary: ");
                emps[i].setSalary(Convert.ToDouble(Console.ReadLine()));

                Console.Write($"Employee {i + 1}'s HireDate Year: ");
                int year = Convert.ToInt32(Console.ReadLine());

                Console.Write($"Employee {i + 1}'s HireDate Month: ");
                int month = Convert.ToInt32(Console.ReadLine());

                Console.Write($"Employee {i + 1}'s HireDate Day: ");
                int day = Convert.ToInt32(Console.ReadLine());

                emps[i].setHireDate(new HireDate(year, month, day));
                Console.Write($"Employee {i + 1}'s Security Clearance: ");

                emps[i].setSecurity(Enum.Parse<Security>(Console.ReadLine()));
                Console.Write($"Employee {i + 1}'s Gender: ");

                emps[i].setGender(Enum.Parse<Gender>(Console.ReadLine()));
                Console.WriteLine();
            }

        }

        struct HireDate : IComparable
        {
            public int year;
            public int month;
            public int day;

            public HireDate(int year,int month,int day)
            {
                this.year = year;
                this.month = month;
                this.day = day;
            }

            public void setYear(object? obj)
            {
                string msg;
                if(CheckInput(obj,typeof(int),out msg))
                {
                    year = (int)obj;
                }
                else
                {
                    Console.WriteLine($"Error : {msg}");
                }
            }
            public void setMonth(object? obj)
            {
                string msg;
                if (CheckInput(obj, typeof(int), out msg))
                {
                    month = (int)obj;
                }
                else
                {
                    Console.WriteLine($"Error : {msg}");
                }
            }
            public void setDay(object? obj)
            {
                string msg;
                if (CheckInput(obj, typeof(int), out msg))
                {
                    day = (int)obj;
                }
                else
                {
                    Console.WriteLine($"Error : {msg}");
                }
            }

            public int GetYear() {  return year; }
            public int GetMonth() { return month; }
            public int GetDay() { return day; }

            public override string ToString()
            {
                return $"{year}-{month}-{day}";
            }

            public int CompareTo(object? obj)
            {
                if (obj == null)
                {
                    return 1;
                }
                if (obj.GetType() != typeof(HireDate))
                {
                    throw new ArgumentException("The Object sent to the parameters is not of type 'HireDate'");
                }
                HireDate date = (HireDate)obj;
                if(year < date.year)
                {
                    return -1;
                }
                else if(year > date.year)
                {
                    return 1;
                }
                else
                {
                    if(month < date.month)
                    {
                        return -1;
                    }
                    else if(month > date.month)
                    {
                        return 1;
                    }
                    else
                    {
                        if (day < date.day)
                        {
                            return -1;
                        }
                        else if (day > date.day)
                        {
                            return 1;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
            }
        }

        struct Employee
        {
            int ID;
            double Salary;
            Gender Gender;
            HireDate HireDate;
            Security Security;

            public Employee(int ID, double Salary, Gender Gender, HireDate HireDate , Security Security)
            {
                this.ID = ID;
                this.Salary = Salary;
                this.Gender = Gender;
                this.HireDate = HireDate;
                this.Security = Security;
            }

            public void setID(object? obj)
            {
                string msg;
                if (CheckInput(obj, typeof(int), out msg))
                {
                    ID = (int)obj;
                }
                else
                {
                    Console.WriteLine($"Error : {msg}");
                }
            }

            public void setSecurity(object? obj)
            {
                string msg;
                if (CheckInput(obj, typeof(Security), out msg))
                {
                    Security = (Security)obj;
                }
                else
                {
                    Console.WriteLine($"Error : {msg}");
                }
            }

            public void setSalary(object? obj)
            {
                string msg;
                if (CheckInput(obj, typeof(double), out msg))
                {
                    Salary = (double)obj;
                }
                else
                {
                    Console.WriteLine($"Error : {msg}");
                }
            }

            public void setGender(object? obj)
            {
                string msg;
                if (CheckInput(obj, typeof(Gender), out msg))
                {
                    Gender = (Gender)obj;
                }
                else
                {
                    Console.WriteLine($"Error : {msg}");
                }
            }

            public void setHireDate(object? obj)
            {
                string msg;
                if (CheckInput(obj, typeof(HireDate), out msg))
                {
                    HireDate = (HireDate)obj;
                }
                else
                {
                    Console.WriteLine($"Error : {msg}");
                }
            }

            public HireDate GetHireDate() {  return HireDate; }
            public int GetID() {  return ID; }
            public double GetSalary() {  return Salary; }
            public Gender GetGender() { return Gender; }
            public Security GetSecurity() { return Security; }

            public override string ToString()
            {
                return $"ID : {ID} , Salary : {Salary:C} , Gender : {Gender} , HireDate : {HireDate}";
            }
        }


        public static bool CheckInput(object? obj , Type type,out string msg)
        {
            if (obj == null)
            {
                msg = "The object sent cannot be null";
                return false;
            }
            if (obj.GetType() != type)
            {
                msg = $"The Object sent to the parameters is not of type {type.Name}";
                return false;
            }
            msg = "";
            return true;
        }
    }
}
