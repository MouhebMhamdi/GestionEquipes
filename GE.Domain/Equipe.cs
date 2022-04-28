using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GE.Domain
{
    public class Equipe
    {
        public String AdressLocal { get; set; }
        [Key]
        public int EquipeId { get; set; }
        public String Logo { get; set; }
        public String NomEquipe { get; set; }
        public virtual ICollection<Trophee> Trophees { get; set; }
        public virtual ICollection<Contrat> Contrats { get; set; }

    }
}
