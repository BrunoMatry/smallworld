﻿using System;
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
        private Dictionary<int, StackPanel> UniteeCase = new Dictionary<int, StackPanel>();
        private Dictionary<int, Unite> Unitee = new Dictionary<int, Unite>();
        private Dictionary<int, ListBoxItem> UniteeListBox = new Dictionary<int, ListBoxItem>();
        private StackPanel unitsel;
        private Unite uniteMorte;
        private int idcourant;
        private Direction courante = Direction.INIT;
        private String peupleJ1;
        private String nbTourJ1;
        private String nbPointJ1;
        private String peupleJ2;
        private String nbTourJ2;
        private String nbPointJ2;
        private String nbTourRestant;
        private Border myBorder1 = new Border();
        private string source ;
        private string sourceEau;
        private string sourceDesert;
        private string sourcePlaine;
        private string sourceForet;
        private string sourceMontagne;
        private string sourceGaulois;
        private string sourceNain;
        private string sourceViking;
		private string sourceBackground;
        public CarteGraph(Partie p)
        {
            try
            {
                InitializeComponent();
                DefinirImage();
                partie = p;
                idcourant = p.UniteCourante.Id;
                MajPoint();
                MajInfoUniteCourant();
                AfficherCarte();
                PlacerUnite();
                PlacerUniteListe();
            }
            catch(PartieException exc){
                if (exc.Type == "perdu" || exc.Type == "Fin")
                {
                    MessageBox.Show(exc.Message);
                    this.Close();
                }
            }   
            


        }

        private void DefinirImage() {
            source = System.IO.Path.GetFullPath(@".\Resources\");
            sourceEau = source + "eau.png";
            sourceDesert = source + "desert.png";
            sourcePlaine = source + "plaine.png";
            sourceForet = source + "foret.png";
            sourceMontagne = source + "montagne.png";
            sourceGaulois = source + "gaulois.png";
            sourceNain = source + "dwarf.png";
            sourceViking = source + "viking.png";
			sourceBackground = source + "backgnd.png";
        }
        private void MajPoint() {
            nbTourRestant = partie.Tr.ToString();

            peupleJ1 = partie.Joueurs[0].GetType().ToString() + " " + (partie.Joueurs[0].Id+1);
            nbTourJ1 = partie.Joueurs[0].Ctj.ToString();
            nbPointJ1 = partie.Joueurs[0].Points.ToString();
            PeupleJ1.Content = peupleJ1;
            NbTourJ1.Content = "Tour : " + nbTourJ1;
            NbPointJ1.Content = "Points : " + nbPointJ1;
            peupleJ2 = partie.Joueurs[1].GetType().ToString() + " " + (partie.Joueurs[1].Id+1);
            nbTourJ2 = partie.Joueurs[1].Ctj.ToString();
            nbPointJ2 = partie.Joueurs[1].Points.ToString();
            PeupleJ2.Content = peupleJ2;
            NbTourJ2.Content = "Tour : " + nbTourJ2;
            NbPointJ2.Content = "Points : " + nbPointJ2;
            NbToursRestant.Content = "Tours restants : " + nbTourRestant;

        }
        private void AfficherCarte()
        {
            for (int i = 0; i < partie.Hauteur; i++)
            {
                for (int j = 0; j < partie.Largeur; j++)
                {
                    canvas1.Children.Add(AfficherCase(partie.Grille[i][j], i, j));
                }

            }

        }
        private void MajInfoUniteCourant()
        {
            Unite uniteCour = partie.UniteCourante;
            Uatt.Content="Attaque :  "+uniteCour.Attaque;
            Udef.Content="Defense : "+uniteCour.Defense;
            Updv.Content="Pts de vie : "+uniteCour.PointsDeVie;
            Updd.Content="Pts de dépl : "+uniteCour.PointsDeplacement;
            Uval.Content ="Valeur : "+uniteCour.Valeur;
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
					i = new Image { Height = 40, Source = new BitmapImage(new Uri(sourceDesert)), Width = 40 };
                    s.Children.Add(i);
                    //s.Children.Add(text);
                    break;
                case (TypeCase.EAU):
                    i = new Image { Height = 40, Source = new BitmapImage(new Uri(sourceEau)), Width = 40 };
                    s.Children.Add(i);
                    break;
                case (TypeCase.FORET):
                    i = new Image { Height = 40, Source = new BitmapImage(new Uri(sourceForet)), Width = 40 };
                    s.Children.Add(i);
                    break;
                case (TypeCase.MONTAGNE):
                    i = new Image { Height = 40, Source = new BitmapImage(new Uri(sourceMontagne)), Width = 40 };
                    s.Children.Add(i);
                    break;
                case (TypeCase.PLAINE):
					i = new Image { Height = 40, Source = new BitmapImage(new Uri(sourcePlaine)), Width = 40 };
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
                    if (!Unitee.ContainsKey(v.Id))
                    {
                        if (!UniteeList.ContainsKey(v.Id))
                            UniteeList.Add(v.Id, s);
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
                                i = new Image { Height = 30, Source = new BitmapImage(new Uri(sourceGaulois)) };
                                s.Children.Add(i);
                                break;
                            case "UniteNain":
                                i = new Image { Height = 30, Source = new BitmapImage(new Uri(sourceNain)) };
                                s.Children.Add(i);
                                break;
                            case "UniteViking":
								i = new Image { Height = 30, Source = new BitmapImage(new Uri(sourceViking)) };
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
        private void MajUniteMorte(int u)
        {
            StackPanel unit = UniteeList[u];
            canvas1.Children.Remove(unit);
        }
        private void PlacerUniteListe()
        {
            foreach (IUnite u in partie.Joueurs[0].Peuple.Unites)
            {

                Unite v = (Unite)u;
                ListBoxItem lb = new ListBoxItem()
                {
                    Content = (v.GetType().ToString() + " " + v.Id +"\n Points de Vie: "+v.PointsDeVie +"\n Points de déplacements :"+v.PointsDeplacement)
                };

                UniteeListBox.Add(v.Id,lb);
                unites.Items.Add(lb);
            }
            if (UniteeListBox.ContainsKey(idcourant))
                unites.SelectedItem = UniteeListBox[idcourant];
        }
        private void unites_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                String[] SelectID = unites.SelectedItem.ToString().Split();
                idcourant = int.Parse(SelectID[2]);
                unitsel = UniteeList[idcourant];
                partie.Selectionner(Unitee[idcourant]);
                myBorder1.Background = Brushes.SkyBlue;
                myBorder1.BorderBrush = Brushes.Red;
                myBorder1.BorderThickness = new Thickness(1);
                myBorder1.Width = 40;
                unitsel.Children.Add(myBorder1);
                
            }
            catch { }

        }

        private void KeyEventHandler(object sender, KeyEventArgs e)
        {

            if (unites.SelectedItem != null)
                ((ListBoxItem)unites.SelectedItem).Focus();
            try
            {
                if (e.Key == Key.Up)
                {
                    unitsel.Children.Remove(myBorder1);
                    courante = Direction.NORD;
                    partie.Deplacement(courante);
                    e.Handled = true;
                    canvas1.Children.Remove(unitsel);
                    Unitee.Remove(idcourant);
                    UniteeList.Remove(idcourant);
                    unites.Items.Clear();
                    PlacerUnite();


                }
                if (e.Key == Key.Down)
                {
                    unitsel.Children.Remove(myBorder1);
                    courante = Direction.SUD;
                    partie.Deplacement(courante);
                    e.Handled = true;
                    canvas1.Children.Remove(unitsel);
                    Unitee.Remove(idcourant);
                    UniteeList.Remove(idcourant);
                    unites.Items.Clear();
                    PlacerUnite();


                }
                if (e.Key == Key.Right)
                {
                    unitsel.Children.Remove(myBorder1);
                    courante = Direction.EST;
                    partie.Deplacement(courante);
                    e.Handled = true;
                    canvas1.Children.Remove(unitsel);
                    Unitee.Remove(idcourant);
                    UniteeList.Remove(idcourant);
                    PlacerUnite();


                }
                if (e.Key == Key.Left)
                {
                    unitsel.Children.Remove(myBorder1);
                    courante = Direction.OUEST;
                    partie.Deplacement(courante);
                    e.Handled = true;
                    canvas1.Children.Remove(unitsel);
                    Unitee.Remove(idcourant);
                    UniteeList.Remove(idcourant);
                    PlacerUnite();

                }
                if (e.Key == Key.Space)
                {
                    unitsel.Children.Remove(myBorder1);
                    partie.PasserTourUniteCourante();
                    idcourant = partie.UniteCourante.Id;
                    MajInfoUniteCourant();
                }
                if (e.Key == Key.F)
                {
                    finirTour();
                    MajInfoUniteCourant();
                }
            }
            catch (PartieException exc)
            {

                if (exc.Type == "attaque")
                {

                    var result = MessageBox.Show(exc.Message, "", MessageBoxButton.YesNo);

                    if (result == MessageBoxResult.Yes)
                    {
                        try
                        {
                            partie.Attaque(courante);
                        }
                        catch (UniteMorteException exc1)
                        {
                            MessageBox.Show(exc1.Message);
                            MajUniteMorte(exc1.UniteMorte);
                        }
                        catch (UniteGagnanteException exc2)
                        {
                            MessageBox.Show(exc2.Message);
                        }
                        catch (PartieException exc3)
                        {
                           if (exc.Type == "perdu" || exc.Type == "Fin")
                                {
                                    MessageBox.Show(exc.Message);
                                    this.Close();
                                }
                        }

                    }
                }



                else
                {
                    MessageBox.Show(exc.Message);
                }
            }
            

            unites.Items.Clear();
            UniteeListBox.Clear();
            PlacerUniteListe();
        }
       
        private void FinDuTour(object sender, RoutedEventArgs e)
        {
            finirTour();

        }
        private void finirTour()
        {
            unitsel.Children.Remove(myBorder1);
            partie.Joueurs[0].Ctj++;
            partie.PasserTourJoueur();
            unites.Items.Clear();
            UniteeListBox.Clear();
            PlacerUniteListe();
            MajPoint();
            MajInfoUniteCourant();
        }
        private void Enregistrer(object sender, RoutedEventArgs e)
        {
            partie.Enregistrer();
        }
        private void EnregistrerSous(object sender, RoutedEventArgs e){
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.DefaultExt = ".sav";
            dlg.Filter = "Fichier de sauvegarde (.sav)|*.sav";
            dlg.Title = "Save a game file (sav)";
            Nullable<bool> result = dlg.ShowDialog();
            dlg.ShowDialog();
            if(dlg.FileName != "")
                partie.EnregistrerSous(dlg.FileName);
            
        }

    }

        }

    


