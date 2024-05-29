using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApiCore.EF;
using WebApiCore.Models;
using WebApiCore.Models.Response;
using WebApiCore.Services.Interfaces;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _ICustomerService;
        private readonly AppSettings _optionsMonitor;

        public CustomersController(ICustomerService ICustomerService, IOptionsMonitor<AppSettings> optionsMonitor)
        {
            _ICustomerService = ICustomerService;
            _optionsMonitor = optionsMonitor.CurrentValue;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] CustomerModel customer)
        {
            try
            {
                var data = await _ICustomerService.Login(customer);
                if (data != null)
                    return Ok(new ResponseModel()
                    {
                        Success = true,
                        Message = "Login Success",
                        Data = GenerateToken(data),
                    });
                else
                    return Ok(new ResponseModel()
                    {
                        Success = true,
                        Message = "UserName or Password incorrect",
                        Data = null,
                    });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel()
                {
                    Success = false,
                    Message = ex.ToString()
                });
            }
        }
        private string GenerateToken(Customer customer)
        {
            var jwtTokenHandle = new JwtSecurityTokenHandler();
            var secretKeyByte = Encoding.UTF8.GetBytes(_optionsMonitor.ScretKey);
            var tokenDecryption = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, customer.UserName),
                    new Claim(ClaimTypes.Email, customer.Email),
                    new Claim("tokenId", Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyByte), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = jwtTokenHandle.CreateToken(tokenDecryption);
            return jwtTokenHandle.WriteToken(token);
        }
    }
}
