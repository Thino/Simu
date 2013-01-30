using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsimonWorld
{
    public class Dresseur : EntiteActive
    {

        public Dresseur(String inNom, String inImage, Plateau plateau)
            : base(inNom, inImage,plateau)
        { }

        public override void Agir()
        {
            SeDeplacer();
        }

    }
}
