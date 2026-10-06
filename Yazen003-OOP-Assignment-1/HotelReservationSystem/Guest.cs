using System;
using System.Collections.Generic;
using System.Text;

namespace Yazen003_OOP_Assignment_1.HotelReservationSystem
{
    public sealed class Guest
    {
        private static int _nextId = 1;

        public ReservationStatus reservationStatus;

        private readonly List<Reservation> _reservations = new();
        public int Id { get; }

        public string FullName { get;  }

        public string PhoneNumber { get; }
        public IReadOnlyList<Reservation> Reservations => _reservations;
        public Guest( string fullName, string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                throw new ArgumentException("Guest full name cannot be null, empty, or consist only of white-space characters.", nameof(fullName));
            }

            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                throw new ArgumentException("Guest phone number cannot be null, empty, or consist only of white-space characters.", nameof(phoneNumber));
            }

            Id = _nextId++;
            FullName = fullName;
            PhoneNumber = phoneNumber;
        }


        public void AddReservation(Reservation reservation)
        {
            if (reservation == null)
                throw new ArgumentNullException(nameof(reservation));

            _reservations.Add(reservation);
        }

    }
}
