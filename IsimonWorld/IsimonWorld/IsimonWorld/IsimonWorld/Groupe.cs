using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsimonWorld
{
    public class Groupe : EntiteActive
    {
        List<Isimon> _grp;
        private static int _cptId = -1;
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public static int CptId
        {
            get { return Groupe._cptId; }
            set { Groupe._cptId = value; }
        }

        public List<Isimon> Grp
        {
            get { return _grp; }
            set { _grp = value; }
        }

        public override void Agir()
        {
            
        }

        public void SeDeplacer()
        {
            bool deplacer;

            int row = PseudoAlea.GetInt(-1, 1);
            int column = PseudoAlea.GetInt(-1, 1);

            deplacer = verifDeplacement(row, column);

            if (deplacer)
            {
                foreach (Isimon i in _grp)
                    i.SeDeplacer(i.MyCase.Row + row, i.MyCase.Column + column);
            }
        }

        public bool verifDeplacement(int row, int column)
        {
            foreach (Isimon i in _grp)
            {
                if (i.Statut != IsiStatut.GROUPE)
                    return false;
                else if ((row == -1 && i.MyCase.Row == 0) || (row == 1 && i.MyCase.Row == _plateau.NbRow - 1) || (column == -1 && i.MyCase.Column == 0) || (column == 1 && i.MyCase.Column == _plateau.NbColumn -1))
                    return false;
                else if (!_plateau.Matrice[i.MyCase.Row + row, i.MyCase.Column + column].IsEmpty() && _plateau.Matrice[i.MyCase.Row + row, i.MyCase.Column + column].Acteur.GetType() == i.GetType())
                {
                    Isimon isi = (Isimon)_plateau.Matrice[i.MyCase.Row + row, i.MyCase.Column + column].Acteur;
                    if (isi.GrpId != i.GrpId)
                        return false;
                }
                else if (!_plateau.Matrice[i.MyCase.Row + row, i.MyCase.Column + column].IsEmpty() && _plateau.Matrice[i.MyCase.Row + row, i.MyCase.Column + column].Acteur.GetType() != i.GetType())
                    return false;
            }
            return true;
        }

        public Groupe(string nom, Plateau plateau, Isimon isi1, EntiteActive isi2): base(nom, null, plateau)
        {
            _cptId++;
            _id = _cptId;
            _grp = new List<Isimon>();
            _grp.Add(isi1);
            _grp.Add((Isimon)isi2);
        }
    }
}
