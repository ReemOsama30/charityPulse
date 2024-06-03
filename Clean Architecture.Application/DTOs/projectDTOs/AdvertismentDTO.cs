﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Application.DTOs.projectDTOs
{
    public class AdvertismentDTO
    {
        public int Id { get; set; }
        public byte[] AdDesign { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime Duration { get; set; }
    }
}
