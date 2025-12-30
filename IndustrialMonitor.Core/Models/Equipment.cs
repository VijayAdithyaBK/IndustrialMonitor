using System;

namespace IndustrialMonitor.Core.Models;

public class Equipment
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public EquipmentStatus Status { get; set; }
    public double Temperature { get; set; }
    public double Vibration { get; set; }
    public DateTime LastUpdated { get; set; }
}
