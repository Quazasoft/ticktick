using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TickTick.Models.Dtos
{
    public class LocationDto
    {
        private string _type;

        public string Street { get; set; }
        public string Nr { get; set; }
        public string City { get; set; }
        public string? State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string Type
        {
            get { return _type; }
            set
            {
                //_type = Enum.GetName(typeof(LocationType), value);
                _type = LocationType.PRIMARY.ToString();
            }
        }
    }
}
