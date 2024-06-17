using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioEstudo.infra.data.Entities
{
    public class People : Entity
    {
        public People(Guid id, DateTime createdAte, string nome , string sobrenome, DateTime dataNascimento, string email) : base(id, createdAte)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            DataNascimento = dataNascimento;
            Email = email;
        }
        public string Nome { get; protected set; }
        public string Sobrenome { get; protected set; }
        public DateTime DataNascimento { get; protected set; }    
        public string Email { get; protected set; }

    }
}
