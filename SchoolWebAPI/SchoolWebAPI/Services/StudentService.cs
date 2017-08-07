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
                          where std.Email == model.Email && model.Email != null && model.Email != string.Empty
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
        public List<StudentViewModel> GetStudents()
        {
            var entity = new SchoolDBEntities();
            List<StudentViewModel> _students = new List<StudentViewModel>();
           var result = from std in entity.Students
                         select std;
            if (result != null)
            {
                foreach (var s in result.ToList())
                {
                    var std = new StudentViewModel();
                    std.Name = s.Name;
                    std.Mobile = s.Mobile;
                    std.Batch = s.Batch;
                    std.RegistrationNo = s.RegistrationNo;
                    std.Email = s.Email;
                    std.PaymentStatus = s.PaymentStatus == null || s.PaymentStatus == false ? "Payment Pending" : "Payment Completed";
                    _students.Add(std);
                }
            }
            return _students;
        }
    }
}