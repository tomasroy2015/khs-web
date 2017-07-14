using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolWebAPI.Services;
using System.Web.Http.Cors;

namespace SchoolWebAPI.Controllers
{
    [EnableCors("*","*","*")]
    public class SmsController : ApiController
    {
        [Route("sms/sendSms")]
        [HttpGet]
        public HttpResponseMessage SendSms()
        {
            try
            {
                
                return Request.CreateResponse(HttpStatusCode.OK, "Sent");
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
