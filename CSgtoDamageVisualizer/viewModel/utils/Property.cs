using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CsgoDamageVisualizerDesktop.viewModel.utils;

public class Property<T> : INotifyPropertyChanged
{
    private T _value;

    public T Value
    {
        get => _value;
        set { _value = value; OnPropertyChanged(); }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    internal virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}