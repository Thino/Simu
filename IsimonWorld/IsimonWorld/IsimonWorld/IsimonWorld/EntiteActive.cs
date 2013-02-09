using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsimonWorld
{
    public abstract class EntiteActive : Entite, Comportement
    {

        protected Plateau _plateau;
     

        public EntiteActive(String inNom, String inImage, Plateau plateau)
            : base(inNom, inImage)
        {
            _plateau = plateau;           
        }

        public void SeDeplacer()
        {           
            List<Case> liste = _plateau.DeplacementsPossibles(this);
            int nb = PseudoAlea.GetInt(0, liste.Count-1);
            _plateau.DeplacerActeur(this, liste[nb]);
        }

        public void SeDeplacer(int i, int j)
        {
            _plateau.DeplacerActeur(this, new Case(i, j));
        }

        public abstract void Agir();
    
    }
}
