using FourthPharos.Domain.CandelaObscuraCharacter;
using FourthPharos.Domain.CandelaObscuraCharacter.Features;
using FourthPharos.Domain.CandelaObscuraCharacter.Models;
using FourthPharos.Domain.CandelaObscuraCharacter.Operations;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.Tests.CandelaObscuraCharacter.Operations;

public class AddMarkOperationTest
{
    [Theory]
    [MemberData(nameof(MarkData))]
    public void AddBodyMark(int marks)
    {
        var character = CharacterFactory.CreateCharacter("Crowley Thornwood");

        for (var i = 0; i < marks; ++i)
        {
            character = character.AddMark<CharacterBodyMarksFeature>();
        }

        character.GetFeature<Character, CharacterBodyMarksFeature>().Marks.ShouldBe(marks % 4);
        character.GetFeature<Character, CharacterScarsFeature>().Scars.Length.ShouldBe(marks / 4);
        character.GetFeature<Character, CharacterScarsFeature>().Scars.ShouldAllBe(_ => _.Type == ScarType.Body);
    }

    [Theory]
    [MemberData(nameof(MarkData))]
    public void AddBrainMark(int marks)
    {
        var character = CharacterFactory.CreateCharacter("Crowley Thornwood");

        for (var i = 0; i < marks; ++i)
        {
            character = character.AddMark<CharacterBrainMarksFeature>();
        }

        character.GetFeature<Character, CharacterBrainMarksFeature>().Marks.ShouldBe(marks % 4);
        character.GetFeature<Character, CharacterScarsFeature>().Scars.Length.ShouldBe(marks / 4);
        character.GetFeature<Character, CharacterScarsFeature>().Scars.ShouldAllBe(_ => _.Type == ScarType.Brain);
    }

    [Theory]
    [MemberData(nameof(MarkData))]
    public void AddBleedMark(int marks)
    {
        var character = CharacterFactory.CreateCharacter("Crowley Thornwood");

        for (var i = 0; i < marks; ++i)
        {
            character = character.AddMark<CharacterBleedMarksFeature>();
        }

        character.GetFeature<Character, CharacterBleedMarksFeature>().Marks.ShouldBe(marks % 4);
        character.GetFeature<Character, CharacterScarsFeature>().Scars.Length.ShouldBe(marks / 4);
        character.GetFeature<Character, CharacterScarsFeature>().Scars.ShouldAllBe(_ => _.Type == ScarType.Bleed);
    }

    public static IEnumerable<object[]> MarkData => Enumerable.Range(1, 10).Select(_ => new object[] { _ });
}
