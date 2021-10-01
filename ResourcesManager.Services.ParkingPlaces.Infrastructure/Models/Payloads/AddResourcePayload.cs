using System.ComponentModel.DataAnnotations;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Models.Payloads
{
    public class AddResourcePayload
    {
        [Required]
        public string UniqueResourceIdentifier { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
