using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using TickTick.Api.Dtos.Persons;
using TickTick.Models;
using TickTick.Repositories.Base;

namespace TickTick.Api.RequestHandlers.Persons
{
    public class AddPersonRequest:CommandBase<PersonDto>
    {
        public AddPersonDto person { get; set; }
        public AddPersonRequest(AddPersonDto person)
        {
            this.person = person;
        }
    }
    /*public class AddPersonRequestHandler : IRequestHandler<GetPersonRequest, PersonDto>
    {
        private readonly IRepository<Person> personsRepository;

        public AddPersonRequestHandler(IRepository<Person> personsRepository)
        {
            this.personsRepository = personsRepository;
        }

        public async Task<IActionResult> Handle(GetPersonRequest request, CancellationToken cancellationToken)
        {
            //var p = await personsRepository.GetAsync(p => p.PublicId == request.publicId);
            //return p.ConvertToDto();
            //throw new NotImplementedException();

            //return;

            personsRepository.Add();

            /*PersonDto newP = svc.AddPerson(person);

            Person p = new Person(person.FirstName, person.LastName, person.Email);
            repo.Add(p);
            int i = await repo.SaveAsync();

            return CreatedAtAction(nameof(Get), new { id = newP.PublicId }, person);*/
        /*}
    }*/
}

