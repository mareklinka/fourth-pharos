using FourthPharos.Domain.CandelaObscuraCharacter;
using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.CandelaObscuraCharacter.Operations;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.Tests.CandelaObscuraCharacter.Operations;

public class SetScarPointTransferOperationTest
{
    [Theory]
    [InlineData(ScarType.Body)]
    [InlineData(ScarType.Brain)]
    [InlineData(ScarType.Bleed)]
    public void SetScarPointTransfer(ScarType type)
    {
        var character = CharacterFactory.CreateCharacter("Crowley Thornwood");
        var scar = character
            .SetActionRating<CharacterNerveFeature>(CharacterNerveFeature.MoveActionCode, 2)
            .AddScar(type)
            .GetFeature<Character, CharacterScarsFeature>()
            .Scars
            .Single();

        scar = character
            .SetScarPointTransfer(scar.Id, CharacterNerveFeature.MoveActionCode, CharacterCunningFeature.HideActionCode)
            .GetFeature<Character, CharacterScarsFeature>()
            .Scars
            .ShouldHaveSingleItem();

        scar.SourcePointActionCode.ShouldBe(CharacterNerveFeature.MoveActionCode);
        scar.TargetPointActionCode.ShouldBe(CharacterCunningFeature.HideActionCode);
    }

    [Theory]
    [InlineData(ScarType.Body)]
    [InlineData(ScarType.Brain)]
    [InlineData(ScarType.Bleed)]
    public void SetScarPointTransferInvalidSourceAction(ScarType type)
    {
        var character = CharacterFactory.CreateCharacter("Crowley Thornwood");
        var scar = character
            .SetActionRating<CharacterNerveFeature>(CharacterNerveFeature.MoveActionCode, 2)
            .AddScar(type)
            .GetFeature<Character, CharacterScarsFeature>()
            .Scars
            .Single();

        Should.Throw<DomainActionException>(() => character
            .SetScarPointTransfer(scar.Id, "realize", CharacterCunningFeature.HideActionCode))
            .Code
            .ShouldBe(nameof(DomainExceptions.CharacterExceptions.InvalidAction));
    }

    [Theory]
    [InlineData(ScarType.Body)]
    [InlineData(ScarType.Brain)]
    [InlineData(ScarType.Bleed)]
    public void SetScarPointTransferInvalidTargetAction(ScarType type)
    {
        var character = CharacterFactory.CreateCharacter("Crowley Thornwood");
        var scar = character
            .SetActionRating<CharacterNerveFeature>(CharacterNerveFeature.MoveActionCode, 2)
            .AddScar(type)
            .GetFeature<Character, CharacterScarsFeature>()
            .Scars
            .Single();

        Should.Throw<DomainActionException>(() => character
            .SetScarPointTransfer(scar.Id, CharacterNerveFeature.MoveActionCode, "reveal"))
            .Code
            .ShouldBe(nameof(DomainExceptions.CharacterExceptions.InvalidAction));
    }

    [Theory]
    [InlineData(ScarType.Body)]
    [InlineData(ScarType.Brain)]
    [InlineData(ScarType.Bleed)]
    public void SetScarPointTransferNotEnoughSourceActionRating(ScarType type)
    {
        var character = CharacterFactory.CreateCharacter("Crowley Thornwood");
        var scar = character
            .AddScar(type)
            .GetFeature<Character, CharacterScarsFeature>()
            .Scars
            .Single();

        Should.Throw<DomainActionException>(() => character
            .SetScarPointTransfer(scar.Id, CharacterNerveFeature.MoveActionCode, CharacterCunningFeature.HideActionCode))
            .Code
            .ShouldBe(nameof(DomainExceptions.CharacterExceptions.InsufficientActionRating));
    }

    [Theory]
    [InlineData(ScarType.Body)]
    [InlineData(ScarType.Brain)]
    [InlineData(ScarType.Bleed)]
    public void SetScarPointTransferTargetActionFullRating(ScarType type)
    {
        var character = CharacterFactory.CreateCharacter("Crowley Thornwood");
        var scar = character
            .SetActionRating<CharacterNerveFeature>(CharacterNerveFeature.MoveActionCode, 2)
            .SetActionRating<CharacterCunningFeature>(CharacterCunningFeature.HideActionCode, 3)
            .AddScar(type)
            .GetFeature<Character, CharacterScarsFeature>()
            .Scars
            .Single();

        Should.Throw<DomainActionException>(() => character
            .SetScarPointTransfer(scar.Id, CharacterNerveFeature.MoveActionCode, CharacterCunningFeature.HideActionCode))
            .Code
            .ShouldBe(nameof(DomainExceptions.CharacterExceptions.ActionRatingFull));
    }

    [Theory]
    [InlineData(ScarType.Body)]
    [InlineData(ScarType.Brain)]
    [InlineData(ScarType.Bleed)]
    public void SetScarPointTransferInvalidScar(ScarType type)
    {
        var character = CharacterFactory.CreateCharacter("Crowley Thornwood");
        character
            .SetActionRating<CharacterNerveFeature>(CharacterNerveFeature.MoveActionCode, 2)
            .AddScar(type);

        Should.Throw<DomainActionException>(() => character
            .SetScarPointTransfer(Guid.Empty, CharacterNerveFeature.MoveActionCode, CharacterCunningFeature.HideActionCode))
            .Code
            .ShouldBe(nameof(DomainExceptions.CharacterExceptions.InvalidScar));
    }

    [Theory]
    [InlineData(ScarType.Body)]
    [InlineData(ScarType.Brain)]
    [InlineData(ScarType.Bleed)]
    public void SetScarPointTransferSameSourceAndTarget(ScarType type)
    {
        var character = CharacterFactory.CreateCharacter("Crowley Thornwood");
        var scar = character
            .SetActionRating<CharacterNerveFeature>(CharacterNerveFeature.MoveActionCode, 2)
            .AddScar(type)
            .GetFeature<Character, CharacterScarsFeature>()
            .Scars
            .Single();

        Should.Throw<DomainActionException>(() => character
            .SetScarPointTransfer(scar.Id, CharacterNerveFeature.MoveActionCode, CharacterNerveFeature.MoveActionCode))
            .Code
            .ShouldBe(nameof(DomainExceptions.CharacterExceptions.ScarSourceActionSameAsTargetAction));
    }
}