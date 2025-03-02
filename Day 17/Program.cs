using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Bogus;
using Dapper;
using Day_17.Bogus;
using Day_17.context;
using Day_17.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Day_17
{
    internal class Program
    {
        static TestBenchContext TBContext = new();
        static void Main(string[] args)
        {
            //var people = new PersonFaker().Generate(10000);
            //TBContext.People.AddRange(people);
            //Console.WriteLine(TBContext.SaveChanges());

            BenchmarkRunner.Run<BenchmarkTests>();

        }

        
    }

    
}
