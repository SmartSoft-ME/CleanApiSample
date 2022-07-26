using CleanApiSample.Domain.Exceptions.UserExceptions;

namespace CleanApiSample.Domain.EntityProperties.UserProperties
{
    public record Username(string Value)
    {
        public static Username Create(string value)
        {
            if (string.IsNullOrEmpty(value) ||
                value.Length < 3 || value.Length > 25)
                throw new InvalidUsernameException();

            return new(value);
        }

        public override string ToString() => $"{Value}";

        public static implicit operator string(Username username) => username.Value;
        public static implicit operator Username(string value) => new(value);
    }
}
