using System;

namespace Game.Scripts.Registry
{
    public struct Identifier : IEquatable<Identifier>
    {
        private readonly string _path;
        private readonly string _namespace;

        private Identifier(string @namespace, string path)
        {
            _namespace = @namespace;
            _path = path;
        }
        public static Identifier Of(string @namespace, string path)
        {
            return new Identifier(@namespace, path);
        }

        public bool Equals(Identifier other)
        {
            return _path == other._path && _namespace == other._namespace;
        }

        public override bool Equals(object obj)
        {
            return obj is Identifier other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_path, _namespace);
        }
    }
}