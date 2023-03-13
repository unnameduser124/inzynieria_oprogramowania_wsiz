using Bogus;
using inzynieria_oprogramowania_lab1.Models;
using System;
using Xunit;

namespace inzynieria_oprogramowania_lab1
{
    public class UnitTest1
    {
        [Fact]
        public void bogus_data_generation()
        {
            Faker<UserAddress> addressBogus = new Faker<UserAddress>();
            addressBogus.RuleFor(x => x.Description, y => y.Address.FullAddress());
            addressBogus.RuleFor(x => x.Number, y => y.Address.CountryCode());
            var personBogus = new Faker<Models.Person>();
            personBogus.RuleFor(x => x.Name, y => y.Person.FirstName);
            personBogus.RuleFor(x => x.Surname, y => y.Person.LastName);
            personBogus.RuleFor(x => x.Birthday, y => y.Person.DateOfBirth);
            personBogus.RuleFor(x => x.Address, y => addressBogus.Generate());
            var hundredPpl = personBogus.Generate(100);
            Assert.True(hundredPpl.Count == 100);

        }

    }
}
