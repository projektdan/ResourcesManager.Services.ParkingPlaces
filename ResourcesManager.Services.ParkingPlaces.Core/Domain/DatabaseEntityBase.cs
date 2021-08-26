using System;

namespace ResourcesManager.Services.ParkingPlaces.Core.Domain
{
    public abstract class DatabaseEntityBase
    {
        public DateTime? UpdatedAt { get; protected set; }

        protected void Update()
            => this.UpdatedAt = DateTime.UtcNow;
    }
}
