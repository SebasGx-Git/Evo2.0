using PeruStars_2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeruStars_2.Domain.Services.Communications
{
    public class PersonResponse : BaseResponse<Person>
    {
        public PersonResponse(Person resource) : base(resource)
        {
        }

        public PersonResponse(string message) : base(message)
        {
        }
    }
}
