//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolWebAPI
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public Nullable<int> Type { get; set; }
        public string Batch { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string AcademicQualification { get; set; }
        public string Grade { get; set; }
        public Nullable<long> GradePoint { get; set; }
    }
}
