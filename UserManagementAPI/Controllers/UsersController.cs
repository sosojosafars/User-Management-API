using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private static List<User> users = new List<User>
        {
            new User { Id = 1, Name = "Alice", Email = "alice@example.com" },
            new User { Id = 2, Name = "Bob", Email = "bob@example.com" }
        };

        // GET: api/users
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            try
            {
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        // GET: api/users/1
        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            try
            {
                var user = users.FirstOrDefault(u => u.Id == id);
                if (user == null) return NotFound($"Usuário com ID {id} não encontrado.");
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        // POST: api/users
        [HttpPost]
        public ActionResult<User> CreateUser([FromBody] User newUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                newUser.Id = users.Any() ? users.Max(u => u.Id) + 1 : 1;
                users.Add(newUser);
                return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        // PUT: api/users/1
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var user = users.FirstOrDefault(u => u.Id == id);
                if (user == null) return NotFound($"Usuário com ID {id} não encontrado.");

                user.Name = updatedUser.Name;
                user.Email = updatedUser.Email;
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        // DELETE: api/users/1
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                var user = users.FirstOrDefault(u => u.Id == id);
                if (user == null) return NotFound($"Usuário com ID {id} não encontrado.");

                users.Remove(user);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
    }
}
