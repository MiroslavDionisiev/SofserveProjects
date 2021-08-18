using System;
using System.ComponentModel.DataAnnotations;

namespace AzureApi
{
    public class Customer
    {
        public int Id {get; set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Range(1, int.MaxValue)]
        public int Age { get; set; }
    }
}
