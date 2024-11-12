using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class PersonalRepository
{
    private readonly AppDbContext _context;

    public PersonalRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Personal>> GetAllAsync()
    {
        return await _context.DncPersonal.ToListAsync();
    }

    public async Task<Personal?> GetByIdAsync(int id)
    {
        return await _context.DncPersonal.FindAsync(id);
    }
    public async Task AddAsync(Personal personal)
    {
        await _context.DncPersonal.AddAsync(personal);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Personal personal)
    {
        _context.Entry(personal).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var personal = await GetByIdAsync(id);
        if (personal != null)
        {
            _context.DncPersonal.Remove(personal);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Personal>> GetPersonalForTable(reqDto<PersonalDto> req)
    {
        return await _context.DncPersonal
            .OrderBy(p => p.Id)           
            .Skip((req.PageNumber.GetValueOrDefault() - 1) * req.PageSize.GetValueOrDefault()) // ข้ามข้อมูลตามเลขหน้า
            .Take(req.PageSize.GetValueOrDefault())                // ดึงข้อมูลตามจำนวนที่กำหนด
            .ToListAsync();
    }

    public async Task<Personal?> GetByUsernameAsync(string username)
    {
        var personal = await _context.DncPersonal
            .Where(p => p.Username == username)
            .FirstOrDefaultAsync();

        return personal; // สามารถคืนค่า null ได้ถ้าไม่มี record เจอ
    }

}
