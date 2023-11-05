using liverary.Data;
using liverary.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace liverary.data.Repositories
{
    public class BaseRepository
    {
        protected IUnitOfWork UnitOfWork { get; set; }

        protected AsiBasecodeDBContext Context => (AsiBasecodeDBContext)UnitOfWork.Database;

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException(nameof(unitOfWork));
            UnitOfWork = unitOfWork;
        }

        protected virtual DbSet<TEntity> GetDbSet<TEntity>() where TEntity : class
        {
            return Context.Set<TEntity>();
        }

        protected virtual void SetEntityState(object entity, EntityState entityState)
        {
            Context.Entry(entity).State = entityState;
        }
    }
}
