namespace FourthFaros.Domain.CandelaObscuraCharacter;

public static class CharacterValidators
{
    public const int NameMaxLength = 100;

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
}
