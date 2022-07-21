using CleanApiSample.Shared.Abstractions.Common;

namespace CleanApiSample.Domain.Exceptions.UserExceptions
{
    internal class InvalidEmailException : CleanApiSampleException
    {
        public InvalidEmailException() : base("This email is invalid.") { }
    }
}
