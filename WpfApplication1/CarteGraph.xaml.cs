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
        private Dictionary<int, StackPanel> UniteeList = new Dictionary<int, StackPanel>();
        private Dictionary<int,Unite> Unitee = new Dictionary<int,Unite>();
        private StackPanel unitsel;
        private Unite uniteCourante;
        private int idcourant;
        public CarteGraph(Partie p)
        {
            InitializeComponent();
            partie = p;
            AfficherCarte();
            PlacerUnite();
            PlacerUniteListe();
        }
        private void AfficherCarte()
        {
            for (int i = 0; i < partie.Hauteur; i++)
            {
                for (int j = 0; j < partie.Largeur; j++)
                {
                    canvas1.Children.Add(AfficherCase(partie.Grille[i, j], i, j));
                }

            }

        }
        private StackPanel AfficherCase(TypeCase t, int left, int bottom)
        {
            //Centrage de la carte
            translationh = 0;
            translationl = 0;
            if (partie.Hauteur == partie.Largeur & partie.Hauteur == 5)
            {
                translationh = 203;
                translationl = 273;
            }
            if (partie.Hauteur == partie.Largeur & partie.Hauteur == 10)
            {
                translationh = 103;
                translationl = 173;
            }
            StackPanel s = new StackPanel() { Orientation = Orientation.Vertical };
            double x = (double)left * 41 + 170 + translationl;
            double y = (double)bottom * 41 + translationh;
            Canvas.SetLeft(s, x);
            Canvas.SetBottom(s, y);
            //Affichage de la case
            Image i;
            switch (t)
            {
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
        private void PlacerUnite()
        {
            foreach (var pair in partie.GrilleUnites)
            {
                foreach (IUnite u in pair.Value)
                {
                    Unite v = (Unite)u;
                    string n = "";
                    StackPanel s = new StackPanel() { Orientation = Orientation.Vertical };

                    if (!UniteeList.ContainsKey(v.Id))
                        UniteeList.Add(v.Id, s);
                    if (!Unitee.ContainsKey(v.Id))
                        Unitee.Add(v.Id, v);

                    double x = (double)pair.Key.X * 41 + 170 + translationl + 10;
                    double y = (double)pair.Key.Y * 41 + translationh + 10;
                    Canvas.SetLeft(s, x);
                    Canvas.SetBottom(s, y);
                    //Affichage de l'unite
                    Image i;
                    switch (v.GetType().ToString())
                    {
                        case "UniteGaulois":
                            i = new Image { Height = 30, Source = new BitmapImage(new Uri("C:\\Users\\Sami\\Documents\\GitHub\\smallworld\\WpfApplication1\\Resources\\gaulois.png")) };
                            s.Children.Add(i);
                            break;
                        case "UniteNain":
                            i = new Image { Height = 30, Source = new BitmapImage(new Uri("C:\\Users\\Sami\\Documents\\GitHub\\smallworld\\WpfApplication1\\Resources\\nain.png")) };
                            s.Children.Add(i);
                            break;
                        case "UniteViking":
                            i = new Image { Height = 30, Source = new BitmapImage(new Uri("C:\\Users\\Sami\\Documents\\GitHub\\smallworld\\WpfApplication1\\Resources\\viking.png")) };
                            s.Children.Add(i);
                            break;
                        default:

                            break;
                    }
                    canvas1.Children.Add(s);
                }

            }
        }
        private void PlacerUniteListe()
        {
            foreach (IUnite u in partie.Joueurs[0].Item2.Peuple.Unites)
            {

                Unite v = (Unite)u;
                unites.Items.Add(v.GetType().ToString() + " " + v.Id);
            }

        }
        private void unites_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            String[] SelectID = unites.SelectedItem.ToString().Split();
            idcourant = int.Parse(SelectID[1]);
            unitsel = UniteeList[idcourant];
            partie.Selectionner(Unitee[idcourant]);

        }
        
        private void KeyEventHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                try
                {
                    partie.Deplacement(Direction.NORD);
                }
                catch (PartieException exc)
                {
                    MessageBox.Show(exc.Message);
                }
               
            }
            if (e.Key == Key.Down)
            {
                try
                {
                    partie.Deplacement(Direction.SUD);
                }
                catch (PartieException exc)
                {
                    MessageBox.Show(exc.Message);
                }

            }
            if (e.Key == Key.Right)
            {
                try
                {
                    partie.Deplacement(Direction.OUEST);
                }
                catch (PartieException exc)
                {
                    MessageBox.Show(exc.Message);
                }

            }
            if (e.Key == Key.Left)
            {
                try
                {
                    partie.Deplacement(Direction.EST);
                }
                catch (PartieException exc)
                {
                    MessageBox.Show(exc.Message);
                }

            }
            canvas1.Children.Remove(unitsel);
            UniteeList.Remove(idcourant);
            PlacerUnite();
        }

        /*private void KeyEventHandler(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case (Key.Up):
                    foreach (object s in canvas1.Children)
                    {
                        if (s is StackPanel) {
                            StackPanel t = (StackPanel)s;
                            if (t.Name == ("unitej1" + partie.Joueurs[0].Item2.Peuple.Unites.IndexOf(partie.UniteCourante))
                            | t.Name == ("unitej2" + partie.Joueurs[1].Item2.Peuple.Unites.IndexOf(partie.UniteCourante)))
                            canvas1.Children.Remove(t);
                    }}
                    partie.Deplacement(Direction.NORD);
                    PlacerUnite();
                    break;
                case (Key.Down):
                    foreach (object s in canvas1.Children)
                    {
                        if (s is StackPanel) {
                            StackPanel t = (StackPanel)s;
                            if (t.Name == ("unitej1" + partie.Joueurs[0].Item2.Peuple.Unites.IndexOf(partie.UniteCourante))
                            | t.Name == ("unitej2" + partie.Joueurs[1].Item2.Peuple.Unites.IndexOf(partie.UniteCourante)))
                            canvas1.Children.Remove(t);
                    }}
                    partie.Deplacement(Direction.SUD);
                    PlacerUnite();
                    break;
                case (Key.Left):
                    foreach (object s in canvas1.Children)
                    {
                        if (s is StackPanel) {
                            StackPanel t = (StackPanel)s;
                            if (t.Name == ("unitej1" + partie.Joueurs[0].Item2.Peuple.Unites.IndexOf(partie.UniteCourante))
                            | t.Name == ("unitej2" + partie.Joueurs[1].Item2.Peuple.Unites.IndexOf(partie.UniteCourante)))
                            canvas1.Children.Remove(t);
                    }}
                    partie.Deplacement(Direction.EST);
                    PlacerUnite();
                    break;
                case (Key.Right):
                    foreach (object s in canvas1.Children)
                    {
                        if (s is StackPanel)
                        {
                            StackPanel t = (StackPanel)s;
                            if (t.Name == ("unitej1" + partie.Joueurs[0].Item2.Peuple.Unites.IndexOf(partie.UniteCourante))
                            | t.Name == ("unitej2" + partie.Joueurs[1].Item2.Peuple.Unites.IndexOf(partie.UniteCourante)))
                                canvas1.Children.Remove(t);
                        }
                    }
                    partie.Deplacement(Direction.OUEST);
                    PlacerUnite();
                    break;
            }
        }
        
        

       
    }*/
    }
}

