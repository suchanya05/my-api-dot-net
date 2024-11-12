using System.Collections.Generic;
using System.Threading.Tasks;

public class RoleListService
{
    private readonly RoleListRepository _repository;

    public RoleListService(RoleListRepository repository)
    {
        _repository = repository;
    }

    //Code Here


    public async Task AddRole(RoleListDto roleDto)
    {

        var role = new RoleList
        {
            RoleName = roleDto.RoleName,
            Description = roleDto.Description
        };

        await _repository.AddRole(role);
    }

    public async Task<RoleList?> GetRoleByName(String name)
    {
        return await _repository.GetRoleByName(name); ;
    }

    public async Task<RoleList?> GetRoleById(int id)
    {
        return await _repository.GetRoleById(id);
    }

    public async Task<List<RoleList>> GetAllRole()
    {
        return await _repository.GetAllRole();
    }

    public async Task UpdateRole(RoleListDto roleDto)
    {
        var role = await _repository.GetRoleById(roleDto.Id.GetValueOrDefault());

        if (role != null)
        {
            role.RoleName = roleDto.RoleName;
            role.Description= roleDto.Description;
            await _repository.UpdateAsync(role);
        }

    }

}
