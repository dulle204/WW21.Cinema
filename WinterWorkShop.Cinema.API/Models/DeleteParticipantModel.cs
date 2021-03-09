﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WinterWorkShop.Cinema.API.Models
{
    public class DeleteParticipantModel
    {
        [Required]
        public Guid ParticipantId { get; set; }
    }
}
