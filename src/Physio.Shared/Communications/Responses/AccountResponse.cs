namespace Physio.Shared.Communications.Responses;

public record AccountResponse(string name, 
    string identificationNumber, 
    List<AddressResponse> addresses, 
    List<ContactResponse> contacts, 
    string about, 
    DateTime createdAt, 
    string accountType, 
    DateOnly? birthDate = null, 
    decimal? appointmentValue = null
);