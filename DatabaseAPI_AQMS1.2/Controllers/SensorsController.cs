using DatabaseAPI_AQMS1._2.Data;
using DatabaseAPI_AQMS1._2.Data.Services;
using DatabaseAPI_AQMS1._2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseAPI_AQMS1._2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorsController : ControllerBase
    {
        public ISensorsService _sensorsService;
        private readonly ILogger<SensorsController> _logger;   
        //Controller
        public SensorsController(ISensorsService sensorsService, ILogger<SensorsController> logger)
        {
            _sensorsService = sensorsService;
            _logger = logger;
        }
        // GET: api/<SensorsController>
        [Authorize]
        [HttpGet]
        public IActionResult GetAllSensor()
        {
            _logger.LogInformation("This is a log");
            var allSensorsData = _sensorsService.GetSensors();
            return Ok(allSensorsData);
        }
        
        // GET api/<SensorsController>/5
        //[Authorize]
        [HttpGet("[action]")]

        public IActionResult GetBySpan(int sec)
        {
            var Sensors = _sensorsService.GetBySpan(sec);
            return Ok(Sensors);

        }
        //[Authorize]
        [HttpGet("[action]")]
        
        public IActionResult GetByFlr(int flr)
        {
            var Sensors = _sensorsService.GetByFlr(flr);
            return Ok(Sensors);
        }
        //// POST api/<SensorsController>
        [HttpPost]
        public void Post([FromBody] Sensor sensor)
        {
            _sensorsService.Post(sensor);
        }
        /*
        // PUT api/<SensorsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SensorsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
    
