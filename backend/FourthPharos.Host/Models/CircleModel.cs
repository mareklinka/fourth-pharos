using FourthPharos.Domain.CandelaObscuraCircle.Features;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Host.Models;

public sealed record CircleModel(Circle Circle, Guid OwnerId)
{
    public Guid Id => Circle.Id;

    public string Name => Circle.GetFeature<Circle, CircleNameFeature>().Name;

    public int Members => Circle.Characters.Length;
}