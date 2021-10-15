using System;
using System.Collections.Generic;
using System.Text;

namespace Week4.EsFinale.Core.Models
{
    public class Order
    {
        //Aggiungere proprietà dell'ordine

        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderCode { get; set; }
        public string ProductCode { get; set; }
        public decimal Price { get; set; }

      
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

    }
}
