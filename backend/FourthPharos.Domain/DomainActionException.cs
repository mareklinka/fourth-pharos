using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace FourthPharos.Domain;

[Serializable]
[SuppressMessage("Design", "CA1032", Justification = "Standard constructors not required")]
[SuppressMessage("Design", "RCS1194", Justification = "Standard constructors not required")]
public class DomainActionException : Exception
{
    [NonSerialized]
    private readonly object[] _parameters = Array.Empty<object>();

    public DomainActionException(string code, string message, params object[] parameters)
        : base(message)
    {
        Code = code;
        _parameters = parameters;
    }

    protected DomainActionException(SerializationInfo info, StreamingContext context)
        : base(info, context) => Code = info.GetString(nameof(Code)) ?? string.Empty;

    public string Code { get; }

    public object[] GetParameters() => _parameters;

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        base.GetObjectData(info, context);
        info.AddValue(nameof(Code), Code);
    }
}
