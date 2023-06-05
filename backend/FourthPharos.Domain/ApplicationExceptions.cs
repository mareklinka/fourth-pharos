using FourthPharos.Domain.Models;

namespace FourthPharos.Domain;

public static class ApplicationExceptions
{
    public static DomainActionException MissingRoleAssignment(CharacterSpecialty specialty) => new(nameof(MissingRoleAssignment), $"The specialty {specialty} has no role assigned");
}