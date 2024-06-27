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

namespace RecipeApp_WPF
{
    /// <summary>
    /// Interaction logic for ExitAppWindow.xaml
    /// </summary>
    public partial class ExitAppWindow : Window
    {
        public ExitAppWindow()
        {
            InitializeComponent();
        }

        private void YesBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Aw we see! We hope to see you again! Closing app...", "Bye for now!", MessageBoxButton.OK, MessageBoxImage.Information);
            Environment.Exit(0);
        }

        private void NoBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Good Choice! Now, go on add more recipes! Re-opening main menu...", "Wise choice!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
