using Microsoft.AspNetCore.Identity;
using ResourcesManager.Services.Libraries.Extensions;
using ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects;
using ResourcesManager.Services.ParkingPlaces.Core.Exceptions;
using System;
using PasswordVerificationResult = Microsoft.AspNetCore.Identity.PasswordVerificationResult;

namespace ResourcesManager.Services.ParkingPlaces.Core.Domain
{
    public class User : DatabaseEntityBase
    {
        public Guid Id { get; private set; }
        public Username Username { get; private set; }
        public Password Password { get; private set; }
        public string Hash { get; private set; }
        public Firstname Firstname { get; private set; }
        public Lastname Lastname { get; private set; }
        public Email Email { get; private set; }
        public DateTime CreatedAt { get; private set; }

        #region CTOR
        private User()
        {
        }
        public User(Email email, Username username, Password password, IPasswordHasher<User> passwordHasher,
            Firstname firstname, Lastname lastname)
        {
            this.Id = Guid.NewGuid();
            this.CreatedAt = DateTime.UtcNow;
            SetEmail(email);
            SetUsername(username);
            SetPassword(password, passwordHasher);
            SetFirstname(firstname);
            SetLastname(lastname);
        }
        #endregion
        
        public void SetUsername(Username username)
        {
            if (username is null)
            {
                throw new NullEntityException<Username>();
            }

            if (this.Username is not null && this.Username != username)
            {
                Update();
                this.Username = username;
            }

        }

        public void SetPassword(Password password, IPasswordHasher<User> passwordHasher)
        {
            if (password is null)
            {
                throw new NullEntityException<Password>();
            }

            var newHash = passwordHasher.HashPassword(this, password.Value);
            if (this.Hash.IsEmpty() && this.Hash != newHash)
            {
                Update();
                this.Hash = newHash;
            }

        }

        public bool ValidatePassword(Password password, IPasswordHasher<User> passwordHasher)
            => passwordHasher.VerifyHashedPassword(this, this.Hash, password?.Value) != PasswordVerificationResult.Failed;

        public void SetFirstname(Firstname firstname)
        {
            if (firstname is null)
            {
                throw new NullEntityException<Firstname>();
            }

            if (this.Firstname is not null && this.Firstname != firstname)
            {
                Update();
                this.Firstname = firstname;
            }

        }

        public void SetLastname(Lastname lastname)
        {
            if (lastname is null)
            {
                throw new NullEntityException<Lastname>();
            }

            if (this.Lastname is not null && this.Lastname != lastname)
            {
                Update();
                this.Lastname = lastname;
            }

        }

        public void SetEmail(Email email)
        {
            if (email is null)
            {
                throw new NullEntityException<Email>();
            }

            if (this.Email is not null && this.Email != email)
            {
                Update();
                this.Email = email;
            }

        }
    }
}
