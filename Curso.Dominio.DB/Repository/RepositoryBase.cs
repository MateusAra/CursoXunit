using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.DB.Context;
using CursoXunit.Dominio.Base;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Curso.Dominio.DB.Repository
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly AppDbContext _context;
        public RepositoryBase(AppDbContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public virtual TEntity GetById(int id)
        {
            var query = _context.Set<TEntity>().Where(entity => entity.Id == id);
            return query.Any() ? query.First() : null;
        }

        public virtual List<TEntity> ConsultList()
        {
            var entitys = _context.Set<TEntity>().ToList();
            return entitys.Any() ? entitys : new List<TEntity>();
        }
    }
}
