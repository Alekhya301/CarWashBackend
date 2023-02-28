using CarWashApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Repository
{
    public class OrderImp : IOrders
    {
        private readonly Context _context;


        public OrderImp(Context context)
        {
            _context = context;
        }

        //To get all cars
        #region
        public async Task<List<Orders>> GetAll()
        {
            try
            {
                var order = await _context.Orders.ToListAsync();
                return order;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        //To get order by Id
        #region

        public async Task<Orders> GetById(int Id)
        {
            try
            {
                var order = await _context.Orders.FindAsync(Id);
                return order;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        //To add orders
        #region

        public async Task<Orders> Add(Orders orders)
        {


            try
            {
                var add = _context.Orders.Add(orders);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }


            return orders;
        }
        #endregion

        //To update orders
        #region

        public async Task<Orders> Update(int Id, Orders orders)
        {

            var ord = await _context.Orders.FindAsync(Id);
            if (ord != null)
            {
                ord.WashingInstructions = orders.WashingInstructions;
                    ord.Date = orders.Date;
                ord.Status = orders.Status;
                ord.PackageName = orders.PackageName;
                ord.Price = orders.Price;
                ord.City = orders.City;
                ord.Pincode = orders.Pincode;

                await _context.SaveChangesAsync();
            }
            return orders;

        }
        #endregion

        //To delete order
        #region
        public async Task Delete(int Id)
        {


            try
            {
                var order = await _context.Orders.FindAsync(Id);
                _context.Orders.Remove(order);
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
