using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        [Required, MaxLength(50)]
        public string BirthDay { get; set; }

        [Required, MaxLength(50)]
        public string Gender { get; set; }

        [Required, MaxLength(50)]
        public string PhoneNumber { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public int NumberGuest { get; set; }

        [Required]
        public string StreetAddress { get; set; }

        [Required, MaxLength(50)]
        public string AptSuite { get; set; }

        [Required]
        public string City { get; set; }

        [Required, MaxLength(50)]
        public string State { get; set; }

        [Required, MaxLength(10)]
        public string ZipCode { get; set; }

        [Required, MaxLength(10)]
        public string RoomType { get; set; }

        [Required, MaxLength(10)]
        public string RoomFloor { get; set; }

        [Required, MaxLength(10)]
        public string RoomNumber { get; set; }

        public double TotalBill { get; set; }

        public string PaymentType { get; set; }

        public string CardType { get; set; }

        public string CardNumber { get; set; }

        public string CardExp { get; set; }

        public string CardCvc { get; set; }

        [Required]
        public DateTime ArrivalTime { get; set; }

        [Required]
        public DateTime LeavingTime { get; set; }

        public bool CheckIn { get; set; }

        public int BreakFast { get; set; }

        public int Lunch { get; set; }

        public int Dinner { get; set; }

        public bool Cleaning { get; set; }

        public bool Towel { get; set; }

        public bool SSurprise { get; set; }

        public bool SupplyStatus { get; set; }

        public int FoodBill { get; set; }
    }
}
