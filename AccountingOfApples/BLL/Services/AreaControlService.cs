using AutoMapper;
using BLL.DTO;
using DAL.Models;
using DAL.Repositories.UnitOfWork;

namespace BLL.Services;

public class AreaControlService : IAreaControlService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AreaControlService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AreaDTO>> GetAllAsync()
    {
         return _mapper.Map<IEnumerable<AreaDTO>>(await _unitOfWork.Areas.GetAllAsync());
    }

    public async Task<AreaDTO> GetByIdAsync(Guid id)
    {
        return _mapper.Map<AreaDTO>(await _unitOfWork.Areas.GetByIdAsync(id));
    }

    public async Task<AreaDTO?> CreateAsync(AreaDTO areaDTO)
    {
        await _unitOfWork.Areas.AddAsync(_mapper.Map<Area>(areaDTO));
        if (_unitOfWork.Complete() == 0)
        {
            return null;
        }
        return areaDTO;
    }

    public async Task<AreaDTO?> UpdateAsync(AreaDTO areaDTO)
    {
        Area? area = await _unitOfWork.Areas.GetByIdAsync(areaDTO.Id);
        if (area != null)
        {
            area = _mapper.Map<Area>(areaDTO);
            _unitOfWork.Areas.Update(area);
            _unitOfWork.Complete();
            return areaDTO;
        }
        return null;
    }

    public async Task<bool> Remove(Guid id)
    {
        Area? area = await _unitOfWork.Areas.GetByIdAsync(id);
        if (area != null)
        {
            _unitOfWork.Areas.Remove(area);
            _unitOfWork.Complete();
            return true;
        }
        return false;
    }
}
