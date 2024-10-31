using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;
using projectNaomi.model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace projectNaomi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RegisterController : ControllerBase
    {
        private static List<Registers> listRegisterents = new List<Registers>{
                new Registers { id="12",name="shaul",age=19,codeTrip="123" ,status=true},
                new Registers  { id="23",name="chaim",age=39,codeTrip="234" ,status=true}
            };

        public RegisterController()
        {

        }
        // GET: api/<RegisterController>
        [HttpGet]
        public IEnumerable<Registers> Get()
        {
            return listRegisterents;
        }

        // GET api/<RegisterController>/5
        [HttpGet("{id}")]
        public Registers Get(int id)
        {
            var index = listRegisterents.FindIndex(e => e.id.Equals(id));
            if (index != -1)
                return listRegisterents[index];
            return null;
        }

        // POST api/<RegisterController>
        [HttpPost]
        public Registers Post([FromBody] Registers register)
        {
            listRegisterents.Add(register);
            return register;
        }

        // PUT api/<RegisterController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Registers register)
        {
            var index = listRegisterents.FindIndex(e => e.id.Equals(id));
            listRegisterents[index].id = register.id;
            listRegisterents[index].name = register.name;
            listRegisterents[index].age = register.age;
            listRegisterents[index].codeTrip = register.codeTrip;

        }

        // DELETE api/<RegisterController>/5
        [HttpDelete("{id}")]
        public void changeStatus(int id)
        {
            var index = listRegisterents.FindIndex(e => e.id.Equals(id));
            listRegisterents[index].status = false;
        }
    }
}
