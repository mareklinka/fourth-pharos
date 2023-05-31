using FourthFaros.Domain.CandelaObscuraCircle;
using FourthFaros.Domain.CandelaObscuraCircle.Features;
using FourthFaros.Domain.CandelaObscuraCircle.Models;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.CandelaObscuraCircle.Operations;

public static class SetLocationOperation
{
    public static Circle SetLocation(this Circle circle, string location)
    {
        var feature = circle.GetFeature<Circle, CircleLocationFeature>();

        CircleValidators.Location(location);

        return circle.UpdateFeature(feature with { Location = location });
    }
}
