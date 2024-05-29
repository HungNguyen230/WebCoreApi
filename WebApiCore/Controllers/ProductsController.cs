using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiCore.Models;
using WebApiCore.Services;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _IProductService;

        public ProductsController(IProductService IProductService)
        {
            _IProductService = IProductService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await _IProductService.Get();
                if (data != null)
                    return Ok(data);
                else
                    return NotFound();
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var data = await _IProductService.GetById(id);
                if (data != null)
                    return Ok(new { data});
                else
                    return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] ProductModel product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status201Created, await _IProductService.Add(product));
                }
                return BadRequest();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductModel product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status201Created, await _IProductService.Update(product));
                }
                return BadRequest();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status201Created, await _IProductService.Delete(id));
                }
                return BadRequest();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
