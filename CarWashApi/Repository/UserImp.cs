using CarWashApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Repository
{
    public class UserImp : IUser
    {
        private readonly Context _context;


        public UserImp(Context context)
        {
            _context = context;
        }

        //To get all users
        #region
        public async Task<List<User>> GetAll()
        {
            try
            {
                var user = await _context.Users.ToListAsync();
                return user;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        //To get user by Id
        #region

        public async Task<User> GetById(int Id)
        {
            try
            {
                var user = await _context.Users.FindAsync(Id);
                return user;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        //to get user by email
        #region

        public async Task<User> GetByEmail(string Email)
        {
            try
            {
                var user = await _context.Users.FindAsync(Email);
                return user;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        //To add user
        #region

        public async Task<User> Add(User user)
        {

            
            try
            {
                var add = _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }


            return user;
        }
        #endregion

        //To update user
        #region

        public async Task<User> Update(int Id, User user)
        {

            var cus = await _context.Users.FindAsync(Id);
            if (cus != null)
            {
                cus.FirstName = user.FirstName;
                cus.LastName = user.LastName;
                cus.Password = user.Password;
                cus.PhoneNumber = user.PhoneNumber;
                cus.Role = user.Role;
                cus.Email = user.Email;
                cus.IsActive = user.IsActive;


                await _context.SaveChangesAsync();
            }
            return cus;

        }
        #endregion

        //To delete user
        #region
        public async Task Delete(int Id)
        {
            

            try
            {
                var user = await _context.Users.FindAsync(Id);
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
               
            }
            catch
            {
                throw;
            }
           

        }
        #endregion

        //Login User
        #region
        public async Task<User> Login(Login login)
        {
            

                var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == login.Email && x.Password == login.Password && x.Role == login.Role);
                if(user == null)
                {
                    return null;
                }



            return user;
        }
        #endregion

        //To check email exists or not
        #region

        public async Task<bool> CheckEmailExistAsync(string Email)
        {
            var check =  await _context.Users.AnyAsync(x => x.Email == Email);
            return check;
         
        }
        #endregion
    }
}
