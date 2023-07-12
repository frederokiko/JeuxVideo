using ApiEF.Models;
using ApiEF;
using Microsoft.AspNetCore.Mvc;

namespace JeuxVideo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly JeuxDbContext _dbContext;

        public GenresController(JeuxDbContext dbContext)
        {
            _dbContext = dbContext;
        }

       
        [HttpPost]
        public IActionResult CreerGenre([FromBody] Genre genre)
        {
            _dbContext.Genres.Add(genre);
            _dbContext.SaveChanges();
            return Ok();
        }

        
        [HttpGet]
        public IActionResult AfficherListeGenres()
        {
            var genres = _dbContext.Genres.ToList();
            return Ok(genres);
        }
    }

}
