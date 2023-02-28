using CarWashApi.Models;
using CarWashApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrders _orders;


        public OrdersController(IOrders orders)
        {
            _orders = orders;

        }
        //To display all orders
        #region


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orders>>> GetAll()
        {
            var ords = await _orders.GetAll();
            if (ords == null)
            {
                return NotFound();
            }
            return Ok(ords);
        }
        #endregion

        // To get order by Id
        #region
        [HttpGet("{Id}")]
        public async Task<ActionResult<Orders>> GetbyId(int Id)
        {
            var o = await _orders.GetById(Id);
            if (o == null)
            {
                return NotFound();
            }

            return Ok(o);
        }
        #endregion

        //to add orders 
        #region
        [HttpPost]
        public async Task<ActionResult<Orders>> AddOrders( Orders orders)
        {

            var add = await _orders.Add(orders);
            return Ok(new
            {
                Message = "Order Placed"
            });

        }
        #endregion

        // To Update order
        #region

        [HttpPut("{Id}")]
        public async Task<ActionResult> UpdateOrder(int Id, Orders orders)
        {

            var pac = await _orders.Update(Id, orders);
            return CreatedAtAction(nameof(GetbyId), new { id = pac.Id }, pac);
        }
        #endregion

        //To Delete Package
        #region

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteOrder(int Id)
        {
            await _orders.Delete(Id);
            return Ok();
        }
        #endregion
    }
}
