using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public record OrderItemCreateDTO
    (
        int ProductId,
        int Quantity,
        double Size
    );
}
