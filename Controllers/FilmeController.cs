﻿using api_filmes_senai.Domains;
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
            _filmeRepository = (IFilmeRepository?)filmeRepository!;
        }

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
        }
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

            //___________________________________________________________

        }
        //[HttpGet]
        //public IFilmeRepositoy Get_filmeRepository()
        //{
        //    return _filmeRepository;
        //}


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
    }
}