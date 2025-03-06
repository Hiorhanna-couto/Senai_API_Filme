using api_filmes_senai.Domains;
using api_filmes_senai.Interfaces;
using api_filmes_senai.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_filmes_senai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]  
    public class UsuarioController : ControllerBase
    { 
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController (IUsuarioRepository usuarioRepository)
        {
             _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Endpoint para Cadastrar pelo seu Id
        /// </summary>
        /// <param name="id">id do genero buscado</param>
        /// <returns>GEnero buscado</returns>

        [HttpPost]

        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);

                return StatusCode(201, usuario);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
                
            }

        }
        // [HttpGet("BuscarPorId/{id}")]
        //public IActionResult GetById(Guid id)
        // {
        //   try
        //    {
        //        Usuario UsuarioRepository = _usuarioRepository.BuscarPorId(id)!;

        //       return Ok(UsuarioRepository);

        // }
        // catch (Exception e)
        ///  {
        //    return BadRequest(e.Message);
        //   }

        // }




        /// <summary>
        /// Endpoint para Usuario pelo seu Id
        /// </summary>
        /// <param name="id">id do genero buscado</param>
        /// <returns>GEnero buscado</returns>

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Usuario Usuario = _usuarioRepository.BuscarPorId(id)!;
                if (Usuario != null) {     
                return Ok(Usuario);
                }
                return null!; 
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        //[HttpGet("BuscarPorEmailESenha")]
        //public IActionResult BuscarPorEmailESenha(string email, string senha)
        //{
        //    try
        //    {
        //        Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(email, senha);

             //   if (usuarioBuscado != null)
            //    {
            //        return NotFound("Usuário não encontrado ou credenciais inválidas.");
           //     }

          //      return Ok(usuarioBuscado);
         //   }
        //    catch (Exception error)
        //    {
       //         return BadRequest($"Erro ao buscar usuário: {error.Message}");
        //    }
       // }






        //[HttpPost("BuscarPorEmailESenha")]
        //public IActionResult GetByEmailAndSenha(Usuario usuario)
        //{
        //    try
        //    {
        //        Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(usuario.Email!, usuario.Senha!);

        //        if (usuarioBuscado != null)
        //        {
        //            return Ok(usuarioBuscado);
        //           // return NotFound("Usuário não encontrado ou credenciais inválidas.");
        //        }

        //        return null!;
        //    }
        //    catch (Exception error)
        //    {
        //        return BadRequest( error.Message);
        //    }
        //}

    }
}
