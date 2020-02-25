﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WinterWorkShop.Cinema.Domain.Common;

namespace WinterWorkShop.Cinema.API.Models
{
    public class CreateAuditoriumModel
    {
        [Required]        
        public int cinemaId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = Messages.AUDITORIUM_PROPERTIE_NAME_NOT_VALID)]
        public string auditoriumName { get; set; }

        [Required]
        [Range(1,20, ErrorMessage = Messages.AUDITORIUM_PROPERTIE_SEATROWSNUMBER_NOT_VALID)]
        public int numberOfRows { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = Messages.AUDITORIUM_PROPERTIE_SEATNUMBER_NOT_VALID)]
        public int numberOfSeatsPerRow { get; set; }

    }
}
