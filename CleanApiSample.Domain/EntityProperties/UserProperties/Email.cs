using CleanApiSample.Domain.Exceptions.UserExceptions;

namespace CleanApiSample.Domain.EntityProperties.UserProperties
{
    public record Email(string Name, string Domain)
    {
        public static Email Create(string value = default)
        {
            if (string.IsNullOrEmpty(value) ||
                !value.Contains('@'))
                throw new InvalidEmailException();

            var splitEmail = value.Split('@');
            return new(splitEmail.First(), splitEmail.Last());
        }

        public override string ToString()
            => $"{Name}@{Domain}";

        public static implicit operator string(Email email) => email.ToString();
        public static implicit operator Email(string email) => Create(email);
    }
}
