using CarWashApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Repository
{
    public class PackageImp : IPackage
    {
        private readonly Context _context;


        public PackageImp(Context context)
        {
            _context = context;
        }

        //To get all packages
        #region
        public async Task<List<Packages>> GetAll()
        {
            try
            {
                var package = await _context.Packages.ToListAsync();
                return package;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        //To get package by Id
        #region

        public async Task<Packages> GetById(int Id)
        {
            try
            {
                var package = await _context.Packages.FindAsync(Id);
                return package;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        //To add package
        #region

        public async Task<Packages> Add(Packages package)
        {


            try
            {
                var add = _context.Packages.Add(package);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }


            return package;
        }
        #endregion

        //To update package
        #region

        public async Task<Packages> Update(int Id, Packages package)
        {

            var pack = await _context.Packages.FindAsync(Id);
            if (pack != null)
            {
                pack.Name = package.Name;
                pack.Description = package.Description;
                pack.Price = package.Price;
                pack.Status = package.Status;


                await _context.SaveChangesAsync();
            }
            return pack;

        }
        #endregion

        //To delete package
        #region
        public async Task Delete(int Id)
        {


            try
            {
                var package = await _context.Packages.FindAsync(Id);
                _context.Packages.Remove(package);
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
