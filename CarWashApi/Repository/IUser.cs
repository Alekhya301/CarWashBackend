using CarWashApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Repository
{
   public interface IUser
    {
        //To get all users
        Task<List<User>> GetAll();

        //to get user by Id
        Task<User> GetById(int Id);

        //to get user by Id
        Task<User> GetByEmail(string Email);
        //to add user
        Task<User> Add(User user);
        //to Update user
        Task<User> Update(int Id, User user);

        //to delete user
        Task Delete(int Id);

        //login user
        Task<User> Login(Login login);

        //to check email validation
        Task<bool> CheckEmailExistAsync(string Email);

        
    }
}
