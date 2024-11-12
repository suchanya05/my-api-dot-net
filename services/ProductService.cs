using System.Collections.Generic;
using System.Threading.Tasks;

public class ProductService
{
    private readonly ProductRepository _repository;

    public ProductService(ProductRepository repository)
    {
        _repository = repository;
    }

    //Code Here

    public async Task AddProduct(ProductListDto productDto)
    {

        var product = new Product
        {
            ProductName = productDto.ProductName,
            MatirialCode = productDto.MatirialCode,
            Description = productDto.Description,
            Price = productDto.Price,
            Qty = productDto.Qty,
            ProductType = productDto.ProductType,
            ProductSubType = productDto.ProductSubType,
            ProductColor = productDto.ProductColor,
            SerialType = productDto.SerialType
        };

        await _repository.AddProduct(product);
    }

    public async Task<Product?> GetProductByMatCode(string productMatCode)
    {
        return await _repository.GetProductByMatCode(productMatCode); ;
    }


    public async Task UpdateProductByMatCode(ProductListDto productDto)
    {
        if (productDto.MatirialCode != null)
        {
            var product = await _repository.GetProductByMatCode(productDto.MatirialCode);

            if (product != null)
            {
                product.MatirialCode = productDto.MatirialCode;
                product.Description = productDto.Description;
                product.ProductName = productDto.ProductName;
                product.Price = productDto.Price;
                product.Qty = productDto.Qty;
                product.ProductType = productDto.ProductSubType;
                product.ProductSubType = productDto.ProductSubType;
                product.ProductColor = productDto.ProductColor;
                product.SerialType = productDto.SerialType;

                await _repository.UpdateAsync(product);
            }
        }


    }

}
