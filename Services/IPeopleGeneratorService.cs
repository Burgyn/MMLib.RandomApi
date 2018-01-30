using System.Collections.Generic;
using System.Threading.Tasks;
using MMLib.RandomApi.Models;

namespace MMLib.RandomApi.Services
{
    public interface IPeopleGeneratorService
    {
        IEnumerable<Person> GeneratePeople(int count);
    }
}