using System.ComponentModel.DataAnnotations;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Models.Payloads
{
    public class AddLocationPayload
    {
        /// <summary>
        /// Locaion Name
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Address of the Location
        /// </summary>
        [Required]
        public string Address { get; set; }
    }
}
