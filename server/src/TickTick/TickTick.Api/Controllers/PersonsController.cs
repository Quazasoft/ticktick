﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TickTick.Api.Dtos.Persons;
using TickTick.Api.ResponseWrappers;
using TickTick.Api.Services;
using TickTick.Models;


namespace TickTick.Api.Controllers
{
    [Route("/v{v:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonsService svc;
        public PersonsController(IPersonsService service)
        {
            this.svc = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<PersonDto>),200)]
        public IActionResult Get()
        {
            try
            {
                List<Person> people = new List<Person>();

                people.Add(new Person("John", "Doe", "john@mail.com"));
                people.Add(new Person("Kevin", "DeRudder", "kevin.derudder@gmail.com"));

                Response<IEnumerable<Person>> resp = new Response<IEnumerable<Person>>();
                resp.Data = people;

                return Ok(resp);
            }
            catch (Exception ex)
            {
                Response<IEnumerable<Person>> r = new Response<IEnumerable<Person>>();
                r.Data = null;
                r.Message = ex.Message;
                r.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                return StatusCode(500, r);
            }
            
        }


        [HttpGet("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<PersonDto>), 200)]
        public IActionResult Get(Guid id)
        {
            // TODO: Haal een persoon op
            Person person = new Person("Kevin", "DeRudder", "kevin.derudder@gmail.com");
            return Ok(person.ConvertToDto());
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


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<PersonDto>), 200)]
        public IActionResult Post([FromBody] AddPersonDto person)
        {
            PersonDto newP = svc.AddPerson(person);
            return CreatedAtAction(nameof(Get), new { id = newP.PublicId }, person);
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
