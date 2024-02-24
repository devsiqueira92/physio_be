using Physio.Domain.Entities;

namespace Physio.Application.Abstractions;

public interface IJwtProvider
{
    //Task<string> GenerateAsync(UserEntity user);
    Task<string> GenerateAsync(UserEntity user, Guid? clinicId);
}
