namespace FourthFaros.Domain;

public static class DomainExceptions
{
    public static class CircleExceptions
    {
        public static DomainActionException CircleNameEmpty() => new(nameof(CircleNameEmpty), "The circle name must not be empty");

        public static DomainActionException CircleNameTooLong(int length) => new(nameof(CircleNameTooLong), $"The circle name must not exceed {length} characters", length);

        public static DomainActionException CircleLocationTooLong(int length) => new(nameof(CircleLocationTooLong), $"The circle's location must not exceed {length} characters", length);
    }
}
