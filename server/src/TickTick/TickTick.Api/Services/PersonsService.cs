﻿using TickTick.Api.Dtos.Persons;
using TickTick.Models;


namespace TickTick.Api.Services
{
    public class PersonsService : IPersonsService
    {
        public void DeletePerson(Guid id)
        {
            // TODO: persoon ophalen
            // Als persoon null is, 404 teruggeven
            // p.Delete()
            // save


        }

        public PersonDto AddPerson(AddPersonDto dto)
        {
            Person person = new Person(
                dto.FirstName,
                dto.LastName,
                dto.Email);

            person.CreatePublicId();
            return person.ConvertToDto();
        }


        public PersonDto UpdatePerson(Guid personId, PersonDto dto)
        {
            // TODO: use a person from the DB
            Person person = new Person(
                dto.FirstName,
                dto.LastName,
                dto.Email);
            person.Update(dto.FirstName, dto.LastName, dto.MiddleName, dto.DateOfBirth, dto.Email);
            return person.ConvertToDto();
        }
    }
}
