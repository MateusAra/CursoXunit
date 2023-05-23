using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoXunit.Dominio.Base
{
    public interface IRepository<TEntity>
    {
        TEntity GetById(int id);
        List<TEntity> ConsultList();
        void Add(TEntity entity);
    }
}
