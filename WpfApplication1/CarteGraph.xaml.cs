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
        Partie partie;
        
        public CarteGraph(Partie p)
        {
            InitializeComponent();
            partie = p;
            AfficherCarte();
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
            int translationh = 0;
            int translationl = 0;
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
            Image i;
            TextBlock text;
            switch(t){
                case (TypeCase.DESERT):
                    i = new Image { Height = 40, Source = new BitmapImage(new Uri("C:\\Users\\Sami\\Documents\\GitHub\\smallworld\\WpfApplication1\\Resources\\desert.png")), Width = 40 };
                    text = new TextBlock { Text = "Desert", HorizontalAlignment = HorizontalAlignment.Center, FontSize = 10 };
                    s.Children.Add(i);
                    //s.Children.Add(text);
                    break;
                case (TypeCase.EAU):
                    i = new Image { Height = 40, Source = new BitmapImage(new Uri("C:\\Users\\Sami\\Documents\\GitHub\\smallworld\\WpfApplication1\\Resources\\eau.png")), Width = 40 };
                    text = new TextBlock { Text = "Eau", HorizontalAlignment = HorizontalAlignment.Center, FontSize = 10 };
                    s.Children.Add(i);
                  //  s.Children.Add(text);
                    break;
                case (TypeCase.FORET):
                    i = new Image { Height = 40, Source = new BitmapImage(new Uri("C:\\Users\\Sami\\Documents\\GitHub\\smallworld\\WpfApplication1\\Resources\\foret.png")), Width = 40 };
                    text = new TextBlock { Text = "Forêt", HorizontalAlignment = HorizontalAlignment.Center, FontSize = 10 };
                    s.Children.Add(i);
       //             s.Children.Add(text);
                    break;
                case (TypeCase.MONTAGNE):
                    i = new Image { Height = 40, Source = new BitmapImage(new Uri("C:\\Users\\Sami\\Documents\\GitHub\\smallworld\\WpfApplication1\\Resources\\montagne.png")), Width = 40 };
                    text = new TextBlock { Text = "Montagne", HorizontalAlignment = HorizontalAlignment.Center, FontSize = 10 };
                    s.Children.Add(i);
                 //   s.Children.Add(text);
                    break;
                case (TypeCase.PLAINE):
                    i = new Image { Height = 40, Source = new BitmapImage(new Uri("C:\\Users\\Sami\\Documents\\GitHub\\smallworld\\WpfApplication1\\Resources\\plaine.png")), Width = 40 };
                    text = new TextBlock { Text = "Plaine", HorizontalAlignment = HorizontalAlignment.Center, FontSize = 10 };
                    s.Children.Add(i);
                   // s.Children.Add(text);
                    break;
                default:
                    break;

            }
            
            return s;
            
        }
       
    }
}
