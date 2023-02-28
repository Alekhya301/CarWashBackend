using CarWashApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Repository
{
   public interface IOrders
    {
        //To get all orders
        Task<List<Orders>> GetAll();

        //to get order by Id
        Task<Orders> GetById(int Id);

        //to add order
        Task<Orders> Add(Orders orders);
        //to Update Order
        Task<Orders> Update(int Id, Orders orders);

        //to delete Order
        Task Delete(int Id);

    }
}
