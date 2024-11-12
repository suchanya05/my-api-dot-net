using Microsoft.EntityFrameworkCore;

public class ProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }


    public async Task AddProduct(Product productlist)
    {
        await _context.DncProduct.AddAsync(productlist);
        await _context.SaveChangesAsync();
    }

    

    public async Task<Product?> GetProductByMatCode(string productMatCode)
    {
        var product = await _context.DncProduct.Where(product => product.MatirialCode == productMatCode).FirstOrDefaultAsync();

        return product;
    }  

    // public async Task AddQtyByMatCode(string productMatCode,int qty)
    // {
    //     var product = await GetProductByMatCode(productMatCode);
    //     if (product!=null)
    //     {
    //         product.Qty += qty;
    //         _context.Entry(product).State = EntityState.Modified;
    //         await _context.SaveChangesAsync();
    //     }
        
    //     // await _context.DncProduct.AddAsync(qtymatcode);
        
    // }  

    // public async Task<List<Product>> Saleout()
    // {
    //     var producttion = await _context.DncProduct.ToListAsync();
    //     return producttion;
    // }

    public async Task UpdateAsync(Product product)
    {
        _context.Entry(product).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteByMatCode(string productMatCode)
    {
        var product = await GetProductByMatCode(productMatCode);
        if (product != null)
        {
            _context.DncProduct.Remove(product);
            await _context.SaveChangesAsync();
        }
    }

}