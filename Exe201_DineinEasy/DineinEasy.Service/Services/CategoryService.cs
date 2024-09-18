using AutoMapper;
using DineinEasy.Data.Models;
using DineinEasy.Data.UnitOfWork;
using DineinEasy.Service.Models;
using DineinEasy.Service.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DineinEasy.Service.Services
{
    public interface ICategoryService
    {
        Task<IBusinessResult> GetAllCategory();
        Task<IBusinessResult> CreateCategory(CategoryModel model);
        Task<IBusinessResult> UpdateCategory(int Id, CategoryModel model);
        Task<IBusinessResult> GetCategoryById(int id);
        Task<IBusinessResult> DeleteCategorybyId(int id);
    }
    public class CategoryService : ICategoryService
    {

        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryService(IMapper mapper)
        {
            _unitOfWork ??= new UnitOfWork();
            _mapper = mapper;
        }

        public async Task<IBusinessResult> CreateCategory(CategoryModel model)
        {
            var obj = _mapper.Map<Category>(model);
            obj.Status = true;
            var created = await _unitOfWork.CategoryRepository.CreateAsync(obj);
            var result = _mapper.Map<CategoryModel>(created);
            return new BusinessResult(200, "Create successfully", result);
        }

        public async Task<IBusinessResult> DeleteCategorybyId(int id)
        {
            var obj = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
            if (obj == null)
            { return new BusinessResult(404, "Can not find Category"); }
            var result = await _unitOfWork.CategoryRepository.RemoveAsync(obj);
            return new BusinessResult(200, "Delete Category by Id successfully", result);
        }

        public async Task<IBusinessResult> GetAllCategory()
        {
            var list = await _unitOfWork.CategoryRepository.GetAllAsync();
            var data = _mapper.Map<List<CategoryModel>>(list);
            var result = new BusinessResult(200, "Get All Category", data);
            return result;
        }

        public async Task<IBusinessResult> GetCategoryById(int id)
        {
            var obj = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
            if (obj == null)
            { return new BusinessResult(404, "Can not find Category"); }
            var result = _mapper.Map<CategoryModel>(obj);
            return new BusinessResult(200, "Get Category by Id successfully", result);
        }

        public async Task<IBusinessResult> UpdateCategory(int Id, CategoryModel model)
        {
            var obj = await _unitOfWork.CategoryRepository.GetByIdAsync(Id);
            if (obj == null) { return new BusinessResult(404, "Can not find Category"); }
            _mapper.Map(model, obj);
            var updated = await _unitOfWork.CategoryRepository.UpdateAsync(obj);
            var result = _mapper.Map<CategoryModel>(obj);
            return new BusinessResult(200, "Update successfully", result);
        }
    }
}
