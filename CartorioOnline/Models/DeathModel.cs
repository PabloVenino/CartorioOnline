using System;

namespace CartorioOnline.Models
{
    public class DeathModel
    {
        public int Id { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime DeathDate { get; set; }
        public string DeadName { get; set; }
        public string DeadCpf { get; set; } // campo a mais para 'controle' das mortes
        public DateTime BirthDate { get; set; }
        public string? FatherName { get; set; } = null; // Em caso de pai não constar no registro (param nullable)
        public string MotherName { get; set; }
        public DateTime? FatherBirthDate { get; set; } = null;
        public DateTime MotherBirthDate { get; set; }

    }
}
