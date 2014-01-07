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
using System.Windows.Shapes;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SmallWorldGraphics
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class CarteGraph : Window
    {
        private Partie partie;
        private int translationh; // Utile pour centrer la carte 
        private int translationl;
        
        public CarteGraph(Partie p)
        {
            InitializeComponent();
            partie = p;
            AfficherCarte();
            PlacerUnite();
        }
        public void AfficherCarte()
        {
                 for (int i = 0; i < partie.Hauteur; i++)
                 {
                     for (int j = 0; j < partie.Largeur; j++)
                     {
                         canvas1.Children.Add(AfficherCase(partie.Grille[i,j],i,j));
                     }

                 }

        }
        public StackPanel AfficherCase(TypeCase t, int left, int bottom)
        {
            //Centrage de la carte
            translationh = 0;
            translationl = 0;
            if (partie.Hauteur == partie.Largeur & partie.Hauteur == 5) { 
                translationh = 203;
                translationl = 273;
            }
            if (partie.Hauteur == partie.Largeur & partie.Hauteur == 10)
            {
                translationh = 103;
                translationl = 173;
            }
            StackPanel s = new StackPanel(){Orientation=Orientation.Vertical};
            double x = (double)left*41 + 170+ translationl;
            double y = (double)bottom*41+translationh;
            Canvas.SetLeft(s,x);
            Canvas.SetBottom(s,y);
            //Affichage de la case
            Image i;
            switch(t){
                case (TypeCase.DESERT):
                    i = new Image { Height = 40, Source = new BitmapImage(new Uri("C:\\Users\\Sami\\Documents\\GitHub\\smallworld\\WpfApplication1\\Resources\\desert.png")), Width = 40 };
                    s.Children.Add(i);
                    //s.Children.Add(text);
                    break;
                case (TypeCase.EAU):
                    i = new Image { Height = 40, Source = new BitmapImage(new Uri("C:\\Users\\Sami\\Documents\\GitHub\\smallworld\\WpfApplication1\\Resources\\eau.png")), Width = 40 };
                    s.Children.Add(i);
                    break;
                case (TypeCase.FORET):
                    i = new Image { Height = 40, Source = new BitmapImage(new Uri("C:\\Users\\Sami\\Documents\\GitHub\\smallworld\\WpfApplication1\\Resources\\foret.png")), Width = 40 };
                    s.Children.Add(i);

                    break;
                case (TypeCase.MONTAGNE):
                    i = new Image { Height = 40, Source = new BitmapImage(new Uri("C:\\Users\\Sami\\Documents\\GitHub\\smallworld\\WpfApplication1\\Resources\\montagne.png")), Width = 40 };
                    s.Children.Add(i);
                    break;
                case (TypeCase.PLAINE):
                    i = new Image { Height = 40, Source = new BitmapImage(new Uri("C:\\Users\\Sami\\Documents\\GitHub\\smallworld\\WpfApplication1\\Resources\\plaine.png")), Width = 40 };
                    s.Children.Add(i);
                    break;
                default:
                    break;

            }
            
            return s;
            
        }
        public void PlacerUnite(){
            foreach (var pair in partie.GrilleUnites)
            {
                foreach (IUnite u in pair.Value)
                {
                    Unite v = (Unite)u;
                    StackPanel s = new StackPanel() { Orientation = Orientation.Vertical };
                    double x = (double)pair.Key.X * 41 + 170 + translationl+10;
                    double y = (double)pair.Key.Y * 41 + translationh+10;
                    Canvas.SetLeft(s, x);
                    Canvas.SetBottom(s, y);
                    //Affichage de l'unite
                    Image i;
                    switch (v.GetType().ToString())
                    {
                        case "UniteGaulois": 
                             i = new Image { Height = 30, Source = new BitmapImage(new Uri("C:\\Users\\Sami\\Documents\\GitHub\\smallworld\\WpfApplication1\\Resources\\gaulois.png"))};
                             s.Children.Add(i);
                             break;
                        case "UniteNain":
                             i = new Image { Height = 30, Source = new BitmapImage(new Uri("C:\\Users\\Sami\\Documents\\GitHub\\smallworld\\WpfApplication1\\Resources\\nain.png"))};
                             s.Children.Add(i);
                             break;
                        case "UniteViking":
                            i = new Image { Height = 30, Source = new BitmapImage(new Uri("C:\\Users\\Sami\\Documents\\GitHub\\smallworld\\WpfApplication1\\Resources\\viking.png"))};
                             s.Children.Add(i);
                             break;
                        default:
                      
                             break;
                    }
                    canvas1.Children.Add(s);
                }

            }
        }

        

       
    }
}
