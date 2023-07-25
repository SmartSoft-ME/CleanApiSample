using CleanApiSample.Shared.Abstractions.Common;

namespace CleanApiSample.Infrastructure.Data.Exceptions
{
    public class NotFoundException : CleanApiSampleException
    {
        public NotFoundException(string typeName, int id) : base("No " + typeName + " with Id " + id + " was found.") { }
    }
}
