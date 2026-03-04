using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    

        public class UserDTO
        {
        // בנאי ריק מפורש כדי ש-AutoMapper לא יתבלבל
        public UserDTO() { }

        public int Id { get; set; } // זה ה-UserId מה-DB
        public string UserEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public bool IsAdmin { get; set; }
    }
    }

