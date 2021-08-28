using ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects;
using ResourcesManager.Services.ParkingPlaces.Core.Exceptions;
using System;

namespace ResourcesManager.Services.ParkingPlaces.Core.Domain
{
    public class Resource : DatabaseEntityBase
    {
        public Guid Id { get; private set; }
        public UniqueResourceIdentifier UniqueResourceIdentifier { get; private set; }
        public Name Name { get; private set; }
        public DateTime CreatedAt { get; private set; }

        #region CTOR
        private Resource()
        {
        }

        public Resource(UniqueResourceIdentifier uniqueResourceIdentifier, Name name)
        {
            this.Id = Guid.NewGuid();
            this.CreatedAt = DateTime.UtcNow;
            SetUniqueResourceIdentifier(uniqueResourceIdentifier);
            SetName(name);
        }
        #endregion

        public void SetUniqueResourceIdentifier(UniqueResourceIdentifier uniqueResourceIdentifier)
        {
            if (uniqueResourceIdentifier is null)
            {
                throw new NullEntityException<UniqueResourceIdentifier>();
            }

            if (this.UniqueResourceIdentifier is not null && this.UniqueResourceIdentifier != uniqueResourceIdentifier)
            {
                Update();
            }

            this.UniqueResourceIdentifier = uniqueResourceIdentifier;
        }

        public void SetName(Name name)
        {
            if (name is null)
            {
                throw new NullEntityException<Name>();
            }

            if (this.Name is not null && this.Name != name)
            {
                Update();
            }
            
            this.Name = name;
        }
    }
}
