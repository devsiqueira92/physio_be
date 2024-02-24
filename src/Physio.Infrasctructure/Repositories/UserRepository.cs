using Microsoft.EntityFrameworkCore;
using Physio.Domain.RepositoryInterfaces;
using Physio.Infrasctructure.Context;

namespace Physio.Infrastructure.Repositories;

internal sealed class UserRepository : IUserRepository
{
    private readonly PhysioContext _context;
    public UserRepository(PhysioContext context) => _context = context;



    public async Task RegisterUser(string id, CancellationToken cancellationToken = default)
    {
        var query = _context.Users
                   .Where(cls => cls.Id == id);

        var user =  await query.SingleOrDefaultAsync(cancellationToken);

        user.IsRegistred = true;

        _context.Users.Update(user);
    }
}
