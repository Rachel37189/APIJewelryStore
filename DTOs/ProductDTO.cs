using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public record productDTO
    (
         string ProductName,

         double Price,

         int? CategoryId,

         string Description,

         string Category_Name 

    );
}
