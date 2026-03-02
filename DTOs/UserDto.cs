using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    //public record UserDto
    //(
    //    int id,
    //    string UserEmail,

    //    string FirstName,

    //    string LastName
    //);

    //public record UserDto
    //{
    //    public int Id { get; init; }
    //    public string UserEmail { get; init; }
    //    public string FirstName { get; init; }
    //    public string LastName { get; init; }
    //}

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

