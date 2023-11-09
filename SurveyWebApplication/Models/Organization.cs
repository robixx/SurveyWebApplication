using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace SurveyWebApplication.Models
{
    public class Organization
    {
        [Key]
        public int OrgId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }

    }
}