using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public record ProductDTO
    (
         int ProductId,

         string ProductName,

         string ShortDescription,

         double ProductPrice,

         string Image1

    );
}
