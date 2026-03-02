using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    

        public class UserDto
        {
            // בנאי ריק מפורש כדי ש-AutoMapper לא יתבלבל
            public UserDto() { }

            public int Id { get; set; }
            public string UserEmail { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }

