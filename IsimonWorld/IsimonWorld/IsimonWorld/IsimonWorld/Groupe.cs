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
            foreach (Isimon i in _grp)
            {
                i.SeDeplacer();
            }
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
