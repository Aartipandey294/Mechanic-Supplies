using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PartsAPI.Data;
using PartsAPI.Models;

namespace PartsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartsController : ControllerBase
    {
        private readonly InMemoryDataStore _dataStore;

        public PartsController(InMemoryDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        [HttpGet]
        public IActionResult GetParts()
        {
            return Ok(_dataStore.Parts);
        }

        [HttpPost]
        public IActionResult AddPart([FromBody] Part part)
        {
            part.Id = _dataStore.Parts.Max(p => p.Id) + 1;
            _dataStore.Parts.Add(part);
            return Ok(part);
        }
    }
}
