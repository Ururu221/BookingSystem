﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookingSystem_web_api.Models
{
    public class RoomModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string RoomType { get; set; } = string.Empty; // "Conference" or "Bedroom"

        public int HumanCapacity { get; set; }

        public string Address { get; set; } = string.Empty;

        public bool IsAvailable { get; set; }

        public List<Reservation>? Reservation { get; set; }

        public decimal Price { get; set; }
    }
}
