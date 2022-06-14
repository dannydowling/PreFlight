using CSharpFunctionalExtensions;
using PreFlight_API.BLL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace PreFlight_API.BLL.Models
{
    public class Location : Entity
    {

        public Guid LocationId { get; set; }
        public virtual string Street { get; set; }
        public virtual string City { get; set; }
        public virtual State State { get; set; }
        public virtual string ZipCode { get; set; }
        public virtual double Latitude { get; set; }
        public virtual double Longitude { get; set; }

     
        private Location(string street, string city, State state, string zipCode, double longitude, double latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        public static Result<Location, Error> Create(
            string street, string city, string state, string zipCode, double latitude, double longitude,  string[] allStates)
        {
            State stateObject = State.Create(state, allStates).Value;

            street = (street ?? "").Trim();
            city = (city ?? "").Trim();
            zipCode = (zipCode ?? "").Trim();

            if (street.Length < 1 || street.Length > 100)
                return Errors.General.InvalidLength("street");

            if (city.Length < 1 || city.Length > 40)
                return Errors.General.InvalidLength("city");

            if (zipCode.Length < 1 || zipCode.Length > 5)
                return Errors.General.InvalidLength("zip code");

            return new Location(street, city, stateObject, zipCode, latitude, longitude);
        }
    }

    public class State : ValueObject
    {
        public string Value { get; }

        private State(string value)
        {
            Value = value;
        }

        public static Result<State, Error> Create(string input, string[] allStates)
        {
            if (string.IsNullOrWhiteSpace(input))
                return Errors.General.ValueIsRequired();

            string name = input.Trim().ToUpper();

            if (name.Length > 2)
                return Errors.General.InvalidLength();

            if (allStates.Any(x => x == name) == false)
                return Errors.Employee.InvalidState(name);

            return new State(name);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
