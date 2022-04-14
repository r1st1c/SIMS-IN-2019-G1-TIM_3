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

namespace Projekat_SIMS_IN_TIM3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Manager_Click(object sender, RoutedEventArgs e)
        {
            var managerMainWindow = new ManagerMainWindow();
            managerMainWindow.Show();
        }

        private void Secretary_Click(object sender, RoutedEventArgs e)
        {
            var secretaryMainWindow = new SecretaryMainWindow();
            secretaryMainWindow.Show();
        }

        private void Doctor_Click(object sender, RoutedEventArgs e)
        {
            var doctorMainWindow = new DoctorMainWindow();
            doctorMainWindow.Show();
        }
    }
}
