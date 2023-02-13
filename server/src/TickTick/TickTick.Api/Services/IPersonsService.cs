using TickTick.Api.Dtos.Persons;


namespace TickTick.Api.Services
{
    public interface IPersonsService
    {
        void DeletePerson(Guid id);
        PersonDto AddPerson(AddPersonDto dto);
        PersonDto UpdatePerson(Guid id, PersonDto dto);
    }
}