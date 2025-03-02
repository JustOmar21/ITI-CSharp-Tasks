
using Iterator.Implementation;
using Iterator.Interfaces;

namespace Iterator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string> { "Omar", "Amina", "Khalid", "Layla", "Zayd", "Fatima", "Rami", "Noura", "Yusuf", "Salma" };
            Names name = new Names(names);

            //IIterator<string> iterator = name.GetIterator();

            name.setIterator(new FourLettersOnlyIterator());
            var iterator = name.GetIterator();

            //for(int i = 0;  i < name.NamesList.Count; i++)
            //{
            //    Console.WriteLine(name.NamesList[i]);
            //}

            while (iterator.HasNext())
            {
                Console.WriteLine(iterator.Next());
            }
        }
    }


}
