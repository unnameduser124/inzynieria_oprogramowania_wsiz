using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using inzynieria_oprogramowania_lab1.Models;
using Xunit;

namespace inzynieria_oprogramowania_lab1.Models
{
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double GPA { get; set; }
        public University University { get; set; }
        public Address Address { get; set; }
    }

    public class StudentTests
    {
        public List<Student> GenerateData()
        {
            var generator = new Faker<Student>();
            var addressGenerator = new Faker<Address>();
            var universityGenerator = new Faker<University>();

            generator.RuleFor(x => x.Name, y => y.Person.FullName);
            generator.RuleFor(x => x.Age, y => y.Random.Int(18, 70));
            generator.RuleFor(x => x.GPA, y => y.Random.Number(2, 5));

            var list = generator.Generate(100);
            addressGenerator.RuleFor(x => x.City, y => y.Address.City());
            addressGenerator.RuleFor(x => x.Country, y => y.Address.Country());
            universityGenerator.RuleFor(x => x.Name, y => "University at " + y.Address.City());
            foreach ( var student in list)
            {
                student.Address = addressGenerator.Generate();
                var university = universityGenerator.Generate();
                university.Address = addressGenerator.Generate();
                student.University = university;
                
            }
            return list;
        }

        [Fact]
        public void GeneratedStudentData()
        {
            var studentList = GenerateData();
            foreach( var student in studentList)
            {
                Assert.True(
                    student.University.Address.City != null &&
                    student.University.Address.Country != null &&
                    student.University.Name != null &&
                    student.Address.City != null &&
                    student.Address.Country != null
                    );
            }
        }
    }
}
