namespace CleanApiSample.Shared.Abstractions.Domain
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; protected set; }
    }
}
