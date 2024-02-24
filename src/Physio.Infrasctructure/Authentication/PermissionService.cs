
using Microsoft.EntityFrameworkCore;
using Physio.Domain.Entities;
using Physio.Infrasctructure.Authentication;
using Physio.Infrasctructure.Context;

namespace Physio.Infrastructure.Authentication;

internal class PermissionService //: IPermissionService
{
    //private readonly PhysioContext _context;

    //public PermissionService(PhysioContext context)
    //{
    //    _context = context;
    //}
    //public async Task<HashSet<string>> GetPermissionsAsync(Guid memberId)
    //{
    //    ICollection<RoleEntity>[] roles = await _context.Set<UserEntity>()
    //         .Include(x => x.Roles)
    //         //.ThenInclude(x => x.Permissions)
    //         //.Where(x => x.Id == memberId)
    //         .Select(x => x.Roles)
    //         .ToArrayAsync();

    //    return roles
    //        .SelectMany(x => x)
    //        //.SelectMany(x => x.Permissions)
    //        .Select(x => x.Name)
    //        .ToHashSet();
    //}
}
