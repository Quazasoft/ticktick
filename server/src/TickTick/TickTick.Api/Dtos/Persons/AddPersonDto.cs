using TickTick.Models;

namespace TickTick.Api.Dtos.Persons
{
    public record AddPersonDto
    {
        public Person ConvertToPerson(PersonDto person)
        {
            Person p = new Person(person.FirstName, person.LastName, person.Email);
            return p;

        }

        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }
    }
}
