namespace BLL.Services;

public interface IControlService<T_DTO> where T_DTO : class
{
    Task<IEnumerable<T_DTO>> GetAllAsync();

    Task<T_DTO> GetByIdAsync(Guid id);

    Task<T_DTO?> CreateAsync(T_DTO dto);

    Task<T_DTO?> UpdateAsync(T_DTO dto);

    Task<bool> Remove(Guid id);
}
