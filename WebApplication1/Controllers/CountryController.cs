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
        [HttpGet] // annotatie om de tonen welke operatie je gaat doen, altijd nodig
        // api/country
        [HttpHead]
        public IEnumerable<Country> Get([FromQuery]string continent, [FromQuery] string capital) // FromQuery -> niet in pad maar in het "vraagtekentje"
        {
            if(!string.IsNullOrWhiteSpace(continent) && !string.IsNullOrWhiteSpace(capital))
                return repo.GetAll(continent,capital);
            else
                return repo.GetAll();
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
    }
}
