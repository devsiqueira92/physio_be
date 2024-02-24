using System.Data;
using Microsoft.EntityFrameworkCore.Storage;
using Physio.Domain.RepositoryInterfaces;
using Physio.Infrasctructure.Context;
using Physio.Infrastructure.Context;

namespace Physio.Infrastructure
{
    internal sealed class UnitOfWork : IUnitOfWork
    {
        private readonly PhysioContext _dbContext;

        public UnitOfWork(PhysioContext dbContext) => _dbContext = dbContext;

        //public IDbTransaction BeginTransaction()
        //{
        //    var transaction = _dbContext.Database.BeginTransaction();

        //    return transaction;
        //}

        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
