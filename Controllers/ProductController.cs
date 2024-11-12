using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

[ApiController]
[Route("api/product")]
public class ProductController : ControllerBase
{
    private readonly ProductService _service;
    public ProductController(AppDbContext context)
    {
        var repository = new ProductRepository(context);
        _service = new ProductService(repository);
    }

    //code here

    [HttpPost("add-product")]
    public async Task<IActionResult> Create(ProductListDto ProductDto)
    {

        if (ProductDto != null)
        {
            await _service.AddProduct(ProductDto);
            return Ok(ProductDto);
        }

        return BadRequest();
    }

    [HttpGet("get-product-by-mat-code/{MatirialCode}")]
    public async Task<ActionResult<Product>> GetProductByMatCode(string MatirialCode)
    {

        if (MatirialCode != null && MatirialCode != "")
        {
            var response = await _service.GetProductByMatCode(MatirialCode);
            return Ok(response);
        }

        return BadRequest();
    }

    [HttpPost("update-product-by-mat-code")]
    public async Task<IActionResult> Update(ProductListDto productDto)
    {

        if (productDto != null && productDto.MatirialCode != null)
        {
            await _service.UpdateProductByMatCode(productDto);
            return Ok(productDto);
        }
        return BadRequest();
    }

}