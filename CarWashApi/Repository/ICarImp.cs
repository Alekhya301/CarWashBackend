using CarWashApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Repository
{
    public class ICarImp : ICar
    {
        private readonly Context _context;


        public ICarImp(Context context)
        {
            _context = context;
        }

        //To get all cars
        #region
        public async Task<List<Car>> GetAll()
        {
            try
            {
                var car = await _context.Car.ToListAsync();
                return car;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        //To get car by Id
        #region

        public async Task<Car> GetById(int Id)
        {
            try
            {
                var car = await _context.Car.FindAsync(Id);
                return car;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        //To add car
        #region

        public async Task<Car> Add(Car car)
        {


            try
            {
                var add = _context.Car.Add(car);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }


            return car;
        }
        #endregion

        //To update car
        #region

        public async Task<Car> Update(int Id, Car car)
        {

            var post = await _context.Car.FindAsync(Id);
            if (post != null)
            {
                post.CarModel = car.CarModel;
     
                post.Status = car.Status;


                await _context.SaveChangesAsync();
            }
            return post;

        }
        #endregion

        //To delete car
        #region
        public async Task Delete(int Id)
        {


            try
            {
                var delete = await _context.Car.FindAsync(Id);
                _context.Car.Remove(delete);
                await _context.SaveChangesAsync();

            }
            catch
            {
                throw;
            }


        }
        #endregion
    }
}
