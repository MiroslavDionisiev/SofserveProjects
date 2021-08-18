using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AzureApi.Controllers
{
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private List<Customer> listCustomers;

        public CustomerController()
        {
            this.listCustomers = new List<Customer>
            {
                new Customer(){ Id = 1, FirstName="Peter", LastName="Moore", Age=35},
                new Customer(){ Id = 2, FirstName="John", LastName="Doe", Age=36},
                new Customer(){ Id = 3, FirstName="Mary", LastName="Parker", Age=27},
                new Customer(){ Id = 4, FirstName="Robert", LastName="Dane", Age=30},
                new Customer(){ Id = 5, FirstName="Judith", LastName="Jones", Age=29}
            };
        }

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return this.listCustomers;
        }

        [HttpGet("{leftBoundarry:int}&{rightBoundarry:int}")]
        public IEnumerable<Customer> Get(int leftBoundarry, int rightBoundarry)
        {
            return this.listCustomers.Where(c => c.Age >= leftBoundarry && c.Age <= rightBoundarry);
        }
    }
}
