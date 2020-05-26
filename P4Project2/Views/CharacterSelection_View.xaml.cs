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
using P4Project2.DBContext;
using P4Project2.Models;

namespace P4Project2.Views
{
    /// <summary>
    /// Logika interakcji dla klasy CharacterSelection_View.xaml
    /// </summary>
    public partial class CharacterSelection_View : Page
    {
        public CharacterSelection_View()
        {
            InitializeComponent();
            Gladiator gladiator = new Gladiator();
            Context context = new Context();
            gladiator._Gladiators = context.Gladiators.ToList();
        }
    }
}
