using ResourcesManager.Services.Libraries.Exceptions;

namespace ResourcesManager.Services.ParkingPlaces.Core.Exceptions
{
    public class NullEntityException<TEntity> : CustomException
    {
        public NullEntityException()
            : base ($"Empty {typeof(TEntity).Name}", $"{typeof(TEntity).Name} can't be null.")
        {
        }
    }
}
