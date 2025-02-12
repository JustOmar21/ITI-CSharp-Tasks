using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Day_4
{
    enum Gender : byte { Male, Female }
    [Flags]
    enum Security : byte { Guest = 0x01, Developer = 0x02, Secretary = 0x04, DBA = 0x08 }
    internal class Program
    {
        static void Main(string[] args)
        {
            //oldTask();
            newTask();
        }

        static void newTask()
        {
            Employee[] emps = new Employee[5]
            {
                new Employee()
                { ID = 1 ,
                  Name = "Omar",
                  Gender = Gender.Male ,
                  Salary = 2000,
                  HireDate = new HireDate(2016,12,20),
                  Security = Security.Developer
                },
                new Employee()
                { ID = 2 ,
                  Name = "Ahmed",
                  Gender = Gender.Male ,
                  Salary = 2000,
                  HireDate = new HireDate(2018,12,20),
                  Security = Security.Developer
                },
                new Employee()
                { ID = 3 ,
                  Name = "Ibrahim",
                  Gender = Gender.Male ,
                  Salary = 2000,
                  HireDate = new HireDate(2012,12,20),
                  Security = Security.Developer
                },
                new Employee()
                { ID = 4 ,
                  Name = "Mohamed",
                  Gender = Gender.Male ,
                  Salary = 2000,
                  HireDate = new HireDate(2011,12,20),
                  Security = Security.Developer
                },
                new Employee()
                { ID = 5 ,
                  Name = "Tawfiq",
                  Gender = Gender.Male ,
                  Salary = 2000,
                  HireDate = new HireDate(2022,12,20),
                  Security = Security.Developer
                },
            };

            Array.Sort(emps);
            foreach(var emp in emps)
            {
                Console.WriteLine(emp);
            }
        }

        static void oldTask()
        {
            Employee[] emps = new Employee[3];

            for (int i = 0; i < emps.Length; i++)
            {
                emps[i] = new Employee();
                int counter = 0;
                int tempID;
                Console.Write($"Employee {i + 1}'s ID: ");
                do
                {
                    if (counter > 0)
                        Console.Write($"Invalid Input || Employee {i + 1}'s ID :");
                    counter++;

                } while (!int.TryParse(Console.ReadLine(), out tempID));
                emps[i].ID = tempID;

                counter = 0;
                double tempSalary;
                Console.Write($"Employee {i + 1}'s Salary: ");
                do
                {
                    if (counter > 0)
                        Console.Write($"Invalid input try again :");
                    counter++;

                } while (!double.TryParse(Console.ReadLine(), out tempSalary));
                emps[i].Salary = tempSalary;


                HireDate date = new HireDate();
                counter = 0;
                int tempYear;
                Console.Write($"Employee {i + 1}'s HireDate Year: ");
                do
                {
                    if (counter > 0)
                        Console.Write($"Invalid input try again :");
                    counter++;

                } while (!int.TryParse(Console.ReadLine(), out tempYear));
                date.Year = tempYear;

                counter = 0;
                Console.Write($"Employee {i + 1}'s HireDate Month: ");
                do
                {
                    if (counter > 0)
                        Console.Write($"Invalid input try again :");
                    counter++;

                } while (!int.TryParse(Console.ReadLine(), out tempYear));
                date.Month = tempYear;

                counter = 0;
                Console.Write($"Employee {i + 1}'s HireDate Day: ");
                do
                {
                    if (counter > 0)
                        Console.Write($"Invalid input try again :");
                    counter++;

                } while (!int.TryParse(Console.ReadLine(), out tempYear));
                date.Day = tempYear;

                emps[i].HireDate = date;

                counter = 0;
                Security tempSecurity;
                Console.Write($"Employee {i + 1}'s Security Clearance: ");
                do
                {
                    if (counter > 0)
                        Console.Write($"Invalid input try again :");
                    counter++;

                } while (!Enum.TryParse(Console.ReadLine(), out tempSecurity));
                emps[i].Security = tempSecurity;

                Console.Write($"Employee {i + 1}'s Gender: ");

                counter = 0;
                Gender tempGender;
                Console.Write($"Employee {i + 1}'s Security Clearance: ");
                do
                {
                    if (counter > 0)
                        Console.Write($"Invalid input try again :");
                    counter++;

                } while (!Enum.TryParse(Console.ReadLine(), out tempGender));
                emps[i].Gender = tempGender;
                Console.WriteLine();
            }
        }

        class SearchEmployee
        {
            public Dictionary<int, Employee> Employees;

            public Employee? this[int ID]
            {
                get
                {
                    return Employees.ContainsKey( ID ) ? Employees[ID] : null;
                }
            }

            public List<Employee> this[HireDate date]
            {
                get
                {
                    return Employees.Values.Where(emp => emp.HireDate.ToString() == date.ToString()).ToList();
                }
            }

            public List<Employee> this[string name]
            {
                get
                {
                    return Employees.Values.Where(emp => emp.Name == name).ToList();
                }
            }
        }

        struct HireDate : IComparable
        {
            private int year;
            private int month;
            private int day;

            public HireDate(int year, int month, int day)
            {
                this.year = year;
                this.month = month;
                this.day = day;
            }

            public static bool operator ==(HireDate a, HireDate b)
            {
                return a.year == b.year && a.month == b.month && a.day == b.day;
            }

            public static bool operator !=(HireDate a, HireDate b)
            {
                return !(a == b);
            }

            public int Year { get { return year; } set { year = value; } }
            public int Month
            {
                get { return month; }
                set
                {
                    if (value < 1 || value > 12)
                        do
                        {
                            Console.Write("Value Should be between 1 and 12 : ");
                        } while (int.TryParse(Console.ReadLine(), out value) &&( value < 1 || value > 12));
                    month = value;
                }
            }
            public int Day
            {
                get { return day; }
                set
                {
                    if (value < 1 || value > 31)
                        do
                        {
                            Console.Write("Value Should be between 1 and 31 : ");
                        } while (int.TryParse(Console.ReadLine(), out value) && (value < 1 || value > 31));
                    day = value;
                }
            }

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
                if (year < date.year)
                {
                    return -1;
                }
                else if (year > date.year)
                {
                    return 1;
                }
                else
                {
                    if (month < date.month)
                    {
                        return -1;
                    }
                    else if (month > date.month)
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

        struct Employee : IComparable
        {
            int id;
            string name;
            double salary;
            Gender gender;
            HireDate hireDate;
            Security security;

            public Employee(int ID, double Salary, Gender Gender, HireDate HireDate, Security Security)
            {
                this.id = ID;
                this.salary = Salary;
                this.gender = Gender;
                this.hireDate = HireDate;
                this.security = Security;
            }

            public int ID { get { return id; } set { id = value; } }
            public string Name { get { return name; } set { name = value; } }
            public double Salary { get { return salary; } set { salary = value; } }
            public Gender Gender { get { return gender; } set { gender = value; } }
            public HireDate HireDate { get { return hireDate; } set { hireDate = value; } }
            public Security Security { get { return security; } set { security = value; } }

            public int CompareTo(object? obj)
            {
                if(obj is Employee)
                {
                    Employee employee = (Employee)obj;
                    return this.hireDate.CompareTo(employee.hireDate);
                }
                else
                {
                    throw new InvalidDataException("The object sent is not of type Employee");
                }
            }

            public override string ToString()
            {
                return $"ID : {id} , Name : {name} , Salary : {salary:C} , Gender : {gender} , HireDate : {hireDate}";
            }
        }

    }
}
