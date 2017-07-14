using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolWebAPI.Models;
using System.Data.Entity;

namespace SchoolWebAPI.Services
{
    public class StudentService
    {
        public string Save(StudentModel model)
        {
            var entity = new SchoolDBEntities();
            var result = from std in entity.Students
                         where std.Name == model.Name && std.Batch == model.Batch
                         select std;
            if (result != null && result.ToList().Count > 0)
                throw new Exception("You already registered.");

            var result1 = from std in entity.Students
                          where std.Email == model.Email
                          select std;
            if (result1 != null && result1.ToList().Count > 0)
                throw new Exception("This email is already used by someone else.");

            var student = new Student();
            student.Name = model.Name;
            student.Email = model.Email;
            student.Batch = model.Batch;
            student.Mobile = model.Mobile;
            student.PermanentAddress = model.PermanentAddress;
            student.PresentAddress = model.PresentAddress;
            
            entity.Students.Add(student);
            entity.SaveChanges();
            var id = student.ID; 
            var registrationNo = model.Batch + DateTime.Today.Day.ToString() + DateTime.Today.Month.ToString() + id.ToString();

            student.RegistrationNo = registrationNo;
            entity.Entry(student).State = EntityState.Modified;
            entity.SaveChanges();
            
            return registrationNo;
        }
    }
}