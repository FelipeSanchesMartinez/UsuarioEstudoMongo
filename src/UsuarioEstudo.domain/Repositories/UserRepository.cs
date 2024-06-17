using UsuarioEstudo.infra.data.Entities;

namespace UsuarioEstudo.domain.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MongoContext context) : base(context)
        {
        }
    }
}
