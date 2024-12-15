using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SM.CustomerProducer.Application.Interfaces;

using SM.Shared.DTOs.Customer;

namespace SM.CustomerProducer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(IBusService busService) : ControllerBase
    {
        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<CreatedResult> Post([FromBody] RequestCustomerDTO requestCustomerDto)
        {
            await busService.CreateCustomerAsync(requestCustomerDto);
            return Created("/consumers", requestCustomerDto);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
