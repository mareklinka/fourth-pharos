using Microsoft.AspNetCore.Components;

namespace FourthPharos.Host.Components;

public abstract class StylePassthroughComponent : ComponentBase
{
    protected string Classes { get; private set; } = "";

    protected string Styles { get; private set; } = "";

    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object> UnmatchedParameters { get; set; } = new Dictionary<string, object>();

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        Classes = $"{UnmatchedParameters.GetValueOrDefault("class")}";
        Styles = $"{UnmatchedParameters.GetValueOrDefault("style")}";
    }
}