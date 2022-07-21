using CleanApiSample.Shared.Abstractions.Common;

namespace CleanApiSample.Domain.Exceptions.UserExceptions
{
    internal class InvalidUsernameException : CleanApiSampleException
    {
        public InvalidUsernameException() : base("This username is invalid. Try another one.") { }
    }
}
