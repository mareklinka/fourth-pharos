using FourthPharos.Domain.CandelaObscuraCircle.Features;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.CandelaObscuraCircle.Operations;
using FourthPharos.Domain.Features;
using FourthPharos.Host.Extensions;
using FourthPharos.Host.Models;
using Microsoft.AspNetCore.Components;

namespace FourthPharos.Host.Pages.Circle;

public partial class CircleEditor
{
    [Parameter]
    public Guid? Id { get; set; }

    public CircleModel Model { get; set; } = null!;

    private Guid userId = Guid.Empty;

    private string? circleName;
    private bool IsCircleNameInvalid => string.IsNullOrWhiteSpace(circleName);

    private string? circleLocation;
    private bool IsCircleLocationInvalid => string.IsNullOrWhiteSpace(circleLocation);

    private readonly IReadOnlyCollection<AbilityModel> abilities = new List<AbilityModel>
    {
        new AbilityModel(null, string.Empty),
        new AbilityModel(CircleAbility.StaminaTraining.Code, "Stamina Training"),
        new AbilityModel(CircleAbility.NobodyLeftBehind.Code, "Nobody Left Behind"),
        new AbilityModel(CircleAbility.ForgedInFire.Code, "Forged in Fire"),
        new AbilityModel(CircleAbility.Interdisciplinary.Code, "Interdisciplinary"),
        new AbilityModel(CircleAbility.ResourceManagement.Code, "Resource Management"),
        new AbilityModel(CircleAbility.OneLastRun.Code, "One Last Run"),
    };

    protected override async Task OnInitializedAsync()
    {
        base.OnInitialized();

        var authState = await authStateProvider.GetAuthenticationStateAsync();
        userId = authState.User.GetUserId();

        if (Id is null)
        {
            Model = circleService.CreateCircle(null, userId);
            Model.Circle.AddIllumination(100);
        }
        else
        {
            var circle = circleService.GetCircles().SingleOrDefault(_ => _.Id == Id);

            if (circle is not null)
            {
                Model = circle;
                circleName = circle.Name;
                circleLocation = circle.Location;
            }
        }
    }

    private void SetName()
    {
        if (IsCircleNameInvalid)
        {
            return;
        }

        Model.Circle.SetName(circleName);
    }

    private void SetLocation()
    {
        if (IsCircleLocationInvalid)
        {
            return;
        }

        Model.Circle.SetLocation(circleLocation);
    }

    private void SetAbility(int rank, string? ability) => Model.Circle.SelectAbility(ability, rank);


    private IEnumerable<AbilityModel> GetAvailableAbilities() =>
        abilities.Where(a => !Model
            .Circle
            .GetFeature<Domain.CandelaObscuraCircle.Models.Circle, CircleAbilitiesFeature>()
            .Abilities
            .Select(_ => _.Code)
            .Contains(a.Code));

    private AbilityModel? GetAbilityAtRank(int rank)
    {
        var ability = Model
            .Circle
            .GetFeature<Domain.CandelaObscuraCircle.Models.Circle, CircleAbilitiesFeature>()
            .Abilities
            .FirstOrDefault(_ => _.TakenAtRank == rank);

        return abilities.FirstOrDefault(_ => _.Code == ability?.Code);
    }

    private record AbilityModel(string? Code, string Name);
}