#nullable enable
using System;
using System.Collections.Generic;

namespace Game.Scripts.Registry
{
    public struct RegistryKey<T> : IEquatable<RegistryKey<T>> where T : IRegistry<object>
    {
        private readonly T _registry;
        private readonly Identifier _identifier;

        public RegistryKey(T registry, Identifier identifier)
        {
            _registry = registry;
            _identifier = identifier;
        }

        public Identifier GetIdentifier()
        {
            return _identifier;
        }

        public T GetRegistry()
        {
            return _registry;
        }

        public bool Equals(RegistryKey<T> other)
        {
            return EqualityComparer<T>.Default.Equals(_registry, other._registry) && _identifier.Equals(other._identifier);
        }

        public override bool Equals(object? obj)
        {
            return obj is RegistryKey<T> other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_registry, _identifier);
        }
    }
}