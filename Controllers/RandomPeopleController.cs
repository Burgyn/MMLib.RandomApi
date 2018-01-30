using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MMLib.RandomApi.Models;
using MMLib.RandomApi.Services;

namespace MMLib.RandomApi.Controllers
{
    [Route("api/[controller]")]
    public class RandomPeopleController
    {
        private readonly IPeopleGeneratorService _peopleGenerator;

        public RandomPeopleController(IPeopleGeneratorService peopleGenerator)
        {
            this._peopleGenerator = peopleGenerator;
        }

        [HttpGet("{count}")]
        public IEnumerable<Person> GetRandomUser(int count) =>
            _peopleGenerator.GeneratePeople(count);
    }
}