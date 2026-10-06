namespace Yazen003_OOP_Assignment_1.HotelReservationSystem
{
    public class ReservationService
    {
        private readonly List<Reservation> _reservations = new();

        public IReadOnlyList<Reservation> Reservations => _reservations;

        public Reservation CreateReservation(Guest guest, Room room, DateTime checkInDate, DateTime checkOutDate)
        {
            ArgumentNullException.ThrowIfNull(guest);
            ArgumentNullException.ThrowIfNull(room);

            if (checkOutDate <= checkInDate)
            {
                throw new ArgumentException("Check-out date must be strictly after check-in date.");
            }

            if (room.IsUnderMaintenance)
            {
                throw new InvalidOperationException($"Room {room.RoomNumber} cannot be booked because it is under maintenance.");
            }

            
            bool isDoubleBooked = _reservations.Any(r =>
                r.Room.RoomNumber == room.RoomNumber &&
                r.Status != ReservationStatus.Cancelled &&
                r.Status != ReservationStatus.CheckedOut &&
                checkInDate < r.CheckOutDate && checkOutDate > r.CheckInDate);

            if (isDoubleBooked)
            {
                throw new InvalidOperationException($"Room {room.RoomNumber} is already booked for the selected dates.");
            }
            var date = new DateRange(checkInDate,checkOutDate);
            var reservation = new Reservation( date , room);

            guest.AddReservation(reservation);
            _reservations.Add(reservation);

            return reservation;
        }
    }
}
