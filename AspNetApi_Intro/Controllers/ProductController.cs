using AspNetApi_Intro.Data.DAL;
using AspNetApi_Intro.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AspNetApi_Intro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult GetProducts()
        {
            return StatusCode(200, _context.Products.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            Product p = _context.Products.FirstOrDefault(p => p.Id == id);
            if (p == null) return NotFound();
            return StatusCode(200, p);
        }

        [HttpPost]
        public IActionResult Add(Product p)
        {
            Product newProduct = new Product();
            newProduct.Name = p.Name;
            newProduct.Price = p.Price;
            newProduct.Count = p.Count;

            _context.Products.Add(newProduct);
            _context.SaveChanges();

            return StatusCode(201, $"{p.Name} adli product elave olundu.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            Product p = _context.Products.FirstOrDefault(p => p.Id == id);
            if (p == null) return NotFound();

            _context.Remove(p);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
