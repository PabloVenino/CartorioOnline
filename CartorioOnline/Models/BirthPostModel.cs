using System;

namespace CartorioOnline.Models
{
    public class BirthPostModel
    {
        public DateTime RegistrationDate { get; set; }
        public DateTime BirthDate { get; set; }
        public string RegistrateCpf { get; set; }
        public string RegistrateName { get; set; }
        public string? FatherName { get; set; } = null; // Em caso de pai ou mãe não constar no registro (param nullable)
        public string? MotherName { get; set; } = null;
        public string? FatherCpf { get; set; } = null;
        public string? MotherCpf { get; set; } = null;
    }
}
