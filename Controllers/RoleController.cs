using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

[ApiController]
[Route("api/role")]
public class RoleController : ControllerBase
{
    private readonly RoleListService _service;
    public RoleController(AppDbContext context)
    {
        var repository = new RoleListRepository(context);
        _service = new RoleListService(repository);
    }

    //code here

    [HttpPost("add")]
    public async Task<IActionResult> Create(RoleListDto roleDto)
    {

        if (roleDto != null)
        {
            await _service.AddRole(roleDto);
            return Ok(roleDto);
        }

        return BadRequest();
    }

    [HttpGet("get-by-name/{name}")]
    public async Task<ActionResult<RoleList>> GetByName(string name)
    {

        if (name != null && name != "")
        {
            var response = await _service.GetRoleByName(name);
            return Ok(response);
        }

        return BadRequest();
    }

    [HttpGet("get-by-id/{id}")]
    public async Task<ActionResult<RoleList>> GetByName(int id)
    {

        if (id > 0)
        {
            var response = await _service.GetRoleById(id);
            return Ok(response);
        }

        return BadRequest();
    }

    [HttpGet("get-all")]
    public async Task<ActionResult<List<RoleList>>> GetAll()
    {
        return await _service.GetAllRole();
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(RoleListDto roleDto)
    {

        if (roleDto != null && roleDto.Id > 0 && roleDto.Id != null)
        {
            await _service.UpdateRole(roleDto);
            return Ok(roleDto);
        }
        return BadRequest();
    }
}