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
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeRepository _filmeRepository;

        public FilmeController(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }
        /// <summary>
        /// Endpoint listaDeFilme pelo seu Id
        /// </summary>
        /// <param name="id">id do genero buscado</param>
        /// <returns>GEnero buscado</returns>
        [HttpGet]

        public IActionResult Get()
        {

            try
            {
                List<Filme> listaDeFilme = _filmeRepository.Listar();
                return Ok(listaDeFilme);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        } /// <summary>
          /// Endpoint Cadastrar Genero pelo seu Id
          /// </summary>
          /// <param name="id">id do genero buscado</param>
          /// <returns>GEnero buscado</returns>
        [HttpPost]
        public IActionResult Post(Filme novofilme)
        {
            try
            {
                _filmeRepository.Cadastrar(novofilme);
                return Created();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint para buscar um Filme pelo seu Id
        /// </summary>
        /// <param name="id">id do genero buscado</param>
        /// <returns>GEnero buscado</returns>
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Filme filmeBuscado = _filmeRepository.BuscarPorId(id);

                return Ok(filmeBuscado);

            }
            catch (Exception)
            {

                return BadRequest();


            }

        }
        /// <summary>
        /// Endpoint Atualizar pelo seu Id
        /// </summary>
        /// <param name="id">id do genero buscado</param>
        /// <returns>GEnero buscado</returns>
        [HttpPut("{id}")]

        public IActionResult Put(Guid id, Filme genero)
        {
            try
            {
                _filmeRepository.Atualizar(id, genero);

                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Endpoint Deletar pelo seu Id
        /// </summary>
        /// <param name="id">id do genero buscado</param>
        /// <returns>GEnero buscado</returns>

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _filmeRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }


        }

        /// <summary>
        /// Endpoint listarDeFilmePorGenero pelo seu Id
        /// </summary>
        /// <param name="id">id do genero buscado</param>
        /// <returns>GEnero buscado</returns>
        [HttpGet("ListarPorGenero/{id}")]
        public IActionResult GetByGenero(Guid id)
        
        {
            try
            {
                List<Filme> listarDeFilmePorGenero = _filmeRepository.listarPorGenero(id);

                return Ok(listarDeFilmePorGenero);
            }
            catch (Exception e)
            {

               return BadRequest(e.Message);
            }

        }
    }
}