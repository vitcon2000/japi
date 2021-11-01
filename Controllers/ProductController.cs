using System;
using System.Threading.Tasks;
using api.Repositories.Dependencies;
using Microsoft.AspNetCore.Mvc;
namespace api.Controllers
{
    [Route("Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _ProductRepository;

        public ProductController(IProductRepository productRepository)
        {
            _ProductRepository = productRepository;
        }

        [HttpGet]
        [Route("status")]
        public async Task<IActionResult> GetStatus()
        {
            try
            {
                var result = await _ProductRepository.GetStatuses();
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("packing")]
        public async Task<IActionResult> GetPacking()
        {
            try
            {
                var result = await _ProductRepository.GetPackMethods();
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("origin")]
        public async Task<IActionResult> GetOrigin()
        {
            try
            {
                var result = await _ProductRepository.GetOrigins();
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateProduct(int quantity)
        {
            try
            {
                var result = await _ProductRepository.GetProducts(quantity);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("getlist")]
        public async Task<IActionResult> GetProducts(int quantity)
        {
            try
            {
                var result = await _ProductRepository.GetProducts(quantity);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> Search(string querySearch, int? CurrentPage, int? PageSize)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(querySearch))
                {
                    querySearch = "";
                }
                int currentPage = CurrentPage != null ? (int)CurrentPage : 1;
                int pageSize = PageSize != null ? (int)PageSize : 9;
                var gameModelList = await _ProductRepository.Search(querySearch, currentPage, pageSize);
                if (gameModelList == null)
                {
                    return NotFound();
                }
                return Ok(gameModelList);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}