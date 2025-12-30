using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IndustrialMonitor.Core.Interfaces;
using IndustrialMonitor.Core.Models;

namespace IndustrialMonitor.App.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly IEquipmentService _equipmentService;

    [ObservableProperty]
    private ObservableCollection<Equipment> _equipmentList = new();

    [ObservableProperty]
    private Equipment? _selectedEquipment;

    public Task Initialization { get; private set; }
    private readonly Action<Action> _uiInvoker;

    public MainViewModel(IEquipmentService equipmentService, Action<Action>? uiInvoker = null)
    {
        _equipmentService = equipmentService;
        _uiInvoker = uiInvoker ?? ((action) => 
        {
            if (Application.Current?.Dispatcher != null)
                Application.Current.Dispatcher.Invoke(action);
            else
                action();
        });

        _equipmentService.EquipmentUpdated += OnEquipmentUpdated;
        
        // Initialize async
        Initialization = InitializeAsync();
    }

    private async Task InitializeAsync()
    {
        var items = await _equipmentService.GetAllEquipmentAsync();
        
        _uiInvoker(() =>
        {
            EquipmentList = new ObservableCollection<Equipment>(items);
        });

        // Start real-time monitoring
        _equipmentService.StartMonitoring();
    }

    private void OnEquipmentUpdated(object? sender, Equipment updatedEquipment)
    {
        _uiInvoker(() =>
        {
            var existing = EquipmentList.FirstOrDefault(e => e.Id == updatedEquipment.Id);
            if (existing != null)
            {
                var index = EquipmentList.IndexOf(existing);
                if (index != -1)
                {
                   EquipmentList[index] = updatedEquipment; 
                }
            }
        });
    }
}
