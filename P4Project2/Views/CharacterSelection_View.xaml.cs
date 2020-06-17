using Microsoft.EntityFrameworkCore;
using P4Project2.DBContext;
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

            _g._Gladiators = _ctx.Gladiators.Include(x => x.PrimaryClass).Include(x => x.CurrentWeapon).Include(x => x.CurrentLevel).ToList();
            DG_Gladiators.ItemsSource = _g._Gladiators;

            //foreach (var item in _g._Gladiators)
            //{
            //    MessageBox.Show(item.PowerCalculation().ToString());
            //}
        }

        Gladiator _g = new Gladiator();
        Context _ctx = new Context();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = (ClientView)Application.Current.MainWindow;
            window.MainFrame.Navigate(new Menu(window));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (DG_Gladiators.SelectedItems.Count > 0)
            {
                DataGridRow _row = DG_Gladiators.SelectedItems[0] as DataGridRow;

                _g.Player = (DG_Gladiators.SelectedItem as Gladiator);

                var window = (ClientView)Application.Current.MainWindow;
                window.MainFrame.Navigate(new Fight.DrawEnemyView(_g.Player));
            }
            else
                MessageBox.Show("You have to choose your gladiator before proceeding further");
        }
    }
}
