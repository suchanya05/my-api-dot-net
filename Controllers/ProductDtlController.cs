using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

[ApiController]
[Route("api/product-serials")]
public class ProductDtlController : ControllerBase
{
    private readonly ProductDtlService _service;
    public ProductDtlController(AppDbContext context)
    {
        var repository = new ProductDtlRepository(context);
        _service = new ProductDtlService(repository);
    }
    [HttpGet("get-by-mat-code/{MatCode}")]
    public async Task<ActionResult<ProductDtl>> GetByMatCode(string MatCode)
    {

        if (MatCode != null && MatCode != "")
        {
            var response = await _service.GetByMatCode(MatCode);
            return Ok(response);
        }

        return BadRequest();
    }
    [HttpGet("get-By-serial/{SerialNumber}")]
    public async Task<ActionResult> GetBySerial(string SerialNumber)
    {

        if (SerialNumber != null && SerialNumber != "")
        {
            var response = await _service.GetBySerial(SerialNumber);
            return Ok(response);
        }

        return BadRequest();
    }
    [HttpPost("add-serial-product")]
    public async Task<IActionResult> Create(ProductDtl product_dtl)
    {

        if (product_dtl != null)
        {
            await _service.AddSerialProduct(product_dtl);
            return Ok(product_dtl);
        }

        return BadRequest();
    }
     [HttpPost("update-serial-product")]
    public async Task<IActionResult> Update(Product_dtlListDto product_DtlListDto)
    {

        if (product_DtlListDto != null && product_DtlListDto.SerialNumber != null)
        {
            await _service.UpdateSerialProduct(product_DtlListDto);
            return Ok(product_DtlListDto);
        }
        return BadRequest();
    }
}

