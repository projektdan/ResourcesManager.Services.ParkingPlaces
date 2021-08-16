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

        public static string EmptyUsername;
        public static string EmptyString;
        public static string InvalidStringLength;
        public static string EmptyPassword;
        public static string EmptyFirstname;
        public static string EmptyLastname;
        public static string EmptyEmail;
        public static string InvalidRegex;
        public static string EmptyName;
        public static string EmptyAddress;
        public static string EmptyUniqueResourceIdentifier;
        public static string InvalidIntvalue;
    }
}
