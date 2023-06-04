using FourthPharos.Domain.CandelaObscuraCharacter;
using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.CandelaObscuraCharacter.Operations;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.Tests.CandelaObscuraCharacter.Operations;

public class RemoveMarkOperationTest
{
    [Fact]
    public void RemoveBodyMark() =>
        CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .AddMark<CharacterBodyMarksFeature>()
            .RemoveMark<CharacterBodyMarksFeature>()
            .GetFeature<Character, CharacterBodyMarksFeature>()
            .Marks
            .ShouldBe(0);

    [Fact]
    public void RemoveBodyMarkThrowWithNoMarks() =>
        Should.Throw<DomainActionException>(() => CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .RemoveMark<CharacterBodyMarksFeature>()
            .GetFeature<Character, CharacterBodyMarksFeature>()
            .Marks
            .ShouldBe(0))
        .Code.ShouldBe(nameof(DomainExceptions.CharacterExceptions.InsufficientMarks));

    [Fact]
    public void RemoveBrainMark() =>
        CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .AddMark<CharacterBrainMarksFeature>()
            .RemoveMark<CharacterBrainMarksFeature>()
            .GetFeature<Character, CharacterBrainMarksFeature>()
            .Marks
            .ShouldBe(0);

    [Fact]
    public void RemoveBrainMarkThrowWithNoMarks() =>
        Should.Throw<DomainActionException>(() => CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .RemoveMark<CharacterBrainMarksFeature>()
            .GetFeature<Character, CharacterBrainMarksFeature>()
            .Marks
            .ShouldBe(0))
        .Code.ShouldBe(nameof(DomainExceptions.CharacterExceptions.InsufficientMarks));

    [Fact]
    public void RemoveBleedMark() =>
        CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .AddMark<CharacterBleedMarksFeature>()
            .RemoveMark<CharacterBleedMarksFeature>()
            .GetFeature<Character, CharacterBleedMarksFeature>()
            .Marks
            .ShouldBe(0);

    [Fact]
    public void RemoveBleedMarkThrowWithNoMarks() =>
        Should.Throw<DomainActionException>(() => CharacterFactory
            .CreateCharacter("Crowley Thornwood")
            .RemoveMark<CharacterBleedMarksFeature>()
            .GetFeature<Character, CharacterBleedMarksFeature>()
            .Marks
            .ShouldBe(0))
        .Code.ShouldBe(nameof(DomainExceptions.CharacterExceptions.InsufficientMarks));
}