using System.Collections.Generic;
using System.Linq;

namespace Game.Scripts.Registry
{
    public class Registry<T> : IRegistry<object>
    {
        private readonly Dictionary<RegistryKey<Registry<T>>, T> _store = new(); 
        public RegistryKey<Registry<T>> KeyOf(Identifier of)
        {
            return new RegistryKey<Registry<T>>(this, of);
        }

        public IEnumerable<RegistryKey<Registry<T>>> GetKeys()
        {
            return _store.Keys;
        }

        public RegistryKey<Registry<T>>? GetKey(Identifier which)
        {
            foreach (var key in _store.Keys.Where(key => key.GetIdentifier().Equals(which)))
            {
                return key;
            }

            return null;
        }

        public RegistryKey<Registry<T>> GetKey(Identifier which, RegistryKey<Registry<T>> or)
        {
            return GetKey(which) ?? or;
        }

        public void Register(RegistryKey<Registry<T>> key, T value)
        {
            _store.Add(key, value);
        }
    }
}