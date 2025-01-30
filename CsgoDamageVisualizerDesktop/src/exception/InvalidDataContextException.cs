using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsgoDamageVisualizerDesktop.src.exception
{
    /// <summary>
    /// When the data context for a view has an unexpected type, or is otherwise not properly set
    /// </summary>
    internal class InvalidDataContextException: Exception
    {

        internal InvalidDataContextException(string message) : base(message) {}

        /// <summary>
        /// Creates a new InvalidDataContextException with a predetermined text using the provided type
        /// </summary>
        /// <param name="expectedViewModelType"></param>
        internal InvalidDataContextException(Type expectedViewModelType) : base(
            $"Expected data context must be of type {expectedViewModelType.Name}") {}
    }
}
