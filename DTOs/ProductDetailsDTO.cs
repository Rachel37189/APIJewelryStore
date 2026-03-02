using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public record ProductDetailsDto(
    int Id,
    string Name,
    string longDescription,
    double Price,
    string Image1,
    string? Image2,
    List<ProductSizeDto> Sizes
);

    public record ProductSizeDto(
        double Size,
        int Amount
    );
}
