using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Domain.Models
{
    public class RegistrationDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
