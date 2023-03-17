using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ALevelSalarySlipServices.Model
{
    public class Feedback
    {
        public string Rating { get; set; }
        public string Message { get; set; }
        public string MessageType { get; set; }
        public int UserId { get; set; }
    }
}