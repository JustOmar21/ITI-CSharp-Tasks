namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region problem
            //•	How can you count the occurrence of 1 from 1 to 99,999,999(1 short of 100 million) and total up how many 1s were there.

            //    (Convert Numbers to String in Case one and use String Functions to Count 1s,
            //   Use Only Mathematical Functions and Numeric values in case 2 and see the difference in performance) 
            //   Is There Any Other Way to Do it in Approximately 1 Second or less
            #endregion
            #region case1
            int totalOnes = 0;
            for (int i = 0; i < 100000000; i++)
            {
                string number = i.ToString();
                totalOnes += number.Split('1').Length - 1;
            }
            Console.WriteLine($"total is : {totalOnes}");
            #endregion
            #region case2
            int totalOnes_c2 = 0;
            for (int i = 0; i < 100000000; i++)
            {
                int number = i;
                while (number > 0)
                {
                    if (number % 10 == 1)
                        totalOnes_c2++;
                    number /= 10;
                }
            }
            Console.WriteLine($"total : {totalOnes_c2}");
            #endregion
            #region case3

            #endregion
        }
    }
}
