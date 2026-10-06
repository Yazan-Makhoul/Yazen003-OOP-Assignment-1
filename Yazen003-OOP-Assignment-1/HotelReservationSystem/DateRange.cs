namespace Yazen003_OOP_Assignment_1.HotelReservationSystem
{
    public record DateRange(DateTime Start, DateTime End)
    {
        public bool Contains(DateTime date) => date >= Start && date <= End;

    }
}
