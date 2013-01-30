using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsimonWorld
{
    public  class ConstantesCombats : Dictionary<KeyValuePair<IsiType,IsiType>,float>
    {
        
        private static ConstantesCombats _instance;
      

        public static ConstantesCombats Instance
        {
            get { if (_instance == null) _instance = new ConstantesCombats(); return ConstantesCombats._instance; }            
        }

        private ConstantesCombats()
        {
            this.Add(new KeyValuePair<IsiType, IsiType>(IsiType.Feu, IsiType.Eau), 0.30F);
            this.Add(new KeyValuePair<IsiType, IsiType>(IsiType.Feu, IsiType.Plante), 1.70F);
            this.Add(new KeyValuePair<IsiType, IsiType>(IsiType.Feu, IsiType.Elec), 1.1F);
            this.Add(new KeyValuePair<IsiType, IsiType>(IsiType.Feu, IsiType.Feu), 1F);
            this.Add(new KeyValuePair<IsiType, IsiType>(IsiType.Eau, IsiType.Feu), 1.70F);         
            this.Add(new KeyValuePair<IsiType, IsiType>(IsiType.Eau, IsiType.Plante), 0.30F);
            this.Add(new KeyValuePair<IsiType, IsiType>(IsiType.Eau, IsiType.Elec), 0.50F);
            this.Add(new KeyValuePair<IsiType, IsiType>(IsiType.Eau, IsiType.Eau), 1F);
            this.Add(new KeyValuePair<IsiType, IsiType>(IsiType.Plante, IsiType.Feu), 0.30F);
            this.Add(new KeyValuePair<IsiType, IsiType>(IsiType.Plante, IsiType.Plante), 1F);
            this.Add(new KeyValuePair<IsiType, IsiType>(IsiType.Plante, IsiType.Elec), 0.80F);
            this.Add(new KeyValuePair<IsiType, IsiType>(IsiType.Plante, IsiType.Eau), 1.70F);
            this.Add(new KeyValuePair<IsiType, IsiType>(IsiType.Elec, IsiType.Feu), 1.1F);
            this.Add(new KeyValuePair<IsiType, IsiType>(IsiType.Elec, IsiType.Plante), 1.2F);
            this.Add(new KeyValuePair<IsiType, IsiType>(IsiType.Elec, IsiType.Elec), 1.0F);
            this.Add(new KeyValuePair<IsiType, IsiType>(IsiType.Elec, IsiType.Eau), 1.80F); 
        }

        public float GetRatio(IsiType attaquant, IsiType defenseur)
        {
            KeyValuePair<IsiType, IsiType> paire = new KeyValuePair<IsiType, IsiType>(attaquant, defenseur);
            return this[paire];
        }


    }
}
