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
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [Authorize(Roles = "Manager")]
        [HttpPost("insert")]
        public IActionResult Insert(ProductCreateVm model)
        {
            var product =  _mapper.Map<Product>(model);

            _productService.Insert(product);

            return Ok();
        }

        [Authorize(Roles = "Manager")]
        [HttpPost("insert-all")]
        public IActionResult InsertAll(List<ProductCreateVm> models)
        {
            var list = new List<Product>();

            foreach (var model in models)
            {
                list.Add(_mapper.Map<Product>(model));
            }
            _productService.InsertAll(list.AsEnumerable());

            return Ok();
        }

        [Authorize(Roles = "Manager")]
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);

            return Ok();
        }

        [Authorize(Roles = "Manager")]
        [HttpDelete("delete-all")]
        public IActionResult DeleteAll(List<int> ids)
        {
            _productService.DeleteAll(ids.AsEnumerable());

            return Ok();
        }

        [Authorize(Roles = "Manager")]
        [HttpPost("update")]
        public IActionResult Update(ProductCreateVm model)
        {
            var product = _mapper.Map<Product>(model);

            _productService.Update(product);

            return Ok();
        }

        [Authorize(Roles = "Manager")]
        [HttpPost("update-all")]
        public IActionResult UpdateAll(List<ProductCreateVm> models)
        {
            var list = new List<Product>();

            foreach (var model in models)
            {
                list.Add(_mapper.Map<Product>(model));
            }

            _productService.UpdateAll(list.AsEnumerable());

            return Ok();
        }

        [Authorize(Roles = "Manager, Assistant")]
        [HttpGet("get/{id}")]
        public IActionResult Get(int id)
        {
            var product = _productService.Get(id);
            var mapped = _mapper.Map<ProductDto>(product);

            return Ok(mapped);
        }

        [Authorize(Roles = "Manager, Assistant")]
        [HttpGet("get-all/{categoryId}")]
        public IActionResult GetAll(int categoryId)
        {
            var res = _productService.GetAll(x => x.CategoryId == categoryId);

            return Ok(res);
        }
    }
}
