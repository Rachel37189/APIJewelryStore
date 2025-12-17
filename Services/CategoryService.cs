using Entities;
using FluentNHibernate.Automapping;
using FluentNHibernate.Testing.Values;
using Repository;
using System.Collections.Generic;
using DTOs;
using AutoMapper;
namespace Services
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepository _categoryRepository;
        //AutoMapper _mapper;
        IMapper _mapper;

        public CategoryService(ICategoryRepository category, IMapper mapper)
        {
            _categoryRepository = category;
            _mapper = mapper;
        }
        public async Task<List<CategoryDto>> GetCategories()
        {
            List<Category> list = await _categoryRepository.GetCategories();
            List<CategoryDto> listDto = _mapper.Map<List<CategoryDto>>(list);
            return listDto;
        }


    }
}
