using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCharacter.Operations;

public static class UpdateBasicInfoOperations
{
    public static Character UpdateBasicInfo(this Character character, BasicInfoModel basicInfo)
    {
        var feature = character.GetFeature<Character, CharacterBasicInfoFeature>();

        CharacterValidators.Name(basicInfo.Name);
        CharacterValidators.BasicInfo(basicInfo.Pronouns);
        CharacterValidators.BasicInfo(basicInfo.Style);
        CharacterValidators.BasicInfo(basicInfo.Question);
        CharacterValidators.BasicInfo(basicInfo.Catalyst);

        return character.UpdateFeature(feature with
        {
            Name = basicInfo.Name,
            Pronouns = basicInfo.Pronouns,
            Style = basicInfo.Style,
            Question = basicInfo.Question,
            Catalyst = basicInfo.Catalyst
        });
    }
}
