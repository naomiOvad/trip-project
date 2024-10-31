using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using projectNaomi.model;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace projectNaomi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuideController : ControllerBase
    {
        private static List<Guide> listGuide = new List<Guide>{
                new Guide {Id="1" ,Name="david" ,status=true },
                new Guide {Id="2" ,Name="dani" ,status=true}
            };
        public GuideController()
        {

        }

        // GET: api/<GuideController>
        [HttpGet]
        public IEnumerable<Guide> Get()
        {
            return listGuide;
        }

        // GET api/<GuideController>/5
        [HttpGet("{id}")]
        public Guide Get(int id)
        {
            var index = listGuide.FindIndex(e => e.Id.Equals(id));
            if(index != -1)
                 return listGuide[index];
            return null;
        }

        // POST api/<GuideController>
        [HttpPost]
        public Guide Post([FromBody] Guide guide)
        {
            listGuide.Add(guide);
            return guide;
        }

        // PUT api/<GuideController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Guide guide)
        {
            var index = listGuide.FindIndex(e => e.Id.Equals(id) );
            listGuide[index].Id = guide.Id;
            listGuide[index].Name = guide.Name;
        }

        // DELETE api/<GuideController>/5
        [HttpDelete("{id}")]
        public void changeStatus(int id)
        {
            var index = listGuide.FindIndex(e => e.Id.Equals(id));
            listGuide[index].status=false;
        }
    }
}
