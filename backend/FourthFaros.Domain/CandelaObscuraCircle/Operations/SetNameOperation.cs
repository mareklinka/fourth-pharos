using FourthFaros.Domain.CandelaObscuraCircle;
using FourthFaros.Domain.CandelaObscuraCircle.Features;
using FourthFaros.Domain.CandelaObscuraCircle.Models;
using FourthFaros.Domain.Features;

namespace FourthFaros.Domain.CandelaObscuraCircle.Operations;

public static class SetNameOperation
{
    public static Circle SetName(this Circle circle, string name)
    {
        var feature = circle.GetFeature<Circle, CircleNameFeature>();

        CircleValidators.Name(name);

        return circle.UpdateFeature(feature with { Name = name });
    }
}
