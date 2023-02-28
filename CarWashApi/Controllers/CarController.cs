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
    public class CarController : ControllerBase
    {
        private readonly ICar _car;


        public CarController(ICar car)
        {
            _car = car;

        }
        //To display all cars
        #region


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetAll()
        {
            var cars = await _car.GetAll();
            if (cars == null)
            {
                return NotFound();
            }
            return Ok(cars);
        }
        #endregion

        // To get car by Id
        #region
        [HttpGet("{Id}")]
        public async Task<ActionResult<User>> GetbyId(int Id)
        {
            var c = await _car.GetById(Id);
            if (c == null)
            {
                return NotFound();
            }

            return Ok(c);
        }
        #endregion

        //to add cars
        #region
        [HttpPost]
        public async Task<ActionResult<Car>> AddCar(Car car)
        {

            var add = await _car.Add(car);
            return Ok(new
            {
                Message = "Package Added"
            });

        }
        #endregion

        // To Update car
        #region
        [HttpPut("{Id}")]
        public async Task<ActionResult> UpdateCar(int Id, Car car)
        {

            var cars = await _car.Update(Id, car);
            return CreatedAtAction(nameof(GetbyId), new { id = cars.Id }, cars);
        }
        #endregion

        //To Delete car
        #region

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteCar(int Id)
        {
            await _car.Delete(Id);
            return Ok();
        }
        #endregion


    }
}
