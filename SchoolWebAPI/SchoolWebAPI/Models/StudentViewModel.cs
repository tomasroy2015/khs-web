using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolWebAPI.Models
{
    public class StudentViewModel
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Batch { get; set; }
        public string RegistrationNo { get; set; }
        public string Email { get; set; }
        public string PaymentStatus { get; set; }
    }
}