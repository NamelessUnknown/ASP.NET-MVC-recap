using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EfficiencyMVC.Models
{
    public class Result
    {
        public int Id { get; set; }
        public string Operator { get; set; }
        public bool IsConductor { get; set; }
        public string  Email { get; set; }
        public Department Department { get; set; }  
        public int Pages { get; set; }
        public int Associations { get; set; }
        public int Ads { get; set; }
    }
}