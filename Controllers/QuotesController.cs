using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuotesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesApi.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        static List<Quote> quotes = new List<Quote>()
        {
            new Quote(){Id=0, Title="Imagination", Author="Einstein", Description="Imagination is more imporant than knowledge"},
            new Quote(){Id=1, Title="Alive in the morning", Author="Tom Hardy", Description="If we still alive in the morning we'll know we are not dead"},
            new Quote(){Id=2, Title="Bed of roses", Author="James Franchio", Description="Life is not a bed of roses"}
        };

        [HttpGet]
        public IEnumerable<Quote> Get()
        {
            return quotes;
        }

        [HttpPost]
        public void Post([FromBody] Quote quote)
        {
            quotes.Add(quote);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Quote quote)
        {
            quotes[id] = quote;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            quotes.RemoveAt(id);
        }
    }
}
