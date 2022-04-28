using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GE.Domain
{
    public class Contrat
    {
        [Key]
        public DateTime DateContrat { get; set; }
        
        [Range(0,24)]
        public int DureeMois { get; set; }
        public Double Salaire { get; set; }
        public int MembreFk { get; set; }
        [ForeignKey("EquipeFk")]
        public virtual Equipe Equipe { get; set; }
        [ForeignKey("MembreFk")]
        public virtual Membre Membre { get; set; }
        public int EquipeFk { get; set; }
    }
}
