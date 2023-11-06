using ClassApiShowCase.Class;
using ClassApiShowCase.Repos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClassApiShowCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmmoTypeRepoController : ControllerBase
    {

        private AmmoRepo _ammoRepo;

        // GET: api/<AmmoTypeRepoController>
        [HttpGet]
        public Dictionary<string, AmmoType> GetAll()
        {
            return _ammoRepo.GetAll();
        }

        // GET api/<AmmoTypeRepoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AmmoTypeRepoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AmmoTypeRepoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AmmoTypeRepoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
