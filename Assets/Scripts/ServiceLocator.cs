using System;
using System.Collections.Generic;

namespace Shipov_Asteroids
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, object> _services = new Dictionary<Type, object>();

        public static void AddService<T>(T pull)
        {
            var type = typeof(T);
            if (!_services.ContainsKey(type))
            {
                _services[type] = pull;
            }
        }

        public static T GetPull<T>()
        {
            var type = typeof(T);
            if (_services.ContainsKey(type))
            {
                return (T)_services[type];
            }

            return default;
        }
    }
}
