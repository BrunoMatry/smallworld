using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmallWorldGraphics
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private String nomPartie;
        private TypeCarte typeCarte;
        private TypePeuple j1;
        private TypePeuple j2;
        private MonteurPartie mp;

        public MainWindow()
        {
            InitializeComponent();

        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Get control that raised this event.
            this.nomPartie = (sender as TextBox).Text;
           
        }
        private void Carte_Checked(object sender, RoutedEventArgs e)
	{
	    // Get RadioButton reference.
	    var button = sender as RadioButton;

        string carte = button.Content.ToString();
        switch (carte)
        {
            case ("Demo (5 Tours - 5x5 cases"):
                this.typeCarte = TypeCarte.DEMO;
                break;
            
            case("Petit (20 Tours - 10x10 cases"):
                this.typeCarte = TypeCarte.PETIT;
                break;
            
            case("Normale (30 Tours - 15x15 cases)"):
                this.typeCarte = TypeCarte.NORMAL;
                break;
            
            default:
                    break;
                
        }
        
        }

        private void J1_Checked(object sender, RoutedEventArgs e)
        {
            var button = sender as RadioButton;

            string joueur1 = button.Content.ToString();
            switch (joueur1)
            {
                case ("Gaulois"): 
                    j1 = TypePeuple.GAULOIS;
                    GauloisJ2.IsEnabled = false;
                    VikingJ2.IsEnabled = true;
                    NainJ2.IsEnabled = true;
                    break;
                case ("Viking"): 
                    j1 = TypePeuple.VIKING;
                    GauloisJ2.IsEnabled = true;
                    VikingJ2.IsEnabled = false;
                    NainJ2.IsEnabled = true;
                    break;
                case ("Nain"):  
                    j1 = TypePeuple.NAINS;
                    GauloisJ2.IsEnabled = true;
                    VikingJ2.IsEnabled = true;
                    NainJ2.IsEnabled = false;
                    break;
                default:
                    break;
            }
          

        }
        private void J2_Checked(object sender, RoutedEventArgs e)
        {
            var button = sender as RadioButton;

            string joueur2 = button.Content.ToString();
            switch (joueur2)
            {
                case ("Gaulois"):
                    j2 = TypePeuple.GAULOIS;
                    GauloisJ1.IsEnabled = false;
                    VikingJ1.IsEnabled = true;
                    NainJ1.IsEnabled = true;
                    break;
                case ("Viking"):
                    j2 = TypePeuple.VIKING;
                    GauloisJ1.IsEnabled = true;
                    VikingJ1.IsEnabled = false;
                    NainJ1.IsEnabled = true;
                    break;
                case ("Nain"):
                    j2 = TypePeuple.NAINS;
                    GauloisJ1.IsEnabled = true;
                    VikingJ1.IsEnabled = true;
                    NainJ1.IsEnabled = false;
                    break;
                default:
                    break;
            }

        }


    }
}
