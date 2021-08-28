using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResourcesManager.Services.ParkingPlaces.Core.Domain;
using ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects;
using System;

namespace ResourcesManager.Services.ParkingPlaces.Core.Tests.Domain
{

    public abstract class BaseTests
    {
        protected Name name;
        protected Address address;
        protected UniqueResourceIdentifier uniqueResourceIdentifier;
        protected Name resourceName;

        protected Email email;
        protected Username username;
        protected Password password;
        protected Firstname firstname;
        protected Lastname lastname;
        protected PasswordHasher<User> passwordHasher = new();
        protected User user;

        protected Resource parkingResource;
        protected Location location;

        protected readonly DateTime todayDateTime = DateTime.Now;
        protected DateTime tomorrowDateTime;

        protected readonly int resourceQuantity = 5;

        [TestInitialize]
        public void Initialize()
        {
            this.name = new Name("Nobel Tower");
            this.address = new Address("Poznań, Dąbrowskiego");
            this.uniqueResourceIdentifier = new UniqueResourceIdentifier("nobel_tower_parking_place");
            this.resourceName = new Name("Parking Place");

            this.email = new Email("jan.nowak@gmail.com");
            this.username = new Username("jankowalski");
            this.password = new Password("password");
            this.firstname = new Firstname("Jan");
            this.lastname = new Lastname("Nowak");

            this.user = new User(email, username, password, passwordHasher, firstname, lastname);

            this.parkingResource = new Resource(uniqueResourceIdentifier, resourceName);
            this.location = new Location(name, address);

            this.tomorrowDateTime = this.todayDateTime.AddDays(1);
        }

    }
}
