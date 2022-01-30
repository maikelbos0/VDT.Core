﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace VDT.Core.DependencyInjection {
    /// <summary>
    /// Commonly used implementations of the <see cref="ServiceTypeFinder"/> delegate
    /// </summary>
    public static class DefaultServiceTypeFinders {
        /// <summary>
        /// Returns the interface for implementation types if only a single interface is found; otherwise returns no service types
        /// </summary>
        /// <param name="implementationType">The implementation type to find service types for</param>
        /// <returns>A single interface type if only one is available</returns>
        public static IEnumerable<Type> SingleInterface(Type implementationType) {
            var serviceTypes = implementationType.GetInterfaces();

            if (serviceTypes.Length == 1) {
                return serviceTypes;
            }

            return Enumerable.Empty<Type>();
        }
    }
}
