using BuilderTask.Interfaces;
using BuilderTask.Models;

namespace BuilderTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IBuilder builder = new Builder();

            var built = builder.BuildPart("Ground").BuildPart("Audicance").Create();

            Console.WriteLine(built);
        }
    }
}
