﻿using VDT.Core.DependencyInjection.Tests.Decorators.Targets;

namespace VDT.Core.DependencyInjection.Tests.AttributeServiceTargets {
    [ScopedService(typeof(ScopedServiceTarget))]
    public abstract class ScopedServiceTargetBase {
        protected readonly string value;

        protected ScopedServiceTargetBase(string value) {
            this.value = value;
        }

        [TestDecorator]
        public abstract string GetValue();
    }
}