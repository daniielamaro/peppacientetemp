using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers.Request;
using API.Domain;
using API.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpPost("CriarConta")]
        public IActionResult CriarConta([FromBody] CriarContaRequest userRequest)
        {
            try
            {
                using var context = new ApiContext();

                var user = new User
                {
                    Id = Guid.NewGuid(),
                    Nome = userRequest.Nome,
                    Rg = userRequest.Rg,
                    Cpf = userRequest.Cpf,
                    Email = userRequest.Email,
                    DataNasc = DateTime.Parse(userRequest.DataNasc),
                    Endereco = userRequest.Endereco,
                    Senha = userRequest.Senha
                };

                context.Usuarios.Add(user);
                context.SaveChanges();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("GetUserByLoginSenha")]
        public IActionResult GetUserByLoginSenha(string emailCpf, string senha)
        {
            try
            {
                using var context = new ApiContext();

                if (!context.Usuarios.Any(x => (x.Email == emailCpf || x.Cpf == emailCpf) && x.Senha == senha))
                    return BadRequest("Usuario ou senha incorreto!");

                var user = context.Usuarios.Include(x => x.FotoPerfil).Where(x => (x.Email == emailCpf || x.Cpf == emailCpf) && x.Senha == senha).FirstOrDefault();

                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("SetPhotoUser")]
        public IActionResult SetPhotoUser(SetPhotoUser request)
        {
            try
            {
                using var context = new ApiContext();

                if (!context.Usuarios.Any(x => x.Id == request.IdUser))
                    return BadRequest("Usuario não existe!");

                var user = context.Usuarios.Include(x => x.FotoPerfil).Where(x => x.Id == request.IdUser).FirstOrDefault();

                user.FotoPerfil = request.Foto;

                context.Update(user);
                context.SaveChanges();

                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
