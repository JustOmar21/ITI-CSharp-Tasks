using DAL.Context;
using DAL.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Managers
{
    public static class ReservationManager
    {
        static HotelContext context = new HotelContext();
        public static List<object> LoadKitchen()
        {
            return context.Reservations
                        .Where(r => r.CheckIn == true && r.SupplyStatus == false)
                        .Select(r => new
                        {
                            r.Id,
                            r.FirstName,
                            r.LastName,
                            r.PhoneNumber,
                            r.RoomType,
                            r.RoomFloor,
                            r.RoomNumber,
                            r.BreakFast,
                            r.Lunch,
                            r.Dinner,
                            r.Cleaning,
                            r.Towel,
                            r.SSurprise,
                            r.SupplyStatus,
                            r.FoodBill
                        })
                        .ToList<object>();
        }

        public static List<object> DapperLoadKitchen()
        {
            using (var connection = new SqlConnection(context.Database.Connection.ConnectionString))
            {
                return connection
                    .Query("select Id,FirstName,LastName,PhoneNumber,RoomType,RoomFloor,RoomNumber,BreakFast,Lunch,Dinner,Cleaning,Towel,SSurprise,SupplyStatus,FoodBill from reservations where checkin = 1 and supplystatus = 0")
                    .ToList();
            }
        }

        public static List<Reservation> LoadReservations()
        {
            return context.Reservations
                     .Where(r => r.CheckIn == true && r.SupplyStatus == false)
                     .ToList();
        }
        public static List<Reservation> DapperLoadReservations()
        {
            using (var connection = new SqlConnection(context.Database.Connection.ConnectionString))
            {
                return connection
                    .Query<Reservation>("select * from reservations where supplystatus = 0 and checkin = 1")
                    .ToList();
            }
        }

        public static List<Reservation> LoadAllReservations()
        {
            return context.Reservations
                     .ToList();
        }


        
        public static Reservation GetReservationById(int id)
        {
            return context.Reservations.Find(id);
        }
        public static Reservation DapperGetReservationById(int id)
        {
            using (var connection = new SqlConnection(context.Database.Connection.ConnectionString))
            {
                return connection.QuerySingleOrDefault<Reservation>("select * from reservations where id = @id", new {id = id});
            }
        }

        public static int InsertReservation(Reservation reservation)
        {
            context.Reservations.Add(reservation);
            context.SaveChanges();
            return reservation.Id;
        }

        public static bool RemoveReservation(int id)
        {
            var reservation = context.Reservations.Find(id);
            if(reservation != null)
            {
                context.Reservations.Remove(reservation);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool UpdateReservation(Reservation updatedReserve)
        {
            var reservation = context.Reservations.Find(updatedReserve.Id);
            if (reservation == null) return false;


            reservation.FirstName = updatedReserve.FirstName;
            reservation.LastName = updatedReserve.LastName;
            reservation.BirthDay = updatedReserve.BirthDay;
            reservation.Gender = updatedReserve.Gender;
            reservation.PhoneNumber = updatedReserve.PhoneNumber;
            reservation.EmailAddress = updatedReserve.EmailAddress;
            reservation.NumberGuest = updatedReserve.NumberGuest;
            reservation.StreetAddress = updatedReserve.StreetAddress;
            reservation.AptSuite = updatedReserve.AptSuite;
            reservation.City = updatedReserve.City;
            reservation.State = updatedReserve.State;
            reservation.ZipCode = updatedReserve.ZipCode;
            reservation.RoomType = updatedReserve.RoomType;
            reservation.RoomFloor = updatedReserve.RoomFloor;
            reservation.RoomNumber = updatedReserve.RoomNumber;
            reservation.TotalBill = updatedReserve.TotalBill + updatedReserve.FoodBill;
            reservation.PaymentType = updatedReserve.PaymentType;
            reservation.CardType = updatedReserve.CardType;
            reservation.CardNumber = updatedReserve.CardNumber;
            reservation.CardExp = updatedReserve.CardExp;
            reservation.CardCvc = updatedReserve.CardCvc;
            reservation.ArrivalTime = updatedReserve.ArrivalTime;
            reservation.LeavingTime = updatedReserve.LeavingTime;
            reservation.CheckIn = updatedReserve.CheckIn;
            reservation.SupplyStatus = updatedReserve.SupplyStatus;
            reservation.Cleaning = updatedReserve.Cleaning;
            reservation.Towel = updatedReserve.Towel;
            reservation.SSurprise = updatedReserve.SSurprise;
            reservation.FoodBill = updatedReserve.FoodBill;
            reservation.BreakFast = updatedReserve.BreakFast;
            reservation.Lunch = updatedReserve.Lunch;
            reservation.Dinner = updatedReserve.Dinner;


            context.SaveChanges();
            return true;

        }

        public static bool UpdateKitchenReservation(Reservation updatedReserve)
        {
            var reservation = context.Reservations.Find(updatedReserve.Id);
            if (reservation == null) return false;

            reservation.TotalBill = updatedReserve.TotalBill + updatedReserve.FoodBill;
            reservation.BreakFast = updatedReserve.BreakFast;
            reservation.Lunch = updatedReserve.Lunch;
            reservation.Dinner = updatedReserve.Dinner;
            reservation.SupplyStatus = updatedReserve.SupplyStatus;
            reservation.Cleaning = updatedReserve.Cleaning;
            reservation.Towel = updatedReserve.Towel;
            reservation.SSurprise = updatedReserve.SSurprise;
            reservation.FoodBill = updatedReserve.FoodBill;


            context.SaveChanges();
            return true;

        }

        public static bool DapperUpdateKitchenReservation(Reservation updatedReserve)
        {
            using (var connection = new SqlConnection(context.Database.Connection.ConnectionString))
            {
                string query = @"
                                update reservations 
                                SET 
                                    totalbill = @TotalBill, 
                                    breakfast = @BreakFast, 
                                    lunch = @Lunch, 
                                    dinner = @Dinner, 
                                    supplystatus = @SupplyStatus, 
                                    cleaning = @Cleaning, 
                                    towel = @Towel, 
                                    ssurprise = @SSurprise, 
                                    foodbill = @FoodBill
                                WHERE Id = @Id
                                ";

                var parameters = new
                {
                    Id = updatedReserve.Id,
                    TotalBill = updatedReserve.TotalBill + updatedReserve.FoodBill,
                    BreakFast = updatedReserve.BreakFast,
                    Lunch = updatedReserve.Lunch,
                    Dinner = updatedReserve.Dinner,
                    SupplyStatus = updatedReserve.SupplyStatus,
                    Cleaning = updatedReserve.Cleaning,
                    Towel = updatedReserve.Towel,
                    SSurprise = updatedReserve.SSurprise,
                    FoodBill = updatedReserve.FoodBill
                };

                return connection.Execute(query, parameters) > 0;
                 
            }

        }

        public static List<Reservation> SearchReservations(string searchText)
        {
            return context.Reservations
                .Where(r => r.Id.ToString().Contains(searchText) ||
                            r.LastName.Contains(searchText) ||
                            r.FirstName.Contains(searchText) ||
                            r.Gender.Contains(searchText) ||
                            r.State.Contains(searchText) ||
                            r.City.Contains(searchText) ||
                            r.RoomNumber.Contains(searchText) ||
                            r.RoomType.Contains(searchText) ||
                            r.EmailAddress.Contains(searchText) ||
                            r.PhoneNumber.Contains(searchText))
                .ToList();
        }

        public static List<string> TakenRooms()
        {
            return context.Reservations
                .Where(r => r.CheckIn == true)
                .Select(r => r.RoomNumber.Trim())
                .ToList();
        }

        public static List<Reservation> ReservedRooms()
        {
            return context.Reservations
                .Where(r => !r.CheckIn)
                .ToList();
        }
        public static List<Reservation> OccupiedRooms()
        {
            return context.Reservations
                .Where(r => r.CheckIn)
                .ToList();
        }

    }
}
