namespace UsuarioEstudo.infra.data.Entities
{
    public class Entity
    {
        public Entity(Guid id, DateTime createdAte, bool? isDeleted = false)
        {
            Id = id;
            CreatedAte = createdAte;
            IsDeleted = isDeleted;
        }

        public Guid Id { get; protected set; }
        public DateTime CreatedAte { get; protected set; }
        public bool? IsDeleted { get; set; }
    }
}
