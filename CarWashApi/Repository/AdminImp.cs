using CarWashApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Repository
{
    public class AdminImp : IAdmin
    {
        private readonly Context _context;


        public AdminImp(Context context)
        {
            _context = context;
        }
        //To get all admin
        #region
        public async Task<List<Admin>> GetAll()
        {
            try
            {
                var admin = await _context.Admin.ToListAsync();
                return admin;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        //To get admin by Id
        #region

        public async Task<Admin> GetById(int Id)
        {
            try
            {
                var admin = await _context.Admin.FindAsync(Id);
                return admin;
            }
            catch
            {
                throw;
            }
        }
        #endregion

      
      

        //To add admin
        #region

        public async Task<Admin> Add(Admin admin)
        {


            try
            {
                var add = _context.Admin.Add(admin);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }


            return admin;
        }
        #endregion

        //To update admin
        #region

        public async Task<Admin> Update(int Id, Admin admin)
        {

            var update = await _context.Admin.FindAsync(Id);
            if (update != null)
            {
                update.Email = admin.Email;
                update.Password = admin.Password;


                await _context.SaveChangesAsync();
            }
            return update;

        }
        #endregion

        //To delete admin
        #region
        public async Task Delete(int Id)
        {


            try
            {
                var delete = await _context.Admin.FindAsync(Id);
                _context.Admin.Remove(delete);
                await _context.SaveChangesAsync();

            }
            catch
            {
                throw;
            }


        }
        #endregion

        //Adminn Login 
        #region
        public async Task<Admin> AdminLogin(AdminLogin alogin)
        {


            var admin = await _context.Admin.FirstOrDefaultAsync(x => x.Email == alogin.Email && x.Password == alogin.Password);
            if (admin == null)
            {
                return null;
            }



            return admin;
        }
        #endregion

        //To check email exists or not
        #region

        public async Task<bool> CheckEmailExistAsync(string Email)
        {
            var check = await _context.Admin.AnyAsync(x => x.Email == Email);
            return check;

        }
        #endregion
    }
}
