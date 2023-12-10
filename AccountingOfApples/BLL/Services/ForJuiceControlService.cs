using AutoMapper;
using BLL.DTO;
using DAL.Models;
using DAL.Repositories.UnitOfWork;

namespace BLL.Services;

public class ForJuiceControlService : IForJuiceControlService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ForJuiceControlService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ForJuiceDTO>> GetAllAsync()
    {
        return _mapper.Map<IEnumerable<ForJuiceDTO>>(await _unitOfWork.ForJuices.GetAllAsync());
    }

    public async Task<ForJuiceDTO> GetByIdAsync(Guid id)
    {
        return _mapper.Map<ForJuiceDTO>(await _unitOfWork.ForJuices.GetByIdAsync(id));
    }

    public async Task<ForJuiceDTO?> CreateAsync(ForJuiceDTO forJuiceDTO)
    {
        await _unitOfWork.ForJuices.AddAsync(_mapper.Map<ForJuice>(forJuiceDTO));
        if (_unitOfWork.Complete() == 0)
        {
            return null;
        }
        return forJuiceDTO;
    }

    public async Task<ForJuiceDTO?> UpdateAsync(ForJuiceDTO forJuiceDTO)
    {
        ForJuice? forJuice = await _unitOfWork.ForJuices.GetByIdAsync(forJuiceDTO.Id);
        if (forJuice != null)
        {
            forJuice = _mapper.Map<ForJuice>(forJuiceDTO);
            _unitOfWork.ForJuices.Update(forJuice);
            _unitOfWork.Complete();
            return forJuiceDTO;
        }
        return null;
    }

    public async Task<bool> Remove(Guid id)
    {
        ForJuice? forJuice = await _unitOfWork.ForJuices.GetByIdAsync(id);
        if (forJuice != null)
        {
            _unitOfWork.ForJuices.Remove(forJuice);
            _unitOfWork.Complete();
            return true;
        }
        return false;
    }
}
