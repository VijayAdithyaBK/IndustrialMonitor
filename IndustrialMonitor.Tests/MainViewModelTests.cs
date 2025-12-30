using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IndustrialMonitor.App.ViewModels;
using IndustrialMonitor.Core.Interfaces;
using IndustrialMonitor.Core.Models;
using Moq;
using Xunit;

namespace IndustrialMonitor.Tests;

public class MainViewModelTests
{
    private readonly Mock<IEquipmentService> _mockService;

    public MainViewModelTests()
    {
        _mockService = new Mock<IEquipmentService>();
    }

    [Fact]
    public async Task InitializeAsync_PopulatesEquipmentList()
    {
        // Arrange
        var mockData = new List<Equipment>
        {
            new() { Id = "1", Name = "Test 1" },
            new() { Id = "2", Name = "Test 2" }
        };

        _mockService.Setup(s => s.GetAllEquipmentAsync())
            .ReturnsAsync(mockData);

        // Act
        // Pass a synchronous invoker for testing
        var vm = new MainViewModel(_mockService.Object, action => action());
        
        await vm.Initialization;

        // Assert
        Assert.NotNull(vm.EquipmentList);
        Assert.Equal(2, vm.EquipmentList.Count);
        Assert.Equal("Test 1", vm.EquipmentList[0].Name);
    }
}
