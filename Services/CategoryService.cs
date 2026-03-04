//using Entities;
//<<<<<<< HEAD
//using Repository;
//=======
//using FluentNHibernate.Automapping;
//using FluentNHibernate.Testing.Values;
//using Repository;
//using System.Collections.Generic;
//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
//using DTOs;
//using AutoMapper;
//namespace Services
//{
//    public class CategoryService : ICategoryService
//    {
//        ICategoryRepository _categoryRepository;
//<<<<<<< HEAD
//        IMapper _mapper;


//        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
//        {
//            _categoryRepository = categoryRepository;
//            _mapper= mapper;
//        }
//        public async Task<List<CategoryDTO>> GetCategories()
//        {
//            List<Category> list = await _categoryRepository.GetCategories();
//            List<CategoryDTO> listDTO = _mapper.Map<List<Category>,List<CategoryDTO>>(list);
//            return listDTO;
//            // return await _categoryRepository.GetCategories();
//        }
//=======
//        //AutoMapper _mapper;
//        IMapper _mapper;

//        public CategoryService(ICategoryRepository category, IMapper mapper)
//        {
//            _categoryRepository = category;
//            _mapper = mapper;
//        }
//        public async Task<List<CategoryDto>> GetCategories()
//        {
//            List<Category> list = await _categoryRepository.GetCategories();
//            List<CategoryDto> listDto = _mapper.Map<List<CategoryDto>>(list);
//            return listDto;
//        }


//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
//    }
//}


using Entities;
using Repository;
using DTOs;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryDTO>> GetCategories()
        {
            List<Category> list = await _categoryRepository.GetCategories();
            // שימוש במיפוי מקוצר ונקי של AutoMapper
            return _mapper.Map<List<CategoryDTO>>(list);
        }
    }
}