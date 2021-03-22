using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Data;
using Model;

namespace WebAPI.Controllers
{
    public class PizzaController : ApiController
    {
        public IEnumerable<Pizza> Get()
        {
            return new PizzaDB().Select();
        }

        public bool Post([FromBody] Pizza pizza)
        {
            return new PizzaDB().Insert(pizza);
        }
    }
}