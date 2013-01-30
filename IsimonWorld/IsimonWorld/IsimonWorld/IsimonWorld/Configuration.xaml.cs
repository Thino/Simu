using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IsimonWorld
{
    /// <summary>
    /// Logique d'interaction pour Configuration.xaml
    /// </summary>
    public partial class Configuration : Window
    {
        private String _casesH;
        private String _casesV;
        private String _arbres;
        private String _isimons;
        private String _dresseurs;

        public String CasesH
        {
            get { return _casesH; }
            set { _casesH = value; }
        }

        public String CasesV
        {
            get { return _casesV; }
            set { _casesV = value; }
        }

        public String Arbres
        {
            get { return _arbres; }
            set { _arbres = value; }
        }

        public String Isimons
        {
            get { return _isimons; }
            set { _isimons = value; }
        }

        public String Dresseurs
        {
            get { return _dresseurs; }
            set { _dresseurs = value; }
        }

        public Configuration()
        {
            InitializeComponent();
        }

        private void tbCasesH_MouseEnter(object sender, MouseEventArgs e)
        {
            tblInfos.Text = "Nombre entre 5 et 100";
        }

        private void tb_MouseLeave(object sender, MouseEventArgs e)
        {
            tblInfos.Text = "";
        }

        private void tbCasesV_MouseEnter(object sender, MouseEventArgs e)
        {
            tblInfos.Text = "Nombre entre 5 et 100";
        }

        private void tbArbres_MouseEnter(object sender, MouseEventArgs e)
        {
            tblInfos.Text = "Nombre entre 1 et 10 %";
        }

        private void tbIsimons_MouseEnter(object sender, MouseEventArgs e)
        {
            tblInfos.Text = "Nombre entre 2 et 40 %";
        }

        private void tbDresseurs_MouseEnter(object sender, MouseEventArgs e)
        {
            tblInfos.Text = "Nombre entre 1 et 20 %";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CheckAndLauch();
        }

        public bool CheckAndLauch()
        {
            String champ = "Cases Horizontales";

            _casesH = tbCasesH.Text;
            _casesV = tbCasesV.Text;
            _arbres = tbArbres.Text;
            _isimons = tbIsimons.Text;
            _dresseurs = tbDresseurs.Text;

            int[] parametres = new int[5];
            try
            {
                parametres[0] = int.Parse(_casesH);
                if (parametres[0] < 5 || parametres[0] > 100)
                    throw new ArgumentException();
                champ = "Cases Verticales";
                parametres[1] = int.Parse(_casesV);
                if (parametres[1] < 5 || parametres[1] > 100)
                    throw new ArgumentException();
                champ = "Arbres";
                parametres[2] = int.Parse(_arbres);
                if (parametres[2] < 1 || parametres[2] > 10)
                    throw new ArgumentException();
                champ = "Isimons";
                parametres[3] = int.Parse(_isimons);
                if (parametres[3] < 2 || parametres[3] > 40)
                    throw new ArgumentException();
                champ = "Dresseurs";
                parametres[4] = int.Parse(_dresseurs);
                if (parametres[4] < 1 || parametres[4] > 20)
                    throw new ArgumentException();
                new MainWindow(parametres).Show();
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Le champ " + champ + " n'est pas correctement renseigné");
                return false;
            }
            return true;
        }

    }
}
