using Microsoft.EntityFrameworkCore;
using MikroButik.Data.DataAccess.Abstract;
using Miktobutik.Models.EntityModel.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MikroButik.Data.DataAccess.Concrete
{
    public class EFRepositoryBase<TEntity> : IRepositoryDAL<TEntity> where TEntity : class, IEntity, new()

    {
        private ApplicationDbContext _context;
        public EFRepositoryBase(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(TEntity entity)
        {

            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            var result = _context.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            return false;


        }

        public bool Delete(TEntity entity)
        {

            var deletedEntity = _context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            var result = _context.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            return false;

        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {

            return _context.Set<TEntity>().SingleOrDefault(filter);

        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {

            return filter == null
                ? _context.Set<TEntity>().ToList()
                : _context.Set<TEntity>().Where(filter).ToList();

        }

        public bool Update(TEntity entity)
        {

            var updatedEntity = _context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            var result = _context.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            return false;

        }
    }
}





