using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace Yazen003_OOP_Assignment_1.HotelReservationSystem
{
    public sealed class Reservation
    {
        private static int _nextId=1;
        public int Id { get; }
        public  DateTime CheckInDate { get; }
        public DateTime CheckOutDate { get; }
        public Room? Room { get; }
        public ReservationStatus Status { get; private set; }
        public int NumberOfNights => (CheckOutDate - CheckInDate).Days ;
        public decimal TotalCost => NumberOfNights * Room.PricePerNight;
        public Reservation(DateRange date , Room room)
        {
            Id = _nextId++;
            CheckInDate = date.Start;
            CheckOutDate = date.End;

            if (room.IsUnderMaintenance) throw new InvalidOperationException($"Cannot create a reservation for Room {room.RoomNumber} because it is currently under maintenance.");
        }
        

        public void Confirm()
        {
            if (Status!= ReservationStatus.Pending)
                throw new InvalidOperationException($"Cannot confirm a reservation in '{Status}' state.");

            Status = ReservationStatus.Confirmed;
        }

        public void CheckIn()
        {
            if(Status!=ReservationStatus.Confirmed)
                throw new InvalidOperationException($"only confirmed reservation can check in ,the current state '{Status}' state.");
            Status = ReservationStatus.CheckedIn;
        }

        public void CheckOut()
        {
            if (Status != ReservationStatus.CheckedIn)
                throw new InvalidOperationException($"only confirmed reservation can check out ,the current state '{Status}' state.");
            Status = ReservationStatus.CheckedOut;
        }

        public void Cancel()
        {
            if (Status == ReservationStatus.CheckedIn || Status == ReservationStatus.CheckedOut)
                throw new InvalidOperationException($"Cannot cancel a stay that is already '{Status}'.");

            if (Status == ReservationStatus.Cancelled)
                throw new InvalidOperationException("Reservation is already cancelled.");

            Status = ReservationStatus.Cancelled;
        }




    }
}
