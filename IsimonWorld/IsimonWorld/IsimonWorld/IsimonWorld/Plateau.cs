using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace IsimonWorld
{
    public class Plateau
    {
        

        private int _nbRow;

        private int _nbColumn;

        private Case[,] _matrice;

        private List<Entite> _acteurs;

        private Grid _gPlateau;

        public Plateau(int[] parametres, Grid _inGPlateau)
        {
            _matrice = new Case[parametres[1], parametres[0]];
            _nbRow = parametres[1];
            _nbColumn = parametres[0];
            for (int i = 0; i < _nbRow; i++)
                for (int j = 0; j < _nbColumn; j++)
                    _matrice[i, j] = new Case(i, j);
            _acteurs = new List<Entite>();
            _gPlateau = _inGPlateau;
            InitActeurs(parametres);
      
        }

        public List<Entite> GetActeurs()
        {
            return _acteurs;
        }

        private void InitActeurs(int[] parametres)
        {                
            int nbIsimons = (int)Math.Ceiling((double)parametres[0] * parametres[1] * parametres[3] / 100);
            int nbArbres = (int)Math.Ceiling((double)parametres[0] * parametres[1] * parametres[2] / 100);
            int nbDresseurs = (int)Math.Ceiling((double)parametres[0] * parametres[1] * parametres[4] / 100);

            for (int i = 0; i < nbArbres; i++)
            {
                int row = PseudoAlea.GetInt(0, _nbRow-1);
                int col = PseudoAlea.GetInt(0, _nbColumn-1);
                while (! _matrice[row, col].IsEmpty())
                {
                    row = PseudoAlea.GetInt(0, _nbRow-1);
                    col = PseudoAlea.GetInt(0, _nbColumn-1);
                }
                Entite a = new Entite("Arbre", "Arbre.png");
                AddActeur(a);
                DeplacerActeur(a, _matrice[row, col]);
            }

            for (int i = 0; i < nbIsimons; i++)
            {
                int row = PseudoAlea.GetInt(0, _nbRow-1);
                int col = PseudoAlea.GetInt(0, _nbColumn-1);
                while (!_matrice[row, col].IsEmpty())
                {
                    row = PseudoAlea.GetInt(0, _nbRow-1);
                    col = PseudoAlea.GetInt(0, _nbColumn-1);
                }
                Isimon a = new Isimon(IsimonsDispos.Instance.getRandomProfil(),this);            
                AddActeur(a);
                DeplacerActeur(a, _matrice[row, col]);
            }

            for (int i = 0; i < nbDresseurs; i++)
            {
                int row = PseudoAlea.GetInt(0, _nbRow-1);
                int col = PseudoAlea.GetInt(0, _nbColumn-1);
                while (!_matrice[row, col].IsEmpty())
                {
                    row = PseudoAlea.GetInt(0, _nbRow-1);
                    col = PseudoAlea.GetInt(0, _nbColumn-1);
                }
                Dresseur a = new Dresseur("Dresseur", "Sacha.png",this);
                AddActeur(a);
                DeplacerActeur(a, _matrice[row, col]);
            }
            
        }

     


        public void AddActeur(Entite inI)
        {
            _acteurs.Add(inI);
            _gPlateau.Children.Add(inI.Image);
        }

        public void DeplacerActeur(Entite inI, Case inC)
        {
            if (inI.MyCase != null)
                inI.MyCase.Empty();
            inI.MyCase = inC;
            _matrice[inC.Row, inC.Column].Acteur=inI;
        }

       
        public List<Case> DeplacementsPossibles(EntiteActive inI)
        {
            List<Case> cases = GetCasesAdjacentes(inI.MyCase);
            List<Case> deplacements = new List<Case>();
            foreach (Case c in cases)
            {
                if (c.IsEmpty())
                    deplacements.Add(c);
            }
            deplacements.Add(inI.MyCase);
            return deplacements;
        }

        public List<Case> GetCasesAdjacentes(Case inC)
        {
            List<Case> cases = new List<Case>();
            if (inC.Row > 0)
                cases.Add(_matrice[inC.Row - 1, inC.Column]);
            if (inC.Row < _nbRow - 1)
                cases.Add(_matrice[inC.Row + 1, inC.Column]);
            if (inC.Column > 0)
                cases.Add(_matrice[inC.Row, inC.Column - 1]);
            if (inC.Column < _nbColumn - 1)
                cases.Add(_matrice[inC.Row, inC.Column + 1]);
            return cases;
        }

        public Entite GetActeurById(String id)
        {
            foreach (Entite e in _acteurs)
                if (e.Id.Equals(id))
                    return e;
            return null;
        }


        public List<Isimon> GetIsimonsAround(Isimon i)
        {
            List<Case>  cases = GetCasesAdjacentes(i.MyCase);
            List<Isimon> ret = new List<Isimon>();
            foreach (Case c in cases)
            {
                if (c.Acteur is Isimon)
                    ret.Add((Isimon)c.Acteur);
            }
            return ret;            
        }

        public List<Dresseur> GetDresseursAround(Isimon i)
        {
            List<Case> cases = GetCasesAdjacentes(i.MyCase);
            List<Dresseur> ret = new List<Dresseur>();
            foreach (Case c in cases)
            {
                if (c.Acteur is Dresseur)
                    ret.Add((Dresseur)c.Acteur);
            }
            return ret;
        }

       
    }
}
