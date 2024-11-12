using Microsoft.EntityFrameworkCore;

public class ProductDtlRepository
{
    private readonly AppDbContext _context;

    public ProductDtlRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<ProductDtl>> GetByMatCode(string productDtlmatCode)
    {
        var productDtl = await _context.DncProductDtl.Where(p => p.MatCode == productDtlmatCode).ToListAsync();
        return productDtl;
    }  

    public async Task<ProductDtl?> GetBySerial(string productDtlSerial)
    {
        var productDtl = await _context.DncProductDtl.Where(p => p.MatCode == productDtlSerial).FirstOrDefaultAsync();
        return productDtl;
    }
    public async Task AddSerialProduct(ProductDtl productDtl)
    {
        await _context.DncProductDtl.AddAsync(productDtl);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateSerialProduct(ProductDtl product_Dtl)
    {
        _context.Entry(product_Dtl).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
   
}