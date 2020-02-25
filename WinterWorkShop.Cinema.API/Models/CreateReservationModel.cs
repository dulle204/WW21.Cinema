using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WinterWorkShop.Cinema.Domain.Common;

namespace WinterWorkShop.Cinema.API.Models
{
    public class CreateReservationModel
    {
        [Required(ErrorMessage = Messages.RESERVATION_SEATID_ERROR)]
        public Guid seatId { get; set; }

        [Required(ErrorMessage = Messages.RESERVATION_PROJECTIONID_ERROR)]
        public Guid projectionId { get; set; }

        [Required(ErrorMessage = Messages.RESERVATION_USERID_ERROR)]
        public Guid userId { get; set; }

        [Required(ErrorMessage = Messages.RESERVATION_PAYMENT_ERROR)]
        public bool payment { get; set; }

        [Required(ErrorMessage = Messages.RESERVATION_MESSAGE_ERROR)]
        public string message { get; set; }
    }
}
