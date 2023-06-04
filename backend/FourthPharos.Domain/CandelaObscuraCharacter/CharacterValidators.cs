namespace FourthPharos.Domain.CandelaObscuraCharacter;

public static class CharacterValidators
{
    public const int BasicInfoMaxLength = 100;

    public const int ScarDescriptionMaxLength = 1000;

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

    public static void MaximumDrive(int drive)
    {
        if (drive is < 0 or > 9)
        {
            throw DomainExceptions.CharacterExceptions.MaximumDriveOutOfRange();
        }
    }

    public static void ActionRating(int drive)
    {
        if (drive is < 0 or > 3)
        {
            throw DomainExceptions.CharacterExceptions.ActionRankOutOfRange();
        }
    }

    public static void ScarDescription(string? description)
    {
        if (description is null)
        {
            return;
        }

        if (description.Length > ScarDescriptionMaxLength)
        {
            throw DomainExceptions.CharacterExceptions.ScarDescriptionTooLong(BasicInfoMaxLength);
        }
    }
}
