using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")] // pad
    [ApiController]
    public class CountryController : ControllerBase
    {
        private ICountryRepository repo;

        public CountryController(ICountryRepository repo)
        {
            this.repo = repo;
        }
        //[HttpGet] // annotatie om de tonen welke operatie je gaat doen, altijd nodig
        //// api/country
        //[HttpHead]
        //public IEnumerable<Country> Get([FromQuery]string continent, [FromQuery] string capital) // FromQuery -> niet in pad maar in het "vraagtekentje"
        //{
        //    if(!string.IsNullOrWhiteSpace(continent) && !string.IsNullOrWhiteSpace(capital))
        //        return repo.GetAll(continent,capital);
        //    else
        //        return repo.GetAll();
        //}

        [HttpGet]
        public ActionResult<List<Country>> GetAll()
        {
            return Ok(repo.GetAll());
        }
        //[HttpGet("{id}")]
        // api/country/2
        //public Country Get(int id)
        //{
           // try {
            //return repo.GetCountry(id);
            //}
            //catch (Exception e)
            //{
              //  Response.StatusCode = 400;
               // return null;
            //}
        //}

        //[HttpGet("{id}")]

        //public IActionResult Get (int id)
        //{
        //    try
        //    {
        //        return Ok(repo.GetCountry(id));
        //    }
        //    catch (Exception e)
        //    {
        //        return NotFound();
        //    }
        //}
        [HttpGet("{id}")]

        public ActionResult<Country> Get(int id)
        {
            try
            {
                return repo.GetCountry(id);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPost]
        public ActionResult<Country> Post([FromBody] Country country)
        {
            repo.AddCountry(country);
            return CreatedAtAction(nameof(Get),new { id = country.Id }, country); // de nameof(get) zorgt ervoor dat je in de response de URL krijgt om het object op te roepen, de new (id) is de parameter die je meegeeft
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!repo.ExistsCountry(id))
            {
                return NotFound();
            }
            repo.RemoveCountry(repo.GetCountry(id));
            return NoContent();
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id,[FromBody] Country country)
        {
            if (country == null || country.Id != id)
                return BadRequest();
            if (!repo.ExistsCountry(id))
            {
                repo.AddCountry(country);
                return CreatedAtAction(nameof(Get), new { id = country.Id }, country); // toegevoegd object returnen
            }
            repo.UpdateCountry(country);
            return NoContent();
        }
        // patch voorbeeld zie core_verbs (hoeft niet te kennen)
        [Route("start/{id:int=3}")] // http://localhost:5143/api/Country/start/2 zoekt country met id 2 op
        [Route("begin/{id:int=2}")] // meerdere routes kunnen naar 1 methode wijzen
        public IActionResult Start(int id)
        {
            return Ok(repo.GetCountry(id));
        }
    }
}