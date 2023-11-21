using AutoMapper;
using BLL.DTO;
using DAL.Models;
using DAL.Repositories.UnitOfWork;

namespace BLL.Services;

public class OwnerControlService : IOwnerControlService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OwnerControlService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OwnerDTO>> GetAllAsync()
    {
        return _mapper.Map<IEnumerable<OwnerDTO>>(await _unitOfWork.Owners.GetAllAsync());
    }

    public async Task<OwnerDTO> GetByIdAsync(Guid id)
    {
        return _mapper.Map<OwnerDTO>(await _unitOfWork.Owners.GetByIdAsync(id));
    }

    public async Task<OwnerDTO?> CreateAsync(OwnerDTO owner)
    {
        await _unitOfWork.Owners.AddAsync(_mapper.Map<Owner>(owner));
        if (_unitOfWork.Complete() == 0)
        {
            return null;
        }
        return owner;
    }

    public async Task<OwnerDTO?> UpdateAsync(OwnerDTO ownerDTO)
    {
        Owner? owner = await _unitOfWork.Owners.GetByIdAsync(ownerDTO.Id);
        if (owner != null)
        {
            owner = _mapper.Map<Owner>(ownerDTO);
            _unitOfWork.Owners.Update(owner);
            _unitOfWork.Complete();
            return ownerDTO;
        }
        return null;
    }

    public async Task<bool> Remove(Guid id)
    {
        Owner? owner = await _unitOfWork.Owners.GetByIdAsync(id);
        if (owner != null)
        {
            _unitOfWork.Owners.Remove(owner);
            _unitOfWork.Complete();
            return true;
        }
        return false;
    }
}
