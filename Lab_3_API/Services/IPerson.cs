using Lab_3_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_3_API.Services
{
    interface IPerson
    {
        public IEnumerable<Person> GetAllInterestsFromPerson(string name);
    }
}
