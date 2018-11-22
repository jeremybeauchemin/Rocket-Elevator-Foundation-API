using System;
using System.Collections.Generic;

namespace RocketApi.Models
{

  public partial class Interventions
    {
        public long Id { get; set; }
        public int? Author_id { get; set; }
        public int Customer_id { get; set; }
        public int Building_id { get; set; }
        public int Battery_id { get; set; }
        public int Column_id { get; set; }
        public int Elevator_id { get; set; }
        public int Employee_id { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; } 
        public string Result { get; set; } 
        public string Report { get; set; }
        public string Status { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; } 
    }


}