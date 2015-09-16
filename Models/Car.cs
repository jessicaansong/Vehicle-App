using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CarList.Models
{
    public class Car
    {
        public int id { get; set; } 
        [DisplayName("Make")]
        public string make { get; set; }
        [DisplayName("Model")]
        public string model_name { get; set; }
        [DisplayName("Trim")]
        public string model_trim { get; set; }
         [DisplayName("Year")]
        public string model_year { get; set; }
        [DisplayName("Body")]
        public string body_style { get; set; }
        [DisplayName("Engine CC")]
        public string engine_cc { get; set; }
        [DisplayName("Engine Cylinders")]
        public string engine_num_cyl { get; set; }

    }

    public class CarViewModel
    {
        public Car Car { get; set; }
        public dynamic Recalls { get; set; }
        public string Image { get; set; }
    }
}