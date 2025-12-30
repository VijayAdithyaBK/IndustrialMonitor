using System.Collections.Generic;
using System.Threading.Tasks;
using IndustrialMonitor.Core.Models;

namespace IndustrialMonitor.Core.Interfaces;

public interface IEquipmentService
{
    event EventHandler<Equipment> EquipmentUpdated;
    Task<IEnumerable<Equipment>> GetAllEquipmentAsync();
    Task<Equipment?> GetEquipmentByIdAsync(string id);
    void StartMonitoring();
    void StopMonitoring();
}
