namespace CleanApiSample.Shared.Abstractions.Common
{
    public abstract class CleanApiSampleException : Exception
    {
        public CleanApiSampleException(string message) : base(message) { }
    }
}
