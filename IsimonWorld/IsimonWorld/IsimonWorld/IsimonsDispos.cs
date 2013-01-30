using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsimonWorld
{
        public class IsiProfil
        {
            private String _nom;

            public String Nom
            {
                get { return _nom; }
                private set { _nom = value; }
            }

            private String _img;

            public String Img
            {
                get { return _img; }
                private set { _img = value; }
            }
            private IsiType _type;

            public IsiType Type
            {
                get { return _type; }
                private set { _type = value; }
            }

            private int _pv_max;

            public int Pv_max
            {
                get { return _pv_max; }
                set { _pv_max = value; }
            }

            private int _atk;

            public int Atk
            {
                get { return _atk; }
                set { _atk = value; }
            }

            private int _def;

            public int Def
            {
                get { return _def; }
                set { _def = value; }
            }

            private int _vit;

            public int Vit
            {
                get { return _vit; }
                set { _vit = value; }
            }

            public IsiProfil(String nom, String img, IsiType type,int pv_max,int atk, int def, int vit)
            {
                this._nom = nom;
                this._img = img;
                this._type = type;
                this._pv_max = pv_max;
                this._atk = atk;
                this._def = def;
                this._vit = vit;
            }
        }


    public class IsimonsDispos : List<IsiProfil>
    {

        private static IsimonsDispos _instance;
      

        public static IsimonsDispos Instance
        {
            get { if (_instance == null) _instance = new IsimonsDispos(); return IsimonsDispos._instance; }            
        }

        private IsimonsDispos()
        {
            this.Add(new IsiProfil("Pikachu", "Pikachu.png", IsiType.Elec,35,10,10,10));
            this.Add(new IsiProfil("Salameche", "Salameche.png", IsiType.Feu,44,14,10,8));
            this.Add(new IsiProfil("Carapuce", "Carapuce.png", IsiType.Eau,45,12,16,10));
            this.Add(new IsiProfil("Bulbizarre", "Bulbizarre.png", IsiType.Plante,39,8,15,8));         

        }


        public IsiProfil getRandomProfil()
        {           
            return this[PseudoAlea.GetInt(0, this.Count-1)];
        }


    }
}
