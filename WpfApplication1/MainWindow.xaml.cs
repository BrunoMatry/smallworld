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
        private String typeCarte;
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
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
	{
	    // Get RadioButton reference.
	    var button = sender as RadioButton;

        typeCarte = button.Content.ToString();
        switch (typeCarte)
        {
          
        }
        
        }


    }
}