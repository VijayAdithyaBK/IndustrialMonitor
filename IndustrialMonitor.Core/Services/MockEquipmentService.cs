using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IndustrialMonitor.Core.Interfaces;
using IndustrialMonitor.Core.Models;

namespace IndustrialMonitor.Core.Services;

public class MockEquipmentService : IEquipmentService
{
    private readonly List<Equipment> _equipmentList;
    private readonly Random _random = new();
    private Timer? _timer;
    private bool _isMonitoring;

    public event EventHandler<Equipment>? EquipmentUpdated;

    public MockEquipmentService()
    {
        _equipmentList = GenerateMockData();
    }

    public Task<IEnumerable<Equipment>> GetAllEquipmentAsync()
    {
        return Task.FromResult<IEnumerable<Equipment>>(_equipmentList);
    }

    public Task<Equipment?> GetEquipmentByIdAsync(string id)
    {
        var equipment = _equipmentList.FirstOrDefault(e => e.Id == id);
        return Task.FromResult(equipment);
    }

    public void StartMonitoring()
    {
        if (_isMonitoring) return;
        _isMonitoring = true;
        // Update every 2 seconds
        _timer = new Timer(UpdateRandomEquipment, null, 1000, 2000); 
    }

    public void StopMonitoring()
    {
        _isMonitoring = false;
        _timer?.Dispose();
        _timer = null;
    }

    private void UpdateRandomEquipment(object? state)
    {
        if (!_equipmentList.Any()) return;

        // Pick a random equipment to update
        var index = _random.Next(_equipmentList.Count);
        var equipment = _equipmentList[index];

        // Simulate value changes
        equipment.Temperature = Math.Round(Math.Max(20, Math.Min(120, equipment.Temperature + (_random.NextDouble() * 10 - 5))), 1); // +/- 5 degrees, clamp 20-120
        equipment.Vibration = Math.Round(Math.Max(0, Math.Min(10, equipment.Vibration + (_random.NextDouble() * 2 - 1))), 2); // +/- 1 unit, clamp 0-10
        equipment.LastUpdated = DateTime.Now;

        // Simulate status changes based on thresholds
        if (equipment.Temperature > 100 || equipment.Vibration > 8)
        {
            equipment.Status = EquipmentStatus.Error;
        }
        else if (equipment.Temperature > 80 || equipment.Vibration > 5)
        {
            equipment.Status = EquipmentStatus.Warning;
        }
        else
        {
             // 5% chance to go to stopped or running if it was okay
             if (_random.NextDouble() > 0.95)
             {
                 equipment.Status = equipment.Status == EquipmentStatus.Stopped ? EquipmentStatus.Running : EquipmentStatus.Stopped;
             }
             else if (equipment.Status != EquipmentStatus.Stopped)
             {
                 equipment.Status = EquipmentStatus.Running;
             }
        }

        EquipmentUpdated?.Invoke(this, equipment);
    }

    private List<Equipment> GenerateMockData()
    {
        return new List<Equipment>
        {
            new() { Id = "M-101", Name = "CNC Milling Machine 1", Status = EquipmentStatus.Running, Temperature = 65.5, Vibration = 2.1, LastUpdated = DateTime.Now },
            new() { Id = "M-102", Name = "Hydraulic Press", Status = EquipmentStatus.Running, Temperature = 55.0, Vibration = 1.0, LastUpdated = DateTime.Now },
            new() { Id = "M-103", Name = "Robot Arm Assembly", Status = EquipmentStatus.Stopped, Temperature = 24.0, Vibration = 0.1, LastUpdated = DateTime.Now },
            new() { Id = "M-104", Name = "Conveyor Belt System", Status = EquipmentStatus.Warning, Temperature = 82.3, Vibration = 4.5, LastUpdated = DateTime.Now },
            new() { Id = "M-105", Name = "Injection Molder", Status = EquipmentStatus.Error, Temperature = 105.2, Vibration = 3.2, LastUpdated = DateTime.Now },
        };
    }
}
