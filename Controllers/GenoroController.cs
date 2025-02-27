using api_filmes_senai.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_filmes_senai.Controllers
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


        [HttpGet]
        public IActionResult Get()
        {
            try{
              return Ok(_generoRepository.Listrar());
                        
            }
            catch(Exception e) 
            {

             return BadRequest(e.Message); 
        
            }

        }  


    }
}
