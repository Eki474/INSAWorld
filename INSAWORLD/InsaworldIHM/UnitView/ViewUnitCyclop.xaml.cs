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

namespace InsaworldIHM.UnitView
{
    /// <summary>
    /// Logique d'interaction pour ViewUnitCentaurs.xaml
    /// </summary>

    partial class ViewUnitCyclop : ViewUnit
    {
        Uri source;
        Uri sourceselected;
        public ViewUnitCyclop() : base()
        {
            source = new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/races/cyclop.png");
            sourceselected = new Uri("pack://application:,,,/InsaworldIHM;component/Ressources/images/races/cyclopselected.jpg");
            Source = new BitmapImage(source);
        }
        override
        public void Select()
        {
            Source = new BitmapImage(sourceselected);
        }
        override
        public void Unselect()
        {
            Source = new BitmapImage(source);
        }
    }
}



