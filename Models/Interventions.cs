using System;
using System.Collections.Generic;

namespace RocketApi.Models
{

  public partial class Interventions
    {
        public int customer_id { get; set; }
        public int building_id { get; set; }
        public int battery_id { get; set; }
        public int column_id { get; set; }
        public int elevator_id { get; set; }
        public int employee_id { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; } 
        public string result { get; set; } 
        public string report { get; set; }
        public string status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; } 
    }


}