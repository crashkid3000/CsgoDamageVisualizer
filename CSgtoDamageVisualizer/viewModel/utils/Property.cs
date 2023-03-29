using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CsgoDamageVisualizerDesktop.viewModel.utils;

/// <summary>
/// A boilerplate implementation for observable properties. Create instances of this class in your constructor and set the <c>Value</c> property in your logic to raise
/// PropertyChangedEvents.
/// </summary>
/// <typeparam name="T">The data type of the property</typeparam>
public class Property<T> : INotifyPropertyChanged
{
    private T _value;

    /// <summary>
    /// The observable value of this property. Raises PropertyChanged events when a value is set; no events are explicitly raised when getting.
    /// </summary>
    public T Value
    {
        get => _value;
        set { _value = value; OnPropertyChanged(); }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Create a new Property using the given initial value
    /// </summary>
    /// <param name="initialValue">The initial value</param>
    /// <exception cref="ArgumentNullException">Thrown if the initial value is <c>null</c></exception>
    public Property(T? initialValue)
    {
        if(initialValue == null) throw new ArgumentNullException(nameof(initialValue)); //due to usage of default in param-less ctor

        this.Value = initialValue;
    }

    /// <summary>
    /// Create a new Property using the default value for the given data type as the in initial value
    /// <exception cref="ArgumentNullException">Thrown if the initial value is <c>null</c></exception>
    /// </summary>
    public Property() : this(default) {}

    internal virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}