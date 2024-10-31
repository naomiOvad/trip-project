using Microsoft.AspNetCore.Mvc;
using projectNaomi.model;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace projectNaomi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {

        private static List<Trip> trips = new List<Trip>{
                new Trip {code="1",location="bney brak",date=DateTime.Today,numRegisters=5, idGuide="123"},
                new Trip {code="2",location="tel aviv",  date=DateTime.Today,numRegisters=8,idGuide ="123" }
            };
        public TripController()
        {

        }

        // GET: api/<TripController>
        [HttpGet]
        public IEnumerable<Trip> Get()
        {
            return trips;
        }

        // GET api/<TripController>/5
        [HttpGet("{id}")]
        public Trip Get(int code)
        {
            var index = trips.FindIndex(e => e.code.Equals(code));
            if (index != -1)
                return trips[index];
            return null;
        }

        // POST api/<TripController>
        [HttpPost]
        public Trip Post([FromBody] Trip trip)
        {
            trips.Add(trip);
            return trip;
        }

        // PUT api/<TripController>/5
        [HttpPut("{id}")]
        public void Put(int code, [FromBody] Trip trip)
        {
            var index = trips.FindIndex(e => e.code.Equals(code));
            trips[index].code = trip.code;
            trips[index].location =trip.location ;
            trips[index].date =trip.date ;
            trips[index].numRegisters =trip.numRegisters;
            trips[index].idGuide =trip.idGuide;
        }

        // DELETE api/<TripController>/5
        [HttpDelete("{id}")]
        public void Delete(int code)
        {
            var index = trips.FindIndex(e => e.code.Equals(code));
            if(index != -1)
                trips.RemoveAt(index);
        }
    }
}
