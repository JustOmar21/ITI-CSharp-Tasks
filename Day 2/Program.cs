
namespace Day_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //LongestDistance();
            //Reverso();
            //OnesCase1();
            //OnesCase2();
            //OnesCase3();
            NaderGifts();
        }

        static void NaderGifts()
        {
            float budget = 183.23f;
            float bagVolume = 64.11f;
            int people = 7;
            int Npresents = 12;
            float[] presentVolume = new float[12]
            {
            4.53f, 9.11f, 4.53f, 6.00f, 1.04f, 0.87f, 2.57f, 19.45f,
            65.59f, 14.14f, 16.66f, 13.53f
            };
            float[] presentPrice = new float[12]
            {
            12.23f, 45.03f, 12.23f, 32.93f, 6.99f, 0.46f, 7.34f,
            65.98f, 152.13f, 7.23f, 10.00f, 25.25f
            };

            Console.WriteLine("Maximum Money Spent " + PresentList(
                budget,
                bagVolume,
                people,
                Npresents,
                presentVolume,
                presentPrice
            ));
        }

        static void LongestDistance()
        {
            Console.Write("Enter Array size : ");
            int size = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                Console.Write($"Number {i + 1} : ");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            int max = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        max = max < (j - i - 1) ? (j - i - 1) : max;
                    }
                }
                if (arr.Length - i - 1 < max)
                {
                    break;
                }
            }

            Console.WriteLine($"Max Distance : {max}");
        }

        static void Reverso()
        {
            Console.Write("Enter String : ");
            string str = Console.ReadLine();
            Console.WriteLine($"Reversed String : {String.Join(" ", str.Split(" ").Reverse())}");
        }

        static void OnesCase1()
        {
            string str;
            int count = 0;
            for (int i = 0; i < 99_999_999; i++)
            {
                str = i.ToString();
                for (int j = 0; j < str.Length; j++)
                {
                    if (str[j] == '1') count++;
                }
            }
            Console.WriteLine($"# of 1s : {count:0,0}");
        }

        static void OnesCase2()
        {
            int count = 0;
            int clone;
            for (int i = 0; i < 99_999_999; i++)
            {
                clone = i;
                while (clone > 0)
                {
                    if (clone % 10 == 1) count++;
                    clone /= 10;
                }
            }
            Console.WriteLine($"# of 1s : {count:0,0}");
        }

        static void OnesCase3()
        {
            string str = "99999999";
            double count = str.Length * Math.Pow(10, str.Length - 1);
            Console.WriteLine($"# of 1s : {count:0,0}");
        }

        static float PresentList(float budget, float bagVolume, int people
            , int Npresents, float[] presentVolume, float[] presentPrice)
        {
            float currentBagVol = 0f;
            float currentPrice = 0f;
            float tempBagVol = 0f;
            float tempPrice = 0f;
            int counter = 0;
            Present[] presents = new Present[presentPrice.Length];
            for (int i = 0; i < presentPrice.Length; i++)
            {
                presents[i] = new Present(presentPrice[i], presentVolume[i]);
            }
            Array.Sort(presents, (a, b) => (b.price / b.volume).CompareTo(a.price / a.volume));
            foreach(var present in presents)
            {
                counter++;
                if (tempBagVol + present.volume <= bagVolume && tempPrice + present.price <= budget && Npresents > 0)
                {
                    tempPrice += present.price;
                    tempBagVol += present.volume;
                    Npresents--;
                }
                if (counter % people == 0)
                {
                    if (currentBagVol + tempBagVol <= bagVolume && currentPrice + tempPrice <= budget)
                    {
                        currentPrice += tempPrice;
                        currentBagVol += tempBagVol;
                        tempBagVol = 0f;
                        tempPrice = 0f;
                    }
                    else
                    {
                        break;
                    }
                }
                    

                
            }
            return currentPrice;
        }

        class Present
        {
            public float price;
            public float volume;

            public Present(float price, float volume)
            {
                this.price = price;
                this.volume = volume;
            }
            public override string ToString()
            {
                return $"Price : {price} , Volume : {volume} , Ratio : {price/volume}";
            }
        }
    }
}
