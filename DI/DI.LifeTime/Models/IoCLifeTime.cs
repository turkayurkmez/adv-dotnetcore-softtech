namespace DI.LifeTime.Models
{
    public interface IGuidGenerator
    {
        Guid Guid { get; }
    }

    public interface ISingletonGuid : IGuidGenerator { }
    public interface IScopedGuid : IGuidGenerator { }
    public interface ITransientGuid : IGuidGenerator { }

    public class SingletonGuid : ISingletonGuid
    {
        public SingletonGuid()
        {
            this.Guid = Guid.NewGuid();
        }
        public Guid Guid { get; }

    }

    public class TransientGuid : ITransientGuid
    {
        public TransientGuid()
        {
            this.Guid = Guid.NewGuid();
        }
        public Guid Guid { get; }
    }

    public class ScopedGuid : IScopedGuid
    {
        public ScopedGuid()
        {
            this.Guid = Guid.NewGuid();
        }
        public Guid Guid { get; }
    }

    public class GuidService
    {
        public ISingletonGuid Singleton { get; set; }
        public ITransientGuid Transient { get; set; }
        public IScopedGuid ScopedGuid { get; set; }

        public GuidService(ISingletonGuid singleton, ITransientGuid transient, IScopedGuid scopedGuid)
        {
            Singleton = singleton;
            Transient = transient;
            ScopedGuid = scopedGuid;
        }
    }
}
