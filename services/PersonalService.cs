using System.Collections.Generic;
using System.Threading.Tasks;

public class PersonalService
{
    private readonly PersonalRepository _repository;

    public PersonalService(PersonalRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Personal>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Personal?> GetByIdAsync(int id) 
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddAsync(Personal personal)
    {
        // Encrypt password
        await _repository.AddAsync(personal);
    }

    public async Task UpdateAsync(Personal personal)
    {
        // Optionally update password, if changed
        personal.Password = BCrypt.Net.BCrypt.HashPassword(personal.Password);
        await _repository.UpdateAsync(personal);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<List<Personal>> GetPersonalForTable(reqDto<PersonalDto> req)
    {
        return await _repository.GetPersonalForTable(req);
    }

    public async Task<Personal?> GetPersonalByUsername(string username)
    {
        return await _repository.GetByUsernameAsync(username);
    }

}
