﻿using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Reflection;

namespace VDT.Core.DependencyInjection {
    /// <summary>
    /// Options for registering services to a <see cref="IServiceCollection"/>
    /// </summary>
    public class ServiceRegistrationOptions {
        /// <summary>
        /// Assemblies to scan for services
        /// </summary>
        public List<Assembly> Assemblies { get; set; } = new List<Assembly>();

        /// <summary>
        /// Methods that return service types for a given implementation type; service types that appear in any method will be registered
        /// </summary>
        public List<ServiceTypeFinder> ServiceTypeFinders { get; set; } = new List<ServiceTypeFinder>();

        /// <summary>
        /// Methods that returns a service lifetime for a given service and implementation type to be registered
        /// </summary>
        public ServiceLifetimeProvider? ServiceLifetimeProvider { get; set; }

        /// <summary>
        /// Service lifetime to use if no <see cref="ServiceLifetimeProvider"/> is provided or the <see cref="ServiceLifetimeProvider"/> did not find a suitable lifetime
        /// </summary>
        public ServiceLifetime DefaultServiceLifetime { get; set; } = ServiceLifetime.Scoped;

        /// <summary>
        /// Method that register the found services to an <see cref="IServiceCollection"/> with the provided lifetime; if no method is provided the default implementation will create a <see cref="ServiceDescriptor"/>
        /// </summary>
        public ServiceRegistrar? ServiceRegistrar { get; set; }
    }
}