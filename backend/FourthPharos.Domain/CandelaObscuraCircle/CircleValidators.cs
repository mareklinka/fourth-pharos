namespace FourthPharos.Domain.CandelaObscuraCircle;

public static class CircleValidators
{
    public const int NameMaxLength = 100;

    public const int LocationMaxLength = 100;

    public static void Name(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw DomainExceptions.CircleExceptions.CircleNameEmpty();
        }

        if (name.Length > NameMaxLength)
        {
            throw DomainExceptions.CircleExceptions.CircleNameTooLong(NameMaxLength);
        }
    }

    public static void Location(string? location)
    {
        if (location?.Length > NameMaxLength)
        {
            throw DomainExceptions.CircleExceptions.CircleLocationTooLong(LocationMaxLength);
        }
    }
}
