using MediatR;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TickTick.Api.Dtos.Persons;
using TickTick.Api.RequestHandlers.Persons;
using TickTick.Api.ResponseWrappers;
using TickTick.Api.Services;
using TickTick.Models;
using TickTick.Repositories;
using TickTick.Repositories.Base;

namespace TickTick.Api.Controllers
{
    [Route("/v{v:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class PersonsController : ApiControllerBase
    {
        private readonly IPersonsService svc;
        private readonly IRepository<Person> repo;

        public PersonsController(IPersonsService service, IRepository<Person> repo, IMediator mediator)
            :base(mediator)
        {
            this.svc = service;
            this.repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<PersonDto>),200)]
        public async Task<IActionResult> Get()
        {
            return await ExecuteRequest(new GetAllPersonsRequest());

            /*try
            {
                var persons = await repo.GetAllAsync(p => p.IsDeleted == false);

                //List<Person> people = new List<Person>();
                //people.Add(new Person("John", "Doe", "john@mail.com"));
                //people.Add(new Person("Kevin", "DeRudder", "kevin.derudder@gmail.com"));

                Response<IEnumerable<Person>> resp = new Response<IEnumerable<Person>>();
                resp.Data = persons;

                return Ok(resp);
            }
            catch (Exception ex)
            {
                Response<IEnumerable<Person>> r = new Response<IEnumerable<Person>>();
                r.Data = null;
                r.Message = ex.Message;
                r.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                return StatusCode(500, r);
            }*/
            
        }


        [HttpGet("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<PersonDto>), 200)]
        public async Task<IActionResult> Get(Guid id)
        {
            // TODO: Haal een persoon op
            //Person person = new Person("Kevin", "DeRudder", "kevin.derudder@gmail.com");
            //return Ok(person.ConvertToDto());

            return await ExecuteRequest(new GetPersonRequest(id));
        }

        /*
        [HttpGet("{personId:guid}/locations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<PersonDto>), 200)]
        public IActionResult GetLocations(Guid personId)
        {
            // TODO: Haal een persoon op
            List<LocationDto> locations = new List<LocationDto>() 
            {
                new LocationDto("Grapheusstraat", "31", "Deurne", "2100", "Belgium"),
                new LocationDto("Kladdenbergstraat", "7", "Edegem", "2650", "Belgium")
            };
            
            return Ok(new Response<IEnumerable<Location>>(locations));
        }*/


        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<PersonDto>), 200)]
        public IActionResult Delete(Guid id)
        {
            svc.DeletePerson(id);
            return NoContent();
        }


        /*[HttpDelete("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<PersonDto>), 200)]
        public async Task<IActionResult> DeletePerson(Guid id)
        {
            
            //svc.DeletePerson(id);
            //return NoContent();
        }*/


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<PersonDto>), 200)]
        public async Task<IActionResult> Post([FromBody] AddPersonDto person)
        {

            /*PersonDto newP = svc.AddPerson(person);

            Person p = new Person(person.FirstName, person.LastName, person.Email);
            repo.Add(p);
            int i = await repo.SaveAsync();

            return CreatedAtAction(nameof(Get), new { id = newP.PublicId }, person);*/

            // moet worden
            return await ExecuteRequest(new AddPersonRequest(person));

        }


        [HttpPut("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<PersonDto>), 200)]
        public IActionResult Put(Guid id, [FromBody] PersonDto person)
        {
            PersonDto newP = svc.UpdatePerson(id, person);
            return Ok(newP);
        }

    }
}
