﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ALevelSalarySlipServices.Model
{
    public class ChangePassword
    {
        public int UserId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}