using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResourcesManager.Services.ParkingPlaces.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Core.Tests.Domain
{
    [TestClass]
    public class UserTests : BaseTests
    {
        [TestMethod]
        public void CreateUser_ValidParameters_ShouldCreate()
        {
            //ARRANGE

            //ACT
            var user = new User(email, username, password, passwordHasher, firstname, lastname);

            //ASSERT
            user.Id.Should().NotBeEmpty();
            user.CreatedAt.Should().BeBefore(DateTime.UtcNow);
            user.Email.Should().Be(email);
            user.Username.Should().Be(username);
            user.ValidatePassword(password, passwordHasher).Should().BeTrue();
            user.Firstname.Should().Be(firstname);
            user.Lastname.Should().Be(lastname);
            user.UpdatedAt.HasValue.Should().BeFalse();
        }
    }
}
