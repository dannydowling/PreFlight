using System;
using System.Collections.Generic;
using CSharpFunctionalExtensions;

namespace PreFlight_API.BLL.Models
{
    public sealed class Error : ValueObject
    {
        private const string Separator = "||";
        
        public string Code { get; }
        public string Message { get; }

        internal Error(string code, string message)
        {
            Code = code;
            Message = message;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Code;
        }

        public string Serialize()
        {
            return $"{Code}{Separator}{Message}";
        }

        public static Error Deserialize(string serialized)
        {
            if (serialized == "A non-empty request body is required.")
                return Errors.General.ValueIsRequired();
            
            string[] data = serialized.Split(new[] { Separator }, StringSplitOptions.RemoveEmptyEntries);

            if (data.Length < 2)
                throw new Exception($"Invalid error serialization: '{serialized}'");

            return new Error(data[0], data[1]);
        }
    }

    public static class Errors
    {
        public static class Employee
        {
            public static Error TooManyRoles() =>
                new Error("employee.too.many.roles", "Employee cannot have more than 2 roles");

            public static Error AlreadyAssigned(string roleName) =>
                new Error("employee.already.assigned", $"Employee is already assigned to task '{roleName}'");
            
            public static Error EmailIsTaken() =>
                new Error("employee.email.is.taken", "Employee email is taken");

            public static Error InvalidState(string name) =>
                new Error("invalid.state", $"Invalid state: '{name}'");

            public static Error RoleIsInvalid() =>
                new Error("role.is.invalid", "Role is invalid");
        }

        public static class General
        {
            public static Error NotFound(long? id = null)
            {
                string forId = id == null ? "" : $" for Id '{id}'";
                return new Error("record.not.found", $"Record not found{forId}");
            }

            public static Error ValueIsInvalid() =>
                new Error("value.is.invalid", "Value is invalid");

            public static Error ValueIsRequired() =>
                new Error("value.is.required", "Value is required");

            public static Error InvalidLength(string name = null)
            {
                string label = name == null ? " " : " " + name + " ";
                return new Error("invalid.string.length", $"Invalid{label}length");
            }
            
            public static Error CollectionIsTooSmall(int min, int current)
            {
                return new Error(
                    "collection.is.too.small",
                    $"The collection must contain {min} items or more. It contains {current} items.");
            }

            public static Error CollectionIsTooLarge(int max, int current)
            {
                return new Error(
                    "collection.is.too.large",
                    $"The collection must contain {max} items or more. It contains {current} items.");
            }

            public static Error InternalServerError(string message)
            {
                return new Error("internal.server.error", message);
            }
        }
    }
}
