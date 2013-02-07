using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsimonWorld
{
    public enum IsiStatut
    {
        REPRODUCTION, COMBAT_DRESSEUR, COMBAT_ISIMON, DISPO, GROUPE, GESTATION, KO
    }

    public class Isimon : EntiteActive
    {

        private char _sexe;
        private int _niveau;
        private IsiType _type;
        private int _pvMax;
        private long _experience;
        private int _pv;
        private int _atk;
        private int _def;
        private int _vit;
        private int _nbJourGestation, _nbJourTotalGestation;
        private IsiStatut _statut;
        private EntiteActive _interact;
        private int _grpId;

        public int GrpId
        {
            get { return _grpId; }
            set { _grpId = value; }
        }

        public int NbJourGestation
        {
            get { return _nbJourGestation; }
            set { _nbJourGestation = value; }
        }

        public int NbJourTotalGestation
        {
            get { return _nbJourTotalGestation; }
            set { _nbJourTotalGestation = value; }
        }

        public EntiteActive Interact
        {
            get { return _interact; }
            set { _interact = value; }
        }

        public IsiStatut Statut
        {
            get { return _statut; }
            set { _statut = value; }
        }


        public int Atk
        {
            get { return _atk; }
            set { _atk = value; }
        }


        public int Def
        {
            get { return _def; }
            set { _def = value; }
        }


        public int Vit
        {
            get { return _vit; }
            set { _vit = value; }
        }

        public int PvMax
        {
            get { return _pvMax; }
            set { _pvMax = value; }
        }

        public IsiType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public char Sexe
        {
            get { return _sexe; }
            set { _sexe = value; }
        }

        public int Niveau
        {
            get { return _niveau; }
            set { _niveau = value; }
        }

        public long Experience
        {
            get { return _experience; }
            set { _experience = value; }
        }

        public int Pv
        {
            get { return _pv; }
            set { _pv = value; }
        }

        public Isimon(IsiProfil i, Plateau plateau)
            : base(i.Nom, i.Img, plateau)
        {
            _experience = 0;
            _grpId = -1;
            _statut = IsiStatut.DISPO;
            _niveau = 1;
            _type = i.Type;
            _pvMax = _pv = i.Pv_max;
            _atk = i.Atk;
            _def = i.Def;
            _vit = i.Vit;
            if (PseudoAlea.GetInt(0, 1) == 0)
                _sexe = 'M';
            else
                _sexe = 'F';
        }

        public override void Agir()
        {
            switch (_statut)
            {
                case (IsiStatut.COMBAT_DRESSEUR):
                    GererCombatDresseur();
                    break;
                case (IsiStatut.COMBAT_ISIMON):
                    GererCombatIsimon();
                    break;
                case (IsiStatut.GESTATION):
                    GererGestation();
                    break;
                case (IsiStatut.GROUPE):
                    GererGroupe();
                    break;
                case (IsiStatut.REPRODUCTION):
                    GererReproduction();
                    break;
                case (IsiStatut.DISPO):
                    GererDispo();
                    break;
                case (IsiStatut.KO):
                    GererKO();
                    break;
            }
        }

        public void GererCombatDresseur()
        {
        }

        public void GererCombatIsimon()
        {
            Attaquer((Isimon)this.Interact);
        }

        public void GererGestation()
        {
            if (NbJourGestation == NbJourTotalGestation)
                NaissanceIsimon();
            else
                NbJourGestation++;
            Console.WriteLine(NbJourGestation + " : " + NbJourTotalGestation);
        }

        public void GererGroupe()
        {
            //Envisager une récupération plus rapide de chaque entité du groupe ( protection de masse)
        }

        public void GererReproduction()
        {
            SeReproduire((Isimon)this.Interact);
        }

        public void GererKO()
        {
            incPV(2);
            if (Pv >= PvMax / 2)
                this.Statut = IsiStatut.DISPO;
        }

        public void GererDispo()
        {
            List<Dresseur> dresseurs = _plateau.GetDresseursAround(this);
            List<Isimon> isimons = _plateau.GetIsimonsAround(this);
            incPV(2); // Récupération progressive

            //Faire cas des dresseurs
            if (dresseurs.Count == 0 && isimons.Count == 0)
                SeDeplacer();
            else if (dresseurs.Count == 0 && isimons.Count == 1)
                OnlyOneIsimonAround(isimons.First());
            else if (dresseurs.Count == 0 && isimons.Count > 1)
                MoreThanOneIsimonAround(isimons);
            else
                SeDeplacer();
        }

        private void incPV(int nbPV)
        {
            if (Pv == PvMax)
                return;
            this.Pv += nbPV;
            if (Pv > PvMax)
                Pv = PvMax;

        }

        public void OnlyOneIsimonAround(Isimon i)
        {
            if (i.Statut == IsiStatut.DISPO || i.Statut == IsiStatut.GROUPE)
            {
                if (i.Nom == this.Nom)
                {
                    if (i.Statut == IsiStatut.GROUPE && LancerIntegrationGroupe())
                    {
                        IntegrerGroupe(i);
                        return;
                    }
                    if (i.Statut == IsiStatut.DISPO && LancerCreationGroupe(i))
                    {
                        CreerGroupe(i);
                        return;
                    }
                    if (Math.Abs(i.Niveau - this.Niveau) <= 10)
                    {
                        /*if (i._sexe != this._sexe && LancerReproduction(i))
                        {
                            GererReproduction();
                            return;
                        }*/
                        if (i._sexe == this._sexe && LancerCombat(i))
                        {
                            GererCombatIsimon();
                            return;
                        }
                    }
                    else
                        SeDeplacer();
                }
                else
                {
                    if (Math.Abs(i.Niveau - this.Niveau) <= 10 && LancerCombat(i))
                        GererCombatIsimon();
                    else
                        SeDeplacer();
                }
            }
            else
                SeDeplacer();
        }

        public void MoreThanOneIsimonAround(List<Isimon> listIsi)
        {
            Isimon i = getBestIsimon(listIsi);
            if (i != null)
                OnlyOneIsimonAround(i);
            else
                SeDeplacer();
        }

        public Isimon getBestIsimon(List<Isimon> listIsi)
        {
            int minLevel = 101;
            Isimon isiSaved = null;
            int level;

            foreach (Isimon i in listIsi)
            {
                level = Math.Abs(i.Niveau - this.Niveau);

                if (level < minLevel)
                {
                    minLevel = Math.Abs(i.Niveau - this.Niveau);
                    isiSaved = i;
                }
            }

            return isiSaved;
        }

        private bool LancerReproduction(Isimon i)
        {
            //retourne toujours vrai, ne pas oublier de faire la proba
            this.Statut = IsiStatut.REPRODUCTION;
            i.Statut = IsiStatut.REPRODUCTION;
            this.Interact = i;
            i.Interact = this;
            return true;
        }

        private bool LancerIntegrationGroupe() 
        {
            //retourne toujours vrai, ne pas oublier de faire la proba
            this.Statut = IsiStatut.GROUPE;
            
            return true;
        }

        private bool LancerCreationGroupe(Isimon i)
        {
            //retourne toujours vrai, ne pas oublier de faire la proba
            this.Statut = IsiStatut.GROUPE;
            i.Statut = IsiStatut.GROUPE;
            this._interact = i;
            i._interact = this;
            return true;
        }

        private bool LancerCombat(Isimon i)
        {
            //retourne toujours vrai, ne pas oublier de faire la proba
            i.Statut = IsiStatut.COMBAT_ISIMON;
            this.Statut = IsiStatut.COMBAT_ISIMON;
            this.Interact = i;
            i.Interact = this;
            return true;
        }

        private bool LancerCombat(Dresseur d) { return true; }

        private int CalculerDegats(Isimon frappeur, Isimon frappé)
        {
            float deg = frappeur.Atk - (frappé.Def / 2) + 1;
            deg *= ConstantesCombats.Instance.GetRatio(frappeur.Type, frappé.Type);
            return (int)deg;
        }

        private void Attaquer(Isimon i)
        {
            i.Pv = i.Pv - CalculerDegats(this, i);
            if (i.Pv <= 0)
            {
                i.Pv = 0;
                this.Statut = IsiStatut.DISPO;
                i.Statut = IsiStatut.KO;
                Victoire(i);
            }
        }

        private void Victoire(Isimon adversaire)
        {
            //Gestion de l'EXP et des niveaux
            float val = 0;
            float ratio = ConstantesCombats.Instance.GetRatio(Type, adversaire.Type);
            ratio = 2 - ratio; ;
            if (Niveau < adversaire.Niveau)
            {
                val = (adversaire.Niveau - Niveau) * 50;
                val *= ratio;
            }
            if (Niveau > adversaire.Niveau)
            {
                val = (Niveau - adversaire.Niveau) * 10;
                val *= ratio;
            }
            if (Niveau == adversaire.Niveau)
            {
                val = 20 * ratio;
            }
            Experience += (int)val;
            if (Experience > (Niveau + 1) * Niveau * 10 && Niveau < 100)
            {
                Niveau++;
                if (Niveau < 50)
                {
                    Atk += (int)(Atk * 0.045) + 1;
                    Def += (int)(Def * 0.045) + 1;
                    Vit += (int)(Vit * 0.045) + 1;
                    PvMax += (int)(PvMax * 0.04);
                }
                else
                {
                    Atk += (int)(Atk * 0.01);
                    Def += (int)(Def * 0.01);
                    Vit += (int)(Vit * 0.01);
                    PvMax += (int)(PvMax * 0.01);

                }
            }
        }

        private void SeReproduire(Isimon i)
        {
            if (this.Sexe == 'F')
            {
                this.Statut = IsiStatut.GESTATION;
                i.Statut = IsiStatut.DISPO;
                this.NbJourTotalGestation = (int)PseudoAlea.boxMuller(20, 3);
            }
            else
            {
                i.Statut = IsiStatut.GESTATION;
                this.Statut = IsiStatut.DISPO;
                i.NbJourTotalGestation = (int)PseudoAlea.boxMuller(20, 3);
            }
        }

        private void CreerGroupe(Isimon i)
        {
            //Changer nom grpe
            Groupe grp = new Groupe("nomPourTest", this._plateau, this, this._interact);
            _plateau.ListGrp.Add(grp);
            this._grpId =  i._grpId = grp.Id;
        }

        private void IntegrerGroupe(Isimon i) 
        {
            this._grpId = i._grpId;
            _plateau.ListGrp[_grpId].Grp.Add(this);
        }

        private void NaissanceIsimon()
        {
            Entite newIsimon;

            //Le place n'importe où (juste pour tester)
            int row = PseudoAlea.GetInt(0, _plateau.NbRow - 1);
            int col = PseudoAlea.GetInt(0, _plateau.NbColumn - 1);

            while (!_plateau.Matrice[row, col].IsEmpty())
            {
                row = PseudoAlea.GetInt(0, _plateau.NbRow - 1);
                col = PseudoAlea.GetInt(0, _plateau.NbColumn - 1);
            }
            this.Statut = IsiStatut.DISPO;
            newIsimon = new Isimon(new IsiProfil(this.Nom, this.Nom+".png", this.Type, 100, 1, 2, 3), this._plateau);
            this._plateau.AddActeur(newIsimon);
            this._plateau.DeplacerActeur(newIsimon, this._plateau.Matrice[row, col]);
        }
    }
}
