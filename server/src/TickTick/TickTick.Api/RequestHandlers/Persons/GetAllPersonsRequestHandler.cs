using MediatR;
using Microsoft.EntityFrameworkCore;
using TickTick.Api.Dtos.Persons;
using TickTick.Models;
using TickTick.Repositories.Base;

namespace TickTick.Api.RequestHandlers.Persons
{

    //CONTRACT
    public class GetAllPersonsRequest:QueryBase<IEnumerable<PersonDto>>
    {

    }


    public class GetAllPersonsRequestHandler : IRequestHandler<GetAllPersonsRequest, IEnumerable<PersonDto>>
    {
        private readonly IRepository<Person> personsRepo;

        public GetAllPersonsRequestHandler(IRepository<Person> personRepo)
        {
            this.personsRepo = personRepo;
        }

        public async Task<IEnumerable<PersonDto>> Handle(GetAllPersonsRequest request, CancellationToken cancellationToken)
        {
            var people = await personsRepo.GetAll().ToListAsync();
            var dto = new List<PersonDto>();

            foreach (var person in people)
            {
                dto.Add(person.ConvertToDto());
            }

            return dto;
        }
    }

}
