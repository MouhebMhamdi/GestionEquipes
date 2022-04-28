using GE.Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
 public   interface IServiceEquipe:IService<Equipe>
    {
        double Recompense(Equipe e);
        IEnumerable<Joueur> JoueursTrophee(Trophee t);
        IEnumerable<Entraineur> EntraineurEquipe(Equipe e);
        DateTime DatePremierChampionnat(Equipe e);
        String EquipeMaxTrophees();
    }
}
