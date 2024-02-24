namespace Physio.Shared.Communications.Requests;

public record RegisterRequest(string email, string password, string confirmPassword, short accountType);