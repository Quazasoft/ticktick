﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using TickTick.Models;

namespace TickTick.Api.Dtos.Persons
{
    public class PersonDto
    {
        public Guid PublicId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }

        /*public IList<LocationDto> Locations { get; set; }*/

    }

    public static class PersonExtensions
    {
        public static PersonDto ConvertToDto(this Person person)
        {
            return new PersonDto()
            {
                PublicId = person.PublicId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                MiddleName = person.MiddleName,
                DateOfBirth = person.DateOfBirth,
                Email = person.Email
            };

        }
    }
}
