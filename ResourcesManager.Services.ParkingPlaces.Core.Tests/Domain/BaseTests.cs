using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResourcesManager.Services.ParkingPlaces.Core.Domain;
using ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

    }
}
