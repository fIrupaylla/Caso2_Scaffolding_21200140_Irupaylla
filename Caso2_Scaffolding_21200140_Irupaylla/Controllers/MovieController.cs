using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Caso2_Scaffolding_21200140_Irupaylla.DOMAIN.Core.Interfaces;
using Caso2_Scaffolding_21200140_Irupaylla.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Caso2_Scaffolding_21200140_Irupaylla.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {

        private readonly IMovieRepository _movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            
            _movieRepository = movieRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var movies = await _movieRepository.GetAll();
           
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getbyid(int id)
        {
            var movie = await _movieRepository.GetById(id);
            if (movie == null)
               return NotFound();

            return Ok(movie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Movies movies)
        {
            if (id != movies.Id) return BadRequest();
            var result = await _movieRepository.Update(movies);
            if (!result) return BadRequest();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _movieRepository.Delete(id);
            if (!result) return BadRequest();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Movies>> Create(Movies movie)
        {
            var result = await _movieRepository.Insert(movie);
            
            return Ok(result);
        }

    }
}
