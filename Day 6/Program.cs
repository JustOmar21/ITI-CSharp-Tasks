using System.Security.Claims;

namespace Day_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Duration D1 = new Duration(1, 10, 15);
            Duration D2 = new Duration(3600);
            Duration D3 = new Duration(7800);
            Duration D4 = new Duration(666);

            Console.WriteLine($"{D1}\n{D2}\n{D3}\n{D4}");

            D3 = D1 + D2;
            D3 = D1 + 7800;
            D3 = 666 + D3;
            D3 = D1++;
            D3 = --D2;
            D1 = -D2;
            if(D1 > D2);
            if(D1 <= D2);
            if (D1) ;
            DateTime Obj = (DateTime)D1;
        }

        class NIC
        {
            public static NIC NetworkIC { get; } = new NIC();
            public string Manufacture { get; set; }
            public string MACAddress { get; set; }
            public NICType Type { get; set; }
            NIC()
            {

            }
        }
        enum NICType { Ethernet , TokenRing }

        class Duration
        {
            public long Hours { get; set; }
            public long Minutes { get; set; }
            public long Seconds { get; set; }

            private long totalSeconds;

            public Duration(long hours, long minutes, long seconds)
            {
                Hours = hours;
                Minutes = minutes;
                Seconds = seconds;
                this.totalSeconds = hours * 3600 + minutes * 60 + seconds;
            }
            
            public Duration(long seconds)
            {
                Hours = (seconds / 60) / 60;
                seconds -= Hours * 60 * 60;
                Minutes = seconds / 60;
                seconds -= Minutes * 60;
                Seconds = seconds;
                seconds = this.totalSeconds;
            }

            public override string ToString()
            {
                if (Hours == 0 && Minutes == 0)
                {
                    return $"Seconds: {Seconds}";
                }
                else if (Hours == 0)
                {
                    return $"Minutes: {Minutes}, Seconds: {Seconds}";
                }
                else
                {
                    return $"Hours: {Hours}, Minutes: {Minutes}, Seconds: {Seconds}";
                }
            }
            public override bool Equals(object? obj)
            {
                if(obj is Duration && obj is not null)
                {
                    var dur = obj as Duration;
                    return this.Hours == dur.Hours && this.Minutes == dur.Minutes && this.Seconds == dur.Seconds ;
                }
                else
                {
                    return false;
                }
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public static Duration operator +(Duration d1 , Duration d2)
            {
                return new Duration(d1.totalSeconds + d2.totalSeconds);
            }

            public static Duration operator +(Duration d1, long seconds)
            {
                return new Duration(d1.totalSeconds + seconds);
            }

            public static Duration operator +(long seconds, Duration d1)
            {
                return new Duration(d1.totalSeconds + seconds);
            }

            public static Duration operator ++(Duration d)
            {
                d.Minutes++;
                d.totalSeconds += 60;
                if(d.Minutes == 60)
                {
                    d.Minutes = 0;
                    d.Hours++;
                }
                return new Duration(d.totalSeconds);
            }

            public static Duration operator --(Duration d)
            {
                if (d.Minutes == 0)
                {
                    if(d.Hours == 0)
                    {
                        throw new Exception("There are no hours to deduct seconds from");
                    }
                    else
                    {
                        d.Hours--;
                        d.Minutes = 59;
                        d.totalSeconds -= 60;
                    }
                }
                else
                {
                    d.Minutes--;
                    d.totalSeconds -= 60;
                }
                
                
                return new Duration(d.totalSeconds);
            }

            public static Duration operator -(Duration d)
            {
                return new Duration(-d.totalSeconds);
            }
            public static bool operator >(Duration d1, Duration d2)
            {
                return d1.totalSeconds > d2.totalSeconds;
            }
            public static bool operator <(Duration d1, Duration d2)
            {
                return d1.totalSeconds < d2.totalSeconds;
            }
            public static bool operator >=(Duration d1, Duration d2)
            {
                return d1.totalSeconds >= d2.totalSeconds;
            }
            public static bool operator <=(Duration d1, Duration d2)
            {
                return d1.totalSeconds <= d2.totalSeconds;
            }

            



            public static bool operator true(Duration d)
            {
                return d.Hours != 0;
            }
            public static bool operator false(Duration d)
            {
                return d.Hours == 0;
            }

            public static explicit operator DateTime(Duration d)
            {
                return new DateTime().AddHours(d.Hours).AddMinutes(d.Minutes).AddSeconds(d.Seconds);
            }


        }

        
    }
}
