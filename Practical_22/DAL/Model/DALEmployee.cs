using BAL.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BAL
{
    public class DALEmployee
    {
        private DateTime _SetDefaultDate = DateTime.Now;
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Salary { get; set; }
        [Required]
        public int Dept_Id { get; set; }
        [Required]
        public string EmailId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime JoiningDate
        {
            get
            {
                return _SetDefaultDate;
            }
            set
            {
                _SetDefaultDate = value;
            }
        }
        [Required]
        public bool Status { get; set; }
        [ForeignKey("Dept_Id")]
        public DALDepartment Department { get; set; }
    }
}
