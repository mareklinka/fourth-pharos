namespace FourthPharos.Domain.CandelaObscuraCharacter;

public static class CharacterValidators
{
    public const int BasicInfoMaxLength = 100;

    public static void Name(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw DomainExceptions.CharacterExceptions.CharacterNameEmpty();
        }

        if (name.Length > BasicInfoMaxLength)
        {
            throw DomainExceptions.CharacterExceptions.CharacterNameTooLong(BasicInfoMaxLength);
        }
    }

    public static void BasicInfo(string? basicInfo)
    {
        if (basicInfo is null)
        {
            return;
        }

        if (basicInfo.Length > BasicInfoMaxLength)
        {
            throw DomainExceptions.CharacterExceptions.BasicInfoTooLong(BasicInfoMaxLength);
        }
    }
}
