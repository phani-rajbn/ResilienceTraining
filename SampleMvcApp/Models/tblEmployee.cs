//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SampleMvcApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblEmployee
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public string EmpPhone { get; set; }
        public decimal EmpSalary { get; set; }
        public Nullable<int> DeptId { get; set; }
    
        public virtual tblDept tblDept { get; set; }
    }
}
