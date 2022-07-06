using AutoMapper;
using BusinessLayer.Interfaces;
using DatasoftECommerceApi.ViewModels;
using Domain.DataTransferObjects;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatasoftECommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [Authorize(Roles = "Manager")]
        [HttpPost("insert")]
        public IActionResult Insert(CategoryCreateVm model)
        {
            var category = _mapper.Map<Category>(model);

            _categoryService.Insert(category);

            return Ok();
        }

        [Authorize(Roles = "Manager")]
        [HttpPost("insert-all")]
        public IActionResult InsertAll(List<CategoryCreateVm> models)
        {
            var list = new List<Category>();

            foreach (var model in models)
            {
                list.Add(_mapper.Map<Category>(model));
            }
            _categoryService.InsertAll(list.AsEnumerable());

            return Ok();
        }

        [Authorize(Roles = "Manager")]
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _categoryService.Delete(id);

            return Ok();
        }

        [Authorize(Roles = "Manager")]
        [HttpDelete("delete-all")]
        public IActionResult DeleteAll(List<int> ids)
        {
            _categoryService.DeleteAll(ids.AsEnumerable());

            return Ok();
        }

        [Authorize(Roles = "Manager")]
        [HttpPost("update")]
        public IActionResult Update(CategoryCreateVm model)
        {
            var category = _mapper.Map<Category>(model);

            _categoryService.Update(category);

            return Ok();
        }

        [Authorize(Roles = "Manager")]
        [HttpPost("update-all")]
        public IActionResult UpdateAll(List<CategoryCreateVm> models)
        {
            var list = new List<Category>();

            foreach (var model in models)
            {
                list.Add(_mapper.Map<Category>(model));
            }

            _categoryService.UpdateAll(list.AsEnumerable());

            return Ok();
        }

        [Authorize(Roles = "Manager, Assistant")]
        [HttpGet("get/{id}")]
        public IActionResult Get(int id)
        {
            var category = _categoryService.Get(id);
            var mapped = _mapper.Map<CategoryDto>(category);

            return Ok(mapped);
        }

        [Authorize(Roles = "Manager, Assistant")]
        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var res = _categoryService.GetAll();

            return Ok(res);
        }
    }
}
