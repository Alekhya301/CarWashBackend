using CarWashApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Repository
{
   public interface ICar
    {
        //To get all car
        Task<List<Car>> GetAll();

        //to get car by Id
        Task<Car> GetById(int Id);

        //to add car
        Task<Car> Add(Car car);
        //to Update car
        Task<Car> Update(int Id, Car car);

        //to delete car
        Task Delete(int Id);
    }
}
