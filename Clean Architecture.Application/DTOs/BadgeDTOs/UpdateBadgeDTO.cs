﻿using charityPulse.core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Application.DTOs.BadgeDTOs
{
    public class UpdateBadgeDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateRecived { get; set; }
        public string Icon { get; set; }
        public int? DonorId { get; set; }
        public int? CharityId { get; set; }
        public int? CorporateId { get; set; }
    }
}
