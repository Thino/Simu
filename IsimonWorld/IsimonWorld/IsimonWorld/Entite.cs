using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace IsimonWorld
{
    public class Entite
    {
        private static long _inc;
        private String _id;
        private String _nom;
        private Image _image;
        private Case _myCase;


        public String Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public String Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public Image Image
        {
            get { return _image; }
            set { _image = value; }
        }

        public Case MyCase
        {
            get { return _myCase; }
            set { _myCase = value; }
        }


        public Entite(String inNom, String inImage)
        {         
            _nom = inNom;
            _id = Nom + _inc++;
            BitmapImage bitmapImage = new BitmapImage(new Uri("images\\" + inImage, UriKind.Relative));
            _image = new Image();
            _image.Name = _id;           
            _image.Source = bitmapImage;
        }

    }
}
