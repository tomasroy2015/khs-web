using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolWebAPI.Models
{
    public class StudentModel 
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Batch { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string RegistrationNo { get; set; }
        public Nullable<long> PaidAmount { get; set; }
        public bool PaymentStatus { get; set; }
    }
}