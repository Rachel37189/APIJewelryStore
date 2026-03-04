//<<<<<<< HEAD
//﻿using Entities;
//using DTOs;
//=======
//﻿using DTOs;
//using Entities;

//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
//namespace Services
//{
//    public interface ICategoryService
//    {
//<<<<<<< HEAD
//        Task<List<CategoryDTO>> GetCategories();
//=======
//        Task<List<CategoryDto>> GetCategories();
//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
//    }
//}

using DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> GetCategories();
    }
}