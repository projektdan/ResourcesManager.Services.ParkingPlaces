using System.Linq;

namespace ResourcesManager.Services.ParkingPlaces.Core.Exceptions
{
    public class ErrorCodes
    {
        static ErrorCodes()
        {
            var fields = typeof(ErrorCodes)
                .GetFields();

            fields.Where(x => x.FieldType == typeof(string))
                .ToList()
                .ForEach(x => x.SetValue(null, x.Name));
        }
    }
}
