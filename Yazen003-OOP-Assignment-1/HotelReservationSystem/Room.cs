using System;
using System.Collections.Generic;
using System.Text;

namespace Yazen003_OOP_Assignment_1.HotelReservationSystem
{
    public class Room
    {
        public int RoomNumber { get; }
        public  RoomType RoomType { get; }
        public decimal PricePerNight { get; private set; }
        public bool IsUnderMaintenance { get; private set; }

        public Room(int roomNumber, RoomType type ,decimal initialNightlyRate)
        {
            if (roomNumber <= 0)
                throw new ArgumentOutOfRangeException(nameof(roomNumber), "Room number must be positive.");

            if (initialNightlyRate <= 0)
                throw new ArgumentOutOfRangeException(nameof(initialNightlyRate), "Nightly rate must be greater than zero.");
            RoomNumber = roomNumber;
            RoomType = type;
            PricePerNight = initialNightlyRate;

        }

        public void StartMaintenance()
        {
            if (IsUnderMaintenance)
                throw new InvalidOperationException($"Room {RoomNumber} is already under maintenance.");

            IsUnderMaintenance = true;
        }

        public void EndMaintenance()
        {
            if (!IsUnderMaintenance)
                throw new InvalidOperationException($"Room {RoomNumber} is not currently under maintenance.");

            IsUnderMaintenance = false;
        }



    }
}
