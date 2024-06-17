using Microsoft.AspNetCore.Mvc;
using UsuarioEstudo.domain.Repositories;
using UsuarioEstudo.infra.data.Entities;

namespace UsuarioEstudo.service.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository Repository;

        public UserController(IUserRepository repository)
        {
            Repository = repository;
        }

        [HttpGet()]
        public IActionResult GetAll(int page, int limit)
        {
            var entity = Repository.GetAll(page, limit);
            if (entity == null) return NotFound();
            return Ok(entity);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var entity = Repository.GetById(id);
            if (entity == null) return NotFound();
            return Ok(entity);
        }
        [HttpPost]
        public IActionResult Insert(User entity)
        {
            Repository.Insert(entity);
            return Ok();
        }
    }
}

