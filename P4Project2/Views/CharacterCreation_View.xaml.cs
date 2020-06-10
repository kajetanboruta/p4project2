using P4Project2.Models;
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
using P4Project2.DBContext;
using Microsoft.EntityFrameworkCore;

namespace P4Project2.Views
{
    /// <summary>
    /// Logika interakcji dla klasy CharacterCreation_View.xaml
    /// </summary>
    public partial class CharacterCreation_View : Page
    {
        public CharacterCreation_View()
        {
            InitializeComponent();
            gender_Field.Items.Add("Female");
            gender_Field.Items.Add("Male");
            var gladiatorClasses = Context.PrimaryClasses.Select(x => x.Name).ToList();
            class_Field.ItemsSource = gladiatorClasses;
        }

        readonly Context Context = new Context();

        /// <summary>
        /// Creates character and adds it to db asaynchronously
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Create_Gladiator(object sender, RoutedEventArgs e)
        {
            Gladiator _gladiator = new Gladiator
            {
                Name = name_Field.Text,
                Gender = gender_Field.Text,
                PrimaryClassID_FK = (class_Field.SelectedIndex + 1),
                WeaponID = (class_Field.SelectedIndex + 1),
                LevelID_FK = 1,
                Experience = 0,
                Losses = 0,
                Wins = 0,
                Mana = 0,
                Health = 0,
                Purse = 50,
                Title = "Prisoner"
            };

            try
            {
                if (String.IsNullOrEmpty(name_Field.Text) || String.IsNullOrEmpty(gender_Field.Text) || String.IsNullOrEmpty(class_Field.Text))
                {
                    MessageBox.Show("Uzupełnij wszystkie pola");
                        return;
                }
                else
                {
                    await Context.Gladiators.AddAsync(_gladiator);
                    await Context.SaveChangesAsync();
                    MessageBox.Show($"New gladiator {_gladiator.Name}, was thrown into the arena pit!");
                        return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = (ClientView)Application.Current.MainWindow;
            window.MainFrame.Navigate(new Menu(window));
        }
    }
}
