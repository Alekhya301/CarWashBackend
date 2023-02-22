using CarWashApi.Models;
using CarWashApi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarWashApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdmin _admin;


        public AdminController(IAdmin admin)
        {
            _admin = admin;

        }
        //To display all admins
        #region

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var admin = await _admin.GetAll();
            if (admin == null)
            {
                return NotFound();
            }
            return Ok(admin);
        }
        #endregion

        // To get Admin by Id
        #region
        [HttpGet("{Id}")]
        public async Task<ActionResult<Admin>> GetbyId(int Id)
        {
            var admin = await _admin.GetById(Id);
            if (admin == null)
            {
                return NotFound();
            }

            return Ok(admin);
        }
        #endregion

        // admin Login Method
        #region
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] AdminLogin alogin)
        {
            if (alogin == null)
            {
                return BadRequest();
            }
            var a = await _admin.AdminLogin(alogin);
            if (a == null)
            {
                return NotFound(new { Message = "Admin not found" });
            }
            //return Ok(new
            //{
            //    Message="Login successful!"
            //});

            string Token = CreateJwtToken(a);
            return Ok(new
            {
                Token,
                Message = " Admin Login Successfull...:)"
            });





        }
        #endregion

        //Register Method 
        #region
        [HttpPost]
        public async Task<ActionResult<Admin>> AddAdmin(Admin admin)
        {

            if (admin != null)
            {

                // check Email
                if (await _admin.CheckEmailExistAsync(admin.Email))
                {
                    return BadRequest(new { Message = "Email alredy exists...!" });
                }

            }
            var add = await _admin.Add(admin);
            return Ok(new
            {
                Message = "Registration Successfull"
            });
            if (admin == null)
            {
                return BadRequest();
            }

        }
        #endregion

        // To Update admin
        #region
        [HttpPut]
        public async Task<ActionResult> Update(int Id, Admin admin)
        {

            var users = await _admin.Update(Id, admin);
            return CreatedAtAction(nameof(GetbyId), new { id = users.Id }, users);
        }
        #endregion

        //To Delete Admin
        #region

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            await _admin.Delete(Id);
            return Ok();
        }
        #endregion

        //to valiadte user email
        #region
        private async Task<ActionResult> CheckEmailExistAsync(string Email)
        {
            var check = await _admin.CheckEmailExistAsync(Email);
            return Ok();


        }
        #endregion

        //jwt token create
        #region
        private string CreateJwtToken(Admin jwt)
        {
            var jwtTokenhandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("ververysecret.....");
            var identity = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, jwt.Email)
                     
                });
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
            var Tokendescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };
            var token = jwtTokenhandler.CreateToken(Tokendescriptor);
            return jwtTokenhandler.WriteToken(token);
        }
        #endregion


    }
}
