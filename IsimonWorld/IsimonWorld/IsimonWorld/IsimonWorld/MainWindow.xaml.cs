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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace IsimonWorld
{

    //Coucou Bryan


    //Pouete

    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private delegate void majPlateau();

        private Thread _th;

        private Plateau _plateau;

        private int _tempo;

        private int[] init;

        private Isimon _selectedOne;


        public int Tempo
        {
            get { return _tempo; }
            set { _tempo = value; }
        }



        public MainWindow(int[] args)
        {
            InitializeComponent();
            this.Closing += new System.ComponentModel.CancelEventHandler(MainWindow_Closing);
            sTempo.DataContext = this;
            Tempo = 1;
            init = args;
            InitPlateau();
            App.Current.Dispatcher.Invoke((majPlateau)ActualiserPlateau);
        }

        void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_th != null)
                _th = null;
        }

        private void InitPlateau()
        {
            for (int i = 0; i < init[1]; i++)
                gPlateau.RowDefinitions.Add(new RowDefinition());
            for (int i = 0; i < init[0]; i++)
                gPlateau.ColumnDefinitions.Add(new ColumnDefinition());
            _plateau = new Plateau(init, gPlateau);
            foreach (Entite e in _plateau.GetActeurs())
                if( e is Isimon )
                    e.Image.MouseUp += new MouseButtonEventHandler(Isimon_MouseUp);
            
                
            
        }

        void Isimon_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Isimon s = (Isimon)_plateau.GetActeurById(((Image)sender).Name);
            if (s != null)
            {
                ucDetails.DataContext = new IsimonDetailsViewModel(s);
                _selectedOne = s;
            }
        }



        private void bStart_Click(object sender, RoutedEventArgs e)
        {
            if (_th == null)
            {
                _th = new Thread(new ThreadStart(Routine));
                _th.Start();
                bStart.Content = "Stop";
            }
            else
            {
                _th = null;
                bStart.Content = "Start";
            }
        }

        private void bExit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Routine()
        {
            while (_th != null)
            {
                List<Entite> liste = _plateau.GetActeurs();
                foreach (Entite ea in liste)
                {
                    if (ea is EntiteActive)
                        ((EntiteActive)ea).Agir();
                }
                App.Current.Dispatcher.Invoke((majPlateau)ActualiserPlateau);
                Thread.Sleep(1001 - Tempo);
            }
        }


        public void ActualiserPlateau()
        {
            foreach (Entite i in _plateau.GetActeurs())
            {
                Grid.SetRow(i.Image, i.MyCase.Row);
                Grid.SetColumn(i.Image, i.MyCase.Column);
            }
            if (_selectedOne != null)
                ((IsimonDetailsViewModel)ucDetails.DataContext).Update(_selectedOne);

        }






       
    }
}
