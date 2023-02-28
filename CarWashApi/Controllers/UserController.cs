using CarWashApi.Models;
using CarWashApi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
    public class UserController : ControllerBase
    {
        private readonly IUser _user;
       

        public UserController(IUser user)
        {
            _user = user;
            
        }
        //To display all users
        #region
        
       [Authorize]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var users = await _user.GetAll();
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }
        #endregion

        // To get user by Id
        #region
        [HttpGet("{Id}")]
        public async Task<ActionResult<User>> GetbyId(int Id)
        {
            var users = await _user.GetById(Id);
            if (users == null)
            {
                return NotFound();
            }
           
            return Ok(users);
        }
        #endregion

        //get user by Email
        #region
        //[HttpGet("{Email}")]
        //public async Task<ActionResult<User>> GetbyEmail(string Email)
        //{
        //    var users = await _user.GetByEmail(Email);
        //    if (users == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(users);
        //}
        #endregion

        //Login Method
        #region
        [HttpPost("authenticate")]
        public async Task<ActionResult> Authenticate([FromBody] Login login)
        {
           if(login == null )
            {
                return BadRequest();
            }
            var u = await _user.Login(login);
            if(u == null)
            {
                return NotFound(new { Message = "User not found" });
            }
            //return Ok(new
            //{
            //    Message="Login successful!"
            //});

            string Token = CreateJwtToken(u);
            return Ok(new
            {
                Token,
                Message = "Login Successfull...:)"
            });





        }
        #endregion

        //Register Method 
        #region
        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User user)
        {
           
          if(user != null)
            {
                
                // check Email
                if(await _user.CheckEmailExistAsync(user.Email))
                {
                    return BadRequest(new { Message = "Email alredy exists...!" });
                }

            }
            var add = await _user.Add(user);
            return Ok(new
            {
                Message = "Registration Successfull"
            });
            if(user == null)
            {
                return BadRequest();
            }
                
        }
        #endregion

        // To Update User
        #region
        [HttpPut("{Id}")]
        public async Task<ActionResult> UpdateUser(int Id, User user)
        {

            var users = await _user.Update(Id, user);
            return CreatedAtAction(nameof(GetbyId), new { id = users.Id }, users);
        }
        #endregion

        //To Delete User
        #region

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteUser(int Id)
        {
            await _user.Delete(Id);
            return Ok();
        }
        #endregion

        //to valiadte user email
        #region
        private async Task<ActionResult> CheckEmailExistAsync(string Email)
        {
              var check =   await _user.CheckEmailExistAsync(Email);
               return Ok();

            
        }
        #endregion

        //jwt token create
        #region
        private string CreateJwtToken(User jwt)
        {
            var jwtTokenhandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("ververysecret.....");
            var identity = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Role, jwt.Role),
                     new Claim(ClaimTypes.Name, $"{jwt.FirstName} {jwt.LastName}")
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


