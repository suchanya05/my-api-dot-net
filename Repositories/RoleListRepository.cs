using Microsoft.EntityFrameworkCore;

public class RoleListRepository
{
    private readonly AppDbContext _context;

    public RoleListRepository(AppDbContext context)
    {
        _context = context;
    }


    public async Task AddRole(RoleList roleList)
    {
        await _context.DncRoleList.AddAsync(roleList);
        await _context.SaveChangesAsync();
    }

    public async Task<RoleList?> GetRoleByName(string roleName)
    {
        var roleRes = await _context.DncRoleList.Where(r => r.RoleName == roleName).FirstOrDefaultAsync();
        return roleRes;
    }

    public async Task<RoleList?> GetRoleById(int roleId)
    {
        var roleRes = await _context.DncRoleList.Where(r => r.Id == roleId).FirstOrDefaultAsync();

        return roleRes;
    }   

    public async Task<List<RoleList>> GetAllRole()
    {
        // return await _context.DncPersonal.ToListAsync();
        var roleResList = await _context.DncRoleList.ToListAsync();
        return roleResList;
    }

    public async Task UpdateAsync(RoleList roleList)
    {
        _context.Entry(roleList).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
    
}
