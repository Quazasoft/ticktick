using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TickTick.Models;
using TickTick.Repositories.Base;

namespace TickTick.Repositories
{
    //public class PersonsRepository:Repository<Person>
    //{
    //}

    public static class PersonsRepositoryExtensions
    {
        public static IEnumerable<Person> GetDeadPeople(this Repository<Person> repo)
        {
            return repo.GetAll();
        }
    }
}
