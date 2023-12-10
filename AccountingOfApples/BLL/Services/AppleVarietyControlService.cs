using AutoMapper;
using BLL.DTO;
using DAL.Models;
using DAL.Repositories.UnitOfWork;

namespace BLL.Services;

public class AppleVarietyControlService : IAppleVarietyControlService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AppleVarietyControlService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AppleVarietyDTO>> GetAllAsync()
    {
        return _mapper.Map<IEnumerable<AppleVarietyDTO>>(await _unitOfWork.AppleVarieties.GetAllAsync());
    }

    public async Task<AppleVarietyDTO> GetByIdAsync(Guid id)
    {
        return _mapper.Map<AppleVarietyDTO>(await _unitOfWork.AppleVarieties.GetByIdAsync(id));
    }

    public async Task<AppleVarietyDTO?> CreateAsync(AppleVarietyDTO appleVarietyDTO)
    {
        await _unitOfWork.AppleVarieties.AddAsync(_mapper.Map<AppleVariety>(appleVarietyDTO));
        if (_unitOfWork.Complete() == 0)
        {
            return null;
        }
        return appleVarietyDTO;
    }

    public async Task<AppleVarietyDTO?> UpdateAsync(AppleVarietyDTO appleVarietyDTO)
    {
        AppleVariety? appleVariety = await _unitOfWork.AppleVarieties.GetByIdAsync(appleVarietyDTO.Id);
        if (appleVariety != null)
        {
            appleVariety = _mapper.Map<AppleVariety>(appleVarietyDTO);
            _unitOfWork.AppleVarieties.Update(appleVariety);
            _unitOfWork.Complete();
            return appleVarietyDTO;
        }
        return null;
    }

    public async Task<bool> Remove(Guid id)
    {
        AppleVariety? appleVariety = await _unitOfWork.AppleVarieties.GetByIdAsync(id);
        if (appleVariety != null)
        {
            _unitOfWork.AppleVarieties.Remove(appleVariety);
            _unitOfWork.Complete();
            return true;
        }
        return false;
    }
}
