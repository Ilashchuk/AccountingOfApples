using AutoMapper;
using BLL.DTO;
using DAL.Models;
using DAL.Repositories.UnitOfWork;

namespace BLL.Services;

public class OrderControlService : IOrderControlService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OrderControlService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OrderDTO>> GetAllAsync()
    {
        IEnumerable<OrderDTO> orders = _mapper.Map<IEnumerable<OrderDTO>>(await _unitOfWork.Orders.GetAllAsync());
        foreach (var order in orders)
        {
            foreach (var item in order.OrderAppleVarieties)
            {
                item.AvarageWeight = item.Weight / item.CountOfBoxes;
                item.TotalPrice = item.Price * item.Weight - item.Packaging?.Price * item.Weight;
                item.SumForOwner = item.TotalPrice / 100 * item.Area?.Owner?.Percent;
                item.MyIncom = item.TotalPrice - item.SumForOwner;
            }
        }
        return orders;
    }

    public async Task<IEnumerable<OrderDTO>> GetAllByClientIdAsync(Guid clientId)
    {
        return _mapper.Map<IEnumerable<OrderDTO>>(await _unitOfWork.Orders.GetAllByClientIdAsync(clientId));
    }

    public async Task<OrderDTO> GetByIdAsync(Guid id)
    {
        return _mapper.Map<OrderDTO>(await _unitOfWork.Orders.GetByIdAsync(id));
    }

    public async Task<OrderDTO?> CreateAsync(OrderDTO orderDTO)
    {
        await _unitOfWork.Orders.AddAsync(_mapper.Map<Order>(orderDTO));
        if (_unitOfWork.Complete() == 0)
        {
            return null;
        }
        return orderDTO;
    }

    public async Task<OrderDTO?> UpdateAsync(OrderDTO areaDTO)
    {
        Order? order = await _unitOfWork.Orders.GetByIdAsync(areaDTO.Id);
        if (order != null)
        {
            order = _mapper.Map<Order>(areaDTO);
            _unitOfWork.Orders.Update(order);
            _unitOfWork.Complete();
            return areaDTO;
        }
        return null;
    }

    public async Task<bool> Remove(Guid id)
    {
        Order? order = await _unitOfWork.Orders.GetByIdAsync(id);
        if (order != null)
        {
            _unitOfWork.Orders.Remove(order);
            _unitOfWork.Complete();
            return true;
        }
        return false;
    }
}
