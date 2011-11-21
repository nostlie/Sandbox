using System;

namespace PrismNavigationTest.Infrastructure
{
    public class InstanceToRegister
    {
        public readonly Type Interface;
        public readonly Type Implementation;
        public readonly bool IsSingleton;

        public InstanceToRegister(Type interFace, Type implementation)
            : this(interFace, implementation, false)
        {
        }

        public InstanceToRegister(Type interFace, Type implementation, bool isSingleton)
        {
            Interface = interFace;
            Implementation = implementation;
            IsSingleton = isSingleton;
        }
    }
}
