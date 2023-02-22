using CarWashApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Repository
{
   public interface IPackage
    {
        //To get all packages
        Task<List<Packages>> GetAll();

        //to get package by Id
        Task<Packages> GetById(int Id);

        //to add package
        Task<Packages> Add(Packages package);
        //to Update Package
        Task<Packages> Update(int Id, Packages package);

        //to delete package
        Task Delete(int Id);

        
    }
}
