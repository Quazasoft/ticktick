using MediatR;
using Microsoft.AspNetCore.Server.IIS.Core;
using TickTick.Api.Dtos.Persons;
using TickTick.Models;
using TickTick.Repositories.Base;

namespace TickTick.Api.RequestHandlers.Persons
{
    public class GetPersonRequest:QueryBase<PersonDto>
    {
        public Guid publicId { get; set; }

        public GetPersonRequest(Guid publicId)
        {
            this.publicId = publicId;
        }
    }
    public class GetPersonRequestHandler:IRequestHandler<GetPersonRequest, PersonDto>
    {
        private readonly IRepository<Person> personsRepository;

        public GetPersonRequestHandler(IRepository<Person> personsRepository)
        {
            this.personsRepository = personsRepository;
        }

        public async Task<PersonDto> Handle(GetPersonRequest request, CancellationToken cancellationToken)
        {
            var p = await personsRepository.GetAsync(p => p.PublicId == request.publicId);
            return p.ConvertToDto();
            //throw new NotImplementedException();
        }
    }
    
}
