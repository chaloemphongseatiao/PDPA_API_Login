using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DotnetAPI5.Models;
using DotnetAPI5.Models.Paramenters;
using System.Threading;
using System.Globalization;
using System;
using static DotnetAPI5.Models.Paramenters.PostParamenter;
using PDPA_API.Models;

namespace DotnetAPI5.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsentController : ControllerBase
    {
        private readonly DataPersonalContext _context;

        public ConsentController(DataPersonalContext DbContext)
        {
            _context = DbContext;
        }

        //POST Api เพิ่มข้อมูลค้า PDPA
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<StatusMessage<int?>>> AddPersonal([FromBody] Consent parameters)
        {
            StatusMessage<int?> result = new StatusMessage<int?>();

            try
            {
                Consent newPersonal = new Consent();
                newPersonal.FirstName = parameters.FirstName;
                newPersonal.LastName = parameters.LastName;
                newPersonal.Email = parameters.Email;
                newPersonal.Mobile = parameters.Mobile;
                newPersonal.Period = parameters.Period;
                newPersonal.Favorites = parameters.Favorites;
                newPersonal.DesiredBranch = parameters.DesiredBranch;
                newPersonal.IPAddress = parameters.IPAddress;
                newPersonal.CardNumber = parameters.CardNumber;
                newPersonal.CreateDateTime = DateTime.Now;
                newPersonal.UpdateDateTime = DateTime.Now;
                newPersonal.PostComment = parameters.PostComment;
                newPersonal.CarRegistration = parameters.CarRegistration;
                newPersonal.ChassisNumber = parameters.ChassisNumber;
                newPersonal.ServiceBranch = parameters.ServiceBranch;
                newPersonal.ContactAgency = parameters.ContactAgency;
                _context.Consents.Add(newPersonal);

                //บันทึก Record ลง ตาราง Personal
                await _context.SaveChangesAsync();

                result.data = newPersonal.DPId;
                result.success = true;
                result.message = "Saved";

            }
            catch (Exception ex)
            {
                result.data = null;
                result.message = ex.Message;
                result.success = false;

            }
            return result;
        }


        //POST API ตรวจสอบข้อมูลบัตรประชาชน
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<StatusMessage<int?>>> VerifyIDCard([FromBody] VerifyIDCard parameters)
        {
            StatusMessage<int?> result = new StatusMessage<int?>();

            try
            {
                Consent query = await _context.Consents.Where(x => x.CardNumber == parameters.CardNumber).FirstOrDefaultAsync();

                if (Equals(query, null))
                {
                    result.data = null;

                }
                else
                {
                    result.data = query.DPId;
                }

                result.success = true;

            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = ex.Message;

            }
            return result;

        }


        // GET: ข้อมูลลูกค้าทั้งหมด
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<StatusMessageExt<List<Consent>>>> GetConsentAll([FromBody] SelectConsentList parameters)
        {
            StatusMessageExt<List<Consent>> result = new StatusMessageExt<List<Consent>>();

            try
            {
                var query = await _context.Consents.ToListAsync();

                result.data = query;
                result.success = true;
                result.message = "success";
            }
            catch (Exception ex)
            {
                result.data = null;
                result.success = false;
                result.message = ex.Message;
            }
            return result;
        }



        //POST API ตรวจสอบ เลขบัตรประชาชน,Email,เบอร์โทร ลูกค้า
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<StatusMessage<Consent>>> VerifyCustomerUpdate([FromBody] VerifyUpdate parameters)
        {
            StatusMessage<Consent> result = new StatusMessage<Consent>();

            try
            {
                Consent querycus = await _context.Consents.Where(x => x.CardNumber == parameters.CardNumber && x.Email == parameters.Email && x.Mobile == parameters.Mobile).FirstOrDefaultAsync();

                result.data = querycus;
                result.success = true;
                result.message = "success";

            }
            catch (Exception ex)
            {
                result.data = null;
                result.success = false;
                result.message = ex.Message;

            }
            return result;
        }

        //POST API แก้ไขข้อมูล Profile ลูกค้า
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<StatusMessage<int?>>> UpdateProfileCustomer([FromBody] UpdateConsentProfile parameters)
        {
            StatusMessage<int?> result = new StatusMessage<int?>();

            try
            {
                Consent dataRecord = await _context.Consents.AsNoTracking().Where(x => x.DPId == parameters.DPid).FirstOrDefaultAsync();

                if (Equals(dataRecord, null))
                {
                    throw new Exception("Data Not Found.");
                }
                dataRecord.FirstName = parameters.FirstName;
                dataRecord.LastName = parameters.LastName;
                dataRecord.Email = parameters.Email;
                dataRecord.Mobile = parameters.Mobile;
                dataRecord.Favorites = parameters.Favorites;
                dataRecord.IPAddress = parameters.IPAddress;
                dataRecord.CarRegistration = parameters.CarRegistration;
                dataRecord.ChassisNumber = parameters.ChassisNumber;
                dataRecord.PostComment = parameters.PostComment;
                dataRecord.DesiredBranch = parameters.DesiredBranch;
                dataRecord.UpdateDateTime = DateTime.Now;
                dataRecord.Period = parameters.Period;
                dataRecord.ServiceBranch = parameters.ServiceBranch;
                dataRecord.ContactAgency = parameters.ContactAgency;

                _context.Entry(dataRecord).State = EntityState.Modified;
                var row_changed = await _context.SaveChangesAsync();

                result.data = null;
                result.success = true;
                result.message = "success";
            }
            catch (Exception ex)
            {
                result.data = null;
                result.success = false;
                result.message = ex.Message;
            }
            return result;

        }


    }
}
