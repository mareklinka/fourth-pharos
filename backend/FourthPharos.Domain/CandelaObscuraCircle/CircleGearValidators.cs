namespace FourthPharos.Domain.CandelaObscuraCircle;

public static class CircleGearValidators
{
    public const int NameMaxLength = 100;

    public static void Name(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw DomainExceptions.CircleGearExceptions.GearNameEmpty();
        }

        if (name.Length > NameMaxLength)
        {
            throw DomainExceptions.CircleGearExceptions.GearNameTooLong(NameMaxLength);
        }
    }
}
