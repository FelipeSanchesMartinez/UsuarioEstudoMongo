using MongoDB.Driver;
using System.Linq.Expressions;
using UsuarioEstudo.infra.data.Entities;

namespace UsuarioEstudo.domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        void Delete(Guid id);
        List<TEntity> GetAll(int page, int limit);
        TEntity GetById(Guid id);
        FilterDefinition<TEntity> GetFilter<TField>(Expression<Func<TEntity, TField>> field, TField value, bool isDeleted = true);
        void Insert(TEntity entity);
        void Update(TEntity entity, Guid id);
    }
}