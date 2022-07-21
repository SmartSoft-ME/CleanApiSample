using CleanApiSample.Domain.Exceptions.UserExceptions;

namespace CleanApiSample.Domain.EntityProperties.UserProperties
{
    public record Username
    {
        public string Value { get; }

        public Username(string value)
        {
            if (string.IsNullOrEmpty(value) ||
                value.Length < 3 || value.Length > 25)
                throw new InvalidUsernameException();

            Value = value;
        }

        public static implicit operator string(Username username) => username.Value;
        public static implicit operator Username(string value) => new(value);
    }
}
