using AutoMapper;
using BLL.DTO;
using DAL.Models;
using DAL.Repositories.UnitOfWork;

namespace BLL.Services;

public class OrderAppleVarietyControlService : IOrderAppleVarietyControlService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OrderAppleVarietyControlService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OrderAppleVarietyDTO>> GetAllAsync()
    {
        return _mapper.Map<IEnumerable<OrderAppleVarietyDTO>>(await _unitOfWork.OrderAppleVarieties.GetAllAsync());
    }

    public async Task<IEnumerable<OrderAppleVarietyDTO>> GetAllByOrderIdAsync(Guid orderId)
    {
        return _mapper.Map<IEnumerable<OrderAppleVarietyDTO>>(await _unitOfWork.OrderAppleVarieties.GetAllByOrderIdAsync(orderId));
    }

    public async Task<OrderAppleVarietyDTO> GetByIdAsync(Guid id)
    {
        return _mapper.Map<OrderAppleVarietyDTO>(await _unitOfWork.OrderAppleVarieties.GetByIdAsync(id));
    }

    public async Task<OrderAppleVarietyDTO?> CreateAsync(OrderAppleVarietyDTO orderAppleVarietyDTO)
    {
        await _unitOfWork.OrderAppleVarieties.AddAsync(_mapper.Map<OrderAppleVariety>(orderAppleVarietyDTO));
        if (_unitOfWork.Complete() == 0)
        {
            return null;
        }
        return orderAppleVarietyDTO;
    }

    public async Task<OrderAppleVarietyDTO?> UpdateAsync(OrderAppleVarietyDTO orderAppleVarietyDTO)
    {
        OrderAppleVariety? order = await _unitOfWork.OrderAppleVarieties.GetByIdAsync(orderAppleVarietyDTO.Id);
        if (order != null)
        {
            order = _mapper.Map<OrderAppleVariety>(orderAppleVarietyDTO);
            _unitOfWork.OrderAppleVarieties.Update(order);
            _unitOfWork.Complete();
            return orderAppleVarietyDTO;
        }
        return null;
    }

    public async Task<bool> Remove(Guid id)
    {
        OrderAppleVariety? order = await _unitOfWork.OrderAppleVarieties.GetByIdAsync(id);
        if (order != null)
        {
            _unitOfWork.OrderAppleVarieties.Remove(order);
            _unitOfWork.Complete();
            return true;
        }
        return false;
    }
}
