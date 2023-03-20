using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Model;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        public static List<SuperHero> heroes = new List<SuperHero>
            {
                new SuperHero { Id = 1, Name = "Spider Man", FirstName = "Peter", LastName = "Parker", Place = "New York City"},
                new SuperHero { Id = 2, Name = "Super Man", FirstName = "Philip", LastName = "Chukwma", Place = "South Shields"}
            };

        private readonly DataContext _context;
        public SuperHeroController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get(int id)
        {

            return Ok(heroes);
        }


        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> Add(SuperHero hero)
        {
            heroes.Add(hero);
            return Ok(heroes);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<List<SuperHero>>> GetById(int id)
        {
            var hero = heroes.Find(x => x.Id == id);
            if (hero == null)
            {
                return BadRequest("hero not found!");
            }
            return Ok(hero);
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> Update(SuperHero superHero)
        {
            var hero = heroes.Find(x => x.Id == superHero.Id);
            if (hero == null)
            {
                return BadRequest("hero not found");
            }

            hero.Name = superHero.Name;
            hero.FirstName = superHero.FirstName;
            hero.LastName = superHero.LastName;
            hero.Place = superHero.Place;
            return Ok(heroes);

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Delete(int id)
        {
            var hero = heroes.Find(x => x.Id==id);
            if (hero == null)
                return BadRequest("Hero not found");
            heroes.Remove(hero);
            return Ok(heroes);

        }


    }
}
