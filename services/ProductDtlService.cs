using System.Collections.Generic;
using System.Threading.Tasks;

public class ProductDtlService
{
    private readonly ProductDtlRepository _repository;

    public ProductDtlService(ProductDtlRepository repository)
    {
        _repository = repository;
    }
    public async Task<List<ProductDtl>> GetByMatCode(string product_dtlmatCode)
    {
        return await _repository.GetByMatCode(product_dtlmatCode); 
    }
     public async Task<ProductDtl?> GetBySerial(string product_dtlmatCode)
    {
        return await _repository.GetBySerial(product_dtlmatCode); 
    }

    public async Task AddSerialProduct(ProductDtl product_dtl)
    {

        var product = new ProductDtl
        {
            Id = product_dtl.Id,
            SerialNumber = product_dtl.SerialNumber,
            MatCode = product_dtl.MatCode,
            Qty = product_dtl.Qty,
        };

        await _repository.AddSerialProduct(product_dtl);
    }
    
    public async Task UpdateSerialProduct(Product_dtlListDto product_dtlDto)
    {
        if (product_dtlDto.SerialNumber != null)
        {
            var product_dtl = await _repository.GetBySerial(product_dtlDto.SerialNumber);

            if (product_dtl != null)
            {
                product_dtl.SerialNumber = product_dtlDto.SerialNumber;
        
                await _repository.UpdateSerialProduct(product_dtl);
            }
        }


    }
}