using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using CsgoDamageVisualizerCore.loader;
using CsgoDamageVisualizerCore.loader.model;
using CsgoDamageVisualizerCore.model;
using ReactiveUI;

namespace CsgoDamageVisualizerDesktop.viewModel;

public class MainWindowViewModelReactive : ReactiveObject, IActivatableViewModel
{
    private ObservableAsPropertyHelper<IReadOnlyDictionary<string, Weapon>> weapons;

    /// <summary>
    /// Holds the loaded, raw weapon info (without analysis). The key of each entry is the __name of the value of the entry.
    /// </summary>
    public IReadOnlyDictionary<string, Weapon> Weapons => weapons.Value;

    public IReadOnlyDictionary<string, string> DisplayableWeaponsProperty =>
        weapons.Value.ToDictionary(dict => dict.Key, dict => dict.Value.Name);

    private bool isLoadingWeapons;

    /// <summary>
    /// Determines if we are currently loading new entries for the WeaponsProperty or not
    /// </summary>
    public bool IsLoadingWeapons
    {
        get => isLoadingWeapons;
        set => this.RaiseAndSetIfChanged(ref isLoadingWeapons, value);
    }

    public ReactiveCommand<Unit, IReadOnlyDictionary<string, Weapon>> LoadWeaponsCommand { get; }
    
    public ViewModelActivator Activator { get; }

    public MainWindowViewModelReactive()
    {
        Activator = new ViewModelActivator();
        
        LoadWeaponsCommand = ReactiveCommand.CreateFromTask(LoadWeaponsAsync);
        
        this.WhenActivated(disposables =>
        {
            // Boilerplate: Do things upon activation/deactivation of view model
            this.HandleActivation();
            Disposable
                .Create(this.HandleDeactivation)
                .DisposeWith(disposables);
            
            // Application-specific code:
            LoadWeaponsCommand
                .Execute()
                .ToProperty(this, vm => vm.Weapons, out weapons);
        });
        
    }

    private async Task<IReadOnlyDictionary<string, Weapon>> LoadWeaponsAsync()
    {
        IsLoadingWeapons = true;

        IReadOnlyDictionary<string, CfgWeapon> cfgWeapons = await Task<IReadOnlyDictionary<string, CfgWeapon>>.Factory.StartNew(
            _ =>
            {
                CfgParser cfgParser = new CfgParser();
                return cfgParser.ParseCfgFile();
            }, Unit.Default);

        // CfgParser cfgParser = new CfgParser();
        // IReadOnlyDictionary<string, CfgWeapon> cfgWeapons = cfgParser.ParseCfgFile();

        Debug.WriteLine($"  Loaded {cfgWeapons.Count} Weapons");

        Dictionary<string, Weapon> weapons = new Dictionary<string, Weapon>();

        foreach (KeyValuePair<string, CfgWeapon> entry in cfgWeapons)
        {
            Weapon weapon;
            string item_class = CfgWeapon.GetStringValue(entry.Value, "item_class");
            if (entry.Key.Equals(item_class + "_prefab")) //i.e. the gun is based on a different gun
            {
                weapon = new Weapon(entry.Value);
            }
            else
            {
                CfgWeapon baseCfgWeapon = cfgWeapons[item_class + "_prefab"];
                weapon = new Weapon(entry.Value, baseCfgWeapon);
            }

            weapons.Add(weapon.Name, weapon);
        }
        
        IsLoadingWeapons = false;

        return weapons;
    }

    private void HandleActivation()
    {
        
    }

    private void HandleDeactivation()
    {
        
    }
    
}