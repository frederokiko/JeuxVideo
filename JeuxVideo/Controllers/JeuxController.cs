using ApiEF;
using ApiEF.Models;
using Microsoft.AspNetCore.Mvc;

namespace JeuxVideo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JeuxController : ControllerBase
    {
        private readonly JeuxDbContext _dbContext;

        public JeuxController(JeuxDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        
        [HttpPost]
        public IActionResult AjouterJeu([FromBody] Jeu jeu)
        {
            _dbContext.Jeux.Add(jeu);
            _dbContext.SaveChanges();
            return Ok();
        }

       
        [HttpGet]
        public IActionResult AfficherListeJeux()
        {
            var jeux = _dbContext.Jeux.ToList();
            return Ok(jeux);
        }

        
        [HttpGet("{id}")]
        public IActionResult AfficherJeu(int id)
        {
            var jeu = _dbContext.Jeux.Find(id);
            if (jeu == null)
                return NotFound();
            return Ok(jeu);
        }

       
        [HttpGet("rechercher")]
        public IActionResult RechercherJeux(string motCle)
        {
            var jeux = _dbContext.Jeux.Where(j => j.Titre.Contains(motCle)).ToList();
            return Ok(jeux);
        }
        
        [HttpGet("genre/{genreId}")]
        public IActionResult RechercherJeuxParGenre(int genreId)
        {
            var jeux = _dbContext.Jeux.Where(j => j.GenreId == genreId).ToList();
            return Ok(jeux);
        }
    }
}
