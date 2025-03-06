using api_filmes_senai.Domains;
using api_filmes_senai.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Filmes_SENAI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class GeneroController : ControllerBase
    {
        private readonly IGeneroRepository _generoRepository;
        public GeneroController(IGeneroRepository generoRepository)
        {
            _generoRepository = generoRepository;
        }
        /// <summary>
        /// Endpoint para Listar pelo seu Id
        /// </summary>
        /// <param name="id">id do genero buscado</param>
        /// <returns>GEnero buscado</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_generoRepository.Listar());

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        /// <summary>
        /// Endpoint Cadastrar pelo seu Id
        /// </summary>
        /// <param name="id">id do genero buscado</param>
        /// <returns>GEnero buscado</returns>
        [Authorize]
        [HttpPost]
        public IActionResult Post(Genero novoGenero)
        {
            try
            {
                _generoRepository.Cadastrar(novoGenero);
                return Created();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);   
            }


        }

        /// <summary>
        /// Endpoint para buscar um Genero pelo seu Id
        /// </summary>
        /// <param name="id">id do genero buscado</param>
        /// <returns>GEnero buscado</returns>
        [HttpGet("BuscarPorId/{id}")]


      public IActionResult GetById(Guid id)
        {
            try
            {
                Genero generoBuscado = _generoRepository.BuscarPorId(id)!;

                return Ok (generoBuscado);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);

                
            }

        } /// <summary>
          /// Endpoint para Deletar  pelo seu id
          /// </summary>
          /// <param name="id">id do genero buscado</param>
          /// <returns>Genero buscado</returns>
        [HttpDelete("{id}")]  
        public IActionResult Delete(Guid id)
        {
            try
            {
                _generoRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }


        }
        /// <summary>
        /// Endpoint para Atualizar um Genero pelo seu Id
        /// </summary>
        /// <param name="id">id do genero buscado</param>
        /// <returns>GEnero buscado</returns>
        [HttpPut("{id}") ]

        public IActionResult Put (Guid id, Genero genero )
        {
            try
            {
                _generoRepository.Atualizar(id, genero);

                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }
         


    }
}