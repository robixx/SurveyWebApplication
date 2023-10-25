﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using SurveyWebApplication.ModelViewInfo;
namespace SurveyWebApplication.Models
{

    public class OptionType : BaseModel
    {
        [Key]
        public int OptionTypeId { get; set; }
        public string OptionTypeName { get; set; }
    }
}