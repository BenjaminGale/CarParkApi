using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CarParkApi.Controllers
{
    public class AvailableSpacesRequest
    {
        [Required]
        [FromQuery(Name = "start-date")]
        public DateTime StartDate { get; set; }

        [Required]
        [FromQuery(Name = "end-date")]
        public DateTime EndDate { get; set; }
    }
}
