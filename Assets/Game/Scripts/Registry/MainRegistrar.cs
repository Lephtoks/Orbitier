namespace Game.Scripts.Registry
{
    public class MainRegistrar
    {
        public readonly string Namespace;

        public MainRegistrar(string @namespace)
        {
            Namespace = @namespace;
        }

        public Registrar<T> RegistrarOf<T>(Registry<T> registry)
        {
            return new Registrar<T>(this, registry);
        }
    }

    public class Registrar<T>
    {
        private readonly MainRegistrar _main;
        private readonly Registry<T> _registry;

        internal Registrar(MainRegistrar mainRegistrar, Registry<T> registry)
        {
            _main = mainRegistrar;
            _registry = registry;
        }

        public T Register(string name, T value)
        {
            _registry.Register(_registry.KeyOf(Identifier.Of(_main.Namespace, name)), value);
            return value;
        }
    }
}