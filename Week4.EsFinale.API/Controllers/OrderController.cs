using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week4.EsFinale.Core.Interfaces;
using Week4.EsFinale.Core.Models;

namespace Week4.EsFinale.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMainBL mainBusinessLayer;

        public OrderController(IMainBL mainBusinessLayer)
        {
            this.mainBusinessLayer = mainBusinessLayer;
        }


        // GET: api/Order
        [HttpGet]
        public IActionResult GetOrders()
        {
            var orders = mainBusinessLayer.FetchOrders();
            return Ok(orders);
        }

        // GET api/Order/5
        [HttpGet("{id}")]
        public IActionResult GetOrderBy(int id)
        {
            if (id <= 0)
                return BadRequest("Id ordine non valido");

            Order order = mainBusinessLayer.GetOrderById(id);
            if (order == null)
                return NotFound("Ordine non trovato");


            return Ok(order);
        }

        // POST api/order
        [HttpPost]
        public IActionResult PostOrder([FromBody] Order order)
        {
            if (order == null)
                return BadRequest("Dati del nuovo ordine non validi");

            bool isAdded = mainBusinessLayer.CreateOrder(order);
            if (!isAdded)
                return StatusCode(500, "Il nuovo ordine non può essere salvato");

            return CreatedAtAction("PostOrder", order);
        }

        // PUT api/Order/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Order order)
        {
            if (id <= 0 || order == null)
                return BadRequest("Ordine non valido");

            if (id != order.Id)
                return BadRequest("Gli id non combaciano");

            bool isUpdated = mainBusinessLayer.EditOrder(order);
            if (!isUpdated)
                return BadRequest("Ordine non modificato");

            return Ok(order);
        }

        // DELETE api/order/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Order orderToDelete = mainBusinessLayer.GetOrderById(id);
            if (id <= 0 || orderToDelete == null)
                return BadRequest("Id ordine non valido");
            

            bool isDeleted = mainBusinessLayer.DeleteOrder(orderToDelete);
            if (!isDeleted)
                return BadRequest("Ordine non cancellato");


            return Ok();
        }

        
    }
}
