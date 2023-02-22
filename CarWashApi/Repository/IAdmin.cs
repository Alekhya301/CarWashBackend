using CarWashApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Repository
{
   public  interface IAdmin
    {
        //To get all admin
        Task<List<Admin>> GetAll();

        //to get Admin by Id
        Task<Admin> GetById(int Id);

        //to add admin
        Task<Admin> Add(Admin admin);
        //to Update admin
        Task<Admin> Update(int Id, Admin admin);

        //to delete admin
        Task Delete(int Id);

        //admin login
        Task<Admin> AdminLogin(AdminLogin alogin);

        //to check email validation
        Task<bool> CheckEmailExistAsync(string Email);

    }
}
