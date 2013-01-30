using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsimonWorld
{
    public class Case
    {

        //Test ou pas

        private int _row;

        //il va être bien ce test

        public int Row
        {
            get { return _row; }
        }

        private int _column;

        public int Column
        {
            get { return _column; }
        }

        private Entite _acteur = null;

        public Entite Acteur
        {
            get { return _acteur; }
            set { _acteur = value; }
        }

        public Case(int inRow, int inColumn)
        {
            _row = inRow;
            _column = inColumn;
        }

        public bool IsEmpty()
        {
            return _acteur == null;
        }

        public void Empty()
        {
            _acteur = null;
        }     

    }
}
