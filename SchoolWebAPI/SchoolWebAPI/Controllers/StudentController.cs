using SchoolWebAPI.Models;
using SchoolWebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SchoolWebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class StudentController : ApiController
    {
        [Route("student/registration")]
        [HttpPost]
        public HttpResponseMessage Register(StudentModel model)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    var result =  new StudentService().Save(model);
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid data model");
                }
            }            
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
