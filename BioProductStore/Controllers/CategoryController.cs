﻿using BioProductStore.Data;
using BioProductStore.DTOs;
using BioProductStore.Services.CategoryService;
using Microsoft.AspNetCore.Mvc;
using System;


namespace BioProductStore.Controllers
{
    //[EnableCors("AllowOrigin")]
    [Route("api/[controller]")] 
    [ApiController]
    //[Authorization(Role.Admin)]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly BioProductStoreContext _context;

        public CategoryController(ICategoryService categoryService, BioProductStoreContext context)
        {
            _categoryService = categoryService;
            _context = context;
        }

        //GET
        [HttpGet("byId/{id}")]
        public IActionResult GetById(Guid id)
        {
            return Ok(_categoryService.GetCategoryByCategoryId(id));
        }

        
        [HttpGet("/allCategories")]
        public IActionResult GetAllCategories()
        {
            return Ok(_categoryService.GetAllCategories());
        }


        //POST
        [HttpPost("create")]
        public IActionResult Create(RegisterCategoryDTO category)
        {
            _categoryService.CreateCategory(category);
            return Ok();
        }

        //PUT
        [HttpPut("update")]
        public IActionResult Update(RegisterCategoryDTO category, Guid id)
        {
            _categoryService.UpdateCategory(category, id);
            return Ok();
        }


        //DELETE
        [HttpDelete]
        public IActionResult DeleteById(Guid Id)
        {
            _categoryService.DeleteCategoryById(Id);
            return Ok();
        }
    }
}
