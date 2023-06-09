using FourthPharos.Domain.CandelaObscuraCircle.Features;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.Features;

namespace FourthPharos.Domain.CandelaObscuraCircle.Operations;

public static class SetLocationOperation
{
    public static Circle SetLocation(this Circle circle, string location)
    {
        var feature = circle.GetFeature<Circle, CircleLocationFeature>();

        CircleValidators.Location(location);

        return circle.UpdateFeature(feature with { Location = location });
    }
}
