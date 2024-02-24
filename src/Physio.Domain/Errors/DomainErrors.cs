﻿using Physio.Domain.Shared;

namespace Physio.Domain.Errors;

public static class DomainErrors
{
    public static class Auth
    {
        public static readonly Error InvalidUser = new(
            "Auth.Invalid",
            "Email or password is invalid");
    }

    public static class Register
    {
        public static readonly Error InvalidRegister = new(
            "Register.Invalid",
            "Email or password is invalid");
    }

    public static class Patient
    {
        public static readonly Error ChildError = new(
            "Child.Error",
            "Patient must have more than 18 years");
    }

    public static class Scheduling
    {
        public static readonly Error PatientUnavailable = new(
            "Scheduling.PatientUnavailable",
            "Patient unavailable to requested date.");

        public static readonly Error ProfessionalUnavailable = new(
            "Scheduling.ProfessionalUnavailable",
            "Profissional unavailable to requested date.");

        public static readonly Error PastDate = new(
            "Scheduling.PastDate",
            "Scheduling date can't be on past");
    }

    public static class Token
    {
        public static readonly Error InvalidToken = new(
            "Token.Invalid",
            "Token is invalid");

        public static readonly Error EmptyToken = new(
            "Token.Empty",
            "Token is empty");
    }

    public static class Generic
    {
        public static readonly Error NotFound = new(
            "Generic.NotFound",
            "Resource not found.");

        public static readonly Error AlreadyExists = new(
            "Generic.AlreadyExists",
            "Resource already exists.");

        public static readonly Error CreateError = new(
            "Create.Error",
            "Error on Patient creating");

        public static readonly Error UpdateError = new(
           "Create.Update",
           "Error on Patient updating");

    }

    

}