using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Mapster;
using MMLib.RandomApi.Models;
using Newtonsoft.Json;

namespace MMLib.RandomApi.Services
{
    public class PeopleExternalGeneratorService : IPeopleGeneratorService
    {
        private Lazy<IEnumerable<Person>> _people;

        public PeopleExternalGeneratorService()
        {
            _people = new Lazy<IEnumerable<Person>>(() =>
            {
                List<Person> people = new List<Person>();
                using(var webClient = new WebClient())
                {
                    for (int i = 0; i < 100; i++)
                    {
                        var data = webClient.DownloadString("https://randomuser.me/api/");

                        dynamic ext = JsonConvert.DeserializeObject(data);
                        string firstName = ext.results[0].name.first;
                        string lastName = ext.results[0].name.last;

                        people.Add(new Person()
                        {
                            Title = ext.results[0].name.title,
                                FirstName = firstName.ToTitle(),
                                LastName = lastName.ToTitle(),
                                Address = $"{ext.results[0].location.street} ({ext.results[0].location.city})",
                                Email = ext.results[0].email,
                                PhotoUrl = ext.results[0].picture.large,
                                Phone = ext.results[0].phone
                        });
                    }
                }

                return people;
            });
        }

        public IEnumerable<Person> GeneratePeople(int count) => _people.Value.Take(count);
    }

    public static class StringExtensions
    {
        public static  string ToTitle(this string value) =>
            CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
    }
}