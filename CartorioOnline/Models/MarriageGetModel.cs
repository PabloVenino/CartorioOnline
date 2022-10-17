
using System;

namespace CartorioOnline.Models
{
    public class MarriageGetModel
    {
        public DateTime RegistrationDate { get; set; }
        public DateTime MarriedDate { get; set; }
        public Spouse Spouse1 { get; set; }
        public Spouse Spouse2 { get; set; }
    }
}
