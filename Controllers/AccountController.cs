using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using DotnetAPI5.Models;
using DotnetAPI5.Models.Paramenters;
using Microsoft.AspNetCore.Authorization;
using static DotnetAPI5.Models.Paramenters.PostParamenter;
using System.Security.Cryptography;
using PDPA_API.Models;

namespace DotnetAPI5.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly DataPersonalContext _context;


        public AccountController(IConfiguration config, DataPersonalContext context)
        {
            _config = config;
            _context = context;

        }
        // API สร้าง User และ เอารหัสผ่านไปเข้ารหัส
        //[HttpPost]
        //[Route("[action]")]
        //public async Task<ActionResult<StatusMessage<Account>>> CreateUserAccount([FromBody] Account parameters)
        //{
        //    StatusMessage<Account> result = new StatusMessage<Account>();

        //    try
        //    {
        //        //สร้าง Object รับค่าใหม่
        //        Account newuser = new Account();
        //        newuser.Username = parameters.Username;
        //        newuser.Password = parameters.Password;
        //        newuser.FullName = parameters.FullName;
        //        newuser.CreateDateTime = DateTime.Now;

        //        // บันทึกข้อมูล Account             
        //        _context.Accounts.Add(newuser);
        //        await _context.SaveChangesAsync();

        //        result.data = newuser;
        //        result.success = true;
        //        result.message = "success";
        //    }
        //    catch (Exception ex)
        //    {
        //        result.data = null;
        //        result.success = false;
        //        result.message = ex.Message;
        //    }
        //    return result;

        //}


        // API Login เข้าใช้งานสำหรับ Admin    
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<StatusMessage<Account>>> LoginAccount([FromBody] LoginAccounts parameters)
        {
            StatusMessage<Account> result = new StatusMessage<Account>();

            try
            {
                Account loginst = await _context.Accounts.Where(x => x.Username == parameters.Username && x.Password == parameters.Password).FirstOrDefaultAsync();

                result.data = loginst;
                result.success = true;
                result.message = "success";
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = ex.Message;
            }
            return result;

        }


      




    }
}
