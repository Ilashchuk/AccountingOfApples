using AutoMapper;
using BLL.DTO;
using DAL.Models;
using DAL.Repositories.UnitOfWork;

namespace BLL.Services;

public class PackagingControlService : IPackagingControlService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PackagingControlService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PackagingDTO>> GetAllAsync()
    {
        return _mapper.Map<IEnumerable<PackagingDTO>>(await _unitOfWork.Packagings.GetAllAsync());
    }

    public async Task<PackagingDTO> GetByIdAsync(Guid id)
    {
        return _mapper.Map<PackagingDTO>(await _unitOfWork.Packagings.GetByIdAsync(id));
    }

    public async Task<PackagingDTO?> CreateAsync(PackagingDTO packagingDTO)
    {
        await _unitOfWork.Packagings.AddAsync(_mapper.Map<Packaging>(packagingDTO));
        if (_unitOfWork.Complete() == 0)
        {
            return null;
        }
        return packagingDTO;
    }

    public async Task<PackagingDTO?> UpdateAsync(PackagingDTO packaginDTO)
    {
        Packaging? packaging = await _unitOfWork.Packagings.GetByIdAsync(packaginDTO.Id);
        if (packaging != null)
        {
            packaging = _mapper.Map<Packaging>(packaginDTO);
            _unitOfWork.Packagings.Update(packaging);
            _unitOfWork.Complete();
            return packaginDTO;
        }
        return null;
    }

    public async Task<bool> Remove(Guid id)
    {
        Packaging? area = await _unitOfWork.Packagings.GetByIdAsync(id);
        if (area != null)
        {
            _unitOfWork.Packagings.Remove(area);
            _unitOfWork.Complete();
            return true;
        }
        return false;
    }
}
