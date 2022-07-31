using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CsgoDamageVisualizerCore.loader
{
    /// <summary>
    /// A config class
    /// </summary>
    public interface ICsgoDamageVisualizerConfig
    {

        private static ICsgoDamageVisualizerConfig? instance;
        /// <summary>
        /// Gets the singleton instance, if one exists. Otherwise attempts to create one. <b>Note:</b> SetInstanceType(Type) needs to be called beforehand!
        /// </summary>
        /// <returns>The singleton instance</returns>
        /// <exception cref="NullReferenceException">If no instance type has been set.</exception>
        public static ICsgoDamageVisualizerConfig Instance
        {
            get {
                if (instance != null)
                {
                    return instance;
                }

                if (configInstanceType == null)
                {
                    throw new NullReferenceException($"The config instance type has not been set yet. Set it using {nameof(ConfigInstanceType)}(Type value), where value is a subclass of {nameof(ICsgoDamageVisualizerConfig)}");
                }

                ConstructorInfo? ctor = configInstanceType.GetConstructor(new Type[0]);
                instance = (ICsgoDamageVisualizerConfig)(ctor?.Invoke(new object[0]) ?? throw new NullReferenceException($"No default constructor exists for type {configInstanceType.Name}"));
                return instance;
            }
        }
        private static Type? configInstanceType;
        public static Type? ConfigInstanceType
        {
            get { return configInstanceType; }
            
            /// <summary>
            /// Sets the type of the config class that needs to be instantiated. Must be set before the first "GetInstance" call.
            /// </summary>
            /// <param name="t">The implemented config class. Must be a sublcass of IcsgoDamageVisualizerConfig.</param>
            /// <exception cref="ArgumentException">IF the given type is not a class implementing ICsgoDamageVisualizerConfig</exception>
            set
            {
                if (!value.IsAssignableTo(typeof(ICsgoDamageVisualizerConfig)))
                {
                    throw new ArgumentException($"The given type {value.Name} is not a {nameof(ICsgoDamageVisualizerConfig)}");
                }
                configInstanceType = value;
                Console.WriteLine($"The config instance type has been updated to {value.Name}");
            }
        }


        /// <summary>
        /// Sets the path to the CSGO installation directory. This is the path with the csgo.exe in it.
        /// </summary>
        /// <returns></returns>
        public abstract Uri GetCsgoInstallDir();
    }
}
