using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioEstudo.infra.data.Enums;

namespace UsuarioEstudo.infra.data.Entities
{
    public class User:Entity
    {
        public User(Guid id, DateTime createdAte, string userName, string password, UserPermision userPermision, Guid peopleId) : base(id, createdAte)
        {
            UserName = userName;
            Password = password;
            UserPermision = userPermision;
            PeopleId = peopleId;
        }
        public string UserName { get; protected set; }
        public string Password { get; protected set; }
        public Guid PeopleId { get; protected set; }
        public UserPermision UserPermision { get; protected set; }
    }
}
