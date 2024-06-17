using MongoDB.Driver;
using System.IO;
using System.Linq.Expressions;
using UsuarioEstudo.infra.data.Entities;

namespace UsuarioEstudo.domain.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly MongoContext Context;
        private readonly IMongoCollection<TEntity> Collection;
        private readonly FilterDefinition<TEntity> FilterDeletedDefealt;

        public Repository(MongoContext context)
        {
            Context = context;
            Collection = Context.DataBase.GetCollection<TEntity>(typeof(TEntity).Name);
            FilterDeletedDefealt = Builders<TEntity>.Filter.Eq(x => x.IsDeleted, true);

        }
        public FilterDefinition<TEntity> GetFilter<TField>(Expression<Func<TEntity, TField>> field, TField value, bool isDeleted = true)
        {
            var filter = Builders<TEntity>.Filter.Eq(field, value);
            if (isDeleted)
            {
                filter = Builders<TEntity>.Filter.And(FilterDeletedDefealt, filter);
            }
            return filter;
        }
        public List<TEntity> GetAll(int page, int limit)
        {
            try
            {

                return Collection.Find(FilterDeletedDefealt).ToList();

               // return Collection.Find(FilterDeletedDefealt).Skip((page - 1) * limit).Limit(limit).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public TEntity GetById(Guid id)
        {
            try
            {
                var filtro = GetFilter(x => x.Id, id);
                return Collection.Find(filtro).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Update(TEntity entity, Guid id)
        {
            try
            {
                var filter = GetFilter(x => x.Id, id);
                var a = Collection.ReplaceOne(filter, entity);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Delete(Guid id)
        {
            try
            {
                var filter = GetFilter(x => x.Id, id);
                Collection.DeleteOne(filter);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Insert(TEntity entity)
        {
            try
            {
                Collection.InsertOne(entity);
            }
            catch (Exception)
            {

                throw;
            } 

        }
    }
}
