using System;

namespace CartorioOnline.Models
{
    public class MarriageModel
    {
        public DateTime RegistrationDate { get; set; }
        public DateTime MarriedDate { get; set; }
        public Spouse Spouse1 { get; set; }
        public Spouse Spouse2 { get; set; }
    }

    public class Spouse
    {
        public DateTime BirthDate { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string? FatherName { get; set; } = null; // Em caso de pai não constar no registro (param nullable)
        public string MotherName { get; set; }
        public DateTime? FatherBirthDate { get; set; } = null;
        public DateTime MotherBirthDate { get; set; }
        public string? FatherCpf { get; set; } = null;
        public string MotherCpf { get; set; }
    }
}
