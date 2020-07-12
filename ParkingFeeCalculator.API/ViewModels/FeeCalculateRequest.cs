using System;
using System.ComponentModel.DataAnnotations;

namespace ParkingFeeCalculator.API.ViewModels
{
    public class FeeCalculateRequest
    {
        [Required]
        public DateTime EntryTime { get; set; }
        [Required]
        public DateTime ExitTime { get; set; }

    }
}
