using AutoMapper;
using BLL.DTO;
using BLL.Services;
using DAL.Models;
using DAL.Repositories.UnitOfWork;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AccountingsOfAppleTests.BLLTests;

[TestClass]
public class OrderControlServiceTest
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly OrderControlService _orderControlService;

    public OrderControlServiceTest()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _mapperMock = new Mock<IMapper>();
        _orderControlService = new OrderControlService(_unitOfWorkMock.Object, _mapperMock.Object);
    }

    [TestMethod]
    public async Task GetAll_ReturnsListOfOrders()
    {
        Guid Id_1 = Guid.NewGuid();
        Guid Id_1_1 = Guid.NewGuid();
        Guid Id_1_2 = Guid.NewGuid();
        Guid Id_2 = Guid.NewGuid();
        Guid Id_2_1 = Guid.NewGuid();
        Guid Id_2_2 = Guid.NewGuid();
        List<Order> orders = new List<Order> {
        new Order{ Id = Id_1, 
            Date = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), 
            ClientId = Guid.NewGuid(),
            OrderAppleVarieties = new List<OrderAppleVariety>
            {
                new OrderAppleVariety { Id = Guid.NewGuid(), 
                OrderId = Id_1,
                AppleVarietyId = Guid.NewGuid(),
                AreaId = Guid.NewGuid(),
                PackagingId = Guid.NewGuid(),
                Price = 10,
                Weight = 100,
                CountOfBoxes = 52
                },
                new OrderAppleVariety { Id = Guid.NewGuid(),
                OrderId = Id_1,
                AppleVarietyId = Guid.NewGuid(),
                AreaId = Guid.NewGuid(),
                PackagingId = Guid.NewGuid(),
                Price = 20,
                Weight = 200,
                CountOfBoxes = 105
                }
            }
        },
        new Order{ Id = Id_2,
            Date = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
            ClientId = Guid.NewGuid(),
            OrderAppleVarieties = new List<OrderAppleVariety>
            {
                new OrderAppleVariety { Id = Guid.NewGuid(),
                OrderId = Id_2,
                AppleVarietyId = Guid.NewGuid(),
                AreaId = Guid.NewGuid(),
                PackagingId = Guid.NewGuid(),
                Price = 30,
                Weight = 100,
                CountOfBoxes = 52
                },
                new OrderAppleVariety { Id = Guid.NewGuid(),
                OrderId = Id_2,
                AppleVarietyId = Guid.NewGuid(),
                AreaId = Guid.NewGuid(),
                PackagingId = Guid.NewGuid(),
                Price = 40,
                Weight = 200,
                CountOfBoxes = 105
                }
            }
        }
        };

        _unitOfWorkMock.Setup(av => av.Orders.GetAllAsync()).ReturnsAsync(orders);

        List<OrderDTO> ordersDTO = new List<OrderDTO> {
        new OrderDTO{ Id = orders[0].Id,
            Date = orders[0].Date,
            ClientId = orders[0].ClientId,
            OrderAppleVarieties = new List<OrderAppleVarietyDTO>
            {
                new OrderAppleVarietyDTO { Id = Id_1_1,
                OrderId = orders[0].Id,
                AppleVarietyId = Guid.NewGuid(),
                AreaId = Guid.NewGuid(),
                PackagingId = Guid.NewGuid(),
                Price = 10,
                Weight = 100,
                CountOfBoxes = 52
                },
                new OrderAppleVarietyDTO { Id = Id_1_2,
                OrderId = orders[0].Id,
                AppleVarietyId = Guid.NewGuid(),
                AreaId = Guid.NewGuid(),
                PackagingId = Guid.NewGuid(),
                Price = 20,
                Weight = 200,
                CountOfBoxes = 105
                }
            }
        },
        new OrderDTO{ Id = orders[1].Id,
            Date = orders[1].Date,
            ClientId = orders[1].ClientId,
            OrderAppleVarieties = new List<OrderAppleVarietyDTO>
            {
                new OrderAppleVarietyDTO { Id = Id_2_1,
                OrderId = orders[1].Id,
                AppleVarietyId = Guid.NewGuid(),
                AreaId = Guid.NewGuid(),
                PackagingId = Guid.NewGuid(),
                Price = 30,
                Weight = 100,
                CountOfBoxes = 52
                },
                new OrderAppleVarietyDTO { Id = Id_2_2,
                OrderId = orders[1].Id,
                AppleVarietyId = Guid.NewGuid(),
                AreaId = Guid.NewGuid(),
                PackagingId = Guid.NewGuid(),
                Price = 40,
                Weight = 200,
                CountOfBoxes = 105
                }
            }
        }
        };

        _mapperMock.Setup(m => m.Map<IEnumerable<OrderDTO>>(orders)).Returns(ordersDTO);

        var result = await _orderControlService.GetAllAsync();
        List<OrderDTO> res = (List<OrderDTO>)result;
        List<OrderAppleVarietyDTO> oAVList = res[0].OrderAppleVarieties.ToList();

        double avarageWeight = 100.0 / 52.0;
        double totalPrice = 10.0 * 100.0;
        double sumForOwner = 0.0;
        double myIncom = totalPrice - sumForOwner;

        Assert.AreEqual(avarageWeight, oAVList[0].AvarageWeight);
        Assert.AreEqual(totalPrice, oAVList[0].TotalPrice);
        Assert.AreEqual(sumForOwner, oAVList[0].SumForOwner);
        Assert.AreEqual(myIncom, oAVList[0].MyIncom);
    }
}