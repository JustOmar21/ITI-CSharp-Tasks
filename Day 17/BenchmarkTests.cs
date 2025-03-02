using BenchmarkDotNet.Attributes;
using Dapper;
using Day_17.context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_17
{
    public class BenchmarkTests
    {
        private readonly TestBenchContext _context;

        public BenchmarkTests()
        {
            _context = new();
        }

        [Benchmark]
        public List<Models.Person> LoadAllUsingEFCore()
        {
            return _context.People.AsNoTracking().ToList();
        }

        [Benchmark]
        public List<Models.Person> LoadAllUsingEFCoreWithTracking()
        {
            return _context.People.ToList();
        }

        [Benchmark]
        public List<Models.Person> LoadAllUsingDapper()
        {
            using var connection = new SqlConnection(_context.Database.GetConnectionString());
            return connection.Query<Models.Person>("SELECT * FROM Person").ToList();
        }
    }
}
