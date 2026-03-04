//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//<<<<<<< HEAD
//=======

//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
//namespace DTOs
//{
//    public record ProductCreateDTO(
//    int ProductId,
//    string ProductName,
//    string ShortDescription,
//    string LongDescription,
//    double ProductPrice,
//    int CategoryId,
//    string Color,
//    DateOnly DateAdded,
//    string Image1,
//    string? Image2,
//    bool JustOnline,
//    bool IsClassic,
//    bool IsTrendy,
//    bool IsPearls,
//<<<<<<< HEAD
//    bool IsStudio
//);
//=======
//    bool IsStudio,
//    List<SizeDTO> Sizes
//    )
//    {
//        // הבנאי הריק הזה יפתור את כל הצרות של AutoMapper
//        public ProductCreateDTO() : this(0, "", "", "", 0, 0, "", DateOnly.FromDateTime(DateTime.Now), "", null, false, false, false, false, false, new List<SizeDTO>())
//        {
//        }
//    }
//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
//}

using System;
using System.Collections.Generic;

namespace DTOs
{
    public record ProductCreateDTO(
        int ProductId,
        string ProductName,
        string ShortDescription,
        string LongDescription,
        double ProductPrice,
        int CategoryId,
        string Color,
        DateOnly DateAdded,
        string Image1,
        string? Image2,
        bool JustOnline,
        bool IsClassic,
        bool IsTrendy,
        bool IsPearls,
        bool IsStudio,
        List<SizeDTO> Sizes
    )
    {
        // הבנאי הריק הזה עוזר ל-AutoMapper ולתהליכי ה-Deserialization
        public ProductCreateDTO() : this(0, "", "", "", 0, 0, "", DateOnly.FromDateTime(DateTime.Now), "", null, false, false, false, false, false, new List<SizeDTO>())
        {
        }
    }
}
