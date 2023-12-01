using AutoMapper;
using BLL.DTO;
using BLL.Services;
using DAL.Models;
using DAL.Repositories.UnitOfWork;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AccountingsOfAppleTests.BLLTests;

[TestClass]
public class AppleVarietyControlServiceTest
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly AppleVarietyControlService _appleVarietyControlService;

    public AppleVarietyControlServiceTest()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _mapperMock = new Mock<IMapper>();
        _appleVarietyControlService = new AppleVarietyControlService(_unitOfWorkMock.Object, _mapperMock.Object);
    }

    [TestMethod]
    public async Task GetAllAsync_ReturnsListOfAppleVariety()
    {
        List<AppleVariety> list = new List<AppleVariety> {
            new AppleVariety { Id = Guid.NewGuid(), Name = "Golden" },
            new AppleVariety { Id = Guid.NewGuid(), Name = "Gala" }
        };
        _unitOfWorkMock.Setup(av => av.AppleVarieties.GetAllAsync()).ReturnsAsync(list);

        List<AppleVarietyDTO> listDTO = new List<AppleVarietyDTO>
        {
            new AppleVarietyDTO { Id = list[0].Id, Name = "Golden" },
            new AppleVarietyDTO { Id = list[1].Id, Name = "Gala" }
        };
        _mapperMock.Setup(m => m.Map<IEnumerable<AppleVarietyDTO>>(list)).Returns(listDTO);

        var result = await _appleVarietyControlService.GetAllAsync();

        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task GetByIdAsync_ReturnsListOfAppleVariety()
    {
        var id = Guid.NewGuid();
        var appleVariety = new AppleVariety { Id = id, Name = "Some name" };
        _unitOfWorkMock.Setup(av => av.AppleVarieties.GetByIdAsync(id)).ReturnsAsync(appleVariety);
        var appleVarietyDTO = new AppleVarietyDTO { Id = appleVariety.Id, Name = appleVariety.Name };
        _mapperMock.Setup(m => m.Map<AppleVarietyDTO>(appleVariety)).Returns(appleVarietyDTO);

        var result = await _appleVarietyControlService.GetByIdAsync(id);

        Assert.ReferenceEquals(result, appleVarietyDTO);
    }

    [DataTestMethod]
    [DataRow(0)]
    [DataRow(1)]
    public async Task CreateAsync_RetunsAppleVarietyDTO(int complete)
    {
        var appleVarietyDTO = new AppleVarietyDTO { Id = Guid.NewGuid(), Name = "Some name" };
        var appleVariety = new AppleVariety { Id = appleVarietyDTO.Id, Name = appleVarietyDTO.Name };
        _unitOfWorkMock.Setup(av => av.AppleVarieties.AddAsync(appleVariety));
        _mapperMock.Setup(m => m.Map<AppleVariety>(appleVarietyDTO)).Returns(appleVariety);
        _unitOfWorkMock.Setup(u => u.Complete()).Returns(complete);

        var result = await _appleVarietyControlService.CreateAsync(appleVarietyDTO);
        if(complete == 0)
        {
            Assert.IsNull(result);
        }
        else
        {
            Assert.IsNotNull(result);
        }
        _unitOfWorkMock.Verify(u => u.Complete(),Times.Once);
    }
}
