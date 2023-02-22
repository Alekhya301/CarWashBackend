using CarWashApi.Models;
using CarWashApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IPackage _package;


        public PackageController(IPackage package)
        {
            _package = package;

        }
        //To display all packages
        #region

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Packages>>> GetAll()
        {
            var packs = await _package.GetAll();
            if (packs == null)
            {
                return NotFound();
            }
            return Ok(packs);
        }
        #endregion

        // To get package by Id
        #region
        [HttpGet("{Id}")]
        public async Task<ActionResult<User>> GetbyId(int Id)
        {
            var p = await _package.GetById(Id);
            if (p == null)
            {
                return NotFound();
            }

            return Ok(p);
        }
        #endregion

        //to add packages 
        #region
        [HttpPost]
        public async Task<ActionResult<User>> AddPackage(Packages package)
        {

            var add = await _package.Add(package);
            return Ok(new
            {
                Message = "Package Added"
            });
          
        }
        #endregion

        // To Update Package
        #region
        [HttpPut]
        public async Task<ActionResult> UpdatePackage(int Id, Packages package)
        {

            var pac = await _package.Update(Id, package);
            return CreatedAtAction(nameof(GetbyId), new { id = pac.Id }, pac);
        }
        #endregion

        //To Delete Package
        #region

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeletePackage(int Id)
        {
            await _package.Delete(Id);
            return Ok();
        }
        #endregion


    }
}
