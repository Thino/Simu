using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;

namespace IsimonWorld
{
    public class IsimonDetailsViewModel : ViewModelBase
    {

        private String _id;
        private String _nom;
        private ImageSource _imageSource;
        private int _atk;
        private int _def;
        private int _vit;
        private int _pvMax;
        private IsiType _type;
        private char _sexe;
        private long _exp;
        private int _niveau;
        private int _pv;   
        private IsiStatut _statut;

        public IsiStatut Statut
        {
            get { return _statut; }
            set { _statut = value; OnPropertyChanged("Statut"); }
        }

        public int Pv
        {
            get { return _pv; }
            set { _pv = value; OnPropertyChanged("Pv"); }
        }

        public int Niveau
        {
            get { return _niveau; }
            set { _niveau = value; OnPropertyChanged("Niveau"); }
        }

        public long Exp
        {
            get { return _exp; }
            set { _exp = value; OnPropertyChanged("Exp"); }
        }

        public char Sexe
        {
            get { return _sexe; }
            set { _sexe = value; OnPropertyChanged("Sexe"); }
        }

        public IsiType Type
        {
            get { return _type; }
            set { _type = value; OnPropertyChanged("Type"); }
        }

        public int PvMax
        {
            get { return _pvMax; }
            set { _pvMax = value; OnPropertyChanged("PvMax"); }
        }


        public int Atk
        {
            get { return _atk; }
            set { _atk = value; OnPropertyChanged("Atk"); }
        }       

        public int Def
        {
            get { return _def; }
            set { _def = value; OnPropertyChanged("Def"); }
        }       

        public int Vit
        {
            get { return _vit; }
            set { _vit = value; OnPropertyChanged("Vit"); }
        }        


        public String Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("Id"); }
        }

        public String Nom
        {
            get { return _nom; }
            set { _nom = value; OnPropertyChanged("Nom"); }
        }

        public ImageSource ImageSource
        {
            get { return _imageSource; }
            set { _imageSource = value; OnPropertyChanged("ImageSource"); }
        }





        public IsimonDetailsViewModel(Isimon i)
        {
            this.Id = i.Id;
            this.Nom = i.Nom;
            this.ImageSource = i.Image.Source;
            this.Atk = i.Atk;
            this.Def = i.Def;
            this.Vit = i.Vit;
            this.PvMax = i.PvMax;
            this.Type = i.Type;
            this.Sexe = i.Sexe;
            this.Exp = i.Experience;
            this.Niveau = i.Niveau;
            this.Statut = i.Statut;
            this.Pv = i.Pv;
        }

        public void Update(Isimon i)
        {
            this.Id = i.Id;
            this.Nom = i.Nom;
            this.ImageSource = i.Image.Source;
            this.Atk = i.Atk;
            this.Def = i.Def;
            this.Vit = i.Vit;
            this.PvMax = i.PvMax;
            this.Type = i.Type;
            this.Sexe = i.Sexe;
            this.Exp = i.Experience;
            this.Niveau = i.Niveau;
            this.Statut = i.Statut;
            this.Pv = i.Pv;
        }

     

    }
}
