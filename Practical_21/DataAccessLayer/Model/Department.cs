using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer
{
    public class Department
    {
        [Key]
        public int Dept_Id { get; set; }
        public string Dept_Name { get; set; }
    }
}
