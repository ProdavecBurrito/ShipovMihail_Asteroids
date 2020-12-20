using System;
using System.Collections.Generic;

namespace Shipov_Asteroids
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, object> _services = new Dictionary<Type, object>();
    }
}
