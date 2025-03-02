using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_17.Bogus
{
    public class PersonFaker : Faker<Models.Person>
    {
        public PersonFaker()
        {
            RuleFor(PF => PF.Name, FK => FK.Name.FullName());
            RuleFor(PF => PF.Age, FK => FK.Random.Number(18, 70));
            RuleFor(PF => PF.City, FK => FK.Address.City());
            RuleFor(PF => PF.Country, FK => FK.Address.Country());
        }
    }
}
