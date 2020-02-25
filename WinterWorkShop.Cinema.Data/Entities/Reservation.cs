using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WinterWorkShop.Cinema.Data
{
    [Table("reservation")]
    public class Reservation
    {
        public Guid Id { get; set; }

        [Column("seatId")]
        public Guid SeatId { get; set; }

        [Column("projectionId")]
        public Guid ProjectionId { get; set; }

        [Column("userId")]
        public Guid UserId { get; set; }

        public bool Payment { get; set; }

        public string Message { get; set; }

        public virtual User User { get; set; }

        public virtual Seat Seat { get; set; }

        public virtual Projection Projection { get; set; }
    }
}
