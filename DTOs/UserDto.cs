using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public record UserDto
    (
        string UserEmail,

        string FirstName,

        string LastName
    );

    
}
