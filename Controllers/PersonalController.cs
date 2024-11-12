using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

[ApiController]
[Route("api/personal")]
public class PersonalController : ControllerBase
{
    private readonly PersonalService _service;
    private readonly ILogger<PersonalController> _logger;
    public PersonalController(AppDbContext context, ILogger<PersonalController> logger)
    {
        var repository = new PersonalRepository(context);
        _service = new PersonalService(repository);
        _logger = logger;
    }

    // GET: api/personal
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Personal>>> GetAll()
    {
        var personalList = await _service.GetAllAsync();
        return Ok(personalList);
    }

    // GET: api/personal/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Personal>> GetById(int id)
    {
        var personal = await _service.GetByIdAsync(id);
        if (personal == null)
        {
            return NotFound();
        }
        return Ok(personal);
    }
    [HttpPost]
    public async Task<IActionResult> Create(PersonalDto personalDto)
    {
        if (ModelState.IsValid)
        {

            var personal = new Personal
            {
                Username = personalDto.Username,
                Description = personalDto.Description,
                MobileNo = personalDto.MobileNo,
                Role = personalDto.Role,
                Address = personalDto.Address,
                AddressDesc = personalDto.AddressDesc,
                Point = personalDto.Point,
                Coin = personalDto.Coin,
                Level = personalDto.Level,
                Exp = personalDto.Exp
            };
            var chechPersonalDup = await _service.GetPersonalByUsername(personalDto.Username);
            if (chechPersonalDup != null)
            {
                return Ok("Username: " + personalDto.Username + " is Duplicate.");
            }
            // ตั้งค่ารหัสผ่าน
            if (!string.IsNullOrEmpty(personalDto.Password))
            {
                personal.SetPassword(personalDto.Password); // ตรวจสอบว่ามี method นี้ใน class Personal
            }
            else
            {
                return BadRequest("Password is required."); // ให้ข้อมูลเพิ่มเติมเมื่อรหัสผ่านไม่ถูกต้อง
            }
            // ใส่รหัสผ่านจาก client ที่เข้ารหัส
            await _service.AddAsync(personal);
            return Ok(personalDto.Username+" save success!!");
        }

        // ส่งกลับข้อมูลข้อผิดพลาดหาก ModelState ไม่ถูกต้อง
        return BadRequest(ModelState);
    }
    // PUT: api/personal/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] Personal personal)
    {
        if (id != personal.Id)
        {
            return BadRequest();
        }

        if (ModelState.IsValid)
        {
            await _service.UpdateAsync(personal);
            return NoContent();
        }
        return BadRequest(ModelState);
    }

    // DELETE: api/personal/{id}
    [HttpGet("delete/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var personal = await _service.GetByIdAsync(id);
        if (personal == null)
        {
            return NotFound();
        }

        await _service.DeleteAsync(id);
        return NoContent();
    }

    [HttpGet("deleteByUsername/{username}")]
    public async Task<ActionResult> DeleteByUsername(string username)
    {
        var personal = await _service.GetPersonalByUsername(username);
        if (personal == null)
        {
            return NotFound();
        }
        else
        {
            await _service.DeleteAsync(personal.Id);
            return Ok(personal.Username + " Deleted!");
        }
    }

    [HttpPost("pagination")]
    public async Task<IActionResult> GetPaginatedPersonal(reqDto<PersonalDto> req)
    {
        var personalList = await _service.GetPersonalForTable(req);
        return Ok(personalList);
    }

    [HttpGet("username/{username}")]
    public async Task<IActionResult> GetByUsername(string username)
    {
        var personal = await _service.GetPersonalByUsername(username);
        if (personal == null)
        {
            return NotFound();
        }
        return Ok(personal);
    }
}
