using FourthPharos.Domain.CandelaObscuraCircle.Features;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCircle.Operations;

public static class SetNameOperation
{
    public static Circle SetName(this Circle circle, string name)
    {
        var feature = circle.GetFeature<Circle, CircleNameFeature>();

        CircleValidators.Name(name);

        return circle.UpdateFeature(feature with { Name = name });
    }
}
