using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SurveyWebApplication.Models
{
    public class OptionType
    {
        [Key]
        public int OptionId { get; set; }
        public string OptionTypeName { get; set; }
    }
}