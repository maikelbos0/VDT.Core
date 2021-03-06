﻿using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace VDT.Core.DependencyInjection.Tests {
    public class TransientServiceAttributeTests : ServiceAttributeTests {
        [Fact]
        public void AddAttributeServices_Adds_Services() {
            services.AddAttributeServices(typeof(ServiceAttributeTests).Assembly);

            var serviceProvider = services.BuildServiceProvider();

            var service = serviceProvider.GetRequiredService<ITransientServiceTarget>();

            Assert.IsType<TransientServiceTarget>(service);
        }

        [Fact]
        public void AddAttributeServices_Always_Returns_New_Object() {
            services.AddAttributeServices(typeof(ServiceAttributeTests).Assembly);

            var serviceProvider = services.BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope()) {
                Assert.NotSame(scope.ServiceProvider.GetRequiredService<ITransientServiceTarget>(), scope.ServiceProvider.GetRequiredService<ITransientServiceTarget>());
            }
        }

        [Fact]
        public void AddAttributeServices_Adds_Services_With_Decorators() {
            services.AddAttributeServices(typeof(ServiceAttributeTests).Assembly, options => options.AddAttributeDecorators());

            var serviceProvider = services.BuildServiceProvider();

            var proxy = serviceProvider.GetRequiredService<ITransientServiceTarget>();

            Assert.Equal("Bar", proxy.GetValue());

            Assert.Equal(1, decorator.Calls);
        }

        [Fact]
        public void AddAttributeServices_With_Decorators_Always_Returns_New_Object() {
            services.AddAttributeServices(typeof(ServiceAttributeTests).Assembly, options => options.AddAttributeDecorators());

            var serviceProvider = services.BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope()) {
                Assert.NotSame(scope.ServiceProvider.GetRequiredService<ITransientServiceTarget>(), scope.ServiceProvider.GetRequiredService<ITransientServiceTarget>());
            }
        }
    }
}
